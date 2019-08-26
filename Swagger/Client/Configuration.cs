using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;

namespace Swagger.Client
{
    public class Configuration
    {
        public static ApiClient DefaultApiClient = new ApiClient(ConfigurationManager.AppSettings["basePath"]);

        public const string Version = "1.0.0";

        public static Dictionary<String, String> ApiKey = new Dictionary<String, String>();

        public static Dictionary<String, String> ApiKeyPrefix = new Dictionary<String, String>();
  
        private static string _tempFolderPath = Path.GetTempPath();

        public static String TempFolderPath
        {
            get { return _tempFolderPath; }
  
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    _tempFolderPath = value;
                    return;
                }      
                if (!Directory.Exists(value)) 
                    Directory.CreateDirectory(value);
      
                if (value[value.Length - 1] == Path.DirectorySeparatorChar)
                    _tempFolderPath = value;
                else
                    _tempFolderPath = value  + Path.DirectorySeparatorChar;
            }
        }

        private const string ISO8601_DATETIME_FORMAT = "o";

        private static string _dateTimeFormat = ISO8601_DATETIME_FORMAT;

        public static String DateTimeFormat
        {
            get
            {
                return _dateTimeFormat;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _dateTimeFormat = ISO8601_DATETIME_FORMAT;
                    return;
                }
                _dateTimeFormat = value;
            }
        }

        public static String ToDebugReport()
        {
            String report = "C# SDK (IO.Swagger) Debug Report:\n";
            report += "    OS: " + Environment.OSVersion + "\n";
            report += "    .NET Framework Version: " + Assembly
                     .GetExecutingAssembly()
                     .GetReferencedAssemblies()
                     .Where(x => x.Name == "System.Core").First().Version.ToString()  + "\n";
            report += "    Version of the API: 1.0.0\n";
            report += "    SDK Package Version: 1.0.0\n";
  
            return report;
        }
    }
}
