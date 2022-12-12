using System.Collections.Concurrent;
using Homework13.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

namespace Homework13.Common.Drivers
{
    public class WebDriverFactory
    {
        // collection to isolate threads for possible parallelization
        private static readonly ConcurrentDictionary<string, IWebDriver> DriverCollection = new ConcurrentDictionary<string, IWebDriver>();

        public static IWebDriver Driver
        {
            get
            {
                // if the driver hasn't been initialized yet, we initialize it
                if (!DriverCollection.Keys.Contains(TestContextValues.ExecutableClassName))
                {
                    InitializeDriver();
                }

                // return driver for the needed test class
                return DriverCollection.First(pair => pair.Key == TestContextValues.ExecutableClassName).Value;
            }

            // new driver will be assigned only if the collection doesn't have the value for the key
            private set => DriverCollection.TryAdd(TestContextValues.ExecutableClassName, value);
        }

        // create an instance of Actions
        public static Actions Actions => new Actions(Driver);

        // create an instance of IJavaScriptExecutor
        public static IJavaScriptExecutor JavaScriptExecutor => (IJavaScriptExecutor)Driver;

        public static void QuitDriver() => Driver.Quit();

        public static string GetCurrentUrl() => Driver.Url;

        public static void SwitchToWindow(int windowIndex) => Driver.SwitchTo().Window(Driver.WindowHandles[windowIndex]);

        private static void InitializeDriver()
        {
            Driver = TestSettings.Browser switch
            {
                Data.Enums.Browsers.Chrome => new ChromeDriver(),
                Data.Enums.Browsers.Edge => new EdgeDriver(),
                _ => throw new NotSupportedException(),
            };

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }
    }
}
