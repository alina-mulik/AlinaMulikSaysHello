using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.DemoQA.ElementsCategoryPages
{
    public class LinksPage
    {
        private DemoQaWebElement _homeLink= new(By.LinkText("Home"));

        public void ClickHomeLink() => _homeLink.Click();
    }
}
