using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Inheritance;

namespace Marketplace.Concepts.Interfaces
{
    public interface IGreeter
    {
        void Greet(Person other);
        void Greeted(Person other);
    }
}
