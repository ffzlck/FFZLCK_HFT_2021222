using FFZLCK_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Logic.Interfaces
{
    public interface IClipLogic
    {
        void Create(Clip item);
        void Delete(int id);
        Clip Read(int id);
        IQueryable<Clip> ReadAll();
        void Update(Clip item);

        IEnumerable<KeyValuePair<string, double>> PerformerClipIncome();
    }
}
