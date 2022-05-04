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
    public class MusicLogic : IMusicLogic
    {
        IRepository<Music> musicrepo;
        public MusicLogic(IRepository<Music> repo)
        {
            this.musicrepo = repo;
        }
        public void Create(Music item)
        {
            if(item.MusicName == null)
            {
                throw new ArgumentException("Name is missing!");
            }
            this.musicrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.musicrepo.Delete(id);
        }

        public Music Read(int id)
        {
            var item = this.musicrepo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("Music not exists");
            }
            return this.musicrepo.Read(id);
        }

        public IQueryable<Music> ReadAll()
        {
            return this.musicrepo.ReadAll();
        }

        public void Update(Music item)
        {
            if (item.MusicName == null)
            {
                throw new ArgumentException("Name is missing!");
            }
            this.musicrepo.Update(item);
        }

        //non crud

    }
    
}
