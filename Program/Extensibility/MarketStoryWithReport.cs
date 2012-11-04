using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Polymorphism;
using Marketplace.Concepts.Interfaces;

namespace Program.Extensibility
{
    public sealed class MarketStoryWithReport : MarketStoryDecorator
    {
        public MarketStoryWithReport(MarketStory story)
            : base(story)
        {
        }

        public override void Play(IStorySettings settings)
        {
            base.Play(settings);
            GenerateReport();
        }

        protected override void Run()
        {
        }

        private void GenerateReport()
        {
            var purchases = _decoratedStory.Market.GetPurchases();
            OnChanged(String.Format("Visitors report: {0} people attended the market", _decoratedStory.Market.People.Where(p => p.Arrived).Count()));
            OnChanged(String.Format("Sales report: {0} items have been purchased", purchases.Count));
        }
    }
}
