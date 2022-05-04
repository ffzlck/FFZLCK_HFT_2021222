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
    public class AlbumLogicTester
    {
        AlbumLogic albumLogic;
        Mock<IRepository<Album>> albumMockrepo;

        [SetUp]
        public void Init()
        {
            albumMockrepo=new Mock<IRepository<Album>>();
            albumMockrepo.Setup(x => x.ReadAll()).Returns(new List<Album>()
            { 
                new Album() {AlbumID=1, AlbumName="Ösztönlény", AlbumPopularity=10, PerformerID=1},
                new Album() {AlbumID=2, AlbumName="Hova tovább?", AlbumPopularity=3, PerformerID=2},
                new Album() {AlbumID=3, AlbumName="Never give you up", AlbumPopularity=7, PerformerID=3}
            }.AsQueryable());
            albumLogic = new AlbumLogic(albumMockrepo.Object);
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
    }
}
