using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicsChallengeProject.ForEachChallenge
{
    public static class ForEachChallenge
    {
        public static void Run()
        {
            List<Person> persons = new List<Person>() 
            { 
                new Person("Denzel", "Washington"),
                new Person("Jim", "Karey"),
                new Person("Samuel", "Jackson")

            };


            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
