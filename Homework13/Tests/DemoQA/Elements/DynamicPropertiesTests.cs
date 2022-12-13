using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Data.Constants;
using Homework13.PageObjects.DemoQA;
using NUnit.Framework;

namespace Homework13.Tests.DemoQA.Elements
{
    public class DynamicPropertiesTests : BaseTest
    {
        const string RedColor = "rgba(220, 53, 69, 1)";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQaElementsUrl);
            GenericPages.BaseDemoQaPage.ClickOnElementsSubCategory(ElementsCategories.DynamicProperties);
        }

        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.Driver.Navigate().Refresh();
        }

        [Test]
        public void WaitForButtonTest()
        {
            // Waiter with 15 seconds timeout by default is already applied in WebDriverExtensions
            // Check that button is displayed
            Assert.IsTrue(GenericPages.DynamicPropertiesPage.IsButtonToWaitForDisplayed());
        }

        [Test]
        public void DangerRedTextButtonTest()
        {
            // Get color before 5 sec and wait till the time runs out using another element which appears after 5 seconds
            var colorBefore = GenericPages.DynamicPropertiesPage.GetCssColorValueOfDangerButton();
            GenericPages.DynamicPropertiesPage.WaitTillDangerButtonColorIsChanged(colorBefore);

            // Get color after 5 sec
            var colorAfter = GenericPages.DynamicPropertiesPage.GetCssColorValueOfDangerButton();

            // Check color
            Assert.AreEqual(RedColor, colorAfter);
        }
    }
}
