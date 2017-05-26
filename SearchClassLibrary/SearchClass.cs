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

    class Return : ICityResult
    {

        public ICollection<string> NextLetters
        {
            get { return NextLetters; }//Used propfull tab tab to generate get and set, probably could have just used prop tab tab instead of implementing the interface.
            set { NextLetters = value; }
        }

        public ICollection<string> NextCities
        {
            get { return NextCities; }
            set { NextCities = value; }
        }

    }

    public class SearchClass : ICityFinder
    {
        List<string> CitiesList = new List<string>();
        GetCitiesClass GetCitiesObject = new GetCitiesClass();
        int searchStringLength = 0;
        string longest = "";

        //List<string> NextLetters
        //    List<string> NextCities

        public SearchClass()
        {
            CitiesList = GetCitiesObject.GetCitiesMethod("H://axa project//InternationalCitySearch//Cities.txt");

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
            Return ReturnObject = new Return();
            searchStringLength = searchString.Length;
            int maxlength = longest.Length;



            foreach (var City in CitiesList)
            {



                Char[] chararray = new Char[maxlength];
                chararray = City.ToCharArray();
                if ((chararray.Take(searchStringLength) == searchString) && (chararray.Length >= searchString.Length))
                {
                    ReturnObject.NextCities.Add(City);
                    if (chararray.Length > searchString.Length)
                    {
                        string NextChar = City.Substring(searchStringLength+1,1);
                        ReturnObject.NextLetters.Add(NextChar);
                    }

                }


                //ReturnObject.NextCities.Add("");
                //ReturnObject.NextLetters.Add("");

            }




            return ReturnObject;
        }



    }
}
