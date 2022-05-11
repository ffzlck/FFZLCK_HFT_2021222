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
        IClipLogic clipLogic;
        IPerformerLogic prefLogic;
        public StatController(IAlbumLogic albumLogic, IClipLogic clipLogic, IPerformerLogic prefLogic)
        {
            this.albumLogic = albumLogic;
            this.clipLogic = clipLogic;
            this.prefLogic = prefLogic;
        }
        [HttpGet("Popular")]
        public IEnumerable<KeyValuePair<string, ICollection<Music>>> PopoularAlbum()
        {
            return this.albumLogic.PopoularAlbumsWithMusic();
        }

        [HttpGet("Unpopular")]
        public IEnumerable<KeyValuePair<string, ICollection<Music>>> UnPopularAlbum()
        {
            return this.albumLogic.UnPopoularAlbumsWithMusic();
        }
        [HttpGet("ClipIncome")]
        public IEnumerable<KeyValuePair<string,double>> PerformerClipIncome()
        {
            return this.clipLogic.PerformerClipIncome();
        }
        [HttpGet("ProductivePerformer")]
        public IEnumerable<KeyValuePair<string, int>> MostProductivePerformer()
        {
            return this.prefLogic.MostProductivePerformer();
        }
        [HttpGet("MostBiggestAlbum")]
        public IEnumerable<KeyValuePair<string, ICollection<Music>>> MostBiggestAlbum()
        {
            return this.albumLogic.MostBiggestAlbum();
        }
        [HttpGet("AVGIncomewithDirector")]
        public IEnumerable<KeyValuePair<string, double>> AVGIncomewithDirector()
        {
            return this.clipLogic.AVGIncomewithDirector();
        }

    }
}
