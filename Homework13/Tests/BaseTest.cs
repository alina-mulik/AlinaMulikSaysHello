using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Helpers;
using NUnit.Framework;

namespace Homework13.Tests
{
    public class BaseTest
    {
        [OneTimeSetUp]
        public void BaseTestOneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQaHomePageUrl);
        }

        [TearDown]
        public void BaseTestTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                TakeScreenshot();
            }
        }

        [OneTimeTearDown]
        public void BaseTestOneTimeTearDown()
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
