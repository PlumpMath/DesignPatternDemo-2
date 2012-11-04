using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Interfaces;
using System.Configuration;

namespace Program.Extensibility
{
    public sealed class AppConfigStorySettings : IStorySettings
    {
        public DateTime Start
        {
            get { return DateTime.Parse(ConfigurationManager.AppSettings["StorySettings_Start"]); }
        }

        public DateTime End
        {
            get { return DateTime.Parse(ConfigurationManager.AppSettings["StorySettings_End"]); }
        }

        public TimeSpan EventInterval
        {
            get { return TimeSpan.Parse(ConfigurationManager.AppSettings["StorySettings_EventInterval"]); }
        }
    }
}
