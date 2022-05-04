using FFZLCK_HFT_2021222.Logic.Interfaces;
using FFZLCK_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FFZLCK_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        IMusicLogic logic;
        public MusicController(IMusicLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Music> ReadALL()
        {
            return this.logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Music Read(int id)
        {
            return this.logic.Read(id);
        }
        [HttpPost]
        public void Create(Music item)
        {
            this.logic.Create(item);
        }
        [HttpPut]
        public void Put([FromBody] Music item)
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
