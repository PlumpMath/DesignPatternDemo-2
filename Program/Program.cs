using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.ConcreteClasses;
using Marketplace.Concepts.Inheritance;
using Marketplace.Concepts.Interfaces;
using Marketplace.Concepts.Polymorphism;
using Marketplace.Model;
using Program.Extensibility;
using Program.Extensibility.Patrols;
using Data;

namespace Program
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Story story = new MarketStoryWithGreetings();

                IStorySettings settings = new StorySettings(
                    DateTime.Now,
                    DateTime.Now.AddHours(3),
                    TimeSpan.FromMinutes(12)
                );

                story.Play(settings);

                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops:");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
