using Homework11.Common.WebElements;
using OpenQA.Selenium;

namespace Homework11.PageObjects
{
    public class BasePage
    {
        private DemoQaWebElement _demoQaHeader = new(By.XPath("//*[@id='app']/header"));

        public void ClickOnDemoQAHeader() => _demoQaHeader.Click();
    }
}
