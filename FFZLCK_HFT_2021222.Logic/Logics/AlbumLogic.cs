using FFZLCK_HFT_2021222.Logic.Interfaces;
using FFZLCK_HFT_2021222.Models;
using FFZLCK_HFT_2021222.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Logic.Logics
{
    public class AlbumLogic : IAlbumLogic
    {
        IRepository<Album> albumrepo;
        public AlbumLogic(IRepository<Album> albumrepo)
        {
            this.albumrepo = albumrepo;
        }
        public void Create(Album item)
        {
            if (item.AlbumName == null)
            {
                throw new ArgumentException("Albumname is missing!");
            }
            this.albumrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.albumrepo.Delete(id);
        }

        public Album Read(int id)
        {
            var item = this.albumrepo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("Album not exists");
            }
            return this.albumrepo.Read(id);
        }

        public IQueryable<Album> ReadAll()
        {
            return this.albumrepo.ReadAll();
        }

        public void Update(Album item)
        {
            if (item.AlbumName == null)
            {
                throw new ArgumentException("Albumname is missing!");
            }
            this.albumrepo.Update(item);
        }

        //non crud

        public IEnumerable<KeyValuePair<string, ICollection<Music>>> PopoularAlbumsWithMusic()
        {
            return from album in albumrepo.ReadAll()
                   where album.AlbumPopularity>=7
                   orderby album.AlbumPopularity descending
                   select new KeyValuePair<string, ICollection<Music>>
                   (album.AlbumName, album.Musics);
        }

        public IEnumerable<KeyValuePair<string, ICollection<Music>>> UnPopoularAlbumsWithMusic()
        {
            return from album in albumrepo.ReadAll()
                   where album.AlbumPopularity < 7
                   orderby album.AlbumPopularity descending
                   select new KeyValuePair<string, ICollection<Music>>
                   (album.AlbumName, album.Musics);
        }

        public IEnumerable<KeyValuePair<string, ICollection<Music>>> MostBiggestAlbum()
        {
            int max = albumrepo.ReadAll().Max(x => x.Musics.Count);
            return from album in albumrepo.ReadAll()
                   where album.Musics.Count==max
                   select new KeyValuePair<string, ICollection<Music>>(album.AlbumName, album.Musics);
        }



    }
}
