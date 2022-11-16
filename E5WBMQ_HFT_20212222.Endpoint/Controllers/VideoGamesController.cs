using E5WBMQ_HFT_2021222.Logic.Logics;
using E5WBMQ_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using static E5WBMQ_HFT_2021222.Logic.Logics.VideoGamesLogic;

namespace E5WBMQ_HFT_20212222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        IVideoGamesLogic logic;
        public VideoGamesController(IVideoGamesLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<VideoGames> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public VideoGames Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] VideoGames value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] VideoGames value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        [HttpGet("{name}")]
        public double AverageSoldCopiesByPublisher(string name)
        {
            return this.logic.AverageSoldCopiesByPublisher(name);
        }

        [HttpGet]
        public string OldesGameReleasedByWhom()
        {
            return this.logic.OldestGameReleasedByWhom();
        }

        [HttpGet]
        public string MostPopularGenre()
        {
            return this.logic.MostPopularGenre();
        }
        [HttpGet("{name}")]
        public double SoldCopiesOfGivenGenre(string name)
        {
            return this.logic.SoldCopiesOfGivenGenre(name);

        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> CopiesSoldByEachPublisher()
        {
            return this.logic.CopiesSoldByEachPublisher();
        }

        [HttpGet("name")]
        public IQueryable<VideoGames> AllOfTheSameGenre(string name)
        {
            return this.logic.AllOfTheSameGenre(name);
        }

        [HttpGet("gameName")]
        public List<string> GenrePerGame(string gameName)
        {
            return this.logic.GenrePerGame(gameName);
        }

    }
}
