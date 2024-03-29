﻿using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.DemoQA
{
    public class BaseDemoQaPage : BasePage
    {
        private string _demoQaCategoryLocator = "//*[@class='element-group' and .//text()='{0}']//*[@class='group-header']";
        private string _elementsSubCategoryLocator = "//span[@class='text' and .//text()='{0}']/ancestor::li[@class='btn btn-light ']";

        public void ExpandOrCollapseCategory(string categoryName, bool expand)
        {
            var elementGroupXPathLocator = $"//*[@class='element-group' and .//text()='{categoryName}']";
            var elementListWithCollapseClass = new DemoQaWebElement(By.XPath($"{elementGroupXPathLocator}//div[contains(@class, 'collapse')]"));
            var groupHeader = new DemoQaWebElement(By.XPath($"{elementGroupXPathLocator}//*[@class='group-header']"));

            if (expand && !elementListWithCollapseClass.GetValueOfClassAttribute().Contains("show"))
            {
                groupHeader.Click();
            }
            else if (!expand && elementListWithCollapseClass.GetValueOfClassAttribute().Contains("show"))
            {
                groupHeader.Click();
            }
        }

        public void ClickOnDemoQACategory(string categoryName) => new DemoQaWebElement(By.XPath(string.Format(_demoQaCategoryLocator,
            categoryName))).Click();

        public void ClickOnElementsSubCategory(string elementsConstOption) => new DemoQaWebElement(By.XPath(string.Format(_elementsSubCategoryLocator,
            elementsConstOption))).Click();
    }
}
