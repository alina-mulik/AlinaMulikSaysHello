using Homework11.Data.Enums;
using Microsoft.Extensions.Configuration;

namespace Homework11.Data
{
    public static class TestSettings
    {
        public static Browsers Browser { get; set; }
        public static string DemoQAHomePageUrl { get; set; }
        public static string DemoQAElementsUrl { get; set; }

        public static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile(".\\Tests\\testsettings.json").Build();

        static TestSettings()
        {
            Enum.TryParse(TestConfiguration["Common:Browser"], out Browsers browser);
            Browser = browser;
            DemoQAHomePageUrl = TestConfiguration["Common:DemoQAUrls:DemoQAHomePage"];
            DemoQAElementsUrl = TestConfiguration["Common:DemoQAUrls:DemoQAElements"];
        }
    }
}
