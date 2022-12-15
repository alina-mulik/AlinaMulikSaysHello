using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.DemoQA.ElementsCategoryPages
{
    public class BrokenLinksImagesPage
    {
        private DemoQaWebElement _validImageElement = new(By.XPath("//p[contains(text(),'Valid image')]//following::img"));
        private DemoQaWebElement _invalidImageElement = new(By.XPath("//p[contains(text(),'Broken image')]//following::img"));

        public string GetValidImageAttribute(string attributeName) => _validImageElement.GetAttribute(attributeName);

        public string GetInvalidImageAttribute(string attributeName) => _invalidImageElement.GetAttribute(attributeName);
    }
}
