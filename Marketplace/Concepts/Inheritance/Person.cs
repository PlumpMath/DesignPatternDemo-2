using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Model;
using Marketplace.Concepts.EventHandling;
using Marketplace.Concepts.Interfaces;

namespace Marketplace.Concepts.Inheritance
{
    public abstract class Person : IStateEventNotifier, IGreeter
    {
        #region Properties

        protected string _name;
        public string Name
        {
            get { return _name; }
        }

        protected Gender _gender;
        public Gender Gender
        {
            get { return _gender; }
        }

        protected bool _arrived;
        public bool Arrived
        {
            get { return _arrived; }
        }

        protected Address _homeAddress;
        public Address HomeAddress
        {
            get { return _homeAddress; }
            set { _homeAddress = value; }
        }

        #endregion

        #region IStateEventNotifier

        public event StateEventHandler Changed;

        protected virtual void OnChanged(string message)
        {
            StateEventHandler handler = Changed;
            if (handler != null)
            {
                var args = new StateEventArgs() { Message = message };
                handler(this, args);
            }
        }

        #endregion

        #region IGreeter

        public virtual void Greet(Person other)
        {
            if (other == null)
                throw new ArgumentNullException("other");

            if (other == this)
            {
                // Hey, I'm not greeting myself!
                return;
            }
            Speak(String.Format("Hello {0}", other.Name));
            other.Greeted(this);
        }

        public virtual void Greeted(Person greeter)
        {
            if (greeter == null)
                throw new ArgumentNullException("greeter");
            Speak(String.Format("Hi {0}, lovely day isn't it?", greeter.Name));
        }

        #endregion

        public Person(string name, Gender gender)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Person must have a name", "name");

            _name = name;
            _gender = gender;
            _arrived = false;
        }

        protected virtual void Speak(string message)
        {
            OnChanged(String.Format("{0} says '{1}'", this._name, message));
        }

        protected virtual void Yell(string message)
        {
            OnChanged(String.Format("{0} yells '{1}'", this._name, message));
        }

        protected virtual void Do(string act)
        {
            OnChanged(String.Format("{0} {1}", this._name, act));
        }

        public abstract void Act();
    }
}
