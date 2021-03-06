﻿using SearchClassLibrary;
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
            //1049939 Word list.txt

            GetCitiesClass GetCitiesObject = new GetCitiesClass();
            List<string> CitiesList = new List<string>();
            string searchTearm = "";
            string continueQ = "Y";

            try
            {
                CitiesList = GetCitiesObject.GetCitiesMethod("C://Users//Joe//Source//Repos//ICS//1049939 Word list.txt");
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("Ensure correct path to search list is in source code.");
                Console.WriteLine(e);
                Console.ReadLine();
                continueQ = "N";
            }

            SearchClass SearchClassObject = new SearchClass(CitiesList);//Instantiated outside of loop to increase user experience speed.
            while (continueQ.ToUpper() == "Y" || continueQ.ToUpper() == "YES")
            {
                Console.WriteLine("Please enter search term (case sensitive): ");
                searchTearm = Console.ReadLine();
                var returnobj = SearchClassObject.Search(searchTearm);
                List<string> Cities = new List<string>(returnobj.NextCities);
                List<string> Letters = new List<string>(returnobj.NextLetters);

                Console.WriteLine("Found " + Cities.Count + " matching words: ");
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
                if (continueQ.ToUpper() != "Y" && continueQ.ToUpper() != "YES")
                {
                    Console.Write("Thankyou come again.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(1000);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
