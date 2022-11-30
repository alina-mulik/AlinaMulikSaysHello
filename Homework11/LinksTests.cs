using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Homework11
{
    public class LinksTests
    {
        private IWebDriver _driver;
        private IJavaScriptExecutor _javascriptExecutor;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _javascriptExecutor = (IJavaScriptExecutor)_driver;
            _driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/elements");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var navigationButton = _driver.FindElement(By.Id("item-5"));
            ScrollToElement(navigationButton);
            navigationButton.Click();
        }

        [Test]
        public void LinkWithOpenNewTabTest()
        {
            var expectedResultList = new List<string> { "Elements", "Forms", "Alerts, Frame & Windows", "Widgets", "Interactions", "Book Store Application" };
            var actualResultList = new List<string>();

            // Find the link element and click it
            var linkElement = _driver.FindElement(By.LinkText("Home"));
            ScrollToElement(linkElement);
            linkElement.Click();

            // Switch to new window
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);

            // Check that it's a correct url and window by checking smth on the page
            Assert.AreEqual(_driver.Url, "https://demoqa.com/");
            var cardsOnThePage = _driver.FindElements(By.XPath("//div[@class='card-body']/h5"));
            foreach (var card in cardsOnThePage)
            {
                var cardTitle = card.Text;
                actualResultList.Add(cardTitle);
            }
            CollectionAssert.AreEquivalent(expectedResultList, actualResultList);
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
