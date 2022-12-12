﻿using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Helpers;
using NUnit.Framework;

namespace Homework13.Tests
{
    public class BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQaHomePageUrl);
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
