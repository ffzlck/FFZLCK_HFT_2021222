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
    public class PerformerLogic : IPerformerLogic
    {
        IRepository<Performer> perfrepo;
        public PerformerLogic(IRepository<Performer> perfrepo)
        {
            this.perfrepo = perfrepo;
        }
        public void Create(Performer item)
        {
            this.perfrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.perfrepo.Delete(id);
        }

        public Performer Read(int id)
        {
            return this.perfrepo.Read(id);
        }

        public IQueryable<Performer> ReadAll()
        {
            return this.perfrepo.ReadAll();
        }

        public void Update(Performer item)
        {
            this.perfrepo.Update(item);
        }
    }
}
