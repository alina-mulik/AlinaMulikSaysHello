using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Homework11
{
    public class RadioButtonTests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/elements");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var navigationButton = _driver.FindElement(By.Id("item-2"));
            navigationButton.Click();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().Refresh();
        }

        [Test]
        public void CheckYesRadioButtonTest()
        {
            // Find 'yes' radiobutton and click it
            var yesRadioButtonCheckbox = _driver.FindElement(By.XPath("//input[@id='yesRadio']"));
            var yesRadioButton = _driver.FindElement(By.XPath("//label[@for='yesRadio']"));
            yesRadioButton.Click();

            // Assert that 'yes' radiobutton is selected
            Assert.IsTrue(yesRadioButtonCheckbox.Selected);

            // Check the result output
            var resultOutPut = _driver.FindElement(By.XPath("//span[@class='text-success']"));
            Assert.AreEqual("Yes", resultOutPut.Text);
        }

        [Test]
        public void CheckNoRadioButtonIsDisabled()
        {
            // Find 'no' radiobutton and click it
            var noRadioButtonCheckbox = _driver.FindElement(By.XPath("//*[@id='noRadio']"));
            var noRadioButtonLabel = _driver.FindElement(By.XPath("//label[@for='noRadio']"));
            noRadioButtonLabel.Click();

            // Get attribute 'disabled' of the 'no' radiobutton and check that it's truly disabled
            var disabledAttribute = noRadioButtonCheckbox.GetAttribute("disabled");
            Assert.AreEqual("true", disabledAttribute);
            Assert.IsFalse(noRadioButtonCheckbox.Enabled);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }
    }
}
