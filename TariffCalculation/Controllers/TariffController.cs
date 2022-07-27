using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TariffCalculation.Models;

namespace TariffCalculation.Controllers
{

    public class TariffController : ApiController
    {

        /// <summary>
        /// Compare ElectriCity Tariff Calculation 
        /// </summary>
        /// <param name="consumption">Consumption(kWh/year)</param>
        /// <returns>Tariff Comparison List</returns>
        [HttpGet]
        public IHttpActionResult GetElectricityTariff(int consumption)
        {
            List<ElectricityTariff> tariffProducts = new List<ElectricityTariff>();
            if (consumption >= 0)
            {
                double annualCost = 60 + (consumption * 0.22);
                tariffProducts.Add(new ElectricityTariff()
                {
                    AnnualCosts = annualCost,
                    TariffName = "Product A: Basic Electricity Tariff",
                    Consumption = consumption
                });
                if (consumption <= 4000)
                    annualCost = 800;
                else
                {
                    annualCost = 800 + ((consumption - 4000) * 0.30);
                }
                tariffProducts.Add(new ElectricityTariff()
                {
                    AnnualCosts = annualCost,
                    TariffName = "Product B: Packaged Tariff",
                    Consumption = consumption
                });
            }
            else
            {
               return BadRequest("Invalid consumption value");
            }
            List<ElectricityTariff> comparedTariffs = tariffProducts.OrderBy(x => x.AnnualCosts).ToList();
            return Ok(comparedTariffs);
        }
    }
}
