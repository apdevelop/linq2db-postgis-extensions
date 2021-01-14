using System.Linq;

using LinqToDB;
using NUnit.Framework;
using NTSG = NetTopologySuite.Geometries;

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
        public void TestSTBuffer()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var pt1 = db.Select(() => GeometryInput.STGeomFromText("POINT(100 90)"));
                var buffer1 = db.Select(() => GeometryProcessing.STBuffer(pt1, 50, "quad_segs=8").STGeometryType());
                Assert.AreEqual("ST_Polygon", buffer1);

                var buffer2 = db.Select(() => GeometryProcessing.STBuffer(pt1, 50).STNPoints());
                Assert.AreEqual(33, buffer2);

                var buffer3 = db.Select(() => GeometryProcessing.STBuffer(pt1, 50, 2).STNPoints());
                Assert.AreEqual(9, buffer3);

                Assert.IsNull(db.Select(() => GeometryProcessing.STBuffer(null, 0)));
                Assert.IsNull(db.Select(() => GeometryProcessing.STBuffer(null, 0, null)));
            }
        }

        [Test]
        public void TestSTCentroid()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "MULTIPOINT ( -1 0, -1 2, -1 3, -1 4, -1 7, 0 1, 0 3, 1 1, 2 0, 6 0, 7 8, 9 8, 10 6 )";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();

                var centroid1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCentroid()).Single() as NTSG.Point;

                Assert.AreEqual(2.30769230769231, centroid1.X, 1.0E-12);
                Assert.AreEqual(3.30769230769231, centroid1.Y, 1.0E-12);
            }
        }

        [Test]
        public void TestSTClipByBox2D()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var geom1 = db.Select(() => GeometryInput.STGeomFromText("LINESTRING(0 0, 20 20)"));
                var box1 = db.Select(() => GeometryConstructors.STMakeEnvelope(0, 0, 10, 10));

                var clipped1 = db.Select(() => GeometryProcessing.STClipByBox2D(geom1, box1).STAsText());
                Assert.AreEqual("LINESTRING(0 0,10 10)", clipped1);

                Assert.IsNull(db.Select(() => GeometryProcessing.STClipByBox2D(null, null)));
            }
        }

        [Test]
        public void TestSTConvexHull()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "GEOMETRYCOLLECTION( MULTILINESTRING((100 190,10 8),(150 10, 20 30)), MULTIPOINT(50 5, 150 30, 50 10, 10 10) )";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();

                var convexHull1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STConvexHull().STAsText()).Single();

                Assert.AreEqual("POLYGON((50 5,10 8,10 10,100 190,150 30,150 10,50 5))", convexHull1);

                Assert.IsNull(db.Select(() => GeometryProcessing.STConvexHull(null)));
            }
        }

        [Test]
        public void TestSTCurveToLine()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "CIRCULARSTRING(0 0,100 -100,200 0)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                var result1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCurveToLine(20, 1, 1).STAsText()).Single();
                Assert.AreEqual("LINESTRING(0 0,50 -86.6025403784438,150 -86.6025403784439,200 0)", result1);

                Assert.IsNull(db.Select(() => GeometryProcessing.STCurveToLine(null, 20, 1, 1)));
            }
        }

        [Test]
        public void TestSTDelaunayTriangles()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POLYGON((175 150, 20 40, 50 60, 125 100, 175 150))";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                var result1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STDelaunayTriangles(0, 0).STAsText()).Single();
                Assert.AreEqual("GEOMETRYCOLLECTION(POLYGON((20 40,125 100,50 60,20 40)),POLYGON((50 60,125 100,175 150,50 60)))", result1);

                Assert.IsNull(db.Select(() => GeometryProcessing.STDelaunayTriangles(null, 0, 0)));
            }
        }

        [Test]
        public void TestSTDifference()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(50 100, 50 200)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();

                const string wkt2 = "LINESTRING(50 50, 50 150)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var geometry2 = db.TestGeometries.Single(g => g.Id == 2).Geometry;
                var difference = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STDifference(geometry2).STAsText()).Single();

                Assert.AreEqual("LINESTRING(50 150,50 200)", difference);
            }
        }

        [Test]
        public void TestSTFlipCoordinates()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var geom1 = db.Select(() => GeometryInput.STGeomFromText("POINT(1 2)"));

                var result1 = db.Select(() => GeometryProcessing.STFlipCoordinates(geom1).STAsText());
                Assert.AreEqual("POINT(2 1)", result1);

                Assert.IsNull(db.Select(() => GeometryProcessing.STFlipCoordinates(null)));
            }
        }

        [Test]
        public void TestSTGeneratePoints()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var geom1 = db.Select(() => GeometryInput.STGeomFromText("POLYGON((175 150, 20 40, 50 60, 125 100, 175 150))"));

                var result1 = db.Select(() => GeometryProcessing.STGeneratePoints(geom1, 5, 1).STAsText());
                Assert.AreEqual("MULTIPOINT(139.29283354478 118.602516148805,131.832615216622 108.222468996999,114.403606086077 103.400350731553,61.1688280123262 67.8262881638229,136.491955979797 111.749696268158)", result1);

                Assert.IsNull(db.Select(() => GeometryProcessing.STGeneratePoints(null, 1)));
            }
        }

        [Test]
        public void TestSTGeometricMedian()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "MULTIPOINT((0 0), (1 1), (2 2), (200 200))";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt)).Insert();

                var median = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STGeometricMedian())
                    .Single() as NTSG.Point;

                Assert.AreEqual(1.9761550281255, median.X, 1.0E-8);
                Assert.AreEqual(1.9761550281255, median.Y, 1.0E-8);
            }
        }

        [Test]
        public void TestSTLineToCurve()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "POINT(1 3)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () =>
                        GeometryInput.STGeomFromText(wkt).STBuffer(3.0))
                    .Insert();

                // NTS error: 'Geometry type not recognized. GeometryCode: 10'
                var curvePolygon = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STLineToCurve().STAsText())
                    .Single();

                Assert.AreEqual("CURVEPOLYGON(CIRCULARSTRING(4 3,-2 2.99999999999999,4 3))", curvePolygon);
            }
        }

        [Test]
        public void TestSTMakeValid()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(0 0,1 1)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1))
                    .Insert();

                const string wkt2 = "POLYGON((0 0, 1 1, 1 2, 1 1, 0 0))";
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2))
                    .Insert();

                var result1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STMakeValid().STAsText())
                    .Single();

                var result2 = db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STMakeValid().STAsText())
                    .Single();

                // Already-valid geometries are returned without further intervention:
                Assert.AreEqual(wkt1, result1);

                // Single polygons may become multi-geometries in case of self-intersections:
                Assert.AreEqual("MULTILINESTRING((0 0,1 1),(1 1,1 2))", result2);
            }
        }

        [Test]
        public void TestSTUnion()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT(1 2)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();

                const string wkt2 = "POINT(-2 3)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var geometry2 = db.TestGeometries.Single(g => g.Id == 2).Geometry;
                var union = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STUnion(geometry2).STAsText()).Single();

                Assert.AreEqual("MULTIPOINT(1 2,-2 3)", union);
            }
        }
    }
}
