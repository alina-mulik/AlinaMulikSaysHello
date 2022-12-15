using System.Collections.ObjectModel;
using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.DemoQA.ElementsCategoryPages
{
    public class CheckBoxPage
    {
        private DemoQaWebElement _homeOption = new(By.XPath("//*[contains(@class, 'rct-checkbox')]"));
        private DemoQaWebElement _homeCheckbox = new(By.XPath("//*[@id='tree-node-home']"));
        private DemoQaWebElement _expandAllButton = new(By.XPath("//button[contains(@title, 'Expand all')]"));
        private DemoQaWebElement _documentsOption = new(By.XPath("//span/label[@for='tree-node-documents']"));

        public bool IsHomeCheckboxSelected() => _homeCheckbox.Selected;

        public void ClickHomeOption() => _homeOption.Click();

        public int CountAllSelectedCheckboxesOutput()
        {
            var allSelectedCheckboxesOutput = _homeOption.FindElements(By.XPath("//div/span[contains(@class, 'text-success')]"));

            return allSelectedCheckboxesOutput.Count();
        }

        public void ClickExpandAllButton() => _expandAllButton.Click();

        public void ClickDocumentsOption() => _documentsOption.Click();

        public ReadOnlyCollection<IWebElement> GetAllDocumentsOptions()
        {
            var allDocumentsOptions = _homeOption.FindElements(By.XPath("//li[@class='rct-node rct-node-parent rct-node-expanded'][2]//child::input"));

            return allDocumentsOptions;
        }
    }
}
