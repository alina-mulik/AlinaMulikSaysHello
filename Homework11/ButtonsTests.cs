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
            var textBoxButton = _driver.FindElement(By.Id("item-4"));
            ScrollToElement(textBoxButton);
            textBoxButton.Click();
        }

        [Test]
        public void DoubleClickTest()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            var doubleClickButton = _driver.FindElement(By.XPath("//button[@id='doubleClickBtn']"));
            _actions.DoubleClick(doubleClickButton).Perform();
            var expectedResultText = "You have done a double click";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//p[@id='doubleClickMessage']")));
            var actualResultText = _driver.FindElement(By.XPath("//p[@id='doubleClickMessage']"));
            Assert.AreEqual(expectedResultText, actualResultText.Text);
        }

        [Test]
        public void RightClickButtonTest()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            var rightClickButton = _driver.FindElement(By.XPath("//button[@id='rightClickBtn']"));
            _actions.ContextClick(rightClickButton).Perform();
            var expectedResultText = "You have done a right click";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//p[@id='rightClickMessage']")));
            var actualResultText = _driver.FindElement(By.XPath("//p[@id='rightClickMessage']"));
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
            element.Click();
        }
    }
}
