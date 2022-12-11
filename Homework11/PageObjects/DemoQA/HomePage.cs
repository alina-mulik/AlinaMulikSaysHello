using Homework11.Common.WebElements;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Homework11.PageObjects.DemoQA
{
    public class HomePage
    {
        private static DemoQaWebElement _demoQaHomeBodyElement = new(By.XPath("//div[@class='home-body']"));
        private ReadOnlyCollection<IWebElement> _demoQaCategoriesCards = _demoQaHomeBodyElement.FindElements(By.XPath("//div[@class='card-body']/h5"));

        public List<string> GetListOfCategories()
        {
            var listOfCategories = new List<string>();
            foreach (var category in _demoQaCategoriesCards)
            {
                listOfCategories.Add(category.Text);
            }

            return listOfCategories;
        }
    }
}
