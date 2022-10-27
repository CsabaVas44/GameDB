using E5WBMQ_HFT_2021222.Logic.LogicInterfaces;
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
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public VideoGames Read(int id)
        {
            return this.repo.Read(id);
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
        public double AverageSoldCopiesByPublisher(int id)
        {
            return ReadAll().Where(x => x.PublisherId == id).Average(x => x.CopiesSold);
        }

        public Publishers OldestGameReleasedByPublisher()
        {
            var games = ReadAll();
            var gamesWithMinYear = games.Min(x => x.ReleaseYear);
            var result = games.Where(x => x.ReleaseYear == gamesWithMinYear);
            return result.First().Publisher;
        }
        public string MostPopularGenre()
        {
            var result = from g in repo.ReadAll()
                         group g by g.Genre.GenreName into g
                         select new GenreData
                         {
                             Name = g.Key,
                             Copies = g.Sum(x => x.CopiesSold)
                         };
            return result.OrderBy(x => x.Copies).Reverse().First().Name;

        }
        public double SoldCopiesOfGivenGenre(string name)
        {
            return ReadAll().Where(x => x.Genre.GenreName == name).Sum(x => x.CopiesSold);

        }
        public IQueryable<PublisherData> CopiesSoldByEachPublisher()
        {
            var result = from g in repo.ReadAll()
                         group g by g.Publisher.PublisherName into g
                         select new PublisherData
                         {
                             Pub = g.Key,
                             Sold = g.Sum(x => x.CopiesSold),
                         };
            return result;
        }

        public class PublisherData
        {
            public string Pub { get; set; }
            public double Sold { get; set; }
        }

        public class GenreData
        {
            public string Name { get; set; }
            public double Copies { get; set; }
        }

    
           


        //mik azok a játékok, amiket ugyanaz a publisher adott ki? --> random game --> ha ez megvan kiírom annak a publishernek a többi játékát
        //Évek szerint eladott játékok?

    }
}
