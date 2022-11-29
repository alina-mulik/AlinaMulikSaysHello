using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Homework11
{
    public class WebTablesTests
    {
        private IWebDriver _driver;
        private IJavaScriptExecutor _javascriptExecutor;
        private Actions _actions;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _javascriptExecutor = (IJavaScriptExecutor)_driver;
            _driver.Manage().Window.Maximize();
            _actions = new Actions(_driver);
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/elements");
            var textBoxButton = _driver.FindElement(By.Id("item-3"));
            textBoxButton.Click();
        }

        [Test]
        public void DeleteTheFirstRowTest()
        {
            var deletedEntryFirstName = _driver.FindElement(By.XPath("(//*[@role=\"columnheader\"]/following::div" +
                "[@class='rt-tr -even' or @class='rt-tr -odd']/div[@role='gridcell'][1])[1]")).Text;
            DeleteRow(1);
            var firstNameColumnValues = _driver.FindElements(By.XPath("//*[@role=\"columnheader\"]/following::div" +
                "[@class='rt-tr -even' or @class='rt-tr -odd']/div[@role='gridcell'][1]"));
            var listOfFirstNames = new List<string>();
            foreach (var firstNameColumnValue in firstNameColumnValues)
            {
                listOfFirstNames.Add(firstNameColumnValue.Text);
            }
            Assert.IsFalse(listOfFirstNames.Contains(deletedEntryFirstName));
            Assert.AreEqual(2, listOfFirstNames.Count);
        }

        [Test]
        public void SearchForTheRecordThroughSearchBarTest()
        {
            var searchBar = _driver.FindElement(By.XPath("//*[@id='searchBox']"));
            var lensIconButton = _driver.FindElement(By.XPath("//*[@id='basic-addon2']"));
            var firstNameValueForSearch = "Alden";
            searchBar.SendKeys(firstNameValueForSearch);
            lensIconButton.Click();
            var searchResult = _driver.FindElements(By.XPath("//*[@role=\"columnheader\"]/following::div" +
                "[@class='rt-tr -even' or @class='rt-tr -odd']/div[@role='gridcell'][1]"));
            Assert.AreEqual(1, searchResult.Count());
            Assert.AreEqual(firstNameValueForSearch, searchResult[0].Text);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }

        private void ScrollToElement(IWebElement element)
        {
            _javascriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }

        private void DeleteRow(int rowIndex)
        {
            var deleteButton = _driver.FindElement(By.XPath($"((//*[@role='columnheader']" +
                $"/following::div[@class='rt-tr -even' or @class='rt-tr -odd']/div[@role='gridcell'][last()])//span[@title='Delete'])[{rowIndex}]"));
            deleteButton.Click();
        }
    }
}
