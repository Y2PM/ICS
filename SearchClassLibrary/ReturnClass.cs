using System.Collections.Generic;

namespace SearchClassLibrary
{
    class ReturnClass : ICityResult
    {
        public ICollection<string> NextLetters { get; set; }
        public ICollection<string> NextCities { get; set; }
    }
}
