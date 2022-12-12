using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Homework13.Common.Extensions
{
    public static class WebDriverExtensions
    {
        // extension method to get webdriver wait
        // "this IWebDriver driver" shows that extends IWebDriver method extends IWebDriver functionality
        public static WebDriverWait GetWebDriverWait(this IWebDriver driver, int timeoutSeconds = 15, TimeSpan? pollingInterval = null, params Type[] exceptionTypes)
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            if (pollingInterval != null)
            {
                webDriverWait.PollingInterval = (TimeSpan)pollingInterval;
            }

            webDriverWait.IgnoreExceptionTypes(exceptionTypes);

            return webDriverWait;
        }

        // find web element method with explicit wait
        public static IWebElement GetWebElementWhenExists(this IWebDriver driver, By by) => driver.GetWebDriverWait().Until(drv => drv.FindElement(by));
    }
}
