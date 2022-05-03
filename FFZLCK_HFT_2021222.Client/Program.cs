using FFZLCK_HFT_2021222.Logic.Interfaces;
using FFZLCK_HFT_2021222.Logic.Logics;
using FFZLCK_HFT_2021222.Models;
using FFZLCK_HFT_2021222.Repository.Database;
using FFZLCK_HFT_2021222.Repository.GenericRepository;
using FFZLCK_HFT_2021222.Repository.ModelRepository;
using System;

namespace FFZLCK_HFT_2021222.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicDbContext ctx = new MusicDbContext();

            MusicRepository mrepo = new MusicRepository(ctx);
            MusicLogic mlogic = new MusicLogic(mrepo);
            
            var x = mlogic.Read(1);
            /*var y= mlogic.Test();
            foreach (var item in y)
            {
                Console.WriteLine(item.Value + "..." + item.Key);
            }*/
            Console.WriteLine(x.MusicID);

            
        }
    }
}
