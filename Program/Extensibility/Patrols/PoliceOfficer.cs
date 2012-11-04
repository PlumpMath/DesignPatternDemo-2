using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Inheritance;
using Marketplace.Model;

namespace Program.Extensibility.Patrols
{
    public class PoliceOfficer : Person
    {
        public PoliceOfficer(string name, Gender gender)
            :base(name, gender)
        {
        }

        public override void Act()
        {
            if (!_arrived)
            {
                _arrived = true;
                OnChanged(String.Format("Policeman {0} starts patrolling", _name));
            }
            else
            {
                Speak("The law is good!");
            }
        }

        public override void Greeted(Person greeter)
        {
            if (greeter == null)
                throw new ArgumentNullException("greeter");
            Speak(String.Format("Hi {0}, please oblige the law!", greeter.Name));
        }
    }
}
