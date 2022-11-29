using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Homework11
{
    public class LinksTests
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
            var textBoxButton = _driver.FindElement(By.Id("item-5"));
            ScrollToElement(textBoxButton);
            textBoxButton.Click();
        }

        [Test]
        public void LinkWithSendApiCallTest()
        {

        }

        [Test]
        public void LinkWithOpenNewTabTest()
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
