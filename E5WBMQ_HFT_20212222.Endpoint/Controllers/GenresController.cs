using E5WBMQ_HFT_2021222.Logic.Logics;
using E5WBMQ_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;

namespace E5WBMQ_HFT_20212222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        IGenresLogic logic;
        public GenresController(IGenresLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Genres> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]

        public Genres Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Genres value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Genres value)
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
