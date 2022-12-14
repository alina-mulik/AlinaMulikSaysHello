using Homework13.Common.Drivers;
using Homework13.Common.Extensions;
using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.DemoQA.ElementsCategoryPages
{
    public class DynamicPropertiesPage
    {
        private DemoQaWebElement _buttonToWaitFor = new(By.XPath("//*[@id='visibleAfter']"));
        private DemoQaWebElement _dangerButton = new(By.XPath("//*[@id='colorChange']"));

        public bool IsButtonToWaitForDisplayed() => _buttonToWaitFor.Displayed;

        public string GetCssColorValueOfDangerButton()
        {
            _dangerButton.ScrollIntoView();

            return _dangerButton.GetCssValue("color");
        }

        public void WaitTillDangerButtonColorIsChanged(string colorBefore)
        {
            WebDriverFactory.Driver.GetWebDriverWait(pollingInterval: TimeSpan.FromSeconds(1)).Until(_ => _dangerButton.GetCssValue("color") != colorBefore);
        }
    }
}
