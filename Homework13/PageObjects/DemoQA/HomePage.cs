using Homework13.Common.WebElements;
using OpenQA.Selenium;

namespace Homework13.PageObjects.DemoQA
{
    public class HomePage
    {
        private DemoQaWebElement _demoQaHomeBodyElement = new(By.XPath("//div[@class='home-body']"));

        public List<string> GetListOfCategories()
        {
            var demoQaCategoriesCards = _demoQaHomeBodyElement.FindElements(By.XPath("//div[@class='card-body']/h5"));
            var listOfCategories = new List<string>();
            foreach (var category in demoQaCategoriesCards)
            {
                listOfCategories.Add(category.Text);
            }

            return listOfCategories;
        }
    }
}
