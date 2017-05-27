using SearchClassLibrary;
using System;
using System.Collections.Generic;

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
            //1.1million word list.txt

            GetCitiesClass GetCitiesObject = new GetCitiesClass();
            List<string> CitiesList = GetCitiesObject.GetCitiesMethod("C://Users//Joe//Source//Repos//ICS//149893ChineseCityNames.txt");
            SearchClass SearchClassObject = new SearchClass(CitiesList);
            string searchTearm = "";
            string continueQ = "Y";

            while (continueQ.ToUpper() == "Y" || continueQ.ToUpper() == "YES")
            {
                Console.WriteLine("Please enter search term: ");
                searchTearm = Console.ReadLine();
                var returnobj = SearchClassObject.Search(searchTearm);
                List<string> Cities = new List<string>(returnobj.NextCities);
                List<string> Letters = new List<string>(returnobj.NextLetters);

                Console.WriteLine("Found " + Cities.Count + " matching cities: ");
                foreach (var City in Cities)
                {
                    Console.WriteLine(City.ToString());
                }

                Console.WriteLine("Found " + Letters.Count + " possible next characters: ");
                foreach (var Letter in Letters)
                {
                    Console.WriteLine(Letter.ToString());
                }
                Console.WriteLine("Continue searching? Yes or no ");
                continueQ = Console.ReadLine();
            }
        }
    }
}
