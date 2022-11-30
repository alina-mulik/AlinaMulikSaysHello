using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;

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
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var navigationButton = _driver.FindElement(By.Id("item-1"));
            navigationButton.Click();
        }

        [Test]
        public void CheckAllByCheckingHomeCheckBox()
        {
            // Find and click main Home option
            var homeOption = _driver.FindElement(By.XPath("//*[contains(@class, 'rct-checkbox')]"));
            homeOption.Click();

            // Check that checkbox is selected
            var homeCheckbox = _driver.FindElement(By.XPath("//*[@id='tree-node-home']"));
            Assert.IsTrue(homeCheckbox.Selected);

            // Check that all options are displayed as selected in the results
            var selectedCheckboxes = _driver.FindElements(By.XPath("//div/span[contains(@class, 'text-success')]"));
            Assert.AreEqual(17, selectedCheckboxes.Count);
        }

        [Test]
        public void ExpandAllAndSelectDocumentsCheckbox()
        {
            // Expand all options using Expand button
            var expandAllButton = _driver.FindElement(By.XPath("//button[contains(@title, 'Expand all')]"));
            expandAllButton.Click();

            // Click Documents option
            var documentsOption = _driver.FindElement(By.XPath("//span/label[@for='tree-node-documents']"));
            documentsOption.Click();

            // Assert that all Documents checkboxes are checked
            var allDocumentsOptions = _driver.FindElements(By.XPath("//li[@class='rct-node rct-node-parent rct-node-expanded'][2]//child::input"));
            foreach (var document in allDocumentsOptions)
            {
                Assert.IsTrue(document.Selected, $"The option {document} is not selected!");
            }

            // Check that selected options are displayed as selected in the results
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
