using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Services.Services;

namespace Sales.Tests.UnitTest
{
    [TestClass]
    public class TaxServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var Tax = new Tax() { Id = 1, Percentage = 10, StartDate = DateTime.Now };
            var mockRepo = new Mock<IRepository<Tax>>();

            mockRepo.Setup(x => x.GetById(1)).Returns(Tax).Verifiable();

            var taxService = new TaxService(mockRepo.Object);
            var retrnData = taxService.Find(1);

            Assert.IsNotNull(retrnData);
            Assert.AreEqual(Tax, retrnData);
        }
    }
}
