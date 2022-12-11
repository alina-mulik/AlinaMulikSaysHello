using NUnit.Framework;
using OpenQA.Selenium;
using Homework11.PageObjects.DemoQA;
using Homework11.Common.Drivers;
using Homework11.Data.Constants;
using Homework11.Data;

namespace Homework11.Tests.DemoQA.Elements
{
    public class ButtonsTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQAElementsUrl);
            GenericPages.BaseDemoQaPage.ClickOnElementsSubCategory(ElementsCategories.Buttons);
        }

        [SetUp]
        public void SetUp()
        {
            GenericPages.ButtonsPage.WaitUntilButtonsAreClickable();
        }

        [Test]
        public void DoubleClickTest()
        {
            var expectedResultText = "You have done a double click";

            // Perform double-click on double-click button
            GenericPages.ButtonsPage.DoubleClickDoubleClickButton();

            // Wait when message is dispalyed and check it
            var actualResultText = GenericPages.ButtonsPage.GetDoubleClickOutputText();
            Assert.AreEqual(expectedResultText, actualResultText);
        }

        [Test]
        public void RightClickButtonTest()
        {
            var expectedResultText = "You have done a right click";

            // Perform rght-click
            GenericPages.ButtonsPage.RightClickRightClickButton();

            // Wait when message is dispalyed and check it
            var actualResultText = GenericPages.ButtonsPage.GetRightClickOutputText();
            Assert.AreEqual(expectedResultText, actualResultText);
        }
    }
}
