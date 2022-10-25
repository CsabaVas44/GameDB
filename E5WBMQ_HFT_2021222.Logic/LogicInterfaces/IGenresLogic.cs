using E5WBMQ_HFT_2021222.Models;

namespace E5WBMQ_HFT_2021222.Logic.LogicInterfaces
{
    public interface IGenresLogic
    {
        void Create(Genres item);
        void Delete(int id);
        Genres Read(int id);
        IQueryable<Genres> ReadAll();
        void Update(Genres item);
    }
}