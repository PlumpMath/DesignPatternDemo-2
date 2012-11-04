using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Interfaces;
using Marketplace.Model;

namespace Marketplace.Concepts.Inheritance
{
    public abstract class MarketFactory : IMarketFactory
    {
        protected IMarketDataRepository _marketDataRepo;
        protected IMarketFactorySettings _settings;

        public MarketFactory(IMarketDataRepository marketDataRepo, IMarketFactorySettings settings) // Constructor dependency injection
        {
            if (marketDataRepo == null)
                throw new ArgumentNullException("marketDataRepo");
            if (settings == null)
                throw new ArgumentNullException("settings");

            _marketDataRepo = marketDataRepo;
            _settings = settings;
        }

        public abstract Market CreateMarket();
    }
}
