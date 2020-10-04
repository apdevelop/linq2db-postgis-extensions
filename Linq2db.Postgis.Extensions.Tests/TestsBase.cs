using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Linq2db.Postgis.Extensions.Tests
{
    abstract class TestsBase
    {
        public static readonly int SRID_WGS_84 = 4326;

        public static readonly int SRID_WGS84_Web_Mercator = 3857;

        public PostGisTestDataConnection GetDbConnection()
        {
            // TODO: use temporary database
            var fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = AssemblyPath + ".config";
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var connectionString = configuration.ConnectionStrings.ConnectionStrings["postgistest"];

            return new PostGisTestDataConnection(connectionString.ProviderName, connectionString.ConnectionString);
        }

        private static string AssemblyPath
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetFullPath(path);
            }
        }
    }
}