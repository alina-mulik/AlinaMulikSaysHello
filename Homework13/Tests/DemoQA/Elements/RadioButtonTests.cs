using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Data.Constants;
using Homework13.PageObjects.DemoQA;
using NUnit.Framework;

namespace Homework13.Tests.DemoQA.Elements
{
    public class RadioButtonTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQaElementsUrl);
            GenericPages.BaseDemoQaPage.ClickOnElementsSubCategory(ElementsCategories.RadioButton);
        }

        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.Driver.Navigate().Refresh();
        }

        [Test]
        public void CheckYesRadioButtonTest()
        {
            // Find 'yes' radiobutton and click it
            GenericPages.RadioButtonPage.ClickYesRadioButtonOption();

            // Assert that 'yes' radiobutton is selected
            Assert.IsTrue(GenericPages.RadioButtonPage.IsYesRadioButtonSelected());

            // Check the result output
            var resultOutPut = GenericPages.RadioButtonPage.GetResultOutputText();
            Assert.AreEqual("Yes", resultOutPut);
        }

        [Test]
        public void CheckNoRadioButtonIsDisabled()
        {
            // Find 'no' radiobutton and click it
            GenericPages.RadioButtonPage.ClickNoRadioButtonOption();

            // Get attribute 'disabled' of the 'no' radiobutton and check that it's truly disabled
            var disabledAttribute = GenericPages.RadioButtonPage.IsNoRadioButtonDisabled();
            Assert.IsTrue(disabledAttribute);
            Assert.IsFalse(GenericPages.RadioButtonPage.IsNoRadioButtonEnabled());
        }
    }
}
