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
    public class MusicTester
    {
        MusicLogic logicM;
        Mock<IRepository<Music>> musicMockrepo;

        [SetUp]
        public void Init()
        {
            musicMockrepo = new Mock<IRepository<Music>>();
            musicMockrepo.Setup(x => x.ReadAll()).Returns(new List<Music>()
            {
                new Music(){MusicName="Menyországtourist", AlbumID=1, MusicID=1, PerfromerID=2, Style="rock"}

            }.AsQueryable()); 
            logicM = new MusicLogic(musicMockrepo.Object);
        }
        [Test]
        public void CreateAlbumWithoutName()
        {
            var item = new Music() { MusicID=1};

            musicMockrepo.Setup(x => x.Create(It.IsAny<Music>()));

            Assert.Throws<ArgumentException>(() => logicM.Create(item));


        }
    }
}
