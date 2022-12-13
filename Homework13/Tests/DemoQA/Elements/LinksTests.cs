using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Data.Constants;
using Homework13.PageObjects.DemoQA;
using NUnit.Framework;

namespace Homework13.Tests.DemoQA.Elements
{
    public class LinksTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQaElementsUrl);
            GenericPages.BaseDemoQaPage.ClickOnElementsSubCategory(ElementsCategories.Links);
        }

        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.Driver.Navigate().Refresh();
        }

        [Test]
        public void LinkWithOpenNewTabTest()
        {
            var expectedResultList = new List<string>
                {
                    "Elements",
                    "Forms",
                    "Alerts, Frame & Windows",
                    "Widgets", "Interactions",
                    "Book Store Application"
                };

            // Click on the Link
            GenericPages.LinksPage.ClickHomeLink();

            // Switch to new window
            WebDriverFactory.SwitchToWindow(1);

            // Check that it's a correct url and window by checking smth on the page
            Assert.AreEqual(TestSettings.DemoQaHomePageUrl, WebDriverFactory.GetCurrentUrl());
            var actualResultList = GenericPages.HomePage.GetListOfCategories();
            CollectionAssert.AreEquivalent(expectedResultList, actualResultList);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverFactory.CloseAllWindowsAndSwitchToFirst();
        }
    }
}
