using ConsoleTools;
using FFZLCK_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FFZLCK_HFT_2021222.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Music")
            {
                Console.Write("Enter Music Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Music AlbumID: ");
                int albumID= int.Parse(Console.ReadLine());
                Console.Write("Enter PerformerID");
                int perfID=int.Parse(Console.ReadLine());
                Performer p=new Performer() { PerformerID=perfID};
                Console.Write("Enter popularity: ");
                int pop=int.Parse(Console.ReadLine());
                rest.Post(new Music() { MusicName = name, AlbumID=albumID, PerfromerID=perfID }, "music");
            }
            else if(entity =="Album")
            {
                Console.Write("Enter Album Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter PerformerID: ");
                int perfID = int.Parse(Console.ReadLine());
                Console.Write("Enter popularity: ");
                int pop = int.Parse(Console.ReadLine());
                rest.Post(new Album() { AlbumName = name, PerformerID = perfID, AlbumPopularity = pop }, "album");
            }
        }
        static void List(string entity)
        {
            if (entity == "Music")
            {
                List<Music> music = rest.Get<Music>("music");
                foreach (var item in music)
                {
                    Console.WriteLine(item.MusicID + ": " + item.MusicName);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Music")
            {
                Console.Write("Enter Music's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Music one = rest.Get<Music>(id, "music");
                Console.Write($"New name [old: {one.MusicName}]: ");
                string name = Console.ReadLine();
                one.MusicName = name;
                rest.Put(one, "music");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Music")
            {
                Console.Write("Enter Music's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "music");
            }
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:53506/");

           /* var album = rest.Get<Album>(1,"album");
            Console.WriteLine(album.AlbumName);
            album.ToList().ForEach(x => Console.WriteLine(x.AlbumName + "..." + x.AlbumID));*/

            var performerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Performer"))
                .Add("Create", () => Create("Performer"))
                .Add("Delete", () => Delete("Performer"))
                .Add("Update", () => Update("Performer"))
                .Add("Exit", ConsoleMenu.Close);

            var albumSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Album"))
                .Add("Create", () => Create("Album"))
                .Add("Delete", () => Delete("Album"))
                .Add("Update", () => Update("Album"))
                .Add("Exit", ConsoleMenu.Close);

            var musicSubmenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Music"))
                .Add("Create", () => Create("Music"))
                .Add("Delete", () => Delete("Music"))
                .Add("Update", () => Update("Music"))
                .Add("Exit", ConsoleMenu.Close);

            var clipSubmenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Clip"))
                .Add("Create", () => Create("Clip"))
                .Add("Delete", () => Delete("Clip"))
                .Add("Update", () => Update("Clip"))
                .Add("Exit", ConsoleMenu.Close);

            var querySubmenu = new ConsoleMenu(args, level: 1)
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Performer", () => performerSubMenu.Show())
                .Add("Album", () => albumSubMenu.Show())
                .Add("Music", () => musicSubmenu.Show())
                .Add("Clip", () => clipSubmenu.Show())
                .Add("Query", ()=>querySubmenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
