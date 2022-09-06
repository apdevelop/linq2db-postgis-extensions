using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using LinqToDB;
using Npgsql;
using NUnit.Framework;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    /// <summary>
    /// Base class for tests with common code.
    /// </summary>
    [SetUpFixture]
    abstract class TestsBase
    {
        public Version CurrentVersion { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            NpgsqlConnection.GlobalTypeMapper.UseNetTopologySuite();

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                this.CurrentVersion = new Version(db.Select(() => VersionFunctions.PostGISLibVersion()));
            }

            this.Version300 = new Version("3.0.0");
            this.Version310 = new Version("3.1.0");
            this.Version320 = new Version("3.2.0");
        }

        protected const int SRID4326 = 4326;

        protected const int SRID3857 = 3857;

        #region PostGIS versions definitions

        /// <summary>
        /// PostGIS version 3.0.0
        /// </summary>
        public Version Version300 { get; private set; }

        /// <summary>
        /// PostGIS version 3.1.0
        /// </summary>
        public Version Version310 { get; private set; }

        /// <summary>
        /// PostGIS version 3.2.0
        /// </summary>
        public Version Version320 { get; private set; }

        #endregion

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
