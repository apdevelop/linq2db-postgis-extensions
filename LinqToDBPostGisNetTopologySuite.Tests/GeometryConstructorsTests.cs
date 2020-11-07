using System.Linq;

using LinqToDB;
using NUnit.Framework;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryConstructorsTests : TestsBase
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
        public void TestSTCollect()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryConstructors.STCollect(
                        GeometryInput.STGeomFromText("POINT(1 2)"),
                        GeometryInput.STGeomFromText("POINT(-2 3)")))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(p => p.Geometry, () => GeometryConstructors.STCollect(
                        GeometryInput.STGeomFromText("POINT(1 2)"),
                        GeometryInput.STGeomFromText("LINESTRING(0 0, 0 1, 1 0, 1 1, 0 0)")))
                    .Insert();

                var collected1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual("MULTIPOINT(1 2,-2 3)", collected1);

                var collected2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual("GEOMETRYCOLLECTION(POINT(1 2),LINESTRING(0 0,0 1,1 0,1 1,0 0))", collected2);
            }
        }

        [Test]
        public void TestSTLineFromMultiPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryConstructors.STLineFromMultiPoint(
                        GeometryInput.STGeomFromText("MULTIPOINT(1 2 3, 4 5 6, 7 8 9)")))
                    .Insert();

                var line1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("LINESTRING(1 2 3,4 5 6,7 8 9)", line1);
            }
        }

        [Test]
        public void TestSTMakeEnvelope()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryConstructors.STMakeEnvelope(10, 10, 11, 11, SRID4326)).Insert();
                var envelope1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("SRID=4326;POLYGON((10 10,10 11,11 11,11 10,10 10))", envelope1);

                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryConstructors.STMakeEnvelope(10, 10, 11, 11)).Insert();
                var envelope2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("POLYGON((10 10,10 11,11 11,11 10,10 10))", envelope2);
            }
        }


        [Test]
        public void TestSTMakeLine()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryConstructors.STMakeLine(
                        GeometryInput.STGeomFromText("POINT(1 2)"),
                        GeometryInput.STGeomFromText("POINT(3 4)")))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(p => p.Geometry, () => GeometryConstructors.STMakeLine(
                        GeometryInput.STGeomFromText("LINESTRING(0 0, 1 1)"),
                        GeometryInput.STGeomFromText("LINESTRING(2 2, 3 3)")))
                    .Insert();

                var line1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual("LINESTRING(1 2,3 4)", line1);

                var line2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual("LINESTRING(0 0,1 1,2 2,3 3)", line2);
            }
        }

        [Test]
        public void TestSTMakePoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryConstructors.STMakePoint(-71.1043443253471, 42.3150676015829)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryConstructors.STMakePoint(1, 2, 1.5)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => GeometryConstructors.STMakePoint(10, 20, 30, -999)).Insert();

                var point1 = db.TestGeometries.Where(g => g.Id == 1);
                Assert.AreEqual(-71.1043443253471, point1.Select(g => g.Geometry.STX()).Single(), 0.0000000000001);
                Assert.AreEqual(42.3150676015829, point1.Select(g => g.Geometry.STY()).Single(), 0.0000000000001);

                var point2 = db.TestGeometries.Where(g => g.Id == 2);
                Assert.AreEqual(1, point2.Select(g => g.Geometry.STX()).Single(), 0.1);
                Assert.AreEqual(2, point2.Select(g => g.Geometry.STY()).Single(), 0.1);
                Assert.AreEqual(1.5, point2.Select(g => g.Geometry.STZ()).Single(), 0.1);

                var point3 = db.TestGeometries.Where(g => g.Id == 3);
                Assert.AreEqual(10, point3.Select(g => g.Geometry.STX()).Single(), 0.1);
                Assert.AreEqual(20, point3.Select(g => g.Geometry.STY()).Single(), 0.1);
                Assert.AreEqual(30, point3.Select(g => g.Geometry.STZ()).Single(), 0.1);
                Assert.AreEqual(-999, point3.Select(g => g.Geometry.STM()).Single(), 0.1);
            }
        }

        [Test]
        public void TestSTMakePointM()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryConstructors.STMakePointM(10, 20, -999)).Insert();

                var point1 = db.TestGeometries.Where(g => g.Id == 1);
                Assert.AreEqual(10, point1.Select(g => g.Geometry.STX()).Single(), 0.1);
                Assert.AreEqual(20, point1.Select(g => g.Geometry.STY()).Single(), 0.1);
                Assert.AreEqual(-999, point1.Select(g => g.Geometry.STM()).Single(), 0.1);
            }
        }
    }
}