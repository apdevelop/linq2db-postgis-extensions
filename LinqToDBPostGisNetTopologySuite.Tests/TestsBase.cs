using System;
using System.Configuration;
using System.IO;
using System.Reflection;

using Npgsql;
using NUnit.Framework;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [SetUpFixture]
    abstract class TestsBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            NpgsqlConnection.GlobalTypeMapper.UseNetTopologySuite();
        }

        protected const int SRID4326 = 4326;

        protected const int SRID3857 = 3857;

        protected static string TestDatabaseConnectionString
        {
            get
            {
                var fileMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = AssemblyPath + ".config"
                };

                var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                var connectionString = configuration.ConnectionStrings.ConnectionStrings["postgistest"].ConnectionString;

                return connectionString;
            }
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