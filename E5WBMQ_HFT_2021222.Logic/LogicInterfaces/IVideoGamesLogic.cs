using E5WBMQ_HFT_2021222.Models;

namespace E5WBMQ_HFT_2021222.Logic.LogicInterfaces
{
    public interface IVideoGamesLogic
    {
        double AverageSoldCopiesByPublisher(int id);
        IQueryable<VideoGamesLogic.PublisherData> CopiesSoldByEachPublisher();
        void Create(VideoGames item);
        void Delete(int id);
        string MostPopularGenre();
        Publishers OldestGameReleasedByPublisher();
        VideoGames Read(int id);
        IQueryable<VideoGames> ReadAll();
        double SoldCopiesOfGivenGenre(string name);
        void Update(VideoGames item);
    }
}