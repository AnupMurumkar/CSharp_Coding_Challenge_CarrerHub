using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace CareerHub.util
{ 
    public static class DBConnUtil
    {
        private static IConfigurationRoot _configuration;
        static string s = null;
        static DBConnUtil()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("F:\\HEXAWARE C# CODES\\CarrerHubSol\\utils\\AppSettings.json",
               optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }
        public static string ReturnCn(string key)
        {

            s = _configuration.GetConnectionString("CarrerHubCn");

            return s;
        }

    
    }
}
