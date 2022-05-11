﻿using FFZLCK_HFT_2021222.Logic.Interfaces;
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
            if(item.PerformerName == null)
            {
                throw new ArgumentException("Missing name!");
            }
            this.perfrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.perfrepo.Delete(id);
        }

        public Performer Read(int id)
        {
            var item = this.perfrepo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("Performer not exists");
            }
            return this.perfrepo.Read(id);
        }

        public IQueryable<Performer> ReadAll()
        {
            return this.perfrepo.ReadAll();
        }

        public void Update(Performer item)
        {
            if (item.PerformerName == null)
            {
                throw new ArgumentException("Missing name!");
            }
            this.perfrepo.Update(item);
        }

        /*public List<KeyValuePair<string,int>> PerformerMusicNumber()
        {
            return from x in perfrepo.ReadAll()
                   
        }*/
    }
}
