using E5WBMQ_HFT_2021222.Models;

namespace E5WBMQ_HFT_2021222.Logic.Logics
{
    public interface IVideoGamesLogic
    {
        double AverageSoldCopiesByPublisher(string name);
        IEnumerable<KeyValuePair<string, double>> CopiesSoldByEachPublisher();

        void Create(VideoGames item);
        void Delete(int id);
        string MostPopularGenre();
        string OldestGameReleasedByWhom();
        VideoGames Read(int id);
        IQueryable<VideoGames> ReadAll();
        double SoldCopiesOfGivenGenre(string name);
        void Update(VideoGames item);
        IQueryable<VideoGames> AllOfTheSameGenre(string genre);
        List<string> GenrePerGame(string gameName);
        IEnumerable<KeyValuePair<string, int>> NumberOfGamesPerGenre();
    }
}