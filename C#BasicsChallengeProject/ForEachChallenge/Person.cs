using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicsChallengeProject.ForEachChallenge
{
    internal class Person
    {
        public Person()
        {
            Name = "Default Name";
            LastName = "Default Last Name";
        }

        public Person(string nameValue, string lastNameValue)
        {
            Name = nameValue;
            LastName = lastNameValue;
        }

        public string Name { get; set; }
        public string LastName { get; set; }

        public static bool operator == (Person first, Person second)
        {
            return first.LastName == second.LastName && first.Name == second.Name;
        }

        public static bool operator != (Person first, Person second)
        {
            return !(first == second);
        }

        public override bool Equals(object ?second)
        {
            if(second is not null)
            {
                return Equals((Person)second);
            }
            return false;
        }

        private bool Equals(Person second)
        {
            return this.Name == second.Name && this.LastName == second.LastName;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + LastName.GetHashCode();
        }

        public void Copy(Person copyFrom)
        {
            this.Name = copyFrom.Name;
            this.LastName = copyFrom.LastName;
        }

        public override string ToString()
        {
            return $"{Name}, {LastName}";
        }
    }
}
