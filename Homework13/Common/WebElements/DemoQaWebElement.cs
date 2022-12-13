using System.Collections.ObjectModel;
using System.Drawing;
using Homework13.Common.Drivers;
using Homework13.Common.Extensions;
using OpenQA.Selenium;

namespace Homework13.Common.WebElements
{
    public class DemoQaWebElement : IWebElement
    {
        protected By By { get; set; }

        public DemoQaWebElement(By by)
        {
            By = by;
        }

        protected IWebElement WebElement => WebDriverFactory.Driver.GetWebElementWhenExists(By);

        public string TagName => WebElement.TagName;

        public string Text => WebElement.Text;

        public bool Enabled => WebElement.Enabled;

        public bool Selected => WebElement.Selected;

        public Point Location => WebElement.Location;

        public Size Size => WebElement.Size;

        public bool Displayed => WebElement.Displayed;

        public void Clear() => WebElement.Clear();

        public void Click()
        {
            ScrollIntoView();
            WebElement.Click();
        }

        public void DoubleClick()
        {
            WebDriverFactory.Actions.DoubleClick(WebElement).Build().Perform();
        }

        public void RightClick()
        {
            WebDriverFactory.Actions.ContextClick(WebElement).Build().Perform();
        }

        public IWebElement FindElement(By by) => WebElement.FindElement(by);

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            try
            {
                return WebElement.FindElements(by);
            }
            catch (StaleElementReferenceException)
            {
                return WebElement.FindElements(by);
            }
        }

        public string GetAttribute(string attributeName) => WebElement.GetAttribute(attributeName);

        public string GetCssValue(string propertyName) => WebElement.GetCssValue(propertyName);

        public string GetDomAttribute(string attributeName) => WebElement.GetDomAttribute(attributeName);

        public string GetDomProperty(string propertyName) => WebElement.GetDomProperty(propertyName);

        public ISearchContext GetShadowRoot() => WebElement.GetShadowRoot();

        public string GetElementPlaceholder() => WebElement.GetAttribute("placeholder");

        public void SendKeys(string text) => WebElement.SendKeys(text);

        public void Submit() => WebElement.Submit();

        // method to scroll element into view using JavaScript
        public void ScrollIntoView() => WebDriverFactory.JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView()", WebElement);

        // method to get value of class attribute
        public string GetValueOfClassAttribute() => GetAttribute("class");

        public bool IsElementDisabledByAtttribute()
        {
            var isDisabled = WebElement.GetAttribute("disabled");
            if (isDisabled != "true")
            {
                return false;
            }
            return true;
        }
    }
}
