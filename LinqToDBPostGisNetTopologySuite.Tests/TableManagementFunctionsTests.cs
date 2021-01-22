using System.Linq;

using LinqToDB;
using NUnit.Framework;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class TableManagementFunctionsTests : TestsBase
    {
        [SetUp]
        public void Setup()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandText = @"
                    CREATE TABLE test_geometry_ddl( 
                         id   integer primary key,
                         geom geometry);";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        [Test]
        public void TestAddGeometryColumn()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var result = db.Select(() => TableManagementFunctions.AddGeometryColumn("test_geometry_ddl", "geom1", 4326, "POLYGON", 2, true));

                Assert.AreEqual("public.test_geometry_ddl.geom1 SRID:4326 TYPE:POLYGON DIMS:2 ", result);
            }
        }

        [Test]
        public void TestAddGeometryColumnWithSchema()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var result = db.Select(() => TableManagementFunctions.AddGeometryColumn("public", "test_geometry_ddl", "geom2", 4326, "POLYGON", 2, true));

                Assert.AreEqual("public.test_geometry_ddl.geom2 SRID:4326 TYPE:POLYGON DIMS:2 ", result);
            }
        }

        [Test]
        public void TestAddGeometryColumnWithCatalog()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var result = db.Select(() => TableManagementFunctions.AddGeometryColumn("postgistest", "public", "test_geometry_ddl", "geom3", 4326, "POLYGON", 2, true));

                Assert.AreEqual("public.test_geometry_ddl.geom3 SRID:4326 TYPE:POLYGON DIMS:2 ", result);
            }
        }

        [Test]
        public void TestDropGeometryColumn()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var result = db.Select(() => TableManagementFunctions.DropGeometryColumn("test_geometry_ddl", "geom"));

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandText = "select count(1) from information_schema.columns WHERE table_schema = 'public' and table_name = 'test_geometry_ddl' and column_name = 'geom';";
                    var countText = cmd.ExecuteScalar().ToString();

                    Assert.AreEqual("0", countText);
                }
            }
        }

        [Test]
        public void TestDropGeometryColumnSchema()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var result = db.Select(() => TableManagementFunctions.DropGeometryColumn("public", "test_geometry_ddl", "geom"));

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandText = "select count(1) from information_schema.columns WHERE table_schema = 'public' and table_name = 'test_geometry_ddl' and column_name = 'geom';";
                    var countText = cmd.ExecuteScalar().ToString();

                    Assert.AreEqual("0", countText);
                }
            }
        }

        [Test]
        public void TestDropGeometryColumnCatalog()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var result = db.Select(() => TableManagementFunctions.DropGeometryColumn("postgis", "public", "test_geometry_ddl", "geom"));

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandText = "select count(1) from information_schema.columns WHERE table_schema = 'public' and table_name = 'test_geometry_ddl' and column_name = 'geom';";
                    var countText = cmd.ExecuteScalar().ToString();

                    Assert.AreEqual("0", countText);
                }
            }
        }

        [Test]
        public void TestDropGeometryTable()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var result = db.SelectQuery(() => TableManagementFunctions.DropGeometryTable("test_geometry_ddl")).Single();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandText = @"
                    select count(*) from pg_class where relname = 'test_geometry_ddl';";
                    var tableCount = (long)cmd.ExecuteScalar();

                    Assert.AreEqual(0, tableCount);
                }
            }
        }

        [Test]
        public void TestDropGeometryTableSchema()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var result = db.SelectQuery(() => TableManagementFunctions.DropGeometryTable("public", "test_geometry_ddl")).Single();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandText = @"
                    select count(*) from pg_class where relname = 'test_geometry_ddl';";
                    var tableCount = (long)cmd.ExecuteScalar();

                    Assert.AreEqual(0, tableCount);
                }
            }
        }

        [Test]
        public void TestDropGeometryTableCatalog()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var result = db.SelectQuery(() => TableManagementFunctions.DropGeometryTable("postgistest", "public", "test_geometry_ddl")).Single();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandText = @"
                    select count(*) from pg_class where relname = 'test_geometry_ddl';";
                    var tableCount = (long)cmd.ExecuteScalar();

                    Assert.AreEqual(0, tableCount);
                }
            }
        }

        [Test]
        public void TestFindSrid()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var srid = db.Select(() => TableManagementFunctions.FindSrid("public", "test_geometry_ddl", "geom"));

                Assert.IsNotNull(srid);
                Assert.AreEqual(0, srid);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                using (var cmd = db.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "DROP TABLE test_geometry_ddl;";
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Exception)
                    {
                        //ignore
                    }
                }
            }
        }
    }
}