using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.EventHandling;
using Marketplace.Concepts.Interfaces;

namespace Marketplace.Concepts.ConcreteClasses
{
    public class ConsoleEventListener : StateEventListener
    {
        protected override void EventOccured(StateEventSubscription s, StateEventArgs args)
        {
            Console.WriteLine(String.Format("{0} - {1}", s.Subscriber.GetEventOccured().ToShortTimeString(), args.Message));        
        }
    }
}
