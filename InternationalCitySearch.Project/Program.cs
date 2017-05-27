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

            //"C://Users//Joe//Source//Repos//ICS//Cities.txt"
            //"H://axa project//InternationalCitySearch//Cities.txt"

            
            GetCitiesClass GetCitiesObject = new GetCitiesClass();
            List<string> CitiesList = GetCitiesObject.GetCitiesMethod("C://Users//Joe//Source//Repos//ICS//Cities.txt");
            SearchClass SearchClassObject = new SearchClass(CitiesList);
            var returnobj = SearchClassObject.Search("BanG");

            List<string> Cities = new List<string>(returnobj.NextCities);
            List<string> Letters = new List<string>(returnobj.NextLetters);

            foreach (var City in Cities)
            {
                Console.WriteLine(City.ToString());
            }
            foreach (var Letter in Letters)
            {
                Console.WriteLine(Letter.ToString());
            }
            
            Console.ReadLine();
            

            /*
            string a = "abcd";
            char[] b = a.ToCharArray();
            string c = new string(b);
            if (a == c)
            {
                Console.WriteLine("Worked");
            }
            else
            {
                Console.WriteLine("Didn't work ," + a + " not equal to " + b.ToString());
            }
            Console.ReadLine();
            */
        }
    }
}
