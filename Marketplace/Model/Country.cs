using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace.Model
{
    public class Country
    {
        private string _name;
        public string Name
        {
            get { return _name; }
        }

        private string _iso2code;
        public string Iso2Code
        {
            get { return _iso2code; }
        }

        public Country(string name, string iso2code)
        {
            _name = name;
            _iso2code = iso2code;
        }
    }
}
