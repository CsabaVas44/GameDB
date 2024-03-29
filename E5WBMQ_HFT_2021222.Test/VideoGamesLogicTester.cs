﻿using Castle.Components.DictionaryAdapter;
using E5WBMQ_HFT_2021222.Logic.Logics;
using E5WBMQ_HFT_2021222.Models;
using E5WBMQ_HFT_2021222.Repository.GenericRepository;
using Moq;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using static E5WBMQ_HFT_2021222.Logic.Logics.VideoGamesLogic;

namespace E5WBMQ_HFT_2021222.Test
{
    [TestFixture]
    public class VideoGamesLogicTester
    {
        VideoGamesLogic vgl;
        Mock<IRepository<VideoGames>> mockVideoGamesRepository;


        [SetUp]
        public void Init()
        {
            var genres = new List<Genres>()
            {
                new Genres()
                {
                    GenreId = 1,
                    GenreName = "Action"
                },
                new Genres()
                {
                    GenreId = 2,
                    GenreName = "RPG"
                }
            };

            var publishers = new List<Publishers>()
            {
                new Publishers()
                {
                    PublisherId = 1,
                    PublisherName = "Bandai Namco",
                    Foundation = 1950,
                    NumberOfEmployees = 1000,
                },
                 new Publishers()
                {
                    PublisherId = 2,
                    PublisherName = "Electronic Arts",
                    Foundation = 1977,
                    NumberOfEmployees = 1500,
                },
            };
            var games = new List<VideoGames>()
            {
                new VideoGames()
                {
                    GameId = 1,
                    GameName = "Elden Ring",
                    GenreId = 2,
                    PublisherId = 1,
                    CopiesSold = 30,
                    ReleaseYear = 2022,
                    Genre = genres.ToArray()[1],
                    Publisher = publishers.ToArray()[0],
                },
                new VideoGames()
                {
                    GameId = 2,
                    GameName = "Dark Souls 3",
                    GenreId = 2,
                    PublisherId = 1,
                    CopiesSold = 10,
                    ReleaseYear = 2016,
                    Genre = genres.ToArray()[1],
                    Publisher = publishers.ToArray()[0],
                },
                new VideoGames()
                {
                    GameId = 3,
                    GameName = "Magic Mayhem: The Quest for the Majestic Staff of Lies",
                    GenreId = 1,
                    PublisherId = 2,
                    CopiesSold = 30,
                    ReleaseYear = 1990,
                    Genre = genres.ToArray()[0],
                    Publisher = publishers.ToArray()[1],
                }
            }.AsQueryable();



            mockVideoGamesRepository = new Mock<IRepository<VideoGames>>();
            mockVideoGamesRepository
                .Setup(x => x.ReadAll())
                .Returns(games);

            vgl = new VideoGamesLogic(mockVideoGamesRepository.Object);

        }


        [Test]
        public void TestAverageSoldCopiesByPublisher()
        {
            var result = vgl.AverageSoldCopiesByPublisher("Bandai Namco");  
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void TestAverageSoldCopiesByIncorrectPublisher()
        {
            Assert.Throws<InvalidOperationException>(() => vgl.AverageSoldCopiesByPublisher("NotARealPublisher"));
        }

        [Test]
        public void TestCopiesSoldByEachPublisher()
        {
            var result = vgl.CopiesSoldByEachPublisher();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Bandai Namco", 40),
                new KeyValuePair<string, double>("Electronic Arts", 30)
            };

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestMostPopularGenre()
        {
            var result = vgl.MostPopularGenre();

            Assert.That(result, Is.EqualTo("RPG"));
        }
        [Test]
        public void TestOldestGameReleasedBy()
        {
            var expected = new Publishers()
            {
                PublisherName = "Electronic Arts"
            };
            var result = vgl.OldestGameReleasedByWhom();
            Assert.That(result, Is.EqualTo(expected.PublisherName));
        }
        [Test]
        public void TestSoldCopiesofGivenGenre()
        {

            var result = vgl.SoldCopiesOfGivenGenre("RPG");

            Assert.That(result, Is.EqualTo(40));

        }

        [Test]
        public void TestNumberOfGamesPerGenre()
        {
            var result = vgl.NumberOfGamesPerGenre();

            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("RPG", 2),
                new KeyValuePair<string, int>("Action", 1)
            };

            Assert.That(result, Is.EqualTo(expected));


        }

        [Test]
        public void TestDelete()
        {
            vgl.Delete(1);

            mockVideoGamesRepository
                .Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void TestReadWithInvalidID()
        {
            mockVideoGamesRepository
                 .Setup(x => x.Read(It.IsAny<int>()))
                 .Returns(value: null);

            Assert.Throws<ArgumentException>(() => vgl.Read(1));
        }

        [Test]
        public void TestCreateVideoGamesWithCorrectTitle()
        {
            var game = new VideoGames()
            {
                GameId = 1,
                GameName = "asd",
                GenreId = 1,
                PublisherId = 2,
            };

            try { vgl.Create(game); }
            catch { }

            mockVideoGamesRepository.Verify(x => x.Create(game), Times.Once);
        }

        [Test]
        public void TestCreateVideoGamesWithIncorrectTitle()
        {
            var game = new VideoGames()
            {
                GameId = 1,
                GameName = "a",
                GenreId = 1,
                PublisherId = 2,
            };

            try { vgl.Create(game); }
            catch { }
           
            mockVideoGamesRepository.Verify(x => x.Create(game), Times.Never);

        }

        [Test]
        public void TestAllOfTheSameGenre()
        {

            var expected = new List<VideoGames>()
            {
                new VideoGames()
                {
                    GameId = 1,
                    GameName = "Elden Ring",
                    GenreId = 2,
                    PublisherId = 1,
                },
                new VideoGames()
                {
                    GameId = 2,
                    GameName = "Dark Souls 3",
                    GenreId = 2,
                    PublisherId = 1,
                },
            }.AsQueryable();

            var result = vgl.AllOfTheSameGenre("RPG");

            Assert.That(result, Is.EqualTo(expected));

        }

        [Test]
        public void TestGenrePerGame()
        {
            var expected = new List<string> { "Elden Ring", "Dark Souls 3" };

            var result = vgl.GenrePerGame("Dark Souls 3");

            Assert.That(result, Is.EqualTo(expected));
        }






    }
}
