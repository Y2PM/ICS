using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClassLibrary
{
    public class GetCitiesClass
    {
        public List<string> GetCitiesMethod(string Path)
        {
            StreamReader sr = new StreamReader(Path);
            List<string> CitiesList = new List<string>();

            String line = "";
            while ((line = sr.ReadLine()) != null)
            {
                CitiesList.Add(line);
            }

            return CitiesList;
        }
    }
}
