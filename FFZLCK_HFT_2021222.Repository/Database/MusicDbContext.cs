using FFZLCK_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Repository.Database
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Clip> Clips { get; set; }
        public MusicDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("music");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>()
                .HasOne(music=>music.Performer)
                .WithMany(perfromer=>perfromer.Musics)
                .HasForeignKey(music=>music.PerfromerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Album>()
                .HasOne(album => album.Performer)
                .WithMany(performer => performer.Albums)
                .HasForeignKey(album => album.PerformerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Clip>()
                .HasOne(clip => clip.Performer)
                .WithMany(performer => performer.Clips)
                .HasForeignKey(clip => clip.MusicID)
                .OnDelete(DeleteBehavior.Cascade);

            Performer beatles = new Performer() { PerformerID = 1, PerformerName = "The Beatles", PerformerStyle = "pop" };
            Performer michaeljackson = new Performer() { PerformerID = 2, PerformerName = "Michael Jackson", PerformerStyle = "rock&roll" };
            Performer pinkfloyd = new Performer() { PerformerID = 3, PerformerName = "Pink Floyd", PerformerStyle = "rock" };
            Performer tankcsapda = new Performer() { PerformerID = 4, PerformerName = "Tankcsapda", PerformerStyle = "rock" };
            Performer krúbi = new Performer() { PerformerID = 5, PerformerName = "Krúbi", PerformerStyle = "rap" };
            Performer acdc = new Performer() { PerformerID = 6, PerformerName = "AC/DC", PerformerStyle = "rock@roll" };
            Performer nirvana = new Performer() { PerformerID = 7, PerformerName = "Nirvana", PerformerStyle = "grunge" };

            Album help= new Album() { AlbumID = 1, AlbumName = "Help!", AlbumPopularity = 7, PerformerID = 1 };
            Album revoler= new Album() { AlbumID = 2, AlbumName ="Revoler", AlbumPopularity=9, PerformerID = 1 };
            Album jacksonstreet=new Album() { AlbumID = 3, AlbumName ="2300 Jackson Street", AlbumPopularity=4, PerformerID = 2 };
            Album thriller = new Album() { AlbumID = 4, AlbumName = "Thriller", AlbumPopularity = 9, PerformerID = 2 };

            Music mhelp=new Music() { MusicID = 1, MusicName="Help!", AlbumID=1, PerfromerID=1 };
            Music ineedyou = new Music() { MusicID = 2, MusicName = "I Need You", AlbumID = 1, PerfromerID = 1 };
            Music taxman=new Music() { MusicID=3, MusicName="Taxman", AlbumID=2, PerfromerID=1 };
            Music eleanor = new Music() { MusicID = 4, MusicName = "Eleanor Rigby", AlbumID = 2, PerfromerID = 1 };
            Music artofmadnes = new Music() { MusicID = 5, MusicName = "Art of Madness", AlbumID = 3, PerfromerID = 2 };
            Music maria=new Music() { MusicID=6, MusicName="Maria", AlbumID=3, PerfromerID=2 };
            Music beatit=new Music() { MusicID=7, MusicName="Beat It", AlbumID=4, PerfromerID=2 };
            Music babybemine = new Music() { MusicID = 8, MusicName = "Baby Be Mine", AlbumID = 4, PerfromerID = 2 };

            Clip first = new Clip() { ClipID = 1, DirectorName = "Pablo Escobar", Income = 20000, MusicID = 1};
            Clip clip2 = new Clip() { ClipID = 2, DirectorName = "Dancsó Péter", Income = 5000, MusicID = 1 };

            modelBuilder.Entity<Music>().HasData(mhelp, ineedyou, taxman, eleanor, artofmadnes, maria, beatit, babybemine);
            modelBuilder.Entity<Album>().HasData(help, revoler, jacksonstreet, thriller);
            modelBuilder.Entity<Performer>().HasData(beatles, michaeljackson, pinkfloyd, tankcsapda, krúbi, acdc, nirvana);
            modelBuilder.Entity<Clip>().HasData(first, clip2);
            
        }
    }
}
