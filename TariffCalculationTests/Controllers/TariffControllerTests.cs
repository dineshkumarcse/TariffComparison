using Microsoft.VisualStudio.TestTools.UnitTesting;
using TariffCalculation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using TariffCalculation.Models;

namespace TariffCalculation.Controllers.Tests
{
    [TestClass()]
    public class TariffControllerTests
    {
        /// <summary>
        /// To calculate tariff for 3500 kWh/year
        /// </summary>
        [TestMethod()]
        public void GetElectricityTariff_3500()
        {
            var controller = new TariffController();
            IHttpActionResult result = controller.GetElectricityTariff(3500);
            var contentResult = result as OkNegotiatedContentResult<List<ElectricityTariff>>;
            Assert.AreEqual(contentResult.Content.Count, 2);
            Assert.IsNotNull(contentResult.Content[1].AnnualCosts);
            Assert.AreNotEqual(contentResult.Content.Count, 3);
            Assert.AreEqual(contentResult.Content[0].AnnualCosts, 800);
            Assert.AreEqual(contentResult.Content[1].AnnualCosts, 830);
        }
        /// <summary>
        /// To calculate tariff for 4500 kWh/year
        /// </summary>
        [TestMethod()]
        public void GetElectricityTariff_4500()
        {
            var controller = new TariffController();
            IHttpActionResult result = controller.GetElectricityTariff(4500);
            var contentResult = result as OkNegotiatedContentResult<List<ElectricityTariff>>;
            Assert.AreEqual(contentResult.Content.Count, 2);
            Assert.IsNotNull(contentResult.Content[1].AnnualCosts);
            Assert.AreEqual(contentResult.Content[0].AnnualCosts, 950);
            Assert.AreEqual(contentResult.Content[1].AnnualCosts, 1050);
        }
        /// <summary>
        /// To calculate tariff for 6000 kWh/year
        /// </summary>
        [TestMethod()]
        public void GetElectricityTariff_6000()
        {
            var controller = new TariffController();
            IHttpActionResult result = controller.GetElectricityTariff(6000);
            var contentResult = result as OkNegotiatedContentResult<List<ElectricityTariff>>;
            Assert.AreEqual(contentResult.Content.Count, 2);
            Assert.IsNotNull(contentResult.Content[1].AnnualCosts);
            Assert.AreEqual(contentResult.Content[0].AnnualCosts, 1380);
            Assert.AreEqual(contentResult.Content[1].AnnualCosts, 1400);
        }
        /// <summary>
        /// To calculate tariff for 0 kWh/year
        /// </summary>
        [TestMethod()]
        public void GetElectricityTariff_9000()
        {
            var controller = new TariffController();
            IHttpActionResult result = controller.GetElectricityTariff(9000);
            var contentResult = result as OkNegotiatedContentResult<List<ElectricityTariff>>;
            Assert.AreEqual(contentResult.Content.Count, 2);
            Assert.AreEqual(contentResult.Content[0].AnnualCosts, 2040);
            Assert.AreEqual(contentResult.Content[1].AnnualCosts, 2300);
        }
        /// <summary>
        /// To calculate tariff for 0 kWh/year
        /// </summary>
        [TestMethod()]
        public void GetElectricityTariff_0()
        {
            var controller = new TariffController();
            IHttpActionResult result = controller.GetElectricityTariff(0);
            var contentResult = result as OkNegotiatedContentResult<List<ElectricityTariff>>;
            Assert.AreEqual(contentResult.Content.Count, 2);
            Assert.AreEqual(contentResult.Content[0].AnnualCosts, 60);
            Assert.AreEqual(contentResult.Content[1].AnnualCosts, 800);
        }
        /// <summary>
        /// To calculate tariff for -1 kWh/year
        /// </summary>
        [TestMethod()]
        public void GetElectricityTariff_NegativeAnnualCost()
        {
            var controller = new TariffController();
            IHttpActionResult result = controller.GetElectricityTariff(-1);
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }
    }
}