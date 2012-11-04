using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.ConcreteClasses;
using Program.Extensibility;
using System.Configuration;

namespace Program.Extensibility.Patrols
{
    public class MarketFactorySettingsPatrols : AppConfigMarketFactorySettings
    {
        protected override void ReadConfig()
        {
            base.ReadConfig();

            _numberOfPersons.Add(typeof(PoliceOfficer),
                Convert.ToInt32(ConfigurationManager.AppSettings["MarketGenerator_NumberOfPoliceOfficers"]));
        }
    }
}
