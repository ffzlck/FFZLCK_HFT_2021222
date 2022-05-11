using FFZLCK_HFT_2021222.Logic.Logics;
using FFZLCK_HFT_2021222.Models;
using FFZLCK_HFT_2021222.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Test
{
    [TestFixture]
    public class AlbumLogicTester
    {
        AlbumLogic albumLogic;
        MusicLogic musicLogic;
        Mock<IRepository<Album>> albumMockrepo;
        Mock<IRepository<Music>> musicMockrepo;

        [SetUp]
        public void Init()
        {
            musicMockrepo = new Mock<IRepository<Music>>();
            musicMockrepo.Setup(x => x.ReadAll()).Returns(new List<Music>()
            {
                new Music() {MusicID=1, AlbumID=1, MusicName="Nehézlábérzés"},
                new Music() {MusicID=2, AlbumID=1, MusicName="PestiEst"},
                new Music() {MusicID=3, AlbumID=3, MusicName="TEST"}
            }.AsQueryable());

            musicLogic = new MusicLogic(musicMockrepo.Object);

            //var test = musicLogic.ReadAll();

            albumMockrepo =new Mock<IRepository<Album>>();
            albumMockrepo.Setup(x => x.ReadAll()).Returns(new List<Album>()
            { 
                new Album() {AlbumID=1, AlbumName="Ösztönlény", AlbumPopularity=10, PerformerID=1,Musics=new List<Music>(){new Music() {MusicID=1, AlbumID=1, MusicName="Nehézlábérzés"},
                new Music() {MusicID=2, AlbumID=1, MusicName="PestiEst"}} },
                new Album() {AlbumID=2, AlbumName="Hova tovább?", AlbumPopularity=3, PerformerID=2,Musics=new List<Music>(){ new Music() { MusicID = 3, AlbumID = 2, MusicName = "Go" }, 
                new Music{ MusicID=4, AlbumID=2, MusicName="IDC" } } },
                //new Album() {AlbumID=3, AlbumName="Never give you up", AlbumPopularity=7, PerformerID=3,Musics=new List<Music>(){ new Music() { MusicID = 4, AlbumID = 3, MusicName = "Easy" } }}
            }.AsQueryable());
            albumLogic = new AlbumLogic(albumMockrepo.Object);

            var test2=albumLogic.ReadAll();
        }

        [Test]
        public void CreateAlbumWithCorrectName()
        {
            var album = new Album() { AlbumName="DarkSide"};
            try
            {
                albumLogic.Create(album);
            }
            catch
            {

            }
            albumMockrepo.Verify(x => x.Create(album), Times.Once);
        }
        [Test]
        public void CreateAlbumWithoutName()
        {
            var album = new Album() { AlbumPopularity=3, PerformerID=2};

            albumMockrepo.Setup(x => x.Create(It.IsAny<Album>()));
            
            Assert.Throws<ArgumentException>(()=>albumLogic.Create(album));

            
        }
        [Test]
        public void PopularTester()
        {
            var result = albumLogic.PopoularAlbumsWithMusic();
            var except = new List<KeyValuePair<string, ICollection<Music>>>();
            except.Insert(0, new KeyValuePair<string, ICollection<Music>>("Ösztönlény", new List<Music>(){new Music() {MusicID=1, AlbumID=1, MusicName="Nehézlábérzés"},
                new Music() {MusicID=2, AlbumID=1, MusicName="PestiEst"}}) );

            Assert.That(result, Is.EqualTo(except));
        }

        [Test]
        public void UnPopularTest()
        {
            var result = albumLogic.UnPopoularAlbumsWithMusic();
            var except = new List<KeyValuePair<string, ICollection<Music>>>();
            except.Insert(0, new KeyValuePair<string, ICollection<Music>>("Hova tovább?", new List<Music>() { new Music() { MusicID = 3, AlbumID = 2, MusicName = "Go" },
            new Music{ MusicID=4, AlbumID=2, MusicName="IDC" } }));


            Assert.That(result, Is.EqualTo(except));
        }

        [Test]
        public void MostBiggestTest()
        {
            var result = albumLogic.MostBiggestAlbum();
            var except = new List<KeyValuePair<string, ICollection<Music>>>();
            except.Insert(0, new KeyValuePair<string, ICollection<Music>>("Hova tovább?", new List<Music>() { new Music() { MusicID = 3, AlbumID = 2, MusicName = "Go" },
            new Music{ MusicID=4, AlbumID=2, MusicName="IDC" } }));

        }
    }
}
