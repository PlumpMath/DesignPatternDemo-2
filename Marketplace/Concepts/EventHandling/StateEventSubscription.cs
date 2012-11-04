using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Interfaces;

namespace Marketplace.Concepts.EventHandling
{
    public class StateEventSubscription
    {
        private IStateEventSubscriber _subscriber;
        public IStateEventSubscriber Subscriber
        {
            get { return _subscriber; }
        }

        private IStateEventNotifier _notifier;
        public IStateEventNotifier Notifier
        {
            get { return _notifier; }
        }

        public StateEventSubscription(IStateEventSubscriber subscriber, IStateEventNotifier notifier)
        {
            _subscriber = subscriber;
            _notifier = notifier;
        }
    }
}
