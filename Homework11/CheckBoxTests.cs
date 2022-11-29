using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Homework11
{
    public class CheckBoxTests
    {
        private IWebDriver _driver;
        private IJavaScriptExecutor _javascriptExecutor;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _javascriptExecutor = (IJavaScriptExecutor)_driver;
            _driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/elements");
            var textBoxButton = _driver.FindElement(By.Id("item-1"));
            textBoxButton.Click();
        }

        [Test]
        public void CheckAllByCheckingHomeCheckBox()
        {
            var homeCheckBox = _driver.FindElement(By.XPath("//*[contains(@class, 'rct-checkbox')]"));
            Assert.IsNotNull(homeCheckBox);
            homeCheckBox.Click();
            var selectedCheckboxes = _driver.FindElements(By.XPath("//div/span[contains(@class, 'text-success')]"));
            Assert.AreEqual(17, selectedCheckboxes.Count);
        }

        [Test]
        public void ExpandAllAndSelectDocumentsCheckbox()
        {
            var expandAllButton = _driver.FindElement(By.XPath("//button[contains(@title, 'Expand all')]"));
            expandAllButton.Click();
            var documentsCheckbox = _driver.FindElement(By.XPath("//span/label[@for='tree-node-documents']"));
            documentsCheckbox.Click();
            var generalOfficeOption = _driver.FindElement(By.XPath("//input[@id='tree-node-general']"));
            Assert.IsTrue(generalOfficeOption.Selected);
            var selectedCheckboxes = _driver.FindElements(By.XPath("//div/span[contains(@class, 'text-success')]"));
            ScrollToElement(selectedCheckboxes[0]);
            Assert.AreEqual(10, selectedCheckboxes.Count);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }

        private void ScrollToElement(IWebElement element)
        {
            _javascriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
    }
}
