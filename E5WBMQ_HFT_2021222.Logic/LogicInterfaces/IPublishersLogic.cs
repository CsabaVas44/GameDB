using E5WBMQ_HFT_2021222.Models;

namespace E5WBMQ_HFT_2021222.Logic.LogicInterfaces
{
    public interface IPublishersLogic
    {
        void Create(Publishers item);
        void Delete(int id);
        Publishers Read(int id);
        IQueryable<Publishers> ReadAll();
        void Update(Publishers item);
    }
}