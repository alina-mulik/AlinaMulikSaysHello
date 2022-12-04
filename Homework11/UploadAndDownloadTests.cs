using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Homework11
{
    public class UploadAndDownloadTests
    {
        private IWebDriver _driver;
        private IJavaScriptExecutor _javascriptExecutor;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _javascriptExecutor = (IJavaScriptExecutor)_driver;
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/elements");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var navigationButton = _driver.FindElement(By.Id("item-7"));
            ScrollToElement(navigationButton);
            navigationButton.Click();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().Refresh();
        }

        [Test]
        public async Task UploadFile()
        {
            var fileName = "TextFile1.txt";
            var expectedPathPart = "C:\\fakepath\\";
            string fileFullPath = RootDir() + fileName;

            // Upload the file
            var uploadButton = _driver.FindElement(By.XPath("//input[@id='uploadFile']"));
            uploadButton.SendKeys(fileFullPath);

            // Check the file path result message
            var resultPath = _driver.FindElement(By.XPath("//p[@id='uploadedFilePath']")).Text;
            Assert.AreEqual(expectedPathPart + fileName, resultPath);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }

        private void ScrollToElement(IWebElement element)
        {
            _javascriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        private static string RootDir() => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
    }
}
