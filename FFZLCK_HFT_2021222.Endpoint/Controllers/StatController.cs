using FFZLCK_HFT_2021222.Logic.Interfaces;
using FFZLCK_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FFZLCK_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IAlbumLogic albumLogic;
        public StatController(IAlbumLogic albumLogic)
        {
            this.albumLogic = albumLogic;
        }
        [HttpGet("Popular")]
        public IEnumerable<KeyValuePair<string, ICollection<Music>>> PopoularAlbum()
        {
            return this.albumLogic.PopoularAlbumsWithMusic();
        }

        [HttpGet("Not popular")]
        public IEnumerable<KeyValuePair<string, ICollection<Music>>> UnPopularAlbum()
        {
            return this.albumLogic.UnPopoularAlbumsWithMusic();
        }
    }
}
