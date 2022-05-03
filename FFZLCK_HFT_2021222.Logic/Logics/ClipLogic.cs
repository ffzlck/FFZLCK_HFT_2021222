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
    public class ClipLogic : IClipLogic
    {
        IRepository<Clip> cliprepo;
        public ClipLogic(IRepository<Clip> cliprepo)
        {
            this.cliprepo = cliprepo;
        }
        public void Create(Clip item)
        {
            this.cliprepo.Create(item);
        }

        public void Delete(int id)
        {
            this.cliprepo.Delete(id);
        }

        public Clip Read(int id)
        {
            return this.cliprepo.Read(id);
        }

        public IQueryable<Clip> ReadAll()
        {
            return this.cliprepo.ReadAll();
        }

        public void Update(Clip item)
        {
            this.cliprepo.Update(item);
        }
    }
}
