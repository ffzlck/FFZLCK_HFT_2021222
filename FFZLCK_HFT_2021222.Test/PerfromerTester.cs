using FFZLCK_HFT_2021222.Logic.Logics;
using FFZLCK_HFT_2021222.Models;
using FFZLCK_HFT_2021222.Repository.Interfaces;
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
    public class PerfromerTester
    {
            PerformerLogic logicP;
            Mock<IRepository<Performer>> perfMockrepo;

            [SetUp]
            public void Init()
            {
                var music1=new List<Music>() 
                {
                    new Music() { MusicID = 1, MusicName="Help!", AlbumID=1, PerfromerID=1 },
                    new Music() { MusicID = 2, MusicName = "I Need You", AlbumID = 1, PerfromerID = 1 },
                    new Music() { MusicID = 3, MusicName = "Taxman", AlbumID = 2, PerfromerID = 1 },
                    new Music() { MusicID = 4, MusicName = "Eleanor Rigby", AlbumID = 2, PerfromerID = 1 },
            
        };
            var music2 = new List<Music>() 
            {
                new Music() { MusicID = 5, MusicName = "Art of Madness", AlbumID = 3, PerfromerID = 2 },
                new Music() { MusicID = 6, MusicName = "Maria", AlbumID = 3, PerfromerID = 2 }
            };
                perfMockrepo = new Mock<IRepository<Performer>>();
                perfMockrepo.Setup(x => x.ReadAll()).Returns(new List<Performer>()
                {
                    new Performer(){ PerformerID=1, PerformerName="Led Zeppelin", PerformerStyle="rock", Musics=music1},
                    new Performer(){ PerformerID=2, PerformerName="AK26", Musics=music2}
                
                }.AsQueryable());
                logicP = new PerformerLogic(perfMockrepo.Object);
            }
            [Test]
            public void CreateAlbumWithoutName()
            {
                var item = new Performer() { PerformerID=1};

                perfMockrepo.Setup(x => x.Create(It.IsAny<Performer>()));

                Assert.Throws<ArgumentException>(() => logicP.Create(item));


            }

        [Test]
        public void MostProductiveTest()
        {
            var expected = logicP.MostProductivePerformer();
            var result = new List<KeyValuePair<string, int>>();
            result.Insert(0, new KeyValuePair<string, int>("Led Zeppelin", 4));
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
