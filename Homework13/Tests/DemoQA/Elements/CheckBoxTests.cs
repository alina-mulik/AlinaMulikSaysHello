﻿using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Data.Constants;
using Homework13.PageObjects.DemoQA;
using NUnit.Framework;

namespace Homework13.Tests.DemoQA.Elements
{
    public class CheckBoxTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQaElementsUrl);
            GenericPages.BaseDemoQaPage.ClickOnElementsSubCategory(ElementsCategories.CheckBox);
        }

        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.Driver.Navigate().Refresh();
        }

        [Test]
        public void CheckAllByCheckingHomeCheckBox()
        {
            // Find and click main Home option
            GenericPages.CheckBoxPage.ClickHomeOption();

            // Check that checkbox is selected
            var homeCheckBoxSelected = GenericPages.CheckBoxPage.IsHomeCheckboxSelected();
            Assert.IsTrue(homeCheckBoxSelected);

            // Check that all options are displayed as selected in the results
            Assert.AreEqual(17, GenericPages.CheckBoxPage.CountAllSelectedCheckboxesOutput());
        }

        [Test]
        public void ExpandAllAndSelectDocumentsCheckbox()
        {
            // Expand all options using Expand button
            GenericPages.CheckBoxPage.ClickExpandAllButton();

            // Click Documents option
            GenericPages.CheckBoxPage.ClickDocumentsOption();

            // Assert that all Documents checkboxes are checked
            var allDocumentsOptions = GenericPages.CheckBoxPage.GetAllDocumentsOptions();
            foreach (var document in allDocumentsOptions)
            {
                Assert.IsTrue(document.Selected, $"The option {document} is not selected!");
            }

            // Check that selected options are displayed as selected in the results
            Assert.AreEqual(10, GenericPages.CheckBoxPage.CountAllSelectedCheckboxesOutput());
        }
    }
}
