using E5WBMQ_HFT_2021222.Models;

namespace E5WBMQ_HFT_2021222.Logic.LogicInterfaces
{
    public interface IVideoGamesLogic
    {
        void Create(VideoGames item);
        void Delete(int id);
        VideoGames Read(int id);
        IQueryable<VideoGames> ReadAll();
        void Update(VideoGames item);
    }
}