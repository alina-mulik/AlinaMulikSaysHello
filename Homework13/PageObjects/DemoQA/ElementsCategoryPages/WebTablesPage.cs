﻿using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.DemoQA.ElementsCategoryPages
{
    public class WebTablesPage
    {
        private string _firstNameOfTheEntry = "(//div[@class='rt-tr -odd' or @class='rt-tr -even' ])[{0}]/child::*[1]";
        private DemoQaWebElement _searchBar = new(By.XPath("//*[@id='searchBox']"));
        private DemoQaWebElement _lensIconButton = new(By.XPath("//*[@id='basic-addon2']"));

        public string GetFirstNameValueOfEntryByIndex(int entryIndex) => new DemoQaWebElement(By.XPath(string.Format(_firstNameOfTheEntry, entryIndex))).Text;

        public void DeleteRowByRowIndex(int rowIndex)
        {
            var deleteButton = new DemoQaWebElement(By.XPath($"(//div[@class='rt-tr -odd' or @class='rt-tr -even' ])[{rowIndex}]/child::*[7]//span[@title='Delete']"));
            deleteButton.Click();
        }

        public List<string> GetListOfFirstNames()
        {
            var firstNameColumnHeader = new DemoQaWebElement(By.XPath("//div[@role='columnheader' and .//text() ='First Name']"));
            var listOfFirstNameValues = firstNameColumnHeader.FindElements(By.XPath("(//div[@Class='rt-tr -odd' or @Class='rt-tr -even' ])/child::*[1]"))
                .Select(x => x.Text).ToList();

            return listOfFirstNameValues;
        }

        public void SearchEntryUsingSearchBar(string value)
        {
            _searchBar.SendKeys(value);
            _lensIconButton.Click();
        }
    }
}
