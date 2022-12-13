using Homework13.Common.Drivers;
using Homework13.Data;
using Homework13.Data.Constants;
using Homework13.PageObjects.DemoQA;
using NUnit.Framework;

namespace Homework13.Tests.DemoQA.Elements
{
    public class UploadAndDownloadTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQaElementsUrl);
            GenericPages.BaseDemoQaPage.ClickOnElementsSubCategory(ElementsCategories.UploadAndDownload);
        }

        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.Driver.Navigate().Refresh();
        }

        [Test]
        public void UploadFile()
        {
            var fileName = "TextFile1.txt";
            var expectedPathPart = "C:\\fakepath\\";
            string fileFullPath = Helpers.FilesHelper.FilesForUploadDir() + fileName;

            // Upload the file
            GenericPages.UploadAndDownloadPage.UploadADocument(fileFullPath);

            // Check the file path result message
            var resultPath = GenericPages.UploadAndDownloadPage.GetResultPath();
            Assert.AreEqual(expectedPathPart + fileName, resultPath);
        }
    }
}
