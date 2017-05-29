using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchClassLibrary
{
    public class SearchClass : ICityFinder
    {
        List<string> CitiesList = new List<string>();
        int searchStringLength = 0;
        string longest = "";
        //int WordCount = 0;

        public SearchClass(List<string> CitiesList_)
        {
            CitiesList = CitiesList_;

            //Get longest string to work out max length of city name
            foreach (string s in CitiesList)
            {
                //WordCount++;
                if (s.Length > longest.Length)
                {
                    longest = s;
                }
            }
        }

        public ICityResult Search(string searchString)
        {
            ReturnClass ReturnObject = new ReturnClass();
            searchStringLength = searchString.Length;
            int maxlength = longest.Length;
            Char[] chararray = new Char[maxlength];//Instantiate the char[] here instead of for each city in the loop, that is more efficient.
            List<string> ListcitiesResults = new List<string>();
            List<string> ListlettersResults = new List<string>();

            foreach (var City in CitiesList)
            {
                chararray = City.ToCharArray();
                string arrayToStringToCommpare = new string(chararray.Take(searchStringLength).ToArray());
                //           charicter match check
                if (arrayToStringToCommpare == searchString)//Case sensitive (use .ToUpper() here to remove case sensitivity)
                {
                    if (ListcitiesResults.Contains(City) != true)//avoiding duplicate cities
                    {
                        ListcitiesResults.Add(City);
                    }
                    if (chararray.Length > searchString.Length)//Is there a next character check
                    {
                        string NextChar = City.Substring(searchStringLength, 1);//(use .ToUpper() here to remove case sensitivity)
                        if ((ListlettersResults.Contains(NextChar)) != true)//avoiding duplicate characters, case sensitive
                        {
                            ListlettersResults.Add(NextChar);
                        }
                    }
                }
            }
            ReturnObject.NextCities = ListcitiesResults;
            ReturnObject.NextLetters = ListlettersResults;
            return ReturnObject;
        }
    }
}
