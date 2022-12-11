using NUnit.Framework;
using Homework11.Common.Drivers;
using Homework11.Helpers;
using Homework11.Data;

namespace Homework11.Tests
{
    public class BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQAHomePageUrl);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                TakeScreenshot();
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            WebDriverFactory.QuitDriver();
        }

        private void TakeScreenshot()
        {
            var screenshotPath = ScreenshotHelper.TakeScreenshot(WebDriverFactory.Driver, TestContext.CurrentContext.Test.Name);
            TestContext.AddTestAttachment(screenshotPath);
        }
    }
}
