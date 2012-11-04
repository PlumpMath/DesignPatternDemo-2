using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace.Model
{
    public class Stall
    {
        private string _type;
        public string Type
        {
            get { return _type; }
        }

        private StallState _state;

        public bool IsOpen
        {
            get { return _state == StallState.Open; }
        }

        public Stall(string type)
        {
            // Argument constraints
            if (String.IsNullOrEmpty(type))
                throw new ArgumentException("A stall must have a type", "type");

            _type = type;
            _state = StallState.Closed;
        }

        public void Open()
        {
            _state = StallState.Open;
        }

        public void Close()
        {
            _state = StallState.Closed;
        }
    }
}
