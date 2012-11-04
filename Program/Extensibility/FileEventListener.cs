using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Interfaces;
using System.IO;
using Marketplace.Concepts.EventHandling;

namespace Program.Extensibility
{
    public sealed class FileEventListener : StateEventListener
    {
        private string _filePath;

        public FileEventListener(string filePath)
        {
            _filePath = filePath;
        }

        protected override void EventOccured(StateEventSubscription s, StateEventArgs args)
        {
            File.AppendAllText(_filePath, String.Format("{0} - {1}",
                s.Subscriber.GetEventOccured().ToShortTimeString(), args.Message) + Environment.NewLine);
        }
    }
}
