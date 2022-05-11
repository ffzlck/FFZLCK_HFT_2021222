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
            else if (entity == "Performer")
            {
                Console.Write("Enter performer name: ");
                string name= Console.ReadLine();
                Console.Write("Enter style: ");
                string style= Console.ReadLine();
                rest.Post(new Performer() { PerformerName = name, PerformerStyle = style }, "performer");
            }
            else
            {
                Console.Write("Enter clip directorname:");
                string name=Console.ReadLine();
                Console.Write("Income: ");
                int income=int.Parse(Console.ReadLine());
                Console.Write("MusicID: ");
                int mid=int.Parse(Console.ReadLine());
                rest.Post(new Clip() { DirectorName = name, Income = income, MusicID = mid }, "clip");
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
            else if(entity == "Album")
            {
                List<Album> album = rest.Get<Album>("album");
                foreach (var item in album)
                {
                    Console.WriteLine(item.AlbumName +", "+ item.AlbumID);
                }
            }
            else if (entity == "Performer")
            {
                List<Performer> performer = rest.Get<Performer>("performer");
                foreach (var item in performer)
                {
                    Console.WriteLine(item.PerformerID + ", " + item.PerformerName +", "+item.PerformerStyle);
                }
            }
            else
            {
                List<Clip> clip = rest.Get<Clip>("clip");
                foreach (var item in clip)
                {
                    Console.WriteLine(item.ClipID + ", " + item.DirectorName +", "+ item.Income);
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
            else if (entity == "Album")
            {
                Console.Write("Enter Album's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "album");
            }
            else if (entity == "Performer")
            {
                Console.Write("Enter Performer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "performer");
            }
            else
            {
                Console.Write("Enter Clip's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "clip");
            }
        }
        static void Non_Crud(string entity)
        {
            if (entity == "PopularA")
            {
 
                Console.WriteLine("Popular albums with overall minimum 7 rating");
                var x = rest.Get<KeyValuePair<string, ICollection<Music>>>("stat/Popular");
                foreach (var item in x)
                {
                    Console.WriteLine("Album name: " + item.Key);
                    Console.WriteLine();
                    Console.WriteLine("Music list");
                    foreach (var music in item.Value)
                    {
                        Console.WriteLine(music.MusicName);
                    }
                    Console.WriteLine();
                }

            }
            else if (entity == "UnPopularA")
            {
                Console.WriteLine("Unpopular albums with overall maximum 7 rating");
                //List<KeyValuePair<string,ICollection<Music>>> 
                var x = rest.Get<KeyValuePair<string, ICollection<Music>>>("stat/UnPopular");
                foreach (var item in x)
                {
                    Console.WriteLine("Album name: " + item.Key);
                    Console.WriteLine();
                    Console.WriteLine("Music list");
                    foreach (var music in item.Value)
                    {
                        Console.WriteLine(music.MusicName);
                    }
                    Console.WriteLine();
                }
            }
            else if(entity == "ClipIncome")
            {
                Console.WriteLine("Performer's clip income");
                var x = rest.Get<KeyValuePair<string, double>>("stat/ClipIncome");
                foreach (var item in x)
                {
                    Console.Write("Performer name: "+ item.Key+" Income: "+ item.Value);
                    Console.WriteLine();
                    
                }
            }
            else if(entity== "MostProductivePerformer")
            {
                var p = rest.Get< KeyValuePair<string, int> > ("stat/ProductivePerformer");
                foreach (var item in p)
                {
                    Console.Write("Most productive performer: " + item.Key + " with: " + item.Value + " music.");
                }   

            }
            else if(entity=="MostBiggestAlbum")
            {
                var a = rest.Get<KeyValuePair<string, ICollection<Music>>>("stat/MostBiggestAlbum");

                Console.WriteLine("Most biggest album is "+a[0].Key+" with "+a[0].Value.Count+" music.");
                Console.WriteLine();
                
            }
            Console.ReadLine();

        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:53506/");


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
                .Add("Popular Albums",()=>Non_Crud("PopularA"))
                .Add("Unpopular Albums", ()=>Non_Crud("UnPopularA"))
                .Add("Performers all clip income", ()=>Non_Crud("ClipIncome"))
                .Add("Most productive performer", ()=>Non_Crud("MostProductivePerformer"))
                .Add("Most biggest album",()=>Non_Crud("MostBiggestAlbum"))
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
