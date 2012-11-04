using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Interfaces;
using Marketplace.Concepts.Inheritance;

namespace Marketplace.Concepts.ConcreteClasses
{
    public class MarketFactorySettings : IMarketFactorySettings
    {
        protected IDictionary<Type, int> _numberOfPersons;
        public IDictionary<Type, int> NumberOfPersons
        {
            get { return _numberOfPersons; }
        }

        public MarketFactorySettings(int numberOfSalesmen = 3, int numberOfCustomers = 6)
        {
            _numberOfPersons = new Dictionary<Type, int>();

            _numberOfPersons.Add(typeof(Salesman), numberOfSalesmen);
            _numberOfPersons.Add(typeof(Customer), numberOfCustomers);
        }
    }
}
