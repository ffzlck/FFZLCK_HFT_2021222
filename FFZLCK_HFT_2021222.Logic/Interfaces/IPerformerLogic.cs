using FFZLCK_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Logic.Interfaces
{
    public interface IPerformerLogic
    {
        void Create(Performer item);
        void Delete(int id);
        Performer Read(int id);
        IQueryable<Performer> ReadAll();
        void Update(Performer item);
        public IEnumerable<KeyValuePair<string, int>> MostProductivePerformer();

    }
}
