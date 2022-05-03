using FFZLCK_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Logic.Interfaces
{
    public interface IMusicLogic
    {
        void Create(Music item);
        void Delete(int id);
        Music Read(int id);
        IQueryable<Music> ReadAll();
        void Update(Music item);
    }
}
