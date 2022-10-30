using E5WBMQ_HFT_2021222.Logic.Logics;
using E5WBMQ_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;

namespace E5WBMQ_HFT_20212222.Endpoint.Controllers
{
    [Route("[controller]")]
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
    }
}
