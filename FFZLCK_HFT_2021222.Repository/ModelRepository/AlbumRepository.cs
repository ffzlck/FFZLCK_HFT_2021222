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
    public class AlbumRepository : Repository<Album>, IRepository<Album>
    {
        public AlbumRepository(MusicDbContext ctx) : base(ctx)
        {

        }
        public override Album Read(int id)
        {
            return ctx.Albums.FirstOrDefault(x => x.AlbumID == id);
        }

        public override void Update(Album item)
        {
            var old = Read(item.AlbumID);
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
