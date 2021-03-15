using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSG = NetTopologySuite.Geometries.Geometry;

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
                    .Value(g => g.Geometry, () => GeometryConstructors.STCollect(
                        GeometryInput.STGeomFromText("POINT(1 2)"),
                        GeometryInput.STGeomFromText("POINT(-2 3)")))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STCollect(
                        GeometryInput.STGeomFromText("POINT(1 2)"),
                        GeometryInput.STGeomFromText("LINESTRING(0 0, 0 1, 1 0, 1 1, 0 0)")))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => GeometryConstructors.STCollect(
                        "POINT(1 2)",
                        "POINT(-2 3)"))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 4)
                    .Value(g => g.Geometry, () => GeometryConstructors.STCollect(
                        "CIRCULARSTRING(220268 150415,220227 150505,220227 150406)",
                        "CIRCULARSTRING(220227 150406,2220227 150407,220227 150406)"))
                    .Insert();

                var collected1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual("MULTIPOINT(1 2,-2 3)", collected1);

                var collected2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual("GEOMETRYCOLLECTION(POINT(1 2),LINESTRING(0 0,0 1,1 0,1 1,0 0))", collected2);

                Assert.AreEqual(
                    "MULTIPOINT(1 2,-2 3)",
                    db.TestGeometries
                        .Where(g => g.Id == 3)
                        .Select(g => g.Geometry.STAsText())
                        .Single());

                // Converting to WKT using STAsText to avoid 'Geometry type not recognized. GeometryCode: 11' error.
                Assert.AreEqual(
                    "MULTICURVE(CIRCULARSTRING(220268 150415,220227 150505,220227 150406),CIRCULARSTRING(220227 150406,2220227 150407,220227 150406))",
                    db.TestGeometries
                        .Where(g => g.Id == 4)
                        .Select(g => g.Geometry.STAsText())
                        .Single());
            }
        }

        [Test]
        public void TestSTLineFromMultiPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STLineFromMultiPoint(GeometryInput.STGeomFromText("MULTIPOINT(1 2 3, 4 5 6, 7 8 9)")))
                    .Insert();

                Assert.AreEqual(
                    "LINESTRING(1 2 3,4 5 6,7 8 9)",
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STLineFromMultiPoint("MULTIPOINT(1 2 3, 4 5 6, 7 8 9)"))
                    .Insert();

                Assert.AreEqual(
                    "LINESTRING(1 2 3,4 5 6,7 8 9)",
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());
            }
        }

        [Test]
        public void TestSTMakeEnvelope()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakeEnvelope(10, 10, 11, 11, SRID4326))
                    .Insert();

                Assert.AreEqual(
                    "SRID=4326;POLYGON((10 10,10 11,11 11,11 10,10 10))",
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakeEnvelope(10, 10, 11, 11))
                    .Insert();

                Assert.AreEqual(
                    "POLYGON((10 10,10 11,11 11,11 10,10 10))",
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());
            }
        }

        [Test]
        public void TestSTMakeLine()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () =>
                        GeometryInput.STGeomFromText("POINT(1 2)")
                            .STMakeLine(GeometryInput.STGeomFromText("POINT(3 4)")))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakeLine(
                        GeometryInput.STGeomFromText("LINESTRING(0 0, 1 1)"),
                        GeometryInput.STGeomFromText("LINESTRING(2 2, 3 3)")))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakeLine(
                        "LINESTRING(0 0, 1 1)",
                        "LINESTRING(2 2, 3 3)"))
                    .Insert();

                Assert.AreEqual(
                    "LINESTRING(1 2,3 4)",
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STAsText())
                        .Single());

                Assert.AreEqual(
                    "LINESTRING(0 0,1 1,2 2,3 3)",
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STAsText())
                        .Single());

                Assert.AreEqual(
                    "LINESTRING(0 0,1 1,2 2,3 3)",
                    db.TestGeometries
                        .Where(g => g.Id == 3)
                        .Select(g => g.Geometry.STAsText())
                        .Single());

                Assert.IsNull(db.Select(() => GeometryConstructors.STMakeLine((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestSTMakePoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePoint(-71.1043443253471, 42.3150676015829))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePoint(1, 2, 1.5))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePoint(10, 20, 30, -999))
                    .Insert();

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
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePointM(10, 20, -999))
                    .Insert();

                var point1 = db.TestGeometries.Where(g => g.Id == 1);
                Assert.AreEqual(10, point1.Select(g => g.Geometry.STX()).Single(), 0.1);
                Assert.AreEqual(20, point1.Select(g => g.Geometry.STY()).Single(), 0.1);
                Assert.AreEqual(-999, point1.Select(g => g.Geometry.STM()).Single(), 0.1);
            }
        }

        [Test]
        public void TestSTMakePolygon()
        {
            const string Wkt1 = "LINESTRING(75.15 29.53 1,77 29 1,77.6 29.5 1, 75.15 29.53 1)";
            const string Wkt2 = "LINESTRINGM(75.15 29.53 1,77 29 1,77.6 29.5 2, 75.15 29.53 2)";

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePolygon(GeometryInput.STGeomFromText(Wkt1)))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePolygon(GeometryInput.STGeomFromText(Wkt2)))
                    .Insert();

                Assert.AreEqual("POLYGON((75.15 29.53 1,77 29 1,77.6 29.5 1,75.15 29.53 1))",
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());

                Assert.AreEqual("POLYGONM((75.15 29.53 1,77 29 1,77.6 29.5 2,75.15 29.53 2))",
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());
            }
        }

        [Test]
        public void TestSTPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STPoint(-71.104, 42.315))
                    .Insert();

                var point1 = db.TestGeometries.Where(g => g.Id == 1);
                Assert.AreEqual(-71.104, point1.Select(g => g.Geometry.STX()).Single(), 0.001);
                Assert.AreEqual(42.315, point1.Select(g => g.Geometry.STY()).Single(), 0.001);
            }
        }

        [Test]
        public void TestSTPolygon()
        {
            const string Wkt1 = "LINESTRING(75 29, 77 29, 77 29, 75 29)";
            const string Wkt2 = "LINESTRING(75 29 1, 77 29 2, 77 29 3, 75 29 1)";

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STPolygon(GeometryInput.STGeomFromText(Wkt1), SRID4326))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STPolygon(GeometryInput.STGeomFromText(Wkt2), SRID4326))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => GeometryConstructors.STPolygon(Wkt1, SRID4326))
                    .Insert();

                Assert.AreEqual(
                    "POLYGON((75 29,77 29,77 29,75 29))",
                    db.TestGeometries.Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STAsText())
                        .Single());

                Assert.AreEqual(
                    "SRID=4326;POLYGON((75 29 1,77 29 2,77 29 3,75 29 1))",
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());

                Assert.AreEqual(
                    "POLYGON((75 29,77 29,77 29,75 29))",
                    db.TestGeometries.Where(g => g.Id == 3)
                        .Select(g => g.Geometry.STAsText())
                        .Single());
            }
        }

        [Test]
        public void TestSTTileEnvelope()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STTileEnvelope(2, 1, 1))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STTileEnvelope(3, 1, 1, GeometryConstructors.STMakeEnvelope(-180, -90, 180, 90, SRID4326)))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => GeometryConstructors.STTileEnvelope(2, 1, 1, "SRID=3857;LINESTRING(-20037508.342789 -20037508.342789,20037508.342789 20037508.342789)"))
                    .Insert();

                var result1 = db.TestGeometries.Where(g => g.Id == 1);
                Assert.AreEqual("POLYGON((-10018754.1713945 0,-10018754.1713945 10018754.1713945,0 10018754.1713945,0 0,-10018754.1713945 0))",
                    result1.Select(g => g.Geometry.STAsText()).Single());
                Assert.AreEqual(SRID3857,
                    result1.Select(g => g.Geometry.STSrId()).Single());

                var result2 = db.TestGeometries.Where(g => g.Id == 2);
                Assert.AreEqual("POLYGON((-135 45,-135 67.5,-90 67.5,-90 45,-135 45))",
                    result2.Select(g => g.Geometry.STAsText()).Single());
                Assert.AreEqual(SRID4326,
                    result2.Select(g => g.Geometry.STSrId()).Single());

                var result3 = db.TestGeometries.Where(g => g.Id == 3);
                Assert.AreEqual("POLYGON((-10018754.1713945 0,-10018754.1713945 10018754.1713945,0 10018754.1713945,0 0,-10018754.1713945 0))",
                    result3.Select(g => g.Geometry.STAsText()).Single());
                Assert.AreEqual(SRID3857,
                    result3.Select(g => g.Geometry.STSrId()).Single());
            }
        }
    }
}
