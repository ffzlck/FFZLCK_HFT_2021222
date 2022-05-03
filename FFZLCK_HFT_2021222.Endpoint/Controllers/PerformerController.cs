using FFZLCK_HFT_2021222.Logic.Interfaces;
using FFZLCK_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FFZLCK_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerformerController : ControllerBase
    {
        IPerformerLogic logic;
        public PerformerController(IPerformerLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Performer> ReadALL()
        {
            return this.logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Performer Read(int id)
        {
            return this.logic.Read(id);
        }
        [HttpPost]
        public void Create(Performer item)
        {
            this.logic.Create(item);
        }
        [HttpPut]
        public void Put([FromBody] Performer item)
        {
            this.logic.Update(item);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
