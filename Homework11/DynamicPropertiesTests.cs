using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Homework11
{
    public class DynamicPropertiesTests
    {
        private IWebDriver _driver;
        private IJavaScriptExecutor _javascriptExecutor;
        private WebDriverWait _wait;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _javascriptExecutor = (IJavaScriptExecutor)_driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/elements");
            var navigationButton = _driver.FindElement(By.Id("item-8"));
            ScrollToElement(navigationButton);
            navigationButton.Click();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().Refresh();
        }

        [Test]
        public void WaitAndClickButtonTest()
        {
            // Wait for 5 seconds till the button appears
            var buttonToWaitFor = _wait.Until(_ => _driver.FindElement(By.XPath("//*[@id='visibleAfter']")));
            ScrollToElement(buttonToWaitFor);

            // Check that button is displayed after 5 seconds
            Assert.IsTrue(buttonToWaitFor.Displayed);
        }

        [Test]
        public void DangerRedTextButtonTest()
        {
            // Find button and scroll to it
            var dangerButtonElement = _driver.FindElement(By.XPath("//*[@id='colorChange']"));
            ScrollToElement(dangerButtonElement);

            // Get color before 5 sec and wait till the time runs out using another element which appears after 5 seconds
            var colorBefore = dangerButtonElement.GetCssValue("color");
            _wait.Until(_ => IsColorChanged(dangerButtonElement, colorBefore));

            // Get color after 5 sec
            var colorAfter = dangerButtonElement.GetCssValue("color");

            // Check color
            Assert.AreEqual("rgba(220, 53, 69, 1)", colorAfter);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }

        private void ScrollToElement(IWebElement element)
        {
            _javascriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        private bool IsColorChanged(IWebElement element, string rgbaInitialColor)
        {
            if (element.GetCssValue("color") != rgbaInitialColor)
            {
                return true;
            }

            return false;
        }
    }
}
