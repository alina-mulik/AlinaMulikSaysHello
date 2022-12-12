using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects
{
    public class BasePage
    {
        private DemoQaWebElement _demoQaHeader = new(By.XPath("//*[@id='app']/header"));

        public void ClickOnDemoQAHeader() => _demoQaHeader.Click();
    }
}
