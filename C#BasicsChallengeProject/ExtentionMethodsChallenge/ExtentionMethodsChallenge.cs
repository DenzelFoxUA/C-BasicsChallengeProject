using C_BasicsChallengeProject.ForEachChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace C_BasicsChallengeProject.ExtentionMethodsChallenge
{
    public static class ExtentionMethodsChallenge
    {
        public static void Run()
        {
            "Hello world.".Print();
            "Hello. world. Hello. All.".Print();
            "Hello. world. Hello. All.".ChangeSymbol('.','+').Print();
            Person person = new Person("Margareth","Alabama");
            person.Print();
            person.ChangeSymbol('a', 'A').Print();
        }

        public static void Print(this object item)
        {
            Console.WriteLine(Convert(item));

        }

        public static string ChangeSymbol(this object item, char symbolToReplace, char symbolReplaceWith)
        {
            
             return Convert(Convert(item)).Replace(symbolToReplace,symbolReplaceWith);

        }

        private static string Convert(object item)
        {
            string toStringValue = string.Empty;

            if (item is not null)
            {
                toStringValue += item.ToString(); //if object is not string
            }

            return toStringValue;
        }
    }
}
