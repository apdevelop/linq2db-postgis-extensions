using System.Linq;

using LinqToDB;
using NUnit.Framework;
using NTSG = NetTopologySuite.Geometries;

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
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT(1 2)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1).STBuffer(10)).Insert();
                var smallc = db.TestGeometries.Single(g => g.Id == 1).Geometry;
                const string wkt2 = "POINT(1 2)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2).STBuffer(20)).Insert();
                var bigc = db.TestGeometries.Single(g => g.Id == 2).Geometry;

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCovers(smallc)).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCovers(bigc)).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STCovers(bigc.STExteriorRing())).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STContains(bigc.STExteriorRing())).Single());

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCoveredBy(smallc)).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCoveredBy(bigc)).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STExteriorRing().STCoveredBy(bigc)).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STExteriorRing().STWithin(bigc)).Single());
            }
        }

        [Test]
        public void TestSTDisjoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING ( 2 0, 0 2 )";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "LINESTRING ( 0 0, 0 2 )";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var point = new NTSG.Point(new NTSG.Coordinate(0, 0));
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STDisjoint(point)).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STDisjoint(point)).Single());
            }
        }

        [Test]
        public void TestSTEquals()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(0 0, 10 10)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "LINESTRING(0 0, 5 5, 10 10)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Single().Geometry;
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STEquals(geometry2)).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STReverse().STEquals(geometry2)).Single());
            }
        }

        [Test]
        public void TestSTIntersects()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING ( 2 0, 0 2 )";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "LINESTRING ( 0 0, 0 2 )";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var point = new NTSG.Point(new NTSG.Coordinate(0, 0));

                var intersects1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIntersects(point)).Single();
                var intersects2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIntersects(point)).Single();

                Assert.IsFalse(intersects1);
                Assert.IsTrue(intersects2);
            }
        }

        [Test]
        public void TestSTOrderingEquals()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(0 0, 10 10, 20 20)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "LINESTRING(0 0, 10 10, 20 20)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var geometry2 = db.TestGeometries.Single(g => g.Id == 2).Geometry;
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STOrderingEquals(geometry2)).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STReverse().STOrderingEquals(geometry2)).Single());
            }
        }
    }
}