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
        public void DeleteTheRow()
        {
            var firstNameFirstRow = _driver.FindElement(By.XPath("//*[@role='gridcell'][contains(text(),'Cierra')]"));
            var lastColumnFirstRow = _driver.FindElement(By.XPath("(//*[@role='row']/div[@class='rt-td'][last()])[1]"));
            ScrollToElement(lastColumnFirstRow);
            var deleteIcon = _driver.FindElement(By.XPath("//*[@id='delete-record-1']"));
            deleteIcon.Click();
            Assert.IsFalse(firstNameFirstRow.Displayed);
        }

        [Test]
        public void SearchForTheRecordThroughSearchBar()
        {

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
    }
}
