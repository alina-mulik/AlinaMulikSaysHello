using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Data.Constants;
using Homework13.PageObjects.DemoQA;
using NUnit.Framework;

namespace Homework13.Tests.DemoQA.Elements
{
    public class BrokenLinksImagesTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQaElementsUrl);
            GenericPages.BaseDemoQaPage.ClickOnElementsSubCategory(ElementsCategories.BrokenLinksImages);
        }

        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.Driver.Navigate().Refresh();
        }

        [Test]
        public async Task CheckValidImageTest()
        {
            using var client = new HttpClient();

            // Get valid Image src attribute
            var srcAttribute = GenericPages.BrokenLinksImagesPage.GetValidImageAttribute("src");
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
            using var client = new HttpClient();

            // Get invalid Image src attribute
            var srcAttribute = GenericPages.BrokenLinksImagesPage.GetInvalidImageAttribute("src");
            Assert.IsNotNull(srcAttribute);

            // Get response and its content after sending the request to image link
            HttpResponseMessage response = await client.GetAsync(srcAttribute);
            var responseContent = response.Content.Headers.ContentType.ToString();
            Assert.IsNotNull(responseContent);
            var contentTypeHeaderContent = response.Content.Headers.ContentType.ToString();

            // Check image format
            Assert.AreEqual("text/html; charset=utf-8", contentTypeHeaderContent);
        }
    }
}
