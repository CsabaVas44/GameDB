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
    public class PublishersRepository : Repository<Publishers>, IRepository<Publishers>
    {
        public PublishersRepository(WorldOfAllGamesDbContext ctx) : base(ctx)
        {
        }

        public override Publishers Read(int id)
        {
            return ctx.Publishers.FirstOrDefault(t => t.PublisherId == id);
        }

        public override void Update(Publishers item)
        {
            var old = Read(item.PublisherId);
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
