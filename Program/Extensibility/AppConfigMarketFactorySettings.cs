using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Interfaces;
using System.Configuration;
using Marketplace.Concepts.Inheritance;

namespace Program.Extensibility
{
    public class AppConfigMarketFactorySettings : IMarketFactorySettings
    {
        protected IDictionary<Type, int> _numberOfPersons;
        public IDictionary<Type, int> NumberOfPersons
        {
            get 
            {
                return _numberOfPersons;
            }
        }

        public AppConfigMarketFactorySettings()
        {
            _numberOfPersons = new Dictionary<Type, int>();
            ReadConfig();
        }

        protected virtual void ReadConfig()
        {
            _numberOfPersons.Add(typeof(Salesman),
                Convert.ToInt32(ConfigurationManager.AppSettings["MarketGenerator_NumberOfSalesmen"]));
            _numberOfPersons.Add(typeof(Customer),
                Convert.ToInt32(ConfigurationManager.AppSettings["MarketGenerator_NumberOfCustomers"]));
        }
    }
}
