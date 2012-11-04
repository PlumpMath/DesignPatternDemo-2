using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Inheritance;
using Marketplace.Concepts.Interfaces;
using Marketplace.Extensions;
using Marketplace.Model;

namespace Marketplace.Concepts.ConcreteClasses
{
    public class FakeDataRepository : IMarketDataRepository
    {
        public virtual IEnumerable<Person> GetPeople()
        {
            return
                GetSalesmen().AsEnumerable<Person>().Concat(
                GetCustomers().AsEnumerable<Person>());
        }

        public virtual IEnumerable<Market> GetMarkets()
        {
            var belgium = new Country("Belgium", "BE");
            var antwerp = new City("Antwerp", "2000", belgium);

            yield return new Market(new Address("Groenplaats", antwerp));
            yield return new Market(new Address("Sint-Jansplein", antwerp));
        }

        public virtual IEnumerable<Stall> GetStalls()
        {
            yield return new Stall("Fresh Vegetables");
            yield return new Stall("Delicious Fish");
            yield return new Stall("Kentucky Fried Chicken");
            yield return new Stall("Fancy Clothes");
            yield return new Stall("Bling Bling Accessories");
        }

        protected virtual IEnumerable<Salesman> GetSalesmen()
        {
            yield return new Salesman("Dirk", Gender.Male, GetRandomStall());
            yield return new Salesman("Sven", Gender.Male, GetRandomStall());
            yield return new Salesman("An", Gender.Female, GetRandomStall());
            yield return new Salesman("Mark", Gender.Male, GetRandomStall());
            yield return new Salesman("Helen", Gender.Female, GetRandomStall());
            yield return new Salesman("Steve", Gender.Male, GetRandomStall());
            yield return new Salesman("Nele", Gender.Female, GetRandomStall());
            yield return new Salesman("Joke", Gender.Female, GetRandomStall());
            yield return new Salesman("Gert", Gender.Male, GetRandomStall());
        }

        protected virtual IEnumerable<Customer> GetCustomers()
        {
            yield return new Customer("Pascal", Gender.Female, GetRandomWishlist(1));
            yield return new Customer("Eric", Gender.Male, GetRandomWishlist(2));
            yield return new Customer("Rene", Gender.Male, GetRandomWishlist(3));
            yield return new Customer("Dave", Gender.Male, GetRandomWishlist(1));
            yield return new Customer("Inge", Gender.Female, GetRandomWishlist(2));
            yield return new Customer("Roel", Gender.Male, GetRandomWishlist(3));
            yield return new Customer("Els", Gender.Female, GetRandomWishlist(1));
            yield return new Customer("Anja", Gender.Female, GetRandomWishlist(2));
            yield return new Customer("Bart", Gender.Male, GetRandomWishlist(3));
        }

        protected virtual IEnumerable<string> GetWishlistItems()
        {
            yield return "Apples";
            yield return "Fishsticks";
            yield return "Chicken dips";
            yield return "Earring";
            yield return "New shoes";
        }

        protected virtual Stall GetRandomStall()
        {
            return GetStalls().GetRandom<Stall>();
        }

        protected virtual IList<string> GetRandomWishlist(int amount)
        {
            return GetWishlistItems().Randomize().Take(amount).ToList();
        }
    }
}
