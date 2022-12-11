using Homework11.Common.Drivers;
using Homework11.Common.Extensions;
using Homework11.Common.WebElements;
using OpenQA.Selenium;

namespace Homework11.PageObjects.DemoQA.Elements
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
            WebDriverFactory.Driver.GetWebDriverWait(pollingInterval: TimeSpan.FromSeconds(1)).Until(GenericPages.DynamicPropertiesPage.IsColorChangedCondition(colorBefore));
        }

        private Func<IWebDriver, IWebElement> IsColorChangedCondition(string rgbaInitialColor)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    if (_dangerButton.GetCssValue("color") != rgbaInitialColor)
                    {
                        return _dangerButton;
                    }

                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }
    }
}
