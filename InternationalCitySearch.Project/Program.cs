using SearchClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalCitySearch.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Testing GetCitiesMethod, print cities to screen.
            GetCitiesClass GetCitiesClassObject = new GetCitiesClass();
            List<string> CitiesList = new List<string>();
            CitiesList = GetCitiesClassObject.GetCitiesMethod("H://axa project//InternationalCitySearch//Cities.txt");

            foreach (var item in CitiesList)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
            */


            string a = "abcd";
            char[] b = new char[a.Length];
            b = a.ToCharArray();
            Console.WriteLine(b.Take(3).ToArray());
            Console.ReadLine();


        }
    }
}
