using NUnit.Framework;
using Homework11.PageObjects.DemoQA;
using Homework11.Common.Drivers;
using Homework11.Data.Constants;
using Homework11.Data;

namespace Homework11.Tests.DemoQA.Elements
{
    public class UploadAndDownloadTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.DemoQAElementsUrl);
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
            string fileFullPath = Helpers.HelperClass.RootDir() + "FilesForUpload\\" + fileName;

            // Upload the file
            GenericPages.UploadAndDownloadPage.UploadADocument(fileFullPath);

            // Check the file path result message
            var resultPath = GenericPages.UploadAndDownloadPage.GetResultPath();
            Assert.AreEqual(expectedPathPart + fileName, resultPath);
        }
    }
}
