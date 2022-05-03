using FFZLCK_HFT_2021222.Models;
using FFZLCK_HFT_2021222.Repository.Database;
using FFZLCK_HFT_2021222.Repository.GenericRepository;
using FFZLCK_HFT_2021222.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Repository.ModelRepository
{
    public class PerformerRepository : Repository<Performer>, IRepository<Performer>
    {
        public PerformerRepository(MusicDbContext ctx) : base(ctx)
        {

        }
        public override Performer Read(int id)
        {
            return ctx.Performers.FirstOrDefault(x => x.PerformerID == id);
        }

        public override void Update(Performer item)
        {
            var old = Read(item.PerformerID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
