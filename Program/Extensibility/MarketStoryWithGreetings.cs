using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Polymorphism;
using Marketplace.Extensions;
using Marketplace.Model;
using Marketplace.Concepts.Inheritance;
using Marketplace.Concepts.Interfaces;

namespace Program.Extensibility
{
    public sealed class MarketStoryWithGreetings : MarketStory
    {
        private int _loopCount;

        public MarketStoryWithGreetings() : base()
        {
        }

        public MarketStoryWithGreetings(IMarketFactory marketFactory):
            base(marketFactory)
        {
        }

        public override void Play(IStorySettings settings)
        {
            _loopCount = 0;
            base.Play(settings);
        }

        protected override void RunStoryLine() // Template method pattern
        {
            base.RunStoryLine();

            if (_loopCount % 4 == 0 && _market.People.Where(p => p.Arrived).Count() >= 2)
            {
                var greeter = _market.People.GetRandom<Person>();
                var greetee = _market.People.Where(p => p.Arrived && p.Name != greeter.Name).GetRandom<Person>();

                if (greetee != null)
                {
                    greeter.Greet(greetee);
                }
            }
            _loopCount++;
        }
    }
}
