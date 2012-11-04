using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace.Model
{
    public class Address
    {
        private string _streetName;
        public string StreetName
        {
            get { return _streetName; }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
        }

        private string _box;
        public string Box
        {
            get { return _box; }
        }

        private City _city;
        public City City
        {
            get { return _city; }
        }

        public Address(string streetName, City city)
            : this(streetName, city, null, null)
        {
        }

        public Address(string streetName, City city, string number, string box)
        {
            // Argument constraints
            if (String.IsNullOrEmpty(streetName))
                throw new ArgumentException("Address must contain a street name", "streetName");
            if (city == null)
                throw new ArgumentException("Address must contain a city", "city");

            _streetName = streetName;
            _city = city;
            _number = number;
            _box = box;
        }

        public override string ToString()
        {
            if (_number == null)
            {
                return String.Format("{0}, {2} ({3})", _streetName, _number, _city.Name, _city.Country.Name);
            }
            else if (_box == null)
            {
                return String.Format("{0} {1}, {2} ({3})", _streetName, _number, _city.Name, _city.Country.Name);
            }
            else
            {
                return String.Format("{0} {1}-{2}, {3} ({4})", _streetName, _number, _box, _city.Name, _city.Country.Name);
            }
        }
    }
}
