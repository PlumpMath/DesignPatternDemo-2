using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.ConcreteClasses;
using Marketplace.Concepts.Interfaces;
using Marketplace.Extensions;
using Marketplace.Model;

namespace Marketplace.Concepts.Inheritance
{
    public class RandomMarketFactory : MarketFactory
    {
        public RandomMarketFactory()
            : base(new FakeDataRepository(), new MarketFactorySettings()) // Poor man's IoC
        {
        }

        public RandomMarketFactory(IMarketDataRepository marketDataRepo, IMarketFactorySettings settings)
            : base(marketDataRepo, settings)
        {
        }

        public override Market CreateMarket()
        {
            // Retrieve a random market place
            var market = _marketDataRepo.GetMarkets().GetRandom<Market>();

            // Retrieve some random people
            var people = new List<Person>();
            foreach (var personSetting in _settings.NumberOfPersons)
            {
                var persons = _marketDataRepo.GetPeople()
                    .Where(p => p.GetType() == personSetting.Key)
                    .Randomize<Person>()
                    .Take(personSetting.Value);
                people = people.Concat(persons).ToList();
            }
            market.People = people;

            return market;
        }
    }
}
