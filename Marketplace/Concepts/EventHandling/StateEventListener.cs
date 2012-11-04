using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Interfaces;
using Marketplace.Concepts.ConcreteClasses;

namespace Marketplace.Concepts.EventHandling
{
    public abstract class StateEventListener
    {
        protected IList<StateEventSubscription> _subscriptions;

        public static StateEventListener DefaultEventListener
        {
            get { return new ConsoleEventListener(); }
        }

        public StateEventListener()
        {
            _subscriptions = new List<StateEventSubscription>();
        }

        public virtual void Subscribe(IStateEventSubscriber subscriber, IStateEventNotifier notifier) // Template method pattern
        {
            if (subscriber == null)
                throw new ArgumentNullException("subscriber");
            if (notifier == null)
                throw new ArgumentNullException("notifier");
            if (_subscriptions.Count(s => s.Notifier == notifier) > 0)
                throw new ArgumentException("Notifier has already been subscribed", "notifier");

            _subscriptions.Add(new StateEventSubscription(subscriber, notifier));
            notifier.Changed += new StateEventHandler(NotifierChanged);
        }

        protected virtual void NotifierChanged(object sender, StateEventArgs args) // Template method pattern
        {
            if (args != null && !String.IsNullOrEmpty(args.Message))
            {
                // Locate subscription
                var subscription = _subscriptions.FirstOrDefault(s => s.Notifier == (IStateEventNotifier)sender);
                if (subscription != null)
                {
                    EventOccured(subscription, args);
                }
            }    
        }

        protected abstract void EventOccured(StateEventSubscription s, StateEventArgs args);
    }
}
