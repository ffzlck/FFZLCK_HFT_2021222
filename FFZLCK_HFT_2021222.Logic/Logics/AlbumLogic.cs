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
            this.albumrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.albumrepo.Delete(id);
        }

        public Album Read(int id)
        {
            return this.albumrepo.Read(id);
        }

        public IQueryable<Album> ReadAll()
        {
            return this.albumrepo.ReadAll();
        }

        public void Update(Album item)
        {
            this.albumrepo.Update(item);
        }

        //non crud
    }
}
