using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class VersionFunctionsTests : TestsBase
    {
        [Test]
        public void TestPostGISFullVersion()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var fullVersion = db.Select(() => VersionFunctions.PostGISFullVersion());
                Assert.IsNotNull(fullVersion);

                // Just to see in test runner output
                Console.WriteLine(new String('-', 40));
                Console.WriteLine(fullVersion);
                Console.WriteLine(new String('-', 40));

                var geosVersion = db.Select(() => VersionFunctions.PostGISGEOSVersion());
                Console.WriteLine($"GEOS={geosVersion}");

                var liblwgeomVersion = db.Select(() => VersionFunctions.PostGISLiblwgeomVersion());
                Console.WriteLine($"liblwgeom={liblwgeomVersion}");

                var libXmlVersion = db.Select(() => VersionFunctions.PostGISLibXMLVersion());
                Console.WriteLine($"LibXML={libXmlVersion}");

                var libBuildDate = db.Select(() => VersionFunctions.PostGISLibBuildDate());
                Console.WriteLine($"PostGIS lib build date={libBuildDate}");

                var libVersion = db.Select(() => VersionFunctions.PostGISLibVersion());
                Console.WriteLine($"PostGIS lib version={libVersion}");

                var projVersion = db.Select(() => VersionFunctions.PostGISPROJVersion());
                Console.WriteLine($"PROJ4={projVersion}");

                var currentVersion = new Version(db.Select(() => VersionFunctions.PostGISLibVersion()));
                if (currentVersion >= new Version("3.0"))
                {
                    var wagyuVersion = db.Select(() => VersionFunctions.PostGISWagyuVersion());
                    Console.WriteLine($"Wagyu={wagyuVersion}");
                }

                var scriptsBuildDate = db.Select(() => VersionFunctions.PostGISScriptsBuildDate());
                Console.WriteLine($"PostGIS scripts build date={scriptsBuildDate}");

                var scripts = db.Select(() => VersionFunctions.PostGISScriptsInstalled());
                Console.WriteLine($"PostGIS scripts={scripts}");

                var postGisVersion = db.Select(() => VersionFunctions.PostGISVersion());
                Console.WriteLine($"PostGIS version={postGisVersion}");

                Console.WriteLine(new String('-', 40));
            }
        }
    }
}
