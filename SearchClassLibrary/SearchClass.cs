using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClassLibrary
{
    public interface ICityResult
    {
        ICollection<string> NextLetters { get; set; }

        ICollection<string> NextCities { get; set; }
    }

    public interface ICityFinder
    {
        ICityResult Search(string searchString);
    }

    class ReturnClass : ICityResult
    {
        public ICollection<string> NextLetters { get; set; }
        //public ICollection<string> NextLetters
        //{
        //    get { return NextLetters; }
        //    set { NextLetters = value; }
        //}
        public ICollection<string> NextCities { get; set; }
        //public ICollection<string> NextCities
        //{
        //    get { return NextCities; }
        //    set { NextCities = value; }
        //}

    }

    public class SearchClass : ICityFinder
    {
        List<string> CitiesList = new List<string>();
        //GetCitiesClass GetCitiesObject = new GetCitiesClass();
        int searchStringLength = 0;
        string longest = "";

        //List<string> NextLetters
        //    List<string> NextCities

        public SearchClass(List<string> CitiesList_)
        {
            CitiesList = CitiesList_;
            //"C://Users//Joe//Source//Repos//ICS//Cities.txt"
            //"H://axa project//InternationalCitySearch//Cities.txt"
            //CitiesList = GetCitiesObject.GetCitiesMethod("C://Users//Joe//Source//Repos//ICS//Cities.txt");

            //Get longest string to work out max length
            foreach (string s in CitiesList)
            {
                if (s.Length > longest.Length)
                {
                    longest = s;
                }
            }
        }


        public ICityResult Search(string searchString)//Search method, write the code in here.
        {
            //NextLetters = "d";//If d was a collection here then next letters would become equal to it. Setter runs.
            //MyMethod(NextLetters);//An example of making the getter run.
            ReturnClass ReturnObject = new ReturnClass();
            searchStringLength = searchString.Length;
            int maxlength = longest.Length;
            Char[] chararray = new Char[maxlength];//Instantiate the char[] here instead of for each city in the loop, that is more efficient.
            List<string> ListcitiesResults = new List<string>();
            List<string> ListlettersResults = new List<string>();

            foreach (var City in CitiesList)
            {




                chararray = City.ToCharArray();
                //  char[] a = new char[];// chararray.Take(searchStringLength);
                //string compareCharString = new string(chararray.ToString().Substring(0,searchStringLength));
                //compareCharString = compareCharString.Take<string>(searchStringLength);

                string arrayToStringToCommpare = new string(chararray.Take(searchStringLength).ToArray());

                //           charicter match check                                     array length check
                if ((arrayToStringToCommpare.ToUpper() == searchString.ToUpper() && (chararray.Length >= searchString.Length)))
                {
                    string NextChar = City.Substring(searchStringLength, 1);//index might start at 0? check it*************
                    ListcitiesResults.Add(City);
                    //ReturnObject.NextCities.Add(City);
                    //                                                               avoiding duplicates
                    if ((chararray.Length > searchString.Length) && (ReturnObject.NextLetters.Contains(NextChar)) != true)
                    {
                        ListlettersResults.Add(NextChar);
                        //ReturnObject.NextLetters.Add(NextChar);
                    }
                }


                ReturnObject.NextCities = ListcitiesResults;
                ReturnObject.NextLetters = ListlettersResults;

            }




            return ReturnObject;
        }



    }
}
