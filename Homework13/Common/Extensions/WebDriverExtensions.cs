﻿using OpenQA.Selenium;
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

        public static string GetCurrentUrl(this IWebDriver driver) => driver.Url;

        public static void SwitchToWindow(this IWebDriver driver, int windowIndex) => driver.SwitchTo().Window(driver.WindowHandles[windowIndex]);

        public static void CloseAllWindowsAndSwitchToFirst(this IWebDriver driver)
        {
            var collectionOfWindows = driver.WindowHandles;
            if (collectionOfWindows.Count > 1)
            {
                var indexOfLastWindow = collectionOfWindows.Count - 1;
                while (indexOfLastWindow != 0)
                {
                    driver.SwitchToWindow(indexOfLastWindow);
                    driver.Close();
                    indexOfLastWindow -= 1;
                }
                SwitchToWindow(driver, 0);
            }
        }

        // find web element method with explicit wait
        public static IWebElement GetWebElementWhenExists(this IWebDriver driver, By by) => driver.GetWebDriverWait().Until(drv => drv.FindElement(by));
    }
}
