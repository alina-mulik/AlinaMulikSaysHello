using Homework11.Common.WebElements;
using OpenQA.Selenium;

namespace Homework11.PageObjects.DemoQA.Elements
{
    public class RadioButtonPage
    {
        private DemoQaWebElement _yesRadioButton = new(By.XPath("//input[@id='yesRadio']"));
        private DemoQaWebElement _yesRadioButtonOption = new(By.XPath("//label[@for='yesRadio']"));
        private DemoQaWebElement _noRadioButton = new(By.XPath("//input[@id='noRadio']"));
        private DemoQaWebElement _noRadioButtonOption = new(By.XPath("//label[@for='noRadio']"));
        private DemoQaWebElement _resultOutput = new(By.XPath("//span[@class='text-success']"));

        public void ClickYesRadioButtonOption() => _yesRadioButtonOption.Click();

        public void ClickNoRadioButtonOption() => _noRadioButtonOption.Click();

        public bool IsYesRadioButtonSelected() => _yesRadioButton.Selected;

        public string GetResultOutputText() => _resultOutput.Text;

        public string GetNoRadioButtonAttribute(string attribute) => _noRadioButton.GetAttribute(attribute);

        public bool IsNoRadioButtonEnabled() => _noRadioButton.Enabled;
    }
}
