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
                perfMockrepo = new Mock<IRepository<Performer>>();
                perfMockrepo.Setup(x => x.ReadAll()).Returns(new List<Performer>()
                {
                    new Performer(){ PerformerID=1, PerformerName="Led Zeppelin", PerformerStyle="rock"}
                
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
    }
}
