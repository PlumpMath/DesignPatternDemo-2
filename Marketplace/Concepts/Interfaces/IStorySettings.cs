using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace.Concepts.Interfaces
{
    public interface IStorySettings
    {
        DateTime Start { get; }
        DateTime End { get; }
        TimeSpan EventInterval { get; }
    }
}
