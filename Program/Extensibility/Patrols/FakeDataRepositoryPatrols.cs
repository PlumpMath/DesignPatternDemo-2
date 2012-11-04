using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.ConcreteClasses;
using Marketplace.Concepts.Inheritance;
using Marketplace.Model;

namespace Program.Extensibility.Patrols
{
    public class FakeDataRepositoryPatrols : FakeDataRepository
    {
        public override IEnumerable<Person> GetPeople()
        {
            return base.GetPeople().Concat(GetPoliceOfficers());
        }

        protected virtual IEnumerable<PoliceOfficer> GetPoliceOfficers()
        {
            yield return new PoliceOfficer("John", Gender.Male);
            yield return new PoliceOfficer("Naomi", Gender.Female);
        }
    }
}
