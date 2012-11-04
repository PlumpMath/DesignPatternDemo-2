using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Inheritance;
using Marketplace.Model;

namespace Marketplace.Concepts.Interfaces
{
    public interface IMarketDataRepository
    {
        IEnumerable<Person> GetPeople();
        IEnumerable<Market> GetMarkets();
        IEnumerable<Stall> GetStalls();
    }
}
