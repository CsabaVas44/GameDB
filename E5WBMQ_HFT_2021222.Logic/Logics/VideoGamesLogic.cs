using E5WBMQ_HFT_2021222.Logic.LogicInterfaces;
using E5WBMQ_HFT_2021222.Models;
using E5WBMQ_HFT_2021222.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
