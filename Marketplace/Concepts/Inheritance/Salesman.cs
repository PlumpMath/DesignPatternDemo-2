using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Extensions;
using Marketplace.Model;

namespace Marketplace.Concepts.Inheritance
{
    public class Salesman : Person
    {
        private Stall _stall;

        public Salesman(string name, Gender gender, Stall stall)
            :base(name, gender)
        {
            if (stall == null)
                throw new ArgumentNullException("stall");

            _stall = stall;
        }

        public override void Act()
        {
            if (!_stall.IsOpen)
            {
                OpenStall();
            }
            else
            {
                Yell(String.Format("{0}!", _stall.Type));
            }
        }

        public void OpenStall()
        {
            _arrived = true;
            _stall.Open();
            Do(String.Format("arrives and starts selling {0}", _stall.Type));
        }

        public void CloseStall()
        {
            _stall.Close();
            Do(String.Format("closes {0} stall and leaves", _gender == Gender.Male ? "his" : "her"));
        }

        public override void Greet(Person other)
        {
            if (other == null)
                throw new ArgumentNullException("other");

            if (other.Name == _name)
            {
                // Do nothing (I'm not greeting myself)
                return;
            }
            Speak(String.Format("Hello {0}, care for some {1}?", other.Name, _stall.Type));
        }
    }
}
