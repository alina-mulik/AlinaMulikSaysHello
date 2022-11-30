using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Homework11
{
    public class BrokenLinksImagesTests
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
            var navigationButton = _driver.FindElement(By.Id("item-6"));
            ScrollToElement(navigationButton);
            navigationButton.Click();
        }

        [Test]
        public async Task CheckValidImageTest()
        {
            // Find image element
            using var client = new HttpClient();
            var validImageElement = _driver.FindElement(By.XPath("//p[contains(text(),'Valid image')]//following::img"));

            // Get Image src attribute
            var srcAttribute = validImageElement.GetAttribute("src");
            Assert.IsNotNull(srcAttribute);

            // Get response and its content after sending the request to image link
            HttpResponseMessage response = await client.GetAsync(srcAttribute);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsNotNull(responseContent);
            var contentTypeHeaderContent = response.Content.Headers.ContentType.ToString();

            // Check image format
            Assert.AreEqual("image/jpeg", contentTypeHeaderContent);
        }

        [Test]
        public async Task CheckInvalidImageTest()
        {
            // Find image element
            using var client = new HttpClient();
            var invalidImageElement = _driver.FindElement(By.XPath("//p[contains(text(),'Broken image')]//following::img"));

            // Get Image src attribute
            var srcAttribute = invalidImageElement.GetAttribute("src");
            Assert.IsNotNull(srcAttribute);

            // Get response and its content after sending the request to image link
            HttpResponseMessage response = await client.GetAsync(srcAttribute);
            var responseContent = response.Content.Headers.ContentType.ToString();
            Assert.IsNotNull(responseContent);
            var contentTypeHeaderContent = response.Content.Headers.ContentType.ToString();

            // Check image format
            Assert.AreEqual("image/jpeg", contentTypeHeaderContent, $"Image format is incorrect! Should be \"image/jpeg\", but it was {contentTypeHeaderContent}");
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
