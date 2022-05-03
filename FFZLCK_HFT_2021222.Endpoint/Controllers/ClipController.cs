using FFZLCK_HFT_2021222.Logic.Interfaces;
using FFZLCK_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FFZLCK_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClipController : ControllerBase
    {
        IClipLogic logic;
        public ClipController(IClipLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Clip> ReadALL()
        {
            return this.logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Clip Read(int id)
        {
            return this.logic.Read(id);
        }
        [HttpPost]
        public void Create(Clip item)
        {
            this.logic.Create(item);
        }
        [HttpPut]
        public void Put([FromBody] Clip item)
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
