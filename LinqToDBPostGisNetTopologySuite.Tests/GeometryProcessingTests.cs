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
        public void TestSTMinimumBoundingCircle()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "LINESTRING(55 75,125 150)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () =>
                        GeometryConstructors.STCollect(
                            GeometryInput.STGeomFromText(wkt),
                            GeometryConstructors.STPoint(20, 80)))
                    .Insert();

                var geometry = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STAsText())
                    .Single();

                Assert.AreEqual("GEOMETRYCOLLECTION(LINESTRING(55 75,125 150),POINT(20 80))", geometry);

                // TODO: fix 'points must form a closed linestring'
                ////var circle = db.TestGeometries
                ////    .Where(g => g.Id == 1)
                ////    .Select(g => g.Geometry.STMinimumBoundingCircle(8))
                ////    .Single();

                //Assert.AreEqual(135.59714732062, circle.InteriorRings[0].GetPointN(0).X, 1.0E-8);
                //Assert.AreEqual(115, circle.InteriorRings[0].GetPointN(0).Y, 1.0E-8);
            }
        }

        [Test]
        public void TestSTOrientedEnvelope()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "MULTIPOINT ((0 0), (-1 -1), (3 2))";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(p => p.Geometry, () =>
                        GeometryConstructors.STCollect(
                                GeometryInput.STGeomFromText("LINESTRING(55 75,125 150)"),
                                GeometryConstructors.STPoint(20, 80)))
                    .Insert();

                var result1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STOrientedEnvelope().STAsText())
                    .Single();

                Assert.AreEqual("POLYGON((3 2,2.88 2.16,-1.12 -0.84,-1 -1,3 2))", result1);

                var result2 = db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STOrientedEnvelope())
                    .Single() as NTSG.Polygon;

                Assert.AreEqual(20, result2.ExteriorRing.GetPointN(0).X, 1.0E-8);
                Assert.AreEqual(80, result2.ExteriorRing.GetPointN(0).Y, 1.0E-8);
            }
        }

        [Test]
        public void TestSTNode()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "LINESTRINGZ(0 0 0, 10 10 10, 0 10 5, 10 0 3)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STNode().STAsText())
                    .Single();

                Assert.AreEqual("MULTILINESTRING Z ((0 0 0,5 5 4.5),(5 5 4.5,10 10 10,0 10 5,5 5 4.5),(5 5 4.5,10 0 3))", result);
            }
        }

        [Test]
        public void TestSTOffsetCurve()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = @"LINESTRING(164 16,144 16,124 16,104 16,84 16,64 16,
                                    44 16,24 16,20 16,18 16,17 17,
	                                16 18,16 20,16 40,16 60,16 80,16 100,
	                                16 120,16 140,16 160,16 180,16 195)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STOffsetCurve(15, "quad_segs=4 join=round").STAsText())
                    .Single();

                Assert.AreEqual("LINESTRING(164 1,18 1,12.2597485145237 2.1418070123307,7.39339828220179 5.39339828220179,5.39339828220179 7.39339828220179,2.14180701233067 12.2597485145237,1 18,1 195)", result);
            }
        }

        [Test]
        public void TestSTPointOnSurface()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING(0 5 1, 0 0 1, 0 10 2)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STPointOnSurface().STAsEWKT())
                    .Single();

                Assert.AreEqual("POINT(0 0 1)", result);
            }
        }

        [Test]
        public void TestSTRemoveRepeatedPoints()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "LINESTRING(0 5, 0 0, 0 0, 0 10)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRemoveRepeatedPoints(1).AsText())
                    .Single();

                Assert.AreEqual("LINESTRING (0 5, 0 0, 0 10)", result);
            }
        }

        [Test]
        public void TestSTSharedPaths()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "MULTILINESTRING((26 125,26 200,126 200,126 125,26 125),(51 150, 101 150, 76 175, 51 150))";
                const string wkt2 = "LINESTRING(151 100,126 156.25,126 125,90 161, 76 175)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1))
                    .Insert();
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STSharedPaths(db.TestGeometries.Where(g2 => g2.Id == 2).Single().Geometry).AsText())
                    .Single();

                Assert.AreEqual("GEOMETRYCOLLECTION (MULTILINESTRING ((126 156.25, 126 125), (101 150, 90 161), (90 161, 76 175)), MULTILINESTRING EMPTY)", result);
            }
        }

        [Test]
        public void TestSTShiftLongitude()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt1 = "SRID=4326;POINT(-118.58 38.38 10)";
                const string ewkt2 = "SRID=4326;POINT(241.42 38.38 10)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt1))
                    .Insert();
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt2))
                    .Insert();

                var result1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STShiftLongitude().STAsEWKT())
                    .Single();

                var result2 = db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STShiftLongitude().STAsEWKT())
                    .Single();

                Assert.AreEqual("SRID=4326;POINT(241.42 38.38 10)", result1);
                Assert.AreEqual("SRID=4326;POINT(-118.58 38.38 10)", result2);
            }
        }

        [Test]
        public void TestSTSimplify()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "POINT(1 3)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeometryFromText(wkt).STBuffer(10, 12))
                    .Insert();

                var result1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STNPoints())
                    .Single();

                Assert.AreEqual(49, result1);

                var result2 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STSimplify(0.1).STNPoints())
                    .Single();

                Assert.AreEqual(33, result2);

                var result3 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STSimplify(0.5).STNPoints())
                    .Single();

                Assert.AreEqual(17, result3);

                var result4 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STSimplify(1.0).STNPoints())
                    .Single();

                Assert.AreEqual(9, result4);

                var result5 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STSimplify(10.0).STNPoints())
                    .Single();

                Assert.AreEqual(4, result5);

                var result6 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STSimplify(100.0).STNPoints())
                    .Single();

                Assert.IsNull(result6);
            }
        }

        [Test]
        public void TestSTSimplifyPreserveTopology()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "POINT(1 3)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeometryFromText(wkt).STBuffer(10, 12))
                    .Insert();

                var result1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STNPoints())
                    .Single();

                Assert.AreEqual(49, result1);

                var result2 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STSimplifyPreserveTopology(1.0).STNPoints())
                    .Single();

                Assert.AreEqual(9, result2);

                var result3 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STSimplifyPreserveTopology(10.0).STNPoints())
                    .Single();

                Assert.AreEqual(5, result3);
            }
        }

        [Test]
        public void TestSTSimplifyVW()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "LINESTRING(5 2, 3 8, 6 20, 7 25, 10 10)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeometryFromText(wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STSimplifyVW(30).STAsText())
                    .Single();

                Assert.AreEqual("LINESTRING(5 2,7 25,10 10)", result);
            }
        }

        [Test]
        public void TestSTChaikinSmoothing()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "POLYGON((0 0, 8 8, 0 16, 0 0))";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeometryFromText(wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STChaikinSmoothing().STAsText())
                    .Single();

                Assert.AreEqual("POLYGON((2 2,6 6,6 10,2 14,0 12,0 4,2 2))", result);
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
