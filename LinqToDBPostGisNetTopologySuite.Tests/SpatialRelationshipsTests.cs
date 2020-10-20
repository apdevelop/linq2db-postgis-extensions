using System.Linq;

using LinqToDB;
using NUnit.Framework;
using NTSG = NetTopologySuite.Geometries;

using LinqToDBPostGisNetTopologySuite.Tests.Entities;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class SpatialRelationshipsTests : TestsBase
    {
        [SetUp]
        public void Setup()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Delete();
            }
        }

        [Test]
        public void TestSTCovers()
        {
            // https://postgis.net/docs/manual-3.0/ST_Covers.html

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT(1 2)";
                db.Insert(new TestGeometryEntity(1, null));
                var smallc = db.TestGeometries.Where(g => g.Id == 1).Select(g => GeometryInput.STGeomFromText(wkt1).STBuffer(10)).Single();
                db.Update(new TestGeometryEntity(1, smallc));

                const string wkt2 = "POINT(1 2)";
                db.Insert(new TestGeometryEntity(2, null));
                var bigc = db.TestGeometries.Where(g => g.Id == 2).Select(g => GeometryInput.STGeomFromText(wkt2).STBuffer(20)).Single();
                db.Update(new TestGeometryEntity(2, bigc));

                var point = new NTSG.Point(new NTSG.Coordinate(0, 0));

                var covers1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCovers(smallc)).Single();
                Assert.IsTrue(covers1);

                var covers2 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCovers(bigc)).Single();
                Assert.IsFalse(covers2);

                var covers3 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STCovers(bigc.STExteriorRing())).Single();
                Assert.IsTrue(covers3);

                var covers4 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STContains(bigc.STExteriorRing())).Single();
                Assert.IsFalse(covers4);
            }
        }

        [Test]
        public void TestSTIntersects()
        {
            // https://postgis.net/docs/manual-3.0/ST_Intersects.html

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING ( 2 0, 0 2 )";
                db.Insert(new TestGeometryEntity(1, null));
                var geometry1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => GeometryInput.STGeomFromText(wkt1)).Single();
                db.Update(new TestGeometryEntity(1, geometry1));

                const string wkt2 = "LINESTRING ( 0 0, 0 2 )";
                db.Insert(new TestGeometryEntity(2, null));
                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => GeometryInput.STGeomFromText(wkt2)).Single();
                db.Update(new TestGeometryEntity(2, geometry2));

                var point = new NTSG.Point(new NTSG.Coordinate(0, 0));

                var intersects1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIntersects(point)).Single();
                var intersects2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIntersects(point)).Single();

                Assert.IsFalse(intersects1);
                Assert.IsTrue(intersects2);
            }
        }
    }
}