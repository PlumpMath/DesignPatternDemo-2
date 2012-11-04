using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Inheritance;
using Marketplace.Concepts.EventHandling;
using Marketplace.Concepts.Interfaces;

namespace Marketplace.Model
{
    public class Market : IStateEventNotifier
    {
        #region Properties

        private Address _location;
        public Address Location
        {
            get { return _location; }
        }

        private MarketState _state;
        public MarketState State
        {
            get { return _state; }
        }

        private IList<Person> _people;
        public IList<Person> People
        {
            get { return _people; }
            set { _people = value; }
        }

        #endregion

        #region IStateNotifier

        public event StateEventHandler Changed;

        protected virtual void OnChanged(string message)
        {
            StateEventHandler handler = Changed;
            if (handler != null)
            {
                var args = new StateEventArgs() { Message = message };
                handler(this, args);
            }
        }

        #endregion

        public Market(Address location)
        {
            if (location == null)
                throw new ArgumentException("location");

            _location = location;
        }

        public void Open()
        {
            _state = MarketState.Open;
            OnChanged(String.Format("Market starts at {0}", _location));
        }

        public void Close()
        {
            // Ask salesmen to close their stall
            foreach (Person person in _people)
            {
                if (person is Salesman && person.Arrived)
                {
                    ((Salesman)person).CloseStall();
                }
            }
            _state = MarketState.Closed;
            OnChanged(String.Format("Market at {0} has ended", _location));
        }

        public IList<string> GetPurchases()
        {
            var purchases = new List<string>();

            // Ask customers for their purchases
            foreach (Person person in _people)
            {
                if (person is Customer)
                {
                    purchases.AddRange(((Customer)person).Purchases);
                }
            }

            return purchases;
        }
    }
}
