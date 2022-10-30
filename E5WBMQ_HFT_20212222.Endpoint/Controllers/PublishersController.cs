using E5WBMQ_HFT_2021222.Logic.Logics;
using E5WBMQ_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;

namespace E5WBMQ_HFT_20212222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        IPublishersLogic logic;
        public PublishersController(IPublishersLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Publishers> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]

        public Publishers Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Publishers value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Publishers value)
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
