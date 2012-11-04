using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace.Model
{
    public class City
    {
        private string _name;
        public string Name 
        { 
            get { return _name; }
        }

        private string _postalCode;
        public string PostalCode
        {
            get { return _postalCode; }
        }

        private Country _country;
        public Country Country
        {
            get { return _country; }
        }

        public City(string name, string postalCode, Country country)
        {
            _name = name;
            _postalCode = postalCode;
            _country = country;
        }
    }
}
