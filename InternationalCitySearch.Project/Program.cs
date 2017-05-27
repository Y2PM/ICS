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
            //"C://Users//Joe//Source//Repos//ICS//Cities.txt"
            //"H://axa project//InternationalCitySearch//Cities.txt"
            //149893ChineseCityNames.txt
            //Cities.txt

            GetCitiesClass GetCitiesObject = new GetCitiesClass();
            List<string> CitiesList = GetCitiesObject.GetCitiesMethod("C://Users//Joe//Source//Repos//ICS//ChineseCityNames.txt");
            SearchClass SearchClassObject = new SearchClass(CitiesList);
            var returnobj = SearchClassObject.Search("la");

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
        }
    }
}
