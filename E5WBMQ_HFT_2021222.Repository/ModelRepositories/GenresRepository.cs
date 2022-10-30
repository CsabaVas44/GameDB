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
    public class GenresRepository : Repository<Genres>, IRepository<Genres>
    {
        public GenresRepository(WorldOfAllGamesDbContext ctx) : base(ctx)
        {
        }

        public override Genres Read(int id)
        {
            return ctx.Genres.FirstOrDefault(t => t.GenreId == id);
        }

        public override void Update(Genres item)
        {
            var old = Read(item.GenreId);
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
