using E5WBMQ_HFT_2021222.Logic;
using E5WBMQ_HFT_2021222.Models;
using E5WBMQ_HFT_2021222.Repository.Data;
using E5WBMQ_HFT_2021222.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace E5WBMQ_HFT_2021222.Logic.Logics
{
    public class VideoGamesLogic : IVideoGamesLogic
    {
        IRepository<VideoGames> repo;

        public VideoGamesLogic(IRepository<VideoGames> repo)
        {
            this.repo = repo;
        }

        public void Create(VideoGames item)
        {
            if (item.GameName.Length < 2)
            {
                throw new ArgumentException("Video Game Title is too short...");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {  
            this.repo.Delete(id);
        }

        public VideoGames Read(int id)
        {
            return this.repo.Read(id) ?? throw new ArgumentException("Video Games with the given ID does not exist.");
        }

        public IQueryable<VideoGames> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(VideoGames item)
        {
            this.repo.Update(item);
        }


        //NON-CRUDS
        public double AverageSoldCopiesByPublisher(string name)
        {
            //return ReadAll().Where(x => x.PublisherId == id).Average(x => x.CopiesSold);

            return ReadAll().Where(x => x.Publisher.PublisherName == name).Average(x => x.CopiesSold);


        }
        public string? OldestGameReleasedByWhom()
        {

            return ReadAll().Where(x => x.ReleaseYear == ReadAll().Select(x => x.ReleaseYear).Min())
                            .Select(x => x.Publisher.PublisherName)
                            .FirstOrDefault();
        }
        public string? MostPopularGenre()
        {
            return ReadAll().GroupBy(x => x.Genre.GenreName)
                .Select(x => new
                {
                    Name = x.Key,
                    Copies = x.Sum(x => x.CopiesSold),
                }).OrderByDescending(x => x.Copies).First().Name;
        }
        public double SoldCopiesOfGivenGenre(string name)
        {
            return ReadAll().Where(x => x.Genre.GenreName == name).Sum(x => x.CopiesSold);

        }
        public IEnumerable<KeyValuePair<string, double>> CopiesSoldByEachPublisher()
        {
            return ReadAll().GroupBy(x => x.Publisher.PublisherName)
                .Select(x => new KeyValuePair<string, double>(x.Key, x.Sum(x => x.CopiesSold)));
        }
        public IEnumerable<KeyValuePair<string, int>> NumberOfGamesPerGenre()
        {
            return ReadAll().GroupBy(x => x.Genre.GenreName)
                .Select(x => new KeyValuePair<string, int>(x.Key, x.Count()));
        }

        public IQueryable<VideoGames> AllOfTheSameGenre(string genre)
        {
            return ReadAll().Where(x => x.Genre.GenreName == genre).AsQueryable();
        }

        public List<string> GenrePerGame(string gameName)
        {
            return (List<string>)ReadAll().Where(x => x.Genre.GenreId == ReadAll().Where(x => x.GameName == gameName).Select(x => x.Genre.GenreId).First()).Select(x => x.GameName).ToList();
        }
    }
}
