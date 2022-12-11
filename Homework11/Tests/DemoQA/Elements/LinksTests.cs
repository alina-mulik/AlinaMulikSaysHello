using NUnit.Framework;
using Homework11.PageObjects.DemoQA;
using Homework11.Common.Drivers;
using Homework11.Data.Constants;
using Homework11.Data;

namespace Homework11.Tests.DemoQA.Elements
{
    public class LinksTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQAElementsUrl);
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
            var expectedResultList = new List<string> { "Elements", "Forms", "Alerts, Frame & Windows", "Widgets", "Interactions", "Book Store Application" };

            // Click on the Link
            GenericPages.LinksPage.ClickHomeLink();

            // Switch to new window
            WebDriverFactory.SwitchToWindow(1);

            // Check that it's a correct url and window by checking smth on the page
            var actualResultList = GenericPages.HomePage.GetListOfCategories();
            CollectionAssert.AreEquivalent(expectedResultList, actualResultList);
        }
    }
}
