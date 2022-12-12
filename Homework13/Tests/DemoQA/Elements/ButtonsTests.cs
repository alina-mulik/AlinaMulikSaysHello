using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Data.Constants;
using Homework13.PageObjects.DemoQA;
using NUnit.Framework;

namespace Homework13.Tests.DemoQA.Elements
{
    public class ButtonsTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQaElementsUrl);
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
