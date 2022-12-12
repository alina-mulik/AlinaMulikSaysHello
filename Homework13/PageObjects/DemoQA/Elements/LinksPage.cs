using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.DemoQA.Elements
{
    public class LinksPage
    {
        private DemoQaWebElement _homeLink= new(By.LinkText("Home"));

        public void ClickHomeLink() => _homeLink.Click();
    }
}
