using lib_domain.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace scb_services.Core
{
    public class Configuration : lib_application.Ports.IConfiguration
    {
        private static Dictionary<string, string>? data;

        public string? Get(string key)
        {
            return Service(key);
            //return Local(key);
        }

        private string? Service(string key)
        {
            var response = string.Empty;
            if (Startup.Configuration != null)
                response = Startup.Configuration!
                    .GetSection(key!).Value;

            if (Startup.Configuration != null &&
                string.IsNullOrEmpty(response))
                response = Startup.Configuration!
                    .GetSection("Settings")
                    .GetSection(key!).Value;

            if (Startup.Configuration != null &&
                string.IsNullOrEmpty(response))
                response = Startup.Configuration!
                    .GetConnectionString(key!)!;
            return response;
        }

        private string Local(string key)
        {
            if (data == null)
                Load();
            return data![key].ToString();
        }

        private void Load()
        {
            var path3 = GetPath() + @"\config.json";
            if (!File.Exists(path3))
                return;
            data = new Dictionary<string, string>();
            StreamReader jsonStream = File.OpenText(path3);
            var json = jsonStream.ReadToEnd();
            data = JsonHelper.ConvertToObject<Dictionary<string, string>>(json)!;
        }

        private string? GetPath()
        {
            var response = Environment.CurrentDirectory;
            for (var count = 0; count < 1; count++)
                response = Path.GetDirectoryName(response);
            return response;
        }
    }
}