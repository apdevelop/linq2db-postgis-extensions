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
            }
        }
    }
}
