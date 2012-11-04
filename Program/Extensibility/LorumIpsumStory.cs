using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Interfaces;
using Marketplace.Concepts.Inheritance;
using Marketplace.Concepts.EventHandling;
using Marketplace.Extensions;

namespace Program.Extensibility
{
    public class LorumIpsumStory : Story
    {
        protected override void RunStoryLine()
        {
            OnChanged(LorumIpsum().GetRandom());
        }

        protected IEnumerable<string> LorumIpsum()
        {
            yield return "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            yield return "Suspendisse congue metus metus, sit amet vestibulum erat.";
            yield return "Sed venenatis enim non enim ultricies sed aliquet leo porta.";
            yield return "Vivamus pulvinar ante eu nisl tristique tempor.";
            yield return "Donec cursus nisi ac justo aliquet egestas.";
        }
    }
}
