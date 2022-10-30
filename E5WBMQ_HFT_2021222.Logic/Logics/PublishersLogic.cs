using E5WBMQ_HFT_2021222.Logic;
using E5WBMQ_HFT_2021222.Models;
using E5WBMQ_HFT_2021222.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E5WBMQ_HFT_2021222.Logic.Logics
{
    public class PublishersLogic : IPublishersLogic
    {
        IRepository<Publishers> repo;

        public PublishersLogic(IRepository<Publishers> repo)
        {
            this.repo = repo;
        }

        public void Create(Publishers item)
        {
            if (item.AnnualSales < 0)
            {
                throw new ArgumentException("Number of sales has to be at least 0...!");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Publishers Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Publishers> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Publishers item)
        {
            this.repo.Update(item);
        }
    }
}
