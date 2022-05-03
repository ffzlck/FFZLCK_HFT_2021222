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
    public class MusicRepository : Repository<Music>, IRepository<Music>
    {
        public MusicRepository(MusicDbContext ctx) : base(ctx)
        {

        }
        public override Music Read(int id)
        {
            return ctx.Musics.FirstOrDefault(x=>x.MusicID == id);
        }

        public override void Update(Music item)
        {
            var old = Read(item.MusicID);
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
