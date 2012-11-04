using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Polymorphism;
using Marketplace.Concepts.Interfaces;

namespace Program.Extensibility
{
    public sealed class MarketStoryWithExtendedReport : MarketStoryDecorator
    {
        public MarketStoryWithExtendedReport(MarketStory story)
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
            OnChanged(String.Format("Sales report: {0} items have been purchased", purchases.Count));
            foreach (var item in purchases.GroupBy(p => p))
            {
                OnChanged(String.Format("\t{0} x {1}", purchases.Count(p => p == item.Key), item.Key));
            }

            var people = _decoratedStory.Market.People.Where(p => p.Arrived);
            OnChanged(String.Format("Visitors report: {0} people attended the market", people.Count()));
            foreach (var item in people.GroupBy(p => p.GetType()))
            {
                OnChanged(String.Format("\t{0} x {1}", people.Count(p => p.GetType() == item.Key), item.Key.Name));
            }
        }
    }
}
