using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace.Concepts.EventHandling
{
    public delegate void StateEventHandler(object sender, StateEventArgs args);

    public class StateEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
