using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Extensions;
using Marketplace.Model;

namespace Marketplace.Concepts.Inheritance
{
    public class Customer : Person
    {
        private IList<string> _wishList;
        private IList<string> _purchases;
        private bool _doneShopping;

        public IList<string> Purchases
        {
            get { return new List<string>(_purchases); } // Expose purchases for decoration, prevent modification
        }

        public Customer(string name, Gender gender, IList<string> wishList)
            :base(name, gender)
        {
            if (wishList == null)
                throw new ArgumentNullException("wishList");

            _wishList = wishList;
            _purchases = new List<string>();
            _doneShopping = false;
        }

        public override void Act()
        {
            if (_arrived)
            {
                if (_wishList.Count() > 0)
                {
                    var nextItemOnList = _wishList.First();
                    Buy(nextItemOnList);
                }
                else if (!_doneShopping)
                {
                    _doneShopping = true;
                    Do("is done shopping");
                }
                else
                {
                    // Do nothing (already finished shopping)
                }
            }
            else if (_wishList.Count() > 0)
            {
                _arrived = true;
                Do(String.Format("arrives and looks for items on {0} wishlist", _gender == Gender.Male ? "his" : "her"));
            }
            else
            {
                // Do nothing (Not at market, no items at wishlist)
            }
        }

        public virtual void Buy(string item)
        {
            if (_wishList.Contains(item))
            {
                _wishList.Remove(item);
            }
            _purchases.Add(item);
            Do(String.Format("buys {0}", item));
        }
    }
}
