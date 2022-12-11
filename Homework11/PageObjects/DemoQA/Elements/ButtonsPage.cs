using Homework11.Common.Drivers;
using Homework11.Common.Extensions;
using Homework11.Common.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11.PageObjects.DemoQA.Elements
{
    public class ButtonsPage
    {
        private DemoQaWebElement _doubleClickButton = new(By.XPath("//button[@id='doubleClickBtn']"));
        private DemoQaWebElement _doubleClickOutput = new(By.XPath("//p[@id='doubleClickMessage']"));
        private DemoQaWebElement _rightClickButton = new(By.XPath("//button[@id='rightClickBtn']"));
        private DemoQaWebElement _rightClickOutput = new(By.XPath("//p[@id='rightClickMessage']"));

        public void WaitUntilButtonsAreClickable()
        {
            WebDriverFactory.Driver.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='rightClickBtn']")));
            WebDriverFactory.Driver.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='doubleClickBtn']")));
        }

        public void DoubleClickDoubleClickButton()
        {
            _doubleClickButton.ScrollIntoView();
            _doubleClickButton.DoubleClick();
        }

        public string GetDoubleClickOutputText() => _doubleClickOutput.Text;

        public void RightClickRightClickButton()
        {
            _doubleClickButton.ScrollIntoView();
            _rightClickButton.RightClick();
        }

        public string GetRightClickOutputText() => _rightClickOutput.Text;
    }
}
