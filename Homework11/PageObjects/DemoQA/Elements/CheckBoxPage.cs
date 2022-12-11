using Homework11.Common.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11.PageObjects.DemoQA.Elements
{
    public class CheckBoxPage
    {
        private static DemoQaWebElement _homeOption = new(By.XPath("//*[contains(@class, 'rct-checkbox')]"));
        private DemoQaWebElement _homeCheckbox = new(By.XPath("//*[@id='tree-node-home']"));
        private DemoQaWebElement _expandAllButton = new(By.XPath("//button[contains(@title, 'Expand all')]"));
        private DemoQaWebElement _documentsOption = new(By.XPath("//span/label[@for='tree-node-documents']"));
        private ReadOnlyCollection<IWebElement> _allDocumentsOptions = _homeOption.FindElements(By.XPath("//li[@class='rct-node rct-node-parent rct-node-expanded'][2]//child::input"));
        private ReadOnlyCollection<IWebElement> _allSelectedCheckboxesOutput = _homeOption.FindElements(By.XPath("//div/span[contains(@class, 'text-success')]"));

        public bool IsHomeCheckoboxSelected() => _homeCheckbox.Selected;

        public void ClickHomeOption() => _homeOption.Click();

        public int CountAllSelectedCheckboxesOutput() => _allSelectedCheckboxesOutput.Count();

        public void ClickExpandAllButton() => _expandAllButton.Click();

        public void ClickDocumentsOption() => _documentsOption.Click();

        public ReadOnlyCollection<IWebElement> GetAllDocumentsOptions() => _allDocumentsOptions;
    }
}
