using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SearchClassLibrary;

namespace SpecCheckTests
{
    [TestClass]
    public class PrimaryRequirementsTests
    {
        List<string> CitiesList;
        SearchClass SearchClassObject;

        [TestInitialize]
        public void TestInitialize()
        {
            CitiesList = new List<string> { "BANDUNG", "bandung", "BANGUI", "BANGKOK", "BANGALORE", "LA PAZ", "LA PLATA", "LAGOS", "LEEDS", "ZARIA", "ZHUGHAI ZIBO", "LL-LA" };
            SearchClassObject = new SearchClass(CitiesList);
        }

        [TestMethod]
        public void Test_SearchMethodReturnsRequiredCities_WhenGivenRequiredInput_1()
        {
            //Arrange
            List<string> CitiesListExpectedReturn = new List<string> { "BANGUI", "BANGKOK", "BANGALORE" };

            //Act
            var ReturnObject = SearchClassObject.Search("BANG");
            List<string> Cities = new List<string>(ReturnObject.NextCities);

            //Assert
            CollectionAssert.AreEqual(CitiesListExpectedReturn, Cities);
        }

        [TestMethod]
        public void Test_SearchMethodReturnsRequiredCities_WhenGivenRequiredInput_2()
        {
            //Arrange
            List<string> CitiesListExpectedReturn = new List<string> { "LA PAZ", "LA PLATA", "LAGOS" };

            //Act
            var ReturnObject = SearchClassObject.Search("LA");
            List<string> Cities = new List<string>(ReturnObject.NextCities);

            //Assert
            CollectionAssert.AreEqual(CitiesListExpectedReturn, Cities);
        }

        [TestMethod]
        public void Test_SearchMethodReturnsRequiredCities_WhenGivenRequiredInput_3()
        {
            //Arrange
            List<string> CitiesListExpectedReturn = new List<string> { };

            //Act
            var ReturnObject = SearchClassObject.Search("ZE");
            List<string> Cities = new List<string>(ReturnObject.NextCities);

            //Assert
            CollectionAssert.AreEqual(CitiesListExpectedReturn, Cities);
        }

        [TestMethod]
        public void Test_SearchMethodReturnsRequiredNextCharacters_WhenGivenRequiredInput_1()
        {
            //Arrange
            List<string> CharactersListExpectedReturn = new List<string> { "U", "K", "A" };

            //Act
            var ReturnObject = SearchClassObject.Search("BANG");
            List<string> Letters = new List<string>(ReturnObject.NextLetters);

            //Assert
            CollectionAssert.AreEqual(CharactersListExpectedReturn, Letters);
        }

        [TestMethod]
        public void Test_SearchMethodReturnsRequiredNextCharacters_WhenGivenRequiredInput_2()
        {
            //Arrange
            List<string> CharactersListExpectedReturn = new List<string> { " ", "G" };

            //Act
            var ReturnObject = SearchClassObject.Search("LA");
            List<string> Letters = new List<string>(ReturnObject.NextLetters);

            //Assert
            CollectionAssert.AreEqual(CharactersListExpectedReturn, Letters);
        }

        [TestMethod]
        public void Test_SearchMethodReturnsRequiredNextCharacters_WhenGivenRequiredInput_3()
        {
            //Arrange
            List<string> CharactersListExpectedReturn = new List<string> { };

            //Act
            var ReturnObject = SearchClassObject.Search("ZE");
            List<string> Letters = new List<string>(ReturnObject.NextLetters);

            //Assert
            CollectionAssert.AreEqual(CharactersListExpectedReturn, Letters);
        }

        [TestMethod]
        public void Test_SearchMethodReturnsRequiredNextCharacters_WhenGivenRequiredInput_4()
        {
            //Arrange
            List<string> CharactersListExpectedReturn = new List<string> { "-" };

            //Act
            var ReturnObject = SearchClassObject.Search("LL");
            List<string> Letters = new List<string>(ReturnObject.NextLetters);

            //Assert
            CollectionAssert.AreEqual(CharactersListExpectedReturn, Letters);
        }

        [TestMethod]
        public void Test_SearchMethodWorks_WhenGivenOver1MillionRecords()
        {
            //Arrange
            List<string> CitiesList1M = new List<string> { "BANDUNG", "bandung", "BANGUI", "BANGKOK", "BANGALORE", "LA PAZ", "LA PLATA", "LAGOS", "LEEDS", "ZARIA", "ZHUGHAI ZIBO", "LL-LA" };
            for (int i = 0; i < 1e6; i++)
            {
                CitiesList1M.Add(i.ToString());
            }
            List<string> CharactersListExpectedReturn = new List<string> { "-" };
            SearchClass SearchClassObject = new SearchClass(CitiesList1M);

            //Act
            var ReturnObject = SearchClassObject.Search("LL");
            List<string> Letters = new List<string>(ReturnObject.NextLetters);

            //Assert
            CollectionAssert.AreEqual(CharactersListExpectedReturn, Letters);
        }
    }
}
