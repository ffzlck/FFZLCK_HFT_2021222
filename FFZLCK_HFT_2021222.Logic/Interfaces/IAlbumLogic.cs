using FFZLCK_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Logic.Interfaces
{
    public interface IAlbumLogic
    {
        void Create(Album item);
        void Delete(int id);
        Album Read(int id);
        IQueryable<Album> ReadAll();
        void Update(Album item);
        public IEnumerable<KeyValuePair<string, ICollection<Music>>> PopoularAlbumsWithMusic();

        public IEnumerable<KeyValuePair<string, ICollection<Music>>> UnPopoularAlbumsWithMusic();

        public IEnumerable<KeyValuePair<string, ICollection<Music>>> MostBiggestAlbum();
    }
}
