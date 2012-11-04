using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Model;

namespace Marketplace.Concepts.Interfaces
{
    public interface IMarketFactory
    {
        Market CreateMarket();
    }
}
