using Homework11.Common.WebElements;
using OpenQA.Selenium;

namespace Homework11.PageObjects.DemoQA.Elements
{
    public class UploadAndDownloadPage
    {
        private DemoQaWebElement _uploadButton = new(By.XPath("//input[@id='uploadFile']"));
        private DemoQaWebElement _resultPathElement = new(By.XPath("//p[@id='uploadedFilePath']"));

        public void UploadADocument(string filePath) => _uploadButton.SendKeys(filePath);

        public string GetResultPath() => _resultPathElement.Text;
    }
}
