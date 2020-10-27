using System.Linq;

using LinqToDB;
using NUnit.Framework;
using NTSG = NetTopologySuite.Geometries;

using LinqToDBPostGisNetTopologySuite.Tests.Entities;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryProcessingTests : TestsBase
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
        public void TestSTCentroid()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "MULTIPOINT ( -1 0, -1 2, -1 3, -1 4, -1 7, 0 1, 0 3, 1 1, 2 0, 6 0, 7 8, 9 8, 10 6 )";
                db.Insert(new TestGeometryEntity(1, null));
                var geometry1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => GeometryInput.STGeomFromText(wkt1)).Single();
                db.Update(new TestGeometryEntity(1, geometry1));

                var centroid1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STCentroid())
                    .Single() as NTSG.Point;

                Assert.AreEqual(2.30769230769231, centroid1.X, 1.0E-12);
                Assert.AreEqual(3.30769230769231, centroid1.Y, 1.0E-12);
            }
        }

        [Test]
        public void TestSTConvexHull()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "GEOMETRYCOLLECTION( MULTILINESTRING((100 190,10 8),(150 10, 20 30)), MULTIPOINT(50 5, 150 30, 50 10, 10 10) )";
                db.Insert(new TestGeometryEntity(1, null));
                var geometry1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => GeometryInput.STGeomFromText(wkt1)).Single();
                db.Update(new TestGeometryEntity(1, geometry1));

                var convexHull1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STConvexHull().STAsText())
                    .Single();

                Assert.AreEqual("POLYGON((50 5,10 8,10 10,100 190,150 30,150 10,50 5))", convexHull1);
            }
        }

        [Test]
        public void TestSTDifference()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                // TODO: shared method
                const string wkt1 = "LINESTRING(50 100, 50 200)";
                db.Insert(new TestGeometryEntity(1, null));
                var geometry1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => GeometryInput.STGeomFromText(wkt1)).Single();
                db.Update(new TestGeometryEntity(1, geometry1));

                const string wkt2 = "LINESTRING(50 50, 50 150)";
                db.Insert(new TestGeometryEntity(2, null));
                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => GeometryInput.STGeomFromText(wkt2)).Single();
                db.Update(new TestGeometryEntity(2, geometry2));


                var difference = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STDifference(geometry2).STAsText())
                    .Single();

                Assert.AreEqual("LINESTRING(50 150,50 200)", difference);
            }
        }


        [Test]
        public void TestSTUnion()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                // TODO: shared method
                const string wkt1 = "POINT(1 2)";
                db.Insert(new TestGeometryEntity(1, null));
                var geometry1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => GeometryInput.STGeomFromText(wkt1)).Single();
                db.Update(new TestGeometryEntity(1, geometry1));

                const string wkt2 = "POINT(-2 3)";
                db.Insert(new TestGeometryEntity(2, null));
                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => GeometryInput.STGeomFromText(wkt2)).Single();
                db.Update(new TestGeometryEntity(2, geometry2));

                var union = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STUnion(geometry2).STAsText())
                    .Single();

                Assert.AreEqual("MULTIPOINT(1 2,-2 3)", union);
            }
        }
    }
}