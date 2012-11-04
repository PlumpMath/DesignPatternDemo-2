using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Inheritance;
using Marketplace.Concepts.Interfaces;
using Marketplace.Model;
using Data;

namespace Program.Extensibility
{
    public class MarketDataSql : IMarketDataRepository
    {
        private SqlDbProvider _provider;

        public MarketDataSql(SqlDbProvider provider)
        {
            _provider = provider;
        }

        public IEnumerable<Person> GetPeople()
        {
            return _provider.ExecuteQuery<Salesman>("select * from people");
        }

        public IEnumerable<Market> GetMarkets()
        {
            return _provider.ExecuteQuery<Market>("select * from markets");
        }

        public IEnumerable<Stall> GetStalls()
        {
            return _provider.ExecuteQuery<Stall>("select * from stalls");
        }
    }
}
