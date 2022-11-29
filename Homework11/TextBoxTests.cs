using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Homework11
{
    public class TextBoxTests
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
            var textBoxButton = _driver.FindElement(By.Id("item-0"));
            textBoxButton.Click();
        }

        [Test]
        public void TextBoxWithValidValuesFullFlow()
        {
            var textTextValue = HelperClass.RandomString(8);
            var validemail = $"{HelperClass.RandomString(8)}@gmail.com";
            var fullNameInput = _driver.FindElement(By.XPath("//*[@id='userName']"));
            Assert.IsTrue(fullNameInput.Displayed);
            Assert.AreEqual("Full Name", fullNameInput.GetAttribute("placeholder"));
            fullNameInput.SendKeys(textTextValue);
            var emailInput = _driver.FindElement(By.CssSelector("#userEmail"));
            Assert.AreEqual("name@example.com", emailInput.GetAttribute("placeholder"));
            emailInput.SendKeys(validemail);
            var currentAddress = _driver.FindElement(By.Id("currentAddress"));
            Assert.AreEqual("Current Address", currentAddress.GetAttribute("placeholder"));
            currentAddress.SendKeys(textTextValue);
            var permanentAddress = _driver.FindElement(By.Id("permanentAddress"));
            permanentAddress.SendKeys(textTextValue);
            var submitButton = _driver.FindElement(By.Id("submit"));
            ScrollToElementAndClick(submitButton);
            var outputNameValueInBox = _driver.FindElement(By.CssSelector(".mb-1#name"));
            var valueInNameFromBox = outputNameValueInBox.Text;
            Assert.AreEqual($"Name:{textTextValue}", valueInNameFromBox, $"Actual {valueInNameFromBox} and expected Name:{textTextValue} values are not the same!");
            var outputEmailValueInBox = _driver.FindElement(By.XPath("//*[@id='email']"));
            var valueInEmailFromBox = outputEmailValueInBox.Text;
            Assert.AreEqual($"Email:{validemail}", valueInEmailFromBox, $"Actual {valueInEmailFromBox} and expected Email:{textTextValue} values are not the same!");
            var outputCurrentAddressValueInBox = _driver.FindElement(By.XPath("//*[@class='mb-1'][@id=\"currentAddress\"]"));
            var valueInCurrentAddressFromBox = outputCurrentAddressValueInBox.Text;
            Assert.AreEqual($"CurrentAddress:{textTextValue}", String.Concat(valueInCurrentAddressFromBox.Where(x => !Char.IsWhiteSpace(x))));
            var outputPermamentAddressValueInBox = _driver.FindElement(By.XPath("//*[@class='mb-1'][@id=\"permanentAddress\"]"));
            var valueInPermamentAddressFromBox = outputPermamentAddressValueInBox.Text;
            Assert.AreEqual($"PermananetAddress:{textTextValue}", String.Concat(valueInPermamentAddressFromBox.Where(x => !Char.IsWhiteSpace(x))));
        }

        [Test]
        public void TextBoxWithInvalidEmailFullFlow()
        {
            var textTextValue = HelperClass.RandomString(8);
            var allFormInputs = _driver.FindElements(By.XPath("//*[contains(@class, 'form-control')]"));
            foreach (var input in allFormInputs)
            {
                input.SendKeys(textTextValue);
            }
            var submitButton = _driver.FindElement(By.Id("submit"));
            ScrollToElementAndClick(submitButton);
            var resultBox =  _driver.FindElement(By.XPath("//*[@id=\"output\"]/div"));
            Assert.IsFalse(resultBox.Displayed);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }

        private void ScrollToElementAndClick(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (ElementClickInterceptedException)
            {
                _javascriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                element.Click();
            }
        }
    }
}
