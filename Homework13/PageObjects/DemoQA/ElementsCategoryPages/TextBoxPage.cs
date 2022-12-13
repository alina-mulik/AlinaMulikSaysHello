using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.DemoQA.ElementsCategoryPages
{
    public class TextBoxPage
    {
        private DemoQaWebElement _fullNameInput = new(By.XPath("//*[@id='userName']"));
        private DemoQaWebElement _fullNameOutput = new(By.XPath("//*[@class='mb-1'][@id='name']"));
        private DemoQaWebElement _emailInput = new(By.CssSelector("#userEmail"));
        private DemoQaWebElement _emailOutput = new(By.XPath("//*[@class='mb-1'][@id='email']"));
        private DemoQaWebElement _currentAddressInput = new(By.Id("currentAddress"));
        private DemoQaWebElement _currentAddressOutput = new(By.XPath("//*[@class='mb-1'][@id='currentAddress']"));
        private DemoQaWebElement _permanentAddressInput = new(By.Id("permanentAddress"));
        private DemoQaWebElement _permanentAddressOutput = new(By.XPath("//*[@class='mb-1'][@id='permanentAddress']"));
        private DemoQaWebElement _submitButton = new(By.Id("submit"));
        private DemoQaWebElement _resultBox = new(By.XPath("//*[@id='output']/div"));

        public void EnterValueIntoAllInputs(string value)
        {
            var userFormElement = new DemoQaWebElement(By.XPath("//*[@id='userForm']"));
            var allInputsList = userFormElement.FindElements(By.XPath("//*[contains(@class, 'form-control')]"));
            foreach (var input in allInputsList)
            {
                input.SendKeys(value);
            }
        }

        public bool IsFullNameInputDisplayed() => _fullNameInput.Displayed;

        public bool IsResultBoxDisplayed() => _resultBox.Displayed;

        public string GetFullNameInputPlaceholder() => _fullNameInput.GetElementPlaceholder();

        public string GetEmailInputPlaceholder() => _emailInput.GetElementPlaceholder();

        public string GetCurrentAddressInputPlaceholder() => _currentAddressInput.GetAttribute("placeholder");

        public void EnterValueIntoFullNameInput(string value) => _fullNameInput.SendKeys(value);

        public void EnterValueIntoEmailInput(string value) => _emailInput.SendKeys(value);

        public void EnterValueIntoCurrentAddressInput(string value) => _currentAddressInput.SendKeys(value);

        public void EnterValueIntoPermanentAddressInput(string value) => _permanentAddressInput.SendKeys(value);

        public string GetFullNameOutputText() => _fullNameOutput.Text;

        public string GetEmailOutputText() => _emailOutput.Text;

        public string GetCurrentAddressOutputText() => _currentAddressOutput.Text;

        public string GetPermanentAddressOutputText() => _permanentAddressOutput.Text;

        public void ClickSubmitButton() => _submitButton.Click();
    }
}
