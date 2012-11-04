using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.EventHandling;
using Marketplace.Concepts.Inheritance;
using Marketplace.Concepts.Interfaces;
using Marketplace.Concepts.Polymorphism;

namespace Program.Extensibility
{
    public abstract class MarketStoryDecorator : MarketStory
    {
        protected MarketStory _decoratedStory;

        public MarketStoryDecorator(MarketStory decoratedStory)
        {
            _decoratedStory = decoratedStory;
        }

        public override void Play(IStorySettings settings)
        {
            base.Play(settings);
            _decoratedStory.Play(settings); // delegation
        }

        #region IStateEventSubscriber

        public override DateTime GetEventOccured()
        {
            return _decoratedStory.GetEventOccured(); // delegation
        }

        public override void AddListener(StateEventListener listener)
        {
            base.AddListener(listener);
            _decoratedStory.AddListener(listener); // delegation
        }

        #endregion
    }
}
