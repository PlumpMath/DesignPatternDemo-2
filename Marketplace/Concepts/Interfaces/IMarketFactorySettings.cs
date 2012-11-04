using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace.Concepts.Interfaces
{
    public interface IMarketFactorySettings
    {
        IDictionary<Type, int> NumberOfPersons { get; }
    }
}
