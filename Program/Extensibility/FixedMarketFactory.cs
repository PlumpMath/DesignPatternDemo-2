using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Model;
using Marketplace.Concepts.Inheritance;
using Marketplace.Concepts.ConcreteClasses;
using Marketplace.Concepts.Interfaces;

namespace Program.Extensibility
{
    public sealed class FixedMarketFactory : MarketFactory
    {
        public FixedMarketFactory()
            : base(new FakeDataRepository(), new MarketFactorySettings(1,1)) // Poor man's IoC
        {
        }

        public FixedMarketFactory(IMarketDataRepository marketDataRepo, IMarketFactorySettings settings)
            : base(marketDataRepo, settings)
        {
        }

        public override Market CreateMarket()
        {
            // Retrieve the first market
            var market = _marketDataRepo.GetMarkets().First();

            // Retrieve the first people
            var people = new List<Person>();
            foreach (var personSetting in _settings.NumberOfPersons)
            {
                var persons = _marketDataRepo.GetPeople()
                    .Where(p => p.GetType() == personSetting.Key)
                    .Take(personSetting.Value);
                people = people.Concat(persons).ToList();
            }
            market.People = people;

            return market;
        }
    }
}
