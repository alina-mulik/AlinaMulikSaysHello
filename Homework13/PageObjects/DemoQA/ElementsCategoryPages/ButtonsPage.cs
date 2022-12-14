using Homework13.Common.Drivers;
using Homework13.Common.Extensions;
using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.DemoQA.ElementsCategoryPages
{
    public class ButtonsPage
    {
        private DemoQaWebElement _doubleClickOutput = new(By.XPath("//p[@id='doubleClickMessage']"));
        private DemoQaWebElement _rightClickOutput = new(By.XPath("//p[@id='rightClickMessage']"));

        private DemoQaWebElement DoubleClickButton => new(By.XPath("//button[@id='doubleClickBtn']"));
        private DemoQaWebElement RightClickButton => new(By.XPath("//button[@id='rightClickBtn']"));

        public void WaitUntilButtonsAreClickable()
        {
            WebDriverFactory.Driver.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DoubleClickButton));
            WebDriverFactory.Driver.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(RightClickButton));
        }

        public void DoubleClickDoubleClickButton()
        {
            DoubleClickButton.ScrollIntoView();
            DoubleClickButton.DoubleClick();
        }

        public string GetDoubleClickOutputText() => _doubleClickOutput.Text;

        public void RightClickRightClickButton()
        {
            RightClickButton.ScrollIntoView();
            RightClickButton.RightClick();
        }

        public string GetRightClickOutputText() => _rightClickOutput.Text;
    }
}
