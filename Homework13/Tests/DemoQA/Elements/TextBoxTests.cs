using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Data.Constants;
using Homework13.Helpers;
using Homework13.PageObjects.DemoQA;
using Homework13.PageObjects.DemoQA.ElementsCategoryPages;
using NUnit.Framework;

namespace Homework13.Tests.DemoQA.Elements
{
    public class TextBoxTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQaElementsUrl);
            GenericPages.BaseDemoQaPage.ClickOnElementsSubCategory(ElementsCategories.TextBox);
        }

        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.Driver.Navigate().Refresh();
        }

        [Test]
        public void TextBoxWithValidValuesFullFlowTest()
        {
            // Fill in all the input fields
            var textTextValue = RandomHelper.GetRandomString(8);
            var validEmail = $"{RandomHelper.GetRandomString(8)}@gmail.com";
            Assert.IsTrue(GenericPages.TextBoxPage.IsFullNameInputDisplayed());
            Assert.AreEqual("Full Name", GenericPages.TextBoxPage.GetFullNameInputPlaceholder());
            GenericPages.TextBoxPage.EnterValueIntoFullNameInput(textTextValue);
            Assert.AreEqual("name@example.com", GenericPages.TextBoxPage.GetEmailInputPlaceholder());
            GenericPages.TextBoxPage.EnterValueIntoEmailInput(validEmail);
            Assert.AreEqual("Current Address", GenericPages.TextBoxPage.GetCurrentAddressInputPlaceholder());
            GenericPages.TextBoxPage.EnterValueIntoCurrentAddressInput(textTextValue);
            GenericPages.TextBoxPage.EnterValueIntoPermanentAddressInput(textTextValue);

            // Click Submit button
            GenericPages.TextBoxPage.ClickSubmitButton();

            // Check Output
            var valueInNameFromBox = GenericPages.TextBoxPage.GetFullNameOutputText();
            Assert.AreEqual($"Name:{textTextValue}", valueInNameFromBox, $"Actual {valueInNameFromBox} and expected Name:{textTextValue} values are not the same!");
            var valueInEmailFromBox = GenericPages.TextBoxPage.GetEmailOutputText();
            Assert.AreEqual($"Email:{validEmail}", valueInEmailFromBox, $"Actual {valueInEmailFromBox} and expected Email:{textTextValue} values are not the same!");
            var valueInCurrentAddressFromBox = GenericPages.TextBoxPage.GetCurrentAddressOutputText();
            Assert.AreEqual($"CurrentAddress:{textTextValue}", string.Concat(valueInCurrentAddressFromBox.Where(x => !char.IsWhiteSpace(x))));
            var valueInPermanentAddressFromBox = GenericPages.TextBoxPage.GetPermanentAddressOutputText();
            Assert.AreEqual($"PermananetAddress:{textTextValue}", string.Concat(valueInPermanentAddressFromBox.Where(x => !char.IsWhiteSpace(x))));
        }

        [Test]
        public void TextBoxWithInvalidEmailFullFlowTest()
        {
            // Fill in input fields
            var textTextValue = RandomHelper.GetRandomString(8);
            var textBoxPage = new TextBoxPage();
            textBoxPage.EnterValueIntoAllInputs(textTextValue);

            // Click Submit Button
            textBoxPage.ClickSubmitButton();

            // Assert that Output is not displayed
            Assert.IsFalse(textBoxPage.IsResultBoxDisplayed());
        }
    }
}
