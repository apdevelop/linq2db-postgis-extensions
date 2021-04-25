using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSGS = NetTopologySuite.Geometries;
using NTSG = NetTopologySuite.Geometries.Geometry;

using LinqToDBPostGisNetTopologySuite.Tests.Entities;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class MeasurementFunctionsTests : TestsBase
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
        public void TestSTArea()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Ewkt1 = "SRID=2249;POLYGON((743238 2967416,743238 2967450, 743265 2967450,743265.625 2967416,743238 2967416))";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt1))
                    .Insert();

                const string Wkt2 = "LINESTRING(0 0, 1 1)";
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(Wkt2))
                    .Insert();
                db.TestGeometries
                    .Value(g => g.Id, 3)
                    .Value(p => p.Geometry, () => null)
                    .Insert();

                Assert.AreEqual(928.625, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STArea()).Single(), 1.0E-3);
                Assert.AreEqual(86.2724306, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STTransform(26986).STArea()).Single(), 1.0E-5);
                Assert.AreEqual(0.0, db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STArea()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STArea()).Single());

                Assert.AreEqual(928.625, db.Select(() => MeasurementFunctions.STArea(Ewkt1)), 1.0E-3);
                Assert.AreEqual(0.0, db.Select(() => MeasurementFunctions.STArea(Wkt2)));
            }
        }

        [Test]
        public void TestSTAzimuth()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var p1 = db.Select(() => GeometryConstructors.STPoint(25, 45));
                var p2 = db.Select(() => GeometryConstructors.STPoint(75, 100));

                var a1 = db.Select(() => MathematicalFunctions.Degrees(MeasurementFunctions.STAzimuth(p1, p2)));
                var a2 = db.Select(() => MathematicalFunctions.Degrees(MeasurementFunctions.STAzimuth(p2, p1)));

                Assert.AreEqual(42.2736890060937, a1, 1.0E-8);
                Assert.AreEqual(222.273689006094, a2, 1.0E-8);

                Assert.IsNull(db.Select(() => MeasurementFunctions.STAzimuth(p1, p1)));
                Assert.IsNull(db.Select(() => MeasurementFunctions.STAzimuth(p1, null)));
                Assert.IsNull(db.Select(() => MeasurementFunctions.STAzimuth(null, p1)));
                ////Assert.IsNull(db.Select(() => MeasurementFunctions.STAzimuth((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestSTAngle()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var p1 = db.Select(() => GeometryConstructors.STPoint(0, 0));
                var p2 = db.Select(() => GeometryConstructors.STPoint(100, 100));
                var p3 = db.Select(() => GeometryConstructors.STPoint(0, 0));
                var p4 = db.Select(() => GeometryConstructors.STPoint(100, 0));

                var a1 = db.Select(() => MathematicalFunctions.Degrees(MeasurementFunctions.STAngle(p1, p2, p3, p4)));
                Assert.AreEqual(45, a1, 1.0E-8);

                var a2 = db.Select(() => MathematicalFunctions.Degrees(MeasurementFunctions.STAngle(p2, p1, p4)));
                Assert.AreEqual(45, a2, 1.0E-8);

                Assert.IsNull(db.Select(() => MeasurementFunctions.STAngle(p1, p1, p1, p1)));
            }
        }

        [Test]
        public void TestSTClosestPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string PointWkt = "POINT(100 100)";
                const string LineWkt = "LINESTRING (20 80, 98 190, 110 180, 50 75)";

                var point = db.Select(() => GeometryInput.STPointFromText(PointWkt));
                var line = db.Select(() => GeometryInput.STLineFromText(LineWkt));

                var p1 = db.Select(() => MeasurementFunctions.STClosestPoint(point, line).STAsText());
                var p2 = db.Select(() => MeasurementFunctions.STClosestPoint(line, point)) as NTSGS.Point;

                Assert.AreEqual("POINT(100 100)", p1);
                Assert.AreEqual(73.0769230769231, p2.X, 1.0E-9);
                Assert.AreEqual(115.384615384615, p2.Y, 1.0E-9);

                Assert.AreEqual(
                    "POINT(100 100)",
                    db.Select(() => MeasurementFunctions.STClosestPoint(PointWkt, LineWkt).STAsText()));

                Assert.IsNull(db.Select(() => MeasurementFunctions.STClosestPoint((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestST3DClosestPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string PointWkt = "POINT(100 100 30)";
                const string LineWkt = "LINESTRING (20 80 20, 98 190 1, 110 180 3, 50 75 1000)";

                var point = db.Select(() => GeometryInput.STPointFromText(PointWkt));
                var line = db.Select(() => GeometryInput.STLineFromText(LineWkt));

                var point1 = db.Select(() => MeasurementFunctions.ST3DClosestPoint(line, point)) as NTSGS.Point;
                var point2 = db.Select(() => MeasurementFunctions.STClosestPoint(line, point)) as NTSGS.Point;

                Assert.AreEqual(54.6993798867619, point1.X, 1.0E-9);
                Assert.AreEqual(128.935022917228, point1.Y, 1.0E-9);
                Assert.AreEqual(11.5475869506606, point1.Z, 1.0E-9);

                Assert.AreEqual(73.0769230769231, point2.X, 1.0E-9);
                Assert.AreEqual(115.384615384615, point2.Y, 1.0E-9);

                Assert.AreEqual(
                    54.6993798867619,
                    db.Select(() => MeasurementFunctions.ST3DClosestPoint(LineWkt, PointWkt).STX()),
                    1.0E-9);

                Assert.IsNull(db.Select(() => MeasurementFunctions.ST3DClosestPoint((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestSTDistance()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var point = new NTSGS.Point(new NTSGS.Coordinate(-72.1235, 42.3521)) { SRID = SRID4326 };
                db.Insert(new TestGeometryEntity(1, point));

                var lineString = new NTSGS.LineString(new[] { new NTSGS.Coordinate(-72.1260, 42.45), new NTSGS.Coordinate(-72.123, 42.1546) }) { SRID = SRID4326 };
                db.Insert(new TestGeometryEntity(2, lineString));

                // Geometry example - units in planar degrees 4326 is WGS 84 long lat, units are degrees.
                var distances4326 = db.TestGeometries
                    .Select(g => g.Geometry.STDistance(point))
                    .ToList();

                Assert.AreEqual(2, distances4326.Count);
                Assert.AreEqual(0.0, distances4326[0]);
                Assert.AreEqual(0.00150567726382822, distances4326[1], 1.0E-9);

                // Geometry example - units in meters (SRID:3857, proportional to pixels on popular web maps).
                var distances3857 = db.TestGeometries
                    .Select(g => g.Geometry.STTransform(SRID3857).STDistance(point.STTransform(SRID3857)))
                    .ToList();

                Assert.AreEqual(2, distances3857.Count);
                Assert.AreEqual(0.0, distances3857[0]);
                Assert.AreEqual(167.441410065196, distances3857[1], 1.0E-9);

                var nullDistance = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STDistance(null))
                    .Single();
                Assert.IsNull(nullDistance);

                Assert.AreEqual(
                    0.00150567726382282,
                    db.Select(() => MeasurementFunctions.STDistance(
                        "SRID=4326;POINT(-72.1235 42.3521)",
                        "SRID=4326;LINESTRING(-72.1260 42.45, -72.123 42.1546)")),
                    1.0E-12);

                Assert.IsNull(db.Select(() => MeasurementFunctions.STDistance((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestST3DDistance()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                Assert.AreEqual(
                    1.732,
                    db.Select(() => MeasurementFunctions.ST3DDistance(
                        "POINT(0 0 0)",
                        "POINT(1 1 1)")),
                    1.0E-3);

                Assert.IsNull(db.Select(() => MeasurementFunctions.ST3DDistance((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestSTDistanceSphere()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var point = db.Select(() => GeometryInput.STGeomFromText("POINT(-118 38)", SRID4326));
                var geom = db.Select(() => GeometryInput.STGeomFromText("LINESTRING(-118.584 38.374,-118.583 38.5)", SRID4326));

                var dist_meters = db.Select(() => geom.STCentroid().STDistanceSphere(point));
                var dist_utm11_meters = db.Select(() => geom.STCentroid().STTransform(32611).STDistance(point.STTransform(32611)));
                var dist_degrees = db.Select(() => geom.STCentroid().STDistance(point));
                var min_dist_line_point_meters = db.Select(() => geom.STTransform(32611).STDistance(point.STTransform(32611)));

                Assert.AreEqual(70424.71, dist_meters, 0.01);
                Assert.AreEqual(70438.00, dist_utm11_meters, 0.01);
                Assert.AreEqual(0.72900, dist_degrees, 0.00001);
                Assert.AreEqual(65871.18, min_dist_line_point_meters, 0.01);

                Assert.AreEqual(
                    111195.07973463,
                    db.Select(() => MeasurementFunctions.STDistanceSphere(
                        "SRID=4326;POINT(0 0)",
                        "SRID=4326;POINT(0 1)")),
                    1.0E-6);

                Assert.IsNull(db.Select(() => MeasurementFunctions.STDistanceSphere((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestSTDistanceSpheroid()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Spheroid = "SPHEROID[\"WGS 84\",6378137,298.257223563]";
                var point = db.Select(() => GeometryInput.STGeomFromText("POINT(-118 38)", SRID4326));
                var geom = db.Select(() => GeometryInput.STGeomFromText("LINESTRING(-118.584 38.374,-118.583 38.5)", SRID4326));

                var dist_meters_spheroid = db.Select(() => geom.STCentroid().STDistanceSpheroid(point, Spheroid));
                var dist_meters_sphere = db.Select(() => geom.STCentroid().STDistanceSphere(point));
                var dist_utm11_meters = db.Select(() => geom.STCentroid().STTransform(32611).STDistance(point.STTransform(32611)));

                Assert.AreEqual(70454.92, dist_meters_spheroid, 0.01);
                Assert.AreEqual(70424.71, dist_meters_sphere, 0.01);
                Assert.AreEqual(70438.00, dist_utm11_meters, 0.01);

                Assert.AreEqual(
                    4434.73734584354,
                    db.Select(() => MeasurementFunctions.STDistanceSpheroid(
                        "SRID=4326;POINT(120.08 30.96)",
                        "SRID=4326;POINT(120.08 30.92)",
                        Spheroid)),
                    1.0E-8);

                Assert.IsNull(db.Select(() => MeasurementFunctions.STDistanceSpheroid((NTSG)null, (NTSG)null, Spheroid)));
            }
        }

        [Test]
        public void TestSTFrechetDistance()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING (0 0, 100 0)";
                const string Wkt2 = "LINESTRING (0 0, 50 50, 100 0)";
                var geom1 = db.Select(() => GeometryInput.STGeomFromText(Wkt1));
                var geom2 = db.Select(() => GeometryInput.STGeomFromText(Wkt2));

                var dist1 = db.Select(() => geom1.STFrechetDistance(geom2));
                Assert.AreEqual(70.7106781186548, dist1, 1.0E-9);

                var dist2 = db.Select(() => geom1.STFrechetDistance(geom2, 0.5));
                Assert.AreEqual(50.0, dist2, 1.0E-9);

                Assert.AreEqual(50.0, db.Select(() => MeasurementFunctions.STFrechetDistance(Wkt1, Wkt2, 0.5)), 1.0E-9);

                Assert.IsNull(db.Select(() => MeasurementFunctions.STFrechetDistance((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestSTHausdorffDistance()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var geom1 = db.Select(() => GeometryInput.STGeomFromText("LINESTRING (0 0, 2 0)"));
                var geom2 = db.Select(() => GeometryInput.STGeomFromText("MULTIPOINT (0 1, 1 0, 2 1)"));
                var dist12 = db.Select(() => geom1.STHausdorffDistance(geom2));
                Assert.AreEqual(1, dist12, 1.0E-9);

                const string Wkt3 = "LINESTRING (130 0, 0 0, 0 150)";
                const string Wkt4 = "LINESTRING (10 10, 10 150, 130 10)";
                var geom3 = db.Select(() => GeometryInput.STGeomFromText(Wkt3));
                var geom4 = db.Select(() => GeometryInput.STGeomFromText(Wkt4));
                var dist34 = db.Select(() => geom3.STHausdorffDistance(geom4, 0.5));
                Assert.AreEqual(70, dist34, 70.0E-9);

                Assert.AreEqual(70.0,
                    db.Select(() => MeasurementFunctions.STHausdorffDistance(Wkt3, Wkt4, 0.5)),
                    1.0E-9);

                Assert.IsNull(db.Select(() => MeasurementFunctions.STHausdorffDistance((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestSTLength()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Ewkt1 = "SRID=2249;LINESTRING(743238 2967416,743238 2967450,743265 2967450, 743265.625 2967416,743238 2967416)";
                db.TestGeometries.Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt1))
                    .Insert();

                const string Ewkt2 = "SRID=2249;POINT(0 0)";
                db.TestGeometries.Value(g => g.Id, 2)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt2))
                    .Insert();
                db.TestGeometries.Value(g => g.Id, 3)
                    .Value(p => p.Geometry, () => null)
                    .Insert();

                var length1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STLength())
                    .Single();
                Assert.AreEqual(122.630744000095, length1, 0.000000000001);

                var length2 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STLength2D())
                    .Single();
                Assert.AreEqual(122.630744000095, length2, 0.000000000001);

                Assert.AreEqual(0.0,
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STLength())
                        .Single());
                Assert.IsNull(
                    db.TestGeometries.Where(g => g.Id == 3)
                        .Select(g => g.Geometry.STLength())
                        .Single());

                Assert.AreEqual(
                    122.630744000095,
                    db.Select(() => MeasurementFunctions.STLength(Ewkt1)),
                    0.000000000001);

                Assert.AreEqual(
                    122.630744000095,
                    db.Select(() => MeasurementFunctions.STLength2D(Ewkt1)),
                    0.000000000001);

                Assert.IsNull(db.Select(() => MeasurementFunctions.STLength((NTSG)null)));
            }
        }

        [Test]
        public void TestST3DLength()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(743238 2967416 1,743238 2967450 1,743265 2967450 3,743265.625 2967416 3, 743238 2967416 3)";
                var geom1 = db.Select(() => GeometryInput.STGeomFromText(Wkt1, 2249));

                var length1 = db.Select(() => MeasurementFunctions.ST3DLength(geom1));
                Assert.AreEqual(122.704716741457, length1, 1.0E-9);

                Assert.AreEqual(
                    122.704716741457,
                    db.Select(() => MeasurementFunctions.ST3DLength("SRID=2249;" + Wkt1)),
                    1.0E-9);

                Assert.IsNull(db.Select(() => MeasurementFunctions.ST3DLength((NTSG)null)));
            }
        }

        [Test]
        public void TestSTLengthSpheroid()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Spheroid = "SPHEROID[\"GRS_1980\",6378137,298.257222101]";
                const string Wkt = "MULTILINESTRING((-118.584 38.374,-118.583 38.5), (-71.05957 42.3589, -71.061 43))";
                var geom1 = db.Select(() => GeometryInput.STGeomFromText(Wkt));

                var length1 = db.Select(() => MeasurementFunctions.STLengthSpheroid(geom1, Spheroid));
                Assert.AreEqual(85204.5207711811, length1, 1.0E-9);

                var length2 = db.Select(() => MeasurementFunctions.STLengthSpheroid(geom1.STGeometryN(1), Spheroid));
                Assert.AreEqual(13986.8725282447, length2, 1.0E-9);

                var length3 = db.Select(() => MeasurementFunctions.STLengthSpheroid(geom1.STGeometryN(2), Spheroid));
                Assert.AreEqual(71217.6482429363, length3, 1.0E-9);

                Assert.AreEqual(
                    85204.5207711811,
                    db.Select(() => MeasurementFunctions.STLengthSpheroid(Wkt, Spheroid)),
                    1.0E-9);

                Assert.IsNull(db.Select(() => MeasurementFunctions.STLengthSpheroid((NTSG)null, Spheroid)));
            }
        }

        [Test]
        public void TestSTLongestLine()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string PointWkt = "POINT(100 100)";
                const string LineWkt = "LINESTRING (20 80, 98 190, 110 180, 50 75)";
                var point = db.Select(() => GeometryInput.STPointFromText(PointWkt));
                var line = db.Select(() => GeometryInput.STLineFromText(LineWkt));

                var lline1 = db.Select(() => MeasurementFunctions.STLongestLine(point, line).STAsEWKT());

                Assert.AreEqual("LINESTRING(100 100,98 190)", lline1);

                Assert.AreEqual(
                    "LINESTRING(100 100,98 190)",
                    db.Select(() => MeasurementFunctions.STLongestLine(PointWkt, LineWkt).STAsEWKT()));

                Assert.IsNull(db.Select(() => MeasurementFunctions.STLongestLine((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestST3DLongestLine()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string PointWkt = "POINT(100 100 30)";
                const string LineWkt = "LINESTRING (20 80 20, 98 190 1, 110 180 3, 50 75 1000)";
                var point = db.Select(() => GeometryInput.STPointFromText(PointWkt));
                var line = db.Select(() => GeometryInput.STLineFromText(LineWkt));

                var lline1 = db.Select(() => MeasurementFunctions.ST3DLongestLine(line, point).STAsEWKT());

                Assert.AreEqual("LINESTRING(50 75 1000,100 100 30)", lline1);

                Assert.AreEqual(
                    "LINESTRING(50 75 1000,100 100 30)",
                    db.Select(() => MeasurementFunctions.ST3DLongestLine(LineWkt, PointWkt).STAsEWKT()));

                Assert.IsNull(db.Select(() => MeasurementFunctions.ST3DLongestLine((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestSTMaxDistance()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string PointWkt = "POINT(0 0)";
                const string LineWkt = "LINESTRING (2 2, 2 2)";
                var point = db.Select(() => GeometryInput.STPointFromText(PointWkt));
                var line = db.Select(() => GeometryInput.STLineFromText(LineWkt));

                Assert.AreEqual(
                    2.82842712474619,
                    db.Select(() => MeasurementFunctions.STMaxDistance(point, line)),
                    1.0E-9);

                Assert.AreEqual(
                    2.82842712474619,
                    db.Select(() => MeasurementFunctions.STMaxDistance(PointWkt, LineWkt)),
                    1.0E-9);

                Assert.IsNull(db.Select(() => MeasurementFunctions.STMaxDistance((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestST3DMaxDistance()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string PointEwkt = "SRID=4326;POINT(-72.1235 42.3521 10000)";
                const string LineEwkt = "SRID=4326;LINESTRING(-72.1260 42.45 15, -72.123 42.1546 20)";
                var point = db.Select(() => GeometryInput.STGeomFromEWKT(PointEwkt).STTransform(2163));
                var line = db.Select(() => GeometryInput.STGeomFromEWKT(LineEwkt).STTransform(2163));

                var maxDistance1 = db.Select(() => MeasurementFunctions.ST3DMaxDistance(point, line));
                Assert.AreEqual(24383.7467488441, maxDistance1, 1.0E-9);

                Assert.AreEqual(
                    1.732,
                    db.Select(() => MeasurementFunctions.ST3DMaxDistance(
                        "POINT(0 0 0)",
                        "POINT(1 1 1)")),
                    1.0E-3);

                Assert.IsNull(db.Select(() => MeasurementFunctions.ST3DMaxDistance((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestSTMinimumClearance()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "POLYGON ((0 0, 1 0, 1 1, 0.5 3.2e-4, 0 0))";
                var geometry = db.Select(() => GeometryInput.STGeomFromText(Wkt));
                var minimumClearance = db.Select(() => MeasurementFunctions.STMinimumClearance(geometry));
                Assert.AreEqual(0.00032, minimumClearance, 1.0E-5);

                Assert.AreEqual(0.00032, db.Select(() => MeasurementFunctions.STMinimumClearance(Wkt)), 1.0E-5);

                Assert.IsNull(db.Select(() => MeasurementFunctions.STMinimumClearance((NTSG)null)));
            }
        }

        [Test]
        public void TestSTMinimumClearanceLine()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "POLYGON ((0 0, 1 0, 1 1, 0.5 3.2e-4, 0 0))";
                var geometry = db.Select(() => GeometryInput.STGeomFromText(Wkt));
                var lline1 = db.Select(() => MeasurementFunctions.STMinimumClearanceLine(geometry).STAsEWKT());
                Assert.AreEqual("LINESTRING(0.5 0.00032,0.5 0)", lline1);

                Assert.AreEqual("LINESTRING(0.5 0.00032,0.5 0)", db.Select(() => MeasurementFunctions.STMinimumClearanceLine(Wkt).STAsEWKT()));

                Assert.IsNull(db.Select(() => MeasurementFunctions.STMinimumClearanceLine((NTSG)null)));
            }
        }

        [Test]
        public void TestSTPerimeter()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Ewkt1 = "SRID=2249;POLYGON((743238 2967416,743238 2967450,743265 2967450, 743265.625 2967416,743238 2967416))";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt1))
                    .Insert();

                const string Ewkt2 = @"SRID=2249;
                    MULTIPOLYGON(((763104.471273676 2949418.44119003,
                        763104.477769673 2949418.42538203,
                        763104.189609677 2949418.22343004,763104.471273676 2949418.44119003)),
                        ((763104.471273676 2949418.44119003,763095.804579742 2949436.33850239,
                        763086.132105649 2949451.46730207,763078.452329651 2949462.11549407,
                        763075.354136904 2949466.17407812,763064.362142565 2949477.64291974,
                        763059.953961626 2949481.28983009,762994.637609571 2949532.04103014,
                        762990.568508415 2949535.06640477,762986.710889563 2949539.61421415,
                        763117.237897679 2949709.50493431,763235.236617789 2949617.95619822,
                        763287.718121842 2949562.20592617,763111.553321674 2949423.91664605,
                        763104.471273676 2949418.44119003)))";
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt2))
                    .Insert();

                const string Ewkt3 = "SRID=2249;POINT(0 0)";
                db.TestGeometries.Value(g => g.Id, 3)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt3))
                    .Insert();
                db.TestGeometries.Value(g => g.Id, 4)
                    .Value(p => p.Geometry, () => null)
                    .Insert();

                Assert.AreEqual(122.630744000095, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STPerimeter()).Single(), 0.000000000001);
                Assert.AreEqual(122.630744000095, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STPerimeter2D()).Single(), 0.000000000001);
                Assert.AreEqual(845.227713366825, db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STPerimeter()).Single(), 0.000000000001);
                Assert.AreEqual(845.227713366825, db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STPerimeter2D()).Single(), 0.000000000001);
                Assert.AreEqual(0.0, db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STPerimeter()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STPerimeter()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STPerimeter2D()).Single());

                Assert.AreEqual(122.630744000095, db.Select(() => MeasurementFunctions.STPerimeter2D(Ewkt1)), 0.000000000001);
            }
        }

        [Test]
        public void TestST3DPerimeter()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Ewkt = "SRID=2249;POLYGON((743238 2967416 2,743238 2967450 1,743265.625 2967416 1, 743238 2967416 2))";
                var geometry = db.Select(() => GeometryInput.STGeomFromEWKT(Ewkt));
                var perimeter = db.Select(() => MeasurementFunctions.ST3DPerimeter(geometry));
                Assert.AreEqual(105.465793597674, perimeter, 1.0E-9);

                Assert.AreEqual(105.465793597674, db.Select(() => MeasurementFunctions.ST3DPerimeter(Ewkt)), 1.0E-9);

                Assert.IsNull(db.Select(() => MeasurementFunctions.ST3DPerimeter((NTSG)null)));
            }
        }

        [Test]
        public void TestSTShortestLine()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string PointWkt = "POINT(100 100)";
                const string LineWkt = "LINESTRING (20 80, 98 190, 110 180, 50 75)";
                var point = db.Select(() => GeometryInput.STPointFromText(PointWkt));
                var line = db.Select(() => GeometryInput.STLineFromText(LineWkt));

                var sline1 = db.Select(() => MeasurementFunctions.STShortestLine(point, line)) as NTSGS.LineString;
                Assert.AreEqual(100, sline1.Coordinates[0].X, 1.0E-6);
                Assert.AreEqual(100, sline1.Coordinates[0].Y, 1.0E-6);
                Assert.AreEqual(73.0769230769231, sline1.Coordinates[1].X, 1.0E-9);
                Assert.AreEqual(115.384615384615, sline1.Coordinates[1].Y, 1.0E-9);

                var sline2 = db.Select(() => MeasurementFunctions.STShortestLine(PointWkt, LineWkt)) as NTSGS.LineString;
                Assert.AreEqual(100, sline2.Coordinates[0].X, 1.0E-6);
                Assert.AreEqual(100, sline2.Coordinates[0].Y, 1.0E-6);
                Assert.AreEqual(73.0769230769231, sline2.Coordinates[1].X, 1.0E-9);
                Assert.AreEqual(115.384615384615, sline2.Coordinates[1].Y, 1.0E-9);

                Assert.IsNull(db.Select(() => MeasurementFunctions.STShortestLine((NTSG)null, null)));
            }
        }

        [Test]
        public void TestST3DShortestLine()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string PointWkt = "POINT(100 100 30)";
                const string LineWkt = "LINESTRING (20 80 20, 98 190 1, 110 180 3, 50 75 1000)";
                var point = db.Select(() => GeometryInput.STPointFromText(PointWkt));
                var line = db.Select(() => GeometryInput.STLineFromText(LineWkt));

                var sline1 = db.Select(() => MeasurementFunctions.ST3DShortestLine(line, point)) as NTSGS.LineString;
                Assert.AreEqual(54.6993798867619, sline1.Coordinates[0].X, 1.0E-6);
                Assert.AreEqual(128.935022917228, sline1.Coordinates[0].Y, 1.0E-6);
                Assert.AreEqual(11.5475869506606, sline1.Coordinates[0].Z, 1.0E-9);
                Assert.AreEqual(100, sline1.Coordinates[1].X, 1.0E-6);
                Assert.AreEqual(100, sline1.Coordinates[1].Y, 1.0E-6);
                Assert.AreEqual(30, sline1.Coordinates[1].Z, 1.0E-9);

                var sline2 = db.Select(() => MeasurementFunctions.ST3DShortestLine(LineWkt, PointWkt)) as NTSGS.LineString;
                Assert.AreEqual(54.6993798867619, sline2.Coordinates[0].X, 1.0E-6);
                Assert.AreEqual(128.935022917228, sline2.Coordinates[0].Y, 1.0E-6);
                Assert.AreEqual(11.5475869506606, sline2.Coordinates[0].Z, 1.0E-9);
                Assert.AreEqual(100, sline2.Coordinates[1].X, 1.0E-6);
                Assert.AreEqual(100, sline2.Coordinates[1].Y, 1.0E-6);
                Assert.AreEqual(30, sline2.Coordinates[1].Z, 1.0E-9);

                Assert.IsNull(db.Select(() => MeasurementFunctions.ST3DShortestLine((NTSG)null, null)));
            }
        }
    }
}
