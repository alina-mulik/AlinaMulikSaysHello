using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Data.Constants;
using Homework13.PageObjects.DemoQA;
using NUnit.Framework;

namespace Homework13.Tests.DemoQA.Elements
{
    public class WebTablesTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQaElementsUrl);
            GenericPages.BaseDemoQaPage.ClickOnElementsSubCategory(ElementsCategories.WebTables);
        }

        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.Driver.Navigate().Refresh();
        }

        [Test]
        public void DeleteTheFirstRowTest()
        {
            var deletedEntryFirstName = GenericPages.WebTablesPage.GetFirstNameValueOfEntryByIndex(1);

            // Delete First row
            GenericPages.WebTablesPage.DeleteRowByRowIndex(1);

            // Get all First names after deletion of the first row
            var listOfFirstNames = GenericPages.WebTablesPage.GetListOfFirstNames();

            // Check that deleted First Name is not there and check the count
            Assert.IsFalse(listOfFirstNames.Contains(deletedEntryFirstName));
            Assert.AreEqual(2, listOfFirstNames.Count);
        }

        [Test]
        public void SearchForTheRecordThroughSearchBarTest()
        {
            var firstNameValueForSearch = "Alden";

            // Search for the entry by First Name
            GenericPages.WebTablesPage.SearchEntryUsingSearchBar(firstNameValueForSearch);

            // Get Search result and check the count and that the selected first name is there
            var searchResult = GenericPages.WebTablesPage.GetListOfFirstNames();
            Assert.AreEqual(1, searchResult.Count());
            Assert.AreEqual(firstNameValueForSearch, searchResult[0]);
        }
    }
}
