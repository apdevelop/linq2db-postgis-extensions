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
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                // TODO: shared method
                const string wkt1 = "POINT(1 2)";
                db.Insert(new TestGeometryEntity(1, null));
                var smallc = db.TestGeometries.Where(g => g.Id == 1).Select(g => GeometryInput.STGeomFromText(wkt1).STBuffer(10)).Single();
                db.Update(new TestGeometryEntity(1, smallc));

                const string wkt2 = "POINT(1 2)";
                db.Insert(new TestGeometryEntity(2, null));
                var bigc = db.TestGeometries.Where(g => g.Id == 2).Select(g => GeometryInput.STGeomFromText(wkt2).STBuffer(20)).Single();
                db.Update(new TestGeometryEntity(2, bigc));

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
                // TODO: shared method
                const string wkt1 = "LINESTRING ( 2 0, 0 2 )";
                db.Insert(new TestGeometryEntity(1, null));
                var geometry1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => GeometryInput.STGeomFromText(wkt1)).Single();
                db.Update(new TestGeometryEntity(1, geometry1));

                const string wkt2 = "LINESTRING ( 0 0, 0 2 )";
                db.Insert(new TestGeometryEntity(2, null));
                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => GeometryInput.STGeomFromText(wkt2)).Single();
                db.Update(new TestGeometryEntity(2, geometry2));

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
                // TODO: shared method
                const string wkt1 = "LINESTRING(0 0, 10 10)";
                db.Insert(new TestGeometryEntity(1, null));
                var geometry1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => GeometryInput.STGeomFromText(wkt1)).Single();
                db.Update(new TestGeometryEntity(1, geometry1));

                const string wkt2 = "LINESTRING(0 0, 5 5, 10 10)";
                db.Insert(new TestGeometryEntity(2, null));
                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => GeometryInput.STGeomFromText(wkt2)).Single();
                db.Update(new TestGeometryEntity(2, geometry2));

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STEquals(geometry2)).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STReverse().STEquals(geometry2)).Single());
            }
        }

        [Test]
        public void TestSTIntersects()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                // TODO: shared method
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

        [Test]
        public void TestSTOrderingEquals()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                // TODO: shared method
                const string wkt1 = "LINESTRING(0 0, 10 10, 20 20)";
                db.Insert(new TestGeometryEntity(1, null));
                var geometry1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => GeometryInput.STGeomFromText(wkt1)).Single();
                db.Update(new TestGeometryEntity(1, geometry1));

                const string wkt2 = "LINESTRING(0 0, 10 10, 20 20)";
                db.Insert(new TestGeometryEntity(2, null));
                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => GeometryInput.STGeomFromText(wkt2)).Single();
                db.Update(new TestGeometryEntity(2, geometry2));

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STOrderingEquals(geometry2)).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STReverse().STOrderingEquals(geometry2)).Single());
            }
        }
    }
}