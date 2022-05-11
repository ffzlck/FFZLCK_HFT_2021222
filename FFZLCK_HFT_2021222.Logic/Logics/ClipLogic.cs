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
            if(item.DirectorName == null)
            {
                throw new ArgumentException("Missing director name!");
            }
            this.cliprepo.Create(item);
        }

        public void Delete(int id)
        {
            this.cliprepo.Delete(id);
        }

        public Clip Read(int id)
        {
            var item = this.cliprepo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("Clip not exists");
            }
            return this.cliprepo.Read(id);
        }

        public IQueryable<Clip> ReadAll()
        {
            return this.cliprepo.ReadAll();
        }

        public void Update(Clip item)
        {
            if (item.DirectorName == null)
            {
                throw new ArgumentException("Missing director name!");
            }
            this.cliprepo.Update(item);
        }

        public IEnumerable<KeyValuePair<string,double>> PerformerClipIncome()
        {
            return from x in cliprepo.ReadAll()
                   group x by x.Performer.PerformerName into g
                   select new KeyValuePair<string, double>(g.Key, g.Sum(y => y.Income));

        }
    }
}
