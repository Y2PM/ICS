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
            List<string> CitiesList = GetCitiesObject.GetCitiesMethod("C://Users//Joe//Source//Repos//ICS//149893ChineseCityNames.txt");
            SearchClass SearchClassObject = new SearchClass(CitiesList);
            string searchTearm = "";
            string continueQ = "Y";

            while (continueQ.ToUpper()=="Y"|| continueQ.ToUpper() == "YES")
            {
                Console.WriteLine("Please enter search term: ");
                searchTearm = Console.ReadLine();

                var returnobj = SearchClassObject.Search(searchTearm);

                List<string> Cities = new List<string>(returnobj.NextCities);
                List<string> Letters = new List<string>(returnobj.NextLetters);

                Console.WriteLine("Matching cities: ");
                foreach (var City in Cities)
                {
                    Console.WriteLine(City.ToString());
                }

                Console.WriteLine("Possible next characters: ");
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
