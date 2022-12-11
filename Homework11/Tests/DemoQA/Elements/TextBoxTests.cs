using Homework11.Helpers;
using Homework11.PageObjects.DemoQA;
using Homework11.PageObjects.DemoQA.Elements;
using ElementsCategories = Homework11.Data.Constants.ElementsCategories;
using NUnit.Framework;
using Homework11.Common.Drivers;
using Homework11.Data;

namespace Homework11.Tests.DemoQA.Elements
{
    public class TextBoxTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQAElementsUrl);
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
            var textTextValue = HelperClass.RandomString(8);
            var validEmail = $"{HelperClass.RandomString(8)}@gmail.com";
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
            var textTextValue = HelperClass.RandomString(8);
            var textBoxPage = new TextBoxPage();
            textBoxPage.EnterValueIntoAllInputs(textTextValue);

            // Click Submit Button
            textBoxPage.ClickSubmitButton();

            // Assert that Output is not displayed
            Assert.IsFalse(textBoxPage.IsResultBoxDisplayed());
        }
    }
}
