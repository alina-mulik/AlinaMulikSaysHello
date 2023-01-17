using Microsoft.Extensions.Configuration;

namespace Homework18.Adonet
{
    public static class ConfigurationHelper
    {
        private static readonly IConfiguration Configuration;
        public static string LocalDbConnectionString { get; set; }

        static ConfigurationHelper()
        {
            Configuration = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            SetValues();
        }

        public static void SetValues()
        {
            LocalDbConnectionString = Configuration.GetConnectionString("LocalAdonetDb");
        }
    }
}