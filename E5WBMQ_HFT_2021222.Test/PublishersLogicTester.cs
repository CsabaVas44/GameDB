using E5WBMQ_HFT_2021222.Logic.Logics;
using E5WBMQ_HFT_2021222.Models;
using E5WBMQ_HFT_2021222.Repository.GenericRepository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E5WBMQ_HFT_2021222.Test
{
    [TestFixture]
    public class PublishersLogicTester
    {
        PublishersLogic pl;
        Mock<IRepository<Publishers>> mockPublishersRepository;

        [SetUp]
        public void Init()
        {
            var pubs = new List<Publishers>()
            {
                new Publishers()
                {
                    PublisherId = 1,
                    PublisherName = "Bandai Namco",
                    Foundation = 1995,
                },
                new Publishers()
                {
                    PublisherId = 2,
                    PublisherName = "Electronic Arts",
                    Foundation = 1996,
                },
            }.AsQueryable();

            mockPublishersRepository = new Mock<IRepository<Publishers>>();
            mockPublishersRepository
                .Setup(x => x.ReadAll())
                .Returns(pubs);

            pl = new PublishersLogic(mockPublishersRepository.Object);
        }

        [Test]
        public void TestCreatePublishersWithIncorrectNumberOfEmployees()
        {
            var pub = new Publishers()
            {
                PublisherId = 1,
                PublisherName = "Bandai Namco",
                NumberOfEmployees = 0,
                Foundation = 1950,
            };
            try { pl.Create(pub); }
            catch { }
            mockPublishersRepository.Verify(x => x.Create(pub), Times.Never);
        }
        [Test]
        public void TestCreatePublishersWithIncorrectAnnualSales()
        {
            var pub = new Publishers()
            {
                PublisherId = 1,
                PublisherName = "Bandai Namco",
                Foundation = 1950,
                AnnualSales = -1,
            };
            try { pl.Create(pub); }
            catch { }
            mockPublishersRepository.Verify(x => x.Create(pub), Times.Never);
        }
    }
}
