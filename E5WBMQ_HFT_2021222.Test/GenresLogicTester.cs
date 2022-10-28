using E5WBMQ_HFT_2021222.Logic.Logics;
using E5WBMQ_HFT_2021222.Models;
using E5WBMQ_HFT_2021222.Repository.GenericRepository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E5WBMQ_HFT_2021222.Test
{
    [TestFixture]
    public class GenresLogicTester
    {

        GenresLogic gl;
        Mock<IRepository<Genres>> mockGenresRepository;

        [SetUp]
        public void Init()
        {
            var gen = new List<Genres>()
            {
                new Genres()
                {
                    GenreId = 1,
                    GenreName = "Action",
                },
                new Genres()
                {
                    GenreId = 2,
                    GenreName = "RPG",
                },
            }.AsQueryable();

            mockGenresRepository = new Mock<IRepository<Genres>>();
            mockGenresRepository
                .Setup(x => x.ReadAll())
                .Returns(gen);

            gl = new GenresLogic(mockGenresRepository.Object);

        }

        [Test]

        public void TestCreateGenreWithIncorrectNameLength()
        {
            var gen = new Genres()
            {
                GenreId=1,
                GenreName="B",
            };
            try { gl.Create(gen); }
            catch { }

            mockGenresRepository.Verify(x => x.Create(gen), Times.Never);
        }



    }
}
