using Homework13.Common.Drivers;
using Homework13.Common.Extensions;
using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.DemoQA.ElementsCategoryPages
{
    public class ButtonsPage
    {
        private static string _doubleClickButtonLocator = "//button[@id='doubleClickBtn']";
        private static string _rightClickButtonLocator = "//button[@id='rightClickBtn']";
        private DemoQaWebElement _doubleClickButton = new(By.XPath(_doubleClickButtonLocator));
        private DemoQaWebElement _doubleClickOutput = new(By.XPath("//p[@id='doubleClickMessage']"));
        private DemoQaWebElement _rightClickButton = new(By.XPath(_rightClickButtonLocator));
        private DemoQaWebElement _rightClickOutput = new(By.XPath("//p[@id='rightClickMessage']"));

        public void WaitUntilButtonsAreClickable()
        {
            WebDriverFactory.Driver.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_rightClickButtonLocator)));
            WebDriverFactory.Driver.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_doubleClickButtonLocator)));
        }

        public void DoubleClickDoubleClickButton()
        {
            _doubleClickButton.ScrollIntoView();
            _doubleClickButton.DoubleClick();
        }

        public string GetDoubleClickOutputText() => _doubleClickOutput.Text;

        public void RightClickRightClickButton()
        {
            _rightClickButton.ScrollIntoView();
            _rightClickButton.RightClick();
        }

        public string GetRightClickOutputText() => _rightClickOutput.Text;
    }
}
