using System;
using System.Configuration;
using System.IO;
using System.Reflection;

using LinqToDB;

namespace LinqToDBPostGisNpgsqlTypes.Tests
{
    public class TestsBase
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

        public void InsertTestData()
        {
            using (var db = GetDbConnection())
            {
                db.PostgisGeometries.Delete();

                var list = new[]
                {
                    "POINT(0 0)",
                    "POINT(10 20)",
                    "POINT(100 200)",
                    "SRID=3857;POINT(10 10)",
                    "SRID=3857;POINT(25 15)",
                };

                var id = 1;
                foreach (var ewkt in list)
                {
                    var geom = db.STGeomFromEWKT(ewkt);
                    db.Insert(new Entities.PostgisGeometryEntity
                    {
                        Id = id,
                        Geometry = geom,
                    });

                    id++;
                }
            }
        }
    }
}