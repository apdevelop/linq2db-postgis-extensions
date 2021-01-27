using System.Linq;

using LinqToDB;
using Npgsql;
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

        [Test]
        public void TestPopulateGeometryColumns()
        {
            var expectedConstrainNames = new[] { "enforce_dims_geom", "enforce_geotype_geom", "enforce_srid_geom", };
            var expectedCheckClause = new[] { "((st_ndims(geom) = 3))", "((geometrytype(geom) = 'LINESTRING'::text))", "((st_srid(geom) = 4326))" };

            //insert geometry data for populating then get table oid
            int oid = 0;
            using (var conn = new NpgsqlConnection(TestDatabaseConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO test_geometry_ddl(id,geom) VALUES(1,ST_GeomFromText('LINESTRING(1 2 1, 3 4 1)',4326) );";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "select oid::int4 from pg_class where oid = 'test_geometry_ddl'::regclass";
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    oid = reader.GetInt32(0);
                }
            }

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.Select(() => TableManagementFunctions.PopulateGeometryColumns(oid, false));
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandText = @"SELECT
                            	tc.table_schema,
                            	tc.TABLE_NAME,
                            	string_agg ( col.COLUMN_NAME, ', ' ) AS COLUMNS,
                            	tc.CONSTRAINT_NAME,
                            	cc.check_clause 
                            FROM
                            	information_schema.table_constraints tc
                            	JOIN information_schema.check_constraints cc ON tc.CONSTRAINT_SCHEMA = cc.CONSTRAINT_SCHEMA 
                            	AND tc.CONSTRAINT_NAME = cc.
                            	CONSTRAINT_NAME JOIN pg_namespace nsp ON nsp.nspname = cc.
                            	CONSTRAINT_SCHEMA JOIN pg_constraint pgc ON pgc.conname = cc.CONSTRAINT_NAME 
                            	AND pgc.connamespace = nsp.oid 
                            	AND pgc.contype = 'c'
                            	JOIN information_schema.COLUMNS col ON col.table_schema = tc.table_schema 
                            	AND col.TABLE_NAME = tc.TABLE_NAME 
                            	AND col.ordinal_position = ANY ( pgc.conkey ) 
                            WHERE
                            	tc.CONSTRAINT_SCHEMA NOT IN ( 'pg_catalog', 'information_schema' ) and tc.TABLE_NAME = 'test_geometry_ddl' 
                            GROUP BY
                            	tc.table_schema,
                            	tc.TABLE_NAME,
                            	tc.CONSTRAINT_NAME,
                            	cc.check_clause 
                            ORDER BY
                            	tc.table_schema,
                            	tc.TABLE_NAME";
                    var reader = cmd.ExecuteReader();
                    int constraintCount = 0;
                    while (reader.Read())
                    {
                        var constraintName = reader.GetString(3);
                        var check = reader.GetString(4);

                        Assert.True(expectedConstrainNames.Contains(constraintName));
                        Assert.True(expectedCheckClause.Contains(check));
                        constraintCount++;
                    }
                    Assert.AreEqual(3, constraintCount);
                }
            }
        }

        [Test]
        public void TestUpdateGeometrySRID()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var updateGeomText = db.Select(() => TableManagementFunctions.UpdateGeometrySRID("test_geometry_ddl", "geom", 4326));

                var srid = db.Select(() => TableManagementFunctions.FindSrid("public", "test_geometry_ddl", "geom"));
                Assert.AreEqual(4326, srid.GetValueOrDefault());
            }
        }

        [Test]
        public void TestUpdateGeometrySRIDSchema()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var updateGeomText = db.Select(() => TableManagementFunctions.UpdateGeometrySRID("public", "test_geometry_ddl", "geom", 4326));
                var srid = db.Select(() => TableManagementFunctions.FindSrid("public", "test_geometry_ddl", "geom"));

                Assert.AreEqual(4326, srid.GetValueOrDefault());
            }
        }

        [Test]
        public void TestUpdateGeometrySRIDCatalog()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var updateGeomText = db.Select(() => TableManagementFunctions.UpdateGeometrySRID("postgistest", "public", "test_geometry_ddl", "geom", 4326));
                var srid = db.Select(() => TableManagementFunctions.FindSrid("public", "test_geometry_ddl", "geom"));

                Assert.AreEqual(4326, srid.GetValueOrDefault());
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