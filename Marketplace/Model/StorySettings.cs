using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Interfaces;
using System.Configuration;

namespace Marketplace.Model
{
    public class StorySettings : IStorySettings
    {
        private DateTime _start;
        public DateTime Start
        {
            get { return _start; }
        }

        private DateTime _end;
        public DateTime End
        {
            get { return _end; }
        }

        private TimeSpan _eventInterval;
        public TimeSpan EventInterval
        {
            get { return _eventInterval; }
        }

        public static StorySettings FromConfiguration() // Factory method pattern
        {
            return new StorySettings(
                DateTime.Parse(ConfigurationManager.AppSettings["StorySettings_Start"]),
                DateTime.Parse(ConfigurationManager.AppSettings["StorySettings_End"]),
                TimeSpan.Parse(ConfigurationManager.AppSettings["StorySettings_EventInterval"])
            );
        }

        public StorySettings(DateTime start, DateTime end, TimeSpan eventInterval)
        {
            // Argument constraints
            if (start >= end)
                throw new ArgumentException("Storyboard must end after its start date/time", "end");

            _start = start;
            _end = end;
            _eventInterval = eventInterval;
        }
    }
}
