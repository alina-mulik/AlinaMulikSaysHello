using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Homework11
{
    public class RadioButtonTests
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
            var textBoxButton = _driver.FindElement(By.Id("item-2"));
            textBoxButton.Click();
        }

        [Test]
        public void CheckYesRadioButtonTest()
        {
            var yesRadioButtonCheckbox = _driver.FindElement(By.XPath("//input[@id='yesRadio']"));
            var yesRadioButton = _driver.FindElement(By.XPath("//label[@for='yesRadio']"));
            yesRadioButton.Click();
            Assert.IsTrue(yesRadioButtonCheckbox.Selected);
            var resultOutPut = _driver.FindElement(By.XPath("//span[@class='text-success']"));
            Assert.AreEqual("Yes", resultOutPut.Text);
        }

        [Test]
        public void CheckNoRadioButtonIsDisabledAndNothingAppearsAfterClickTest()
        {
            var noRadioButtonCheckbox = _driver.FindElement(By.XPath("//*[@id='noRadio']"));
            var noRadioButtonLabel = _driver.FindElement(By.XPath("//label[@for='noRadio']"));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            noRadioButtonLabel.Click();
            var disabledAttribute = noRadioButtonCheckbox.GetAttribute("disabled");
            Assert.AreEqual("true", disabledAttribute);
            Assert.IsFalse(noRadioButtonCheckbox.Enabled);
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
