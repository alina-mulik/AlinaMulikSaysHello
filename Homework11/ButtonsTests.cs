using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Homework11
{
    public class ButtonsTests
    {
        private IWebDriver _driver;
        private IJavaScriptExecutor _javascriptExecutor;
        private Actions _actions;
        private WebDriverWait _wait;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _javascriptExecutor = (IJavaScriptExecutor)_driver;
            _driver.Manage().Window.Maximize();
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl("https://demoqa.com/elements");
            var navigationButton = _driver.FindElement(By.Id("item-4"));
            ScrollToElement(navigationButton);
            navigationButton.Click();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().Refresh();
        }

        [Test]
        public void DoubleClickTest()
        {
            var expectedResultText = "You have done a double click";

            // Find button element
            var doubleClickButton = _driver.FindElement(By.XPath("//button[@id='doubleClickBtn']"));
            ScrollToElement(doubleClickButton);

            // Perform double-click
            _actions.DoubleClick(doubleClickButton).Build().Perform();

            // Wait when message is dispalyed and check it
            var actualResultText = _wait.Until(_ => _driver.FindElement(By.XPath("//p[@id='doubleClickMessage']")));
            Assert.AreEqual(expectedResultText, actualResultText.Text);
        }

        [Test]
        public void RightClickButtonTest()
        {
            var expectedResultText = "You have done a right click";

            // Find button element
            var rightClickButton = _driver.FindElement(By.XPath("//button[@id='rightClickBtn']"));
            ScrollToElement(rightClickButton);

            // Perform rght-click
            _actions.ContextClick(rightClickButton).Perform();

            // Wait when message is dispalyed and check it
            var actualResultText = _wait.Until(_ => _driver.FindElement(By.XPath("//p[@id='rightClickMessage']")));
            Assert.AreEqual(expectedResultText, actualResultText.Text);
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
    }
}
