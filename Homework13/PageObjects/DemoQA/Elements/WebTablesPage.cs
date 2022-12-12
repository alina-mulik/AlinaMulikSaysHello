using Homework13.Common.WebElements;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Homework13.PageObjects.DemoQA.Elements
{
    public class WebTablesPage
    {
        private string _firstNameOfTheEntry = "(//*[@role=\"columnheader\"]/following::div" +
            "[@class='rt-tr -even' or @class='rt-tr -odd']/div[@role='gridcell'][1])[{0}]";
        private DemoQaWebElement _searchBar = new(By.XPath("//*[@id='searchBox']"));
        private DemoQaWebElement _lensIconButton = new(By.XPath("//*[@id='basic-addon2']"));
        private static DemoQaWebElement _firstNameColumnHeader = new(By.XPath("//div[@role='columnheader' and .//text() ='First Name']"));
        private ReadOnlyCollection<IWebElement> _allFirstNameCellsValues = _firstNameColumnHeader.FindElements(By.XPath("//*[@role=\"columnheader\"]/following::div" +
            "[@class='rt-tr -even' or @class='rt-tr -odd']/div[@role='gridcell'][1]"));

        public string GetFirstNameValueOfEntryByIndex(int entryIndex) => new DemoQaWebElement(By.XPath(string.Format(_firstNameOfTheEntry, entryIndex))).Text;

        public void DeleteRowByRowIndex(int rowIndex)
        {
            var deleteButton = new DemoQaWebElement(By.XPath($"((//*[@role='columnheader']" +
                $"/following::div[@class='rt-tr -even' or @class='rt-tr -odd']/div[@role='gridcell'][last()])//span[@title='Delete'])[{rowIndex}]"));
            deleteButton.Click();
        }

        public List<string> GetListOfFirstNames()
        {
            var listOfFirstNameValues = new List<string>();
            foreach (var element in _allFirstNameCellsValues)
            {
                listOfFirstNameValues.Add(element.Text);
            }

            return listOfFirstNameValues;
        }

        public void SearchEntryUsingSearchBar(string value)
        {
            _searchBar.SendKeys(value);
            _lensIconButton.Click();
        }
    }
}
