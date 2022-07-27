using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TariffCalculation.Models
{
    /// <summary>
    /// ElectricityTariff Model
    /// <param name="consumption">Consumption(kWh/year)</param>
    /// <param name="Tariff name">Tariff name</param>
    /// <param name="Annual costs">Annual costs(kWh/year)</param>
    /// </summary>
    public class ElectricityTariff
    {
        public double AnnualCosts { get; set; }
        public int Consumption { get; set; }
        public string TariffName { get; set; }
    }
}