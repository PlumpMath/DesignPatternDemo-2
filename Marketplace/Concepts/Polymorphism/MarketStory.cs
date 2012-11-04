using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.ConcreteClasses;
using Marketplace.Concepts.EventHandling;
using Marketplace.Concepts.Inheritance;
using Marketplace.Concepts.Interfaces;
using Marketplace.Extensions;
using Marketplace.Model;

namespace Marketplace.Concepts.Polymorphism
{
    public class MarketStory : Story
    {
        protected IMarketFactory _marketFactory;
        protected Market _market;

        public Market Market
        {
            get { return _market; } // Expose for decoration
        }

        public MarketStory():
            this(new RandomMarketFactory()) // Poor man's IoC
        {
        }

        public MarketStory(IMarketFactory marketFactory) // Strategy pattern
        {
            _marketFactory = marketFactory;
        }

        protected override void Initialize()
        {
            base.Initialize();
            _market = _marketFactory.CreateMarket(); // Factory pattern
        }

        protected override void AttachListeners()
        {
            base.AttachListeners();
            foreach (var listener in _eventListeners)
            {
                listener.Subscribe(this, _market); // Polymorphism
                foreach (var p in _market.People)
                {
                    listener.Subscribe(this, p); // Polymorphism
                }
            }
        }

        protected override void Run()
        {
            _market.Open();

            _cur = _settings.Start.Add(_settings.EventInterval);
            while (_cur < _settings.End)
            {
                RunStoryLine();
                _cur = _cur.Add(_settings.EventInterval);
            }

            _market.Close();
        }

        protected virtual void RunStoryLine()
        {
            _market.People.GetRandom<Person>().Act(); // Polymorphism
        }
    }
}
