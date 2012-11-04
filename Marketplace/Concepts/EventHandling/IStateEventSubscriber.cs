using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace.Concepts.EventHandling
{
    public interface IStateEventSubscriber
    {
        DateTime GetEventOccured();
        void AddListener(StateEventListener listener);
    }
}
