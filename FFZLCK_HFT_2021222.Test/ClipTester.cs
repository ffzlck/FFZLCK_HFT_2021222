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
    public class ClipTester
    {
        ClipLogic logicC;
        Mock<IRepository<Clip>> clipMockrepo;

        [SetUp]
        public void Init()
        {
            clipMockrepo = new Mock<IRepository<Clip>>();
            clipMockrepo.Setup(x => x.ReadAll()).Returns(new List<Clip>()
            {
                new Clip(){ ClipID=1, DirectorName="Michale Bay"}

            }.AsQueryable());
            logicC = new ClipLogic(clipMockrepo.Object);
        }
        [Test]
        public void CreateAlbumWithoutName()
        {
            var item = new Clip() { ClipID=1};

            clipMockrepo.Setup(x => x.Create(It.IsAny<Clip>()));

            Assert.Throws<ArgumentException>(() => logicC.Create(item));


        }
    }
}
