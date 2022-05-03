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
    public class ClipRepository : Repository<Clip>, IRepository<Clip>
    {
        public ClipRepository(MusicDbContext ctx) : base(ctx)
        {
        }

        public override Clip Read(int id)
        {
            return ctx.Clips.FirstOrDefault(x => x.ClipID == id);
        }

        public override void Update(Clip item)
        {
            var old = Read(item.ClipID);
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
