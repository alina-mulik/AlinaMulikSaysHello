using Homework13.Data.Enums;
using Microsoft.Extensions.Configuration;

namespace Homework13.Data
{
    public static class TestSettings
    {
        public static Browsers Browser { get; set; }
        public static string DemoQaHomePageUrl { get; set; }
        public static string DemoQaElementsUrl { get; set; }

        public static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile(".\\Tests\\testsettings.json").Build();

        static TestSettings()
        {
            Enum.TryParse(TestConfiguration["Common:Browser"], out Browsers browser);
            Browser = browser;
            DemoQaHomePageUrl = TestConfiguration["Common:DemoQAUrls:DemoQAHomePage"];
            DemoQaElementsUrl = TestConfiguration["Common:DemoQAUrls:DemoQAElements"];
        }
    }
}
