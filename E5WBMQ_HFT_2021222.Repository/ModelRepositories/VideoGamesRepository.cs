using E5WBMQ_HFT_2021222.Models;
using E5WBMQ_HFT_2021222.Repository.Data;
using E5WBMQ_HFT_2021222.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E5WBMQ_HFT_2021222.Repository.ModelRepositories
{
    public class VideoGamesRepository : Repository<VideoGames>, IRepository<VideoGames>
    {
        public VideoGamesRepository(WorldOfAllGamesDbContext ctx) :   base(ctx)
        {
        }

        public override VideoGames Read(int id)
        {
            return ctx.VideoGames.FirstOrDefault(g => g.GameId == id);
        }

        public override void Update(VideoGames item)
        {
            var old = Read(item.GameId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
