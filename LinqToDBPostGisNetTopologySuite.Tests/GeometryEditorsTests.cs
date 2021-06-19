using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSG = NetTopologySuite.Geometries.Geometry;
using NTSGS = NetTopologySuite.Geometries;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryEditorsTests : TestsBase
    {
        [SetUp]
        public void Setup()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Delete();
                db.TestGeographies.Delete();
            }
        }

        [Test]
        public void TestSTAddPoint()
        {
            const string Wkt = "LINESTRING(0 0 1, 0 0 2)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STAddPoint(GeometryConstructors.STMakePoint(0, 0, 3)))
                    .Single() as NTSGS.LineString;

                Assert.AreEqual(3, result.NumPoints);

                var point1 = result.Coordinates[0];
                Assert.AreEqual(0, point1.X);
                Assert.AreEqual(0, point1.Y);
                Assert.AreEqual(1, point1.Z);

                var point2 = result.Coordinates[1];
                Assert.AreEqual(0, point2.X);
                Assert.AreEqual(0, point2.Y);
                Assert.AreEqual(2, point2.Z);

                var point3 = result.Coordinates[2];
                Assert.AreEqual(0, point3.X);
                Assert.AreEqual(0, point3.Y);
                Assert.AreEqual(3, point3.Z);

                Assert.IsNull(db.Select(() => GeometryEditors.STAddPoint(null, null)));
            }
        }

        [Test]
        public void TestSTAddPointWithPosition()
        {
            const string Wkt = "LINESTRING(0 0 1, 0 0 3)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STAddPoint(GeometryConstructors.STMakePoint(0, 0, 2), 1))
                    .Single() as NTSGS.LineString;

                Assert.AreEqual(3, result.NumPoints);

                var point1 = result.Coordinates[0];
                Assert.AreEqual(0, point1.X);
                Assert.AreEqual(0, point1.Y);
                Assert.AreEqual(1, point1.Z);

                var point2 = result.Coordinates[1];
                Assert.AreEqual(0, point2.X);
                Assert.AreEqual(0, point2.Y);
                Assert.AreEqual(2, point2.Z);

                var point3 = result.Coordinates[2];
                Assert.AreEqual(0, point3.X);
                Assert.AreEqual(0, point3.Y);
                Assert.AreEqual(3, point3.Z);

                Assert.IsNull(db.Select(() => GeometryEditors.STAddPoint(null, null, 0)));
            }
        }

        [Test]
        public void TestSTCollectionExtract()
        {
            const string Wkt = "GEOMETRYCOLLECTION(GEOMETRYCOLLECTION(LINESTRING(0 0, 1 1)),LINESTRING(2 2, 3 3))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STCollectionExtract(2))
                    .Single();

                Assert.IsInstanceOf<NTSGS.MultiLineString>(result);
                var multiLine = result as NTSGS.MultiLineString;

                var line1 = multiLine.GetGeometryN(0);
                var point1Line1 = line1.Coordinates[0];
                Assert.AreEqual(0, point1Line1.X);
                Assert.AreEqual(0, point1Line1.Y);
                var point2Line1 = line1.Coordinates[1];
                Assert.AreEqual(1, point2Line1.X);
                Assert.AreEqual(1, point2Line1.Y);

                var line2 = multiLine.GetGeometryN(1);
                var point1Line2 = line2.Coordinates[0];
                Assert.AreEqual(2, point1Line2.X);
                Assert.AreEqual(2, point1Line2.Y);
                var point2Line2 = line2.Coordinates[1];
                Assert.AreEqual(3, point2Line2.X);
                Assert.AreEqual(3, point2Line2.Y);
            }
        }

        [Test]
        public void TestSTCollectionHomogenize()
        {
            const string Wkt = "GEOMETRYCOLLECTION(POINT(0 0),POINT(1 1))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STCollectionHomogenize())
                    .Single();

                Assert.IsInstanceOf<NTSGS.MultiPoint>(result);
                var multiPoint = result as NTSGS.MultiPoint;

                var point1 = multiPoint.GetGeometryN(0);
                Assert.AreEqual(0, point1.Coordinates[0].X);
                Assert.AreEqual(0, point1.Coordinates[0].Y);

                var point2 = multiPoint.GetGeometryN(1);
                Assert.AreEqual(1, point2.Coordinates[0].X);
                Assert.AreEqual(1, point2.Coordinates[0].Y);
            }
        }

        [Test]
        public void TestSTCurveToLine()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "CIRCULARSTRING(0 0,100 -100,200 0)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                var result1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STCurveToLine(20, 1, 1))
                    .Single() as NTSGS.LineString;

                Assert.AreEqual(0, result1.Coordinates[0].X);
                Assert.AreEqual(0, result1.Coordinates[0].Y);
                Assert.AreEqual(50, result1.Coordinates[1].X, 1.0E-9);
                Assert.AreEqual(-86.6025403784438, result1.Coordinates[1].Y, 1.0E-9);
                Assert.AreEqual(150, result1.Coordinates[2].X, 1.0E-9);
                Assert.AreEqual(-86.6025403784439, result1.Coordinates[2].Y, 1.0E-9);
                Assert.AreEqual(200, result1.Coordinates[3].X, 1.0E-9);
                Assert.AreEqual(0, result1.Coordinates[3].Y, 1.0E-9);

                Assert.IsNull(db.Select(() => GeometryEditors.STCurveToLine(null, 20, 1, 1)));
            }
        }

        [Test]
        public void TestSTFlipCoordinates()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var geom1 = db.Select(() => GeometryInput.STGeomFromText("POINT(1 2)"));

                var result1 = db.Select(() => GeometryEditors.STFlipCoordinates(geom1).STAsText());
                Assert.AreEqual("POINT(2 1)", result1);

                Assert.IsNull(db.Select(() => GeometryEditors.STFlipCoordinates(null)));
            }
        }

        [Test]
        public void TestSTForce2D()
        {
            const string Wkt = "LINESTRING(25 50 1, 100 125 1, 150 190 1)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STForce2D())
                    .Single() as NTSGS.LineString;

                Assert.AreEqual(2, result.CoordinateSequence.Dimension);
                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);

                Assert.IsNull(db.Select(() => GeometryEditors.STForce2D((NTSG)null)));

                Assert.AreEqual(
                    2,
                    ((NTSGS.LineString)db.Select(() => GeometryEditors.STForce2D(Wkt))).CoordinateSequence.Dimension);
            }
        }

        [Test]
        public void TestSTForce3D()
        {
            const string Wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STForce3D())
                    .Single() as NTSGS.LineString;

                Assert.AreEqual(3, result.CoordinateSequence.Dimension);

                var nonExistM = result.GetCoordinateN(0).M;
                var existZ = result.GetCoordinateN(0).Z;

                Assert.IsFalse(Double.IsNaN(existZ));
                Assert.IsTrue(Double.IsNaN(nonExistM));

                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(0, result.GetCoordinateN(0).Z);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(0, result.GetCoordinateN(1).Z);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
                Assert.AreEqual(0, result.GetCoordinateN(2).Z);

                Assert.IsNull(db.Select(() => GeometryEditors.STForce3D((NTSG)null)));

                Assert.AreEqual(
                    3,
                    ((NTSGS.LineString)db.Select(() => GeometryEditors.STForce3D(Wkt))).CoordinateSequence.Dimension);
            }
        }

        [Test]
        public void TestSTForce3DZ()
        {
            const string Wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STForce3DZ())
                    .Single() as NTSGS.LineString;

                Assert.AreEqual(3, result.CoordinateSequence.Dimension);
                var nonExistM = result.GetCoordinateN(0).M;
                var existZ = result.GetCoordinateN(0).Z;

                Assert.IsFalse(Double.IsNaN(existZ));
                Assert.IsTrue(Double.IsNaN(nonExistM));

                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(0, result.GetCoordinateN(0).Z);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(0, result.GetCoordinateN(1).Z);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
                Assert.AreEqual(0, result.GetCoordinateN(2).Z);

                Assert.IsNull(db.Select(() => GeometryEditors.STForce3DZ((NTSG)null)));

                Assert.AreEqual(
                    3,
                    ((NTSGS.LineString)db.Select(() => GeometryEditors.STForce3DZ(Wkt))).CoordinateSequence.Dimension);
            }
        }

        [Test]
        public void TestSTForce3DM()
        {
            const string Wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STForce3DM())
                    .Single() as NTSGS.LineString;

                Assert.AreEqual(3, result.CoordinateSequence.Dimension);
                var existM = result.GetCoordinateN(0).M;
                var nonExistZ = result.GetCoordinateN(0).Z;

                Assert.IsFalse(Double.IsNaN(existM));
                Assert.IsTrue(Double.IsNaN(nonExistZ));

                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(0, result.GetCoordinateN(0).M);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(0, result.GetCoordinateN(1).M);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
                Assert.AreEqual(0, result.GetCoordinateN(2).M);

                Assert.IsNull(db.Select(() => GeometryEditors.STForce3DM((NTSG)null)));

                Assert.AreEqual(
                    3,
                    ((NTSGS.LineString)db.Select(() => GeometryEditors.STForce3DM(Wkt))).CoordinateSequence.Dimension);
            }
        }

        [Test]
        public void TestSTForce4D()
        {
            const string Wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STForce4D())
                    .Single() as NTSGS.LineString;

                Assert.AreEqual(4, result.CoordinateSequence.Dimension);
                var existM = result.GetCoordinateN(0).M;
                var existZ = result.GetCoordinateN(0).Z;
                Assert.IsFalse(Double.IsNaN(existM));
                Assert.IsFalse(Double.IsNaN(existZ));

                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(0, result.GetCoordinateN(0).M);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(0, result.GetCoordinateN(1).M);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
                Assert.AreEqual(0, result.GetCoordinateN(2).M);

                Assert.IsNull(db.Select(() => GeometryEditors.STForce4D((NTSG)null)));

                Assert.AreEqual(
                    4,
                    ((NTSGS.LineString)db.Select(() => GeometryEditors.STForce4D(Wkt))).CoordinateSequence.Dimension);
            }
        }

        [Test]
        public void TestSTForcePolygonCCW()
        {
            const string Wkt = "POLYGON((0 0 1,0 5 1,5 0 1,0 0 1),(1 1 1,3 1 1,1 3 1,1 1 1))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var ccwGeom = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STForcePolygonCCW())
                    .Single() as NTSGS.Polygon;

                var originGeom = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry)
                    .Single() as NTSGS.Polygon;

                //Assertion about interior ring
                var originInteriorRing = originGeom.InteriorRings[0];
                var ccwInteriorRing = ccwGeom.InteriorRings[0];

                //Cause that head point equals end point forever,so only check point at index 1,2
                Assert.AreEqual(originInteriorRing.Coordinates[1].Z, ccwInteriorRing.Coordinates[2].Z);
                Assert.AreEqual(originInteriorRing.Coordinates[1].X, ccwInteriorRing.Coordinates[2].X);
                Assert.AreEqual(originInteriorRing.Coordinates[1].Y, ccwInteriorRing.Coordinates[2].Y);

                Assert.AreEqual(originInteriorRing.Coordinates[2].Z, ccwInteriorRing.Coordinates[1].Z);
                Assert.AreEqual(originInteriorRing.Coordinates[2].X, ccwInteriorRing.Coordinates[1].X);
                Assert.AreEqual(originInteriorRing.Coordinates[2].Y, ccwInteriorRing.Coordinates[1].Y);

                //Assertion about exterior ring
                var originExteriorRing = originGeom.ExteriorRing;
                var ccwExteriorRing = ccwGeom.ExteriorRing;

                //Cause that head point equals end point forever,so only check point at index 1,2
                Assert.AreEqual(originExteriorRing.Coordinates[1].Z, ccwExteriorRing.Coordinates[2].Z);
                Assert.AreEqual(originExteriorRing.Coordinates[1].X, ccwExteriorRing.Coordinates[2].X);
                Assert.AreEqual(originExteriorRing.Coordinates[1].Y, ccwExteriorRing.Coordinates[2].Y);

                //Cause that head point equals end point forever,so only check point at index 1,2
                Assert.AreEqual(originExteriorRing.Coordinates[2].Z, ccwExteriorRing.Coordinates[1].Z);
                Assert.AreEqual(originExteriorRing.Coordinates[2].X, ccwExteriorRing.Coordinates[1].X);
                Assert.AreEqual(originExteriorRing.Coordinates[2].Y, ccwExteriorRing.Coordinates[1].Y);
            }
        }

        [Test]
        public void TestSTForcePolygonCW()
        {
            const string Wkt = "POLYGON((0 0 1,5 0 1,0 5 1,0 0 1),(1 1 1,1 3 1,3 1 1,1 1 1))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var cwGeometry = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STForcePolygonCW())
                    .Single() as NTSGS.Polygon;

                var originalGeometry = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry)
                    .Single() as NTSGS.Polygon;

                //Assertion about interior ring
                var originInteriorRing = originalGeometry.InteriorRings[0];
                var cwInteriorRing = cwGeometry.InteriorRings[0];

                //Cause that head point equals end point forever,so only check point at index 1,2
                Assert.AreEqual(originInteriorRing.Coordinates[1].Z, cwInteriorRing.Coordinates[2].Z);
                Assert.AreEqual(originInteriorRing.Coordinates[1].X, cwInteriorRing.Coordinates[2].X);
                Assert.AreEqual(originInteriorRing.Coordinates[1].Y, cwInteriorRing.Coordinates[2].Y);

                Assert.AreEqual(originInteriorRing.Coordinates[2].Z, cwInteriorRing.Coordinates[1].Z);
                Assert.AreEqual(originInteriorRing.Coordinates[2].X, cwInteriorRing.Coordinates[1].X);
                Assert.AreEqual(originInteriorRing.Coordinates[2].Y, cwInteriorRing.Coordinates[1].Y);

                //Assertion about exterior ring
                var originExteriorRing = originalGeometry.ExteriorRing;
                var cwExteriorRing = cwGeometry.ExteriorRing;

                //Cause that head point equals end point forever,so only check point at index 1,2
                Assert.AreEqual(originExteriorRing.Coordinates[1].Z, cwExteriorRing.Coordinates[2].Z);
                Assert.AreEqual(originExteriorRing.Coordinates[1].X, cwExteriorRing.Coordinates[2].X);
                Assert.AreEqual(originExteriorRing.Coordinates[1].Y, cwExteriorRing.Coordinates[2].Y);

                //Cause that head point equals end point forever,so only check point at index 1,2
                Assert.AreEqual(originExteriorRing.Coordinates[2].Z, cwExteriorRing.Coordinates[1].Z);
                Assert.AreEqual(originExteriorRing.Coordinates[2].X, cwExteriorRing.Coordinates[1].X);
                Assert.AreEqual(originExteriorRing.Coordinates[2].Y, cwExteriorRing.Coordinates[1].Y);
            }
        }

        [Test]
        public void TestSTForceCollection()
        {
            const string Wkt = "POINT(0 0)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STForceCollection())
                    .Single() as NTSGS.GeometryCollection;

                Assert.AreEqual(1, result.NumGeometries);
                Assert.IsInstanceOf<NTSGS.Point>(result.Geometries[0]);
                Assert.AreEqual(0, result.Geometries[0].Coordinates[0].X);
                Assert.AreEqual(0, result.Geometries[0].Coordinates[0].Y);

                Assert.IsNull(db.Select(() => GeometryEditors.STForceCollection((NTSG)null)));

                Assert.AreEqual(
                    "GEOMETRYCOLLECTION(POLYGON((0 0 1,0 5 1,5 0 1,0 0 1),(1 1 1,3 1 1,1 3 1,1 1 1)))",
                    db.Select(() => GeometryEditors.STForceCollection("POLYGON((0 0 1,0 5 1,5 0 1,0 0 1),(1 1 1,3 1 1,1 3 1,1 1 1))").STAsEWKT()));
            }
        }

        [Test]
        public void TestSTForceSFS()
        {
            const string Wkt = "CURVEPOLYGON Z ((0 0 1,5 0 1,0 5 1,0 0 1),(1 1 1,1 3 1,3 1 1,1 1 1))";
            const string Expected = "POLYGON Z ((0 0 1,5 0 1,0 5 1,0 0 1),(1 1 1,1 3 1,3 1 1,1 1 1))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                var actual = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STForceSFS().STAsText())
                    .Single();

                Assert.AreEqual(Expected, actual);

                Assert.IsNull(db.Select(() => GeometryEditors.STForceSFS((NTSG)null)));
            }
        }

        [Test]
        public void TestSTForceRHR()
        {
            const string Wkt = "POLYGON((0 0 1,5 0 1,0 5 1,0 0 1),(1 1 1,1 3 1,3 1 1,1 1 1))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var rhrGeom = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STForceRHR())
                    .Single() as NTSGS.Polygon;

                var originGeom = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry)
                    .Single() as NTSGS.Polygon;

                //Assertion about interior ring
                var originInteriorRing = originGeom.InteriorRings[0];
                var rrhInteriorRing = rhrGeom.InteriorRings[0];

                //Cause that head point equals end point forever,so only check point at index 1,2
                Assert.AreEqual(originInteriorRing.Coordinates[1].Z, rrhInteriorRing.Coordinates[2].Z);
                Assert.AreEqual(originInteriorRing.Coordinates[1].X, rrhInteriorRing.Coordinates[2].X);
                Assert.AreEqual(originInteriorRing.Coordinates[1].Y, rrhInteriorRing.Coordinates[2].Y);

                Assert.AreEqual(originInteriorRing.Coordinates[2].Z, rrhInteriorRing.Coordinates[1].Z);
                Assert.AreEqual(originInteriorRing.Coordinates[2].X, rrhInteriorRing.Coordinates[1].X);
                Assert.AreEqual(originInteriorRing.Coordinates[2].Y, rrhInteriorRing.Coordinates[1].Y);

                //Assertion about exterior ring
                var originExteriorRing = originGeom.ExteriorRing;
                var rrhExteriorRing = rhrGeom.ExteriorRing;

                //Cause that head point equals end point forever,so only check point at index 1,2
                Assert.AreEqual(originExteriorRing.Coordinates[1].Z, rrhExteriorRing.Coordinates[2].Z);
                Assert.AreEqual(originExteriorRing.Coordinates[1].X, rrhExteriorRing.Coordinates[2].X);
                Assert.AreEqual(originExteriorRing.Coordinates[1].Y, rrhExteriorRing.Coordinates[2].Y);

                //Cause that head point equals end point forever,so only check point at index 1,2
                Assert.AreEqual(originExteriorRing.Coordinates[2].Z, rrhExteriorRing.Coordinates[1].Z);
                Assert.AreEqual(originExteriorRing.Coordinates[2].X, rrhExteriorRing.Coordinates[1].X);
                Assert.AreEqual(originExteriorRing.Coordinates[2].Y, rrhExteriorRing.Coordinates[1].Y);

                Assert.IsNull(db.Select(() => GeometryEditors.STForceRHR((NTSG)null)));

                Assert.AreEqual(
                    "POLYGON((0 0 2,0 5 2,5 0 2,0 0 2),(1 1 2,3 1 2,1 3 2,1 1 2))",
                    db.Select(() => GeometryEditors.STForceRHR("POLYGON((0 0 2, 5 0 2, 0 5 2, 0 0 2),(1 1 2, 1 3 2, 3 1 2, 1 1 2))").STAsEWKT()));
            }
        }

        [Test]
        public void TestSTForceCurve()
        {
            const string Wkt = "POLYGON((0 0 1,5 0 1,0 5 1,0 0 1),(1 1 1,1 3 1,3 1 1,1 1 1))";
            const string Expected = "CURVEPOLYGON Z ((0 0 1,5 0 1,0 5 1,0 0 1),(1 1 1,1 3 1,3 1 1,1 1 1))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var curvedGeomStr = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STForceCurve().STAsText())
                    .Single();

                Assert.AreEqual(Expected, curvedGeomStr);

                Assert.IsNull(db.Select(() => GeometryEditors.STForceCurve((NTSG)null)));

                Assert.AreEqual(
                    Expected,
                    db.Select(() => GeometryEditors.STForceCurve(Wkt).STAsText()));
            }
        }

        [Test]
        public void TestSTLineMerge()
        {
            const string Wkt = "MULTILINESTRING M ((1 2 3, 9 4 3),(9 4 3, 5 4 5))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var mergedGeom = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STLineMerge())
                    .Single();

                Assert.IsInstanceOf<NTSGS.LineString>(mergedGeom);
                Assert.AreEqual(3, mergedGeom.NumPoints);

                var mergedLine = mergedGeom as NTSGS.LineString;
                Assert.AreEqual(1, mergedLine.GetCoordinateN(0).X);
                Assert.AreEqual(2, mergedLine.GetCoordinateN(0).Y);
                Assert.AreEqual(double.NaN, mergedLine.GetCoordinateN(0).M);

                Assert.AreEqual(9, mergedLine.GetCoordinateN(1).X);
                Assert.AreEqual(4, mergedLine.GetCoordinateN(1).Y);
                Assert.AreEqual(double.NaN, mergedLine.GetCoordinateN(1).M);

                Assert.AreEqual(5, mergedLine.GetCoordinateN(2).X);
                Assert.AreEqual(4, mergedLine.GetCoordinateN(2).Y);
                Assert.AreEqual(double.NaN, mergedLine.GetCoordinateN(2).M);

                Assert.IsNull(db.Select(() => GeometryEditors.STLineMerge((NTSG)null)));

                Assert.AreEqual(
                    "LINESTRING(-29 -27,-30 -29.7,-36 -31,-45 -33,-46 -32)",
                    db.Select(() => GeometryEditors.STLineMerge("MULTILINESTRING((-29 -27,-30 -29.7,-36 -31,-45 -33),(-45 -33,-46 -32))").STAsText()));
            }
        }


        [Test]
        public void TestSTLineToCurve()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "POINT(1 3)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () =>
                        GeometryInput.STGeomFromText(Wkt).STBuffer(3.0))
                    .Insert();

                // NTS error: 'Geometry type not recognized. GeometryCode: 10'
                var curvePolygon = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STLineToCurve().STAsText())
                    .Single();

                Assert.AreEqual("CURVEPOLYGON(CIRCULARSTRING(4 3,-2 2.99999999999999,4 3))", curvePolygon);

                Assert.IsNull(db.Select(() => GeometryEditors.STLineToCurve((NTSG)null)));
            }
        }


        [Test]
        public void TestSTMulti()
        {
            const string Wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var multiGeom = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STMulti())
                    .Single();

                Assert.IsInstanceOf<NTSGS.MultiLineString>(multiGeom);

                var multiLine = multiGeom as NTSGS.MultiLineString;

                Assert.AreEqual(1, multiLine.NumGeometries);

                var line = multiLine.GetGeometryN(0);

                Assert.AreEqual(25, line.Coordinates[0].X);
                Assert.AreEqual(50, line.Coordinates[0].Y);

                Assert.AreEqual(100, line.Coordinates[1].X);
                Assert.AreEqual(125, line.Coordinates[1].Y);

                Assert.AreEqual(150, line.Coordinates[2].X);
                Assert.AreEqual(190, line.Coordinates[2].Y);

                Assert.IsNull(db.Select(() => GeometryEditors.STMulti((NTSG)null)));

                Assert.AreEqual(
                    "MULTIPOLYGON(((743238 2967416,743238 2967450,743265 2967450,743265.625 2967416,743238 2967416)))",
                    db.Select(() => GeometryEditors.STMulti("POLYGON((743238 2967416,743238 2967450,743265 2967450, 743265.625 2967416, 743238 2967416))").STAsText()));
            }
        }
        [Test]

        public void TestSTQuantizeCoordinates()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                Assert.AreEqual(
                    "POINT(100.0625 0)",
                    db.Select(() => GeometryEditors
                        .STQuantizeCoordinates(
                            GeometryConstructors.STMakePoint(100.123456, 0), 0, 0, 0, 0)
                        .STAsText()));

                Assert.AreEqual(
                    100.123455047607,
                    db.Select(() => GeometryEditors
                        .STQuantizeCoordinates(
                            GeometryConstructors.STMakePoint(100.123456, 0), 4)
                        .STX()).Value,
                    1.0E-12);

                Assert.IsNull(db.Select(() => GeometryEditors.STQuantizeCoordinates((NTSG)null, 0, 0, 0, 0)));
            }
        }

        [Test]
        public void TestSTRemovePoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string InputWkt = "LINESTRING(10 10,0 0,10 0,0 10)";
                const string Expected = "LINESTRING(10 10,0 0,0 10)";
                Assert.AreEqual(
                    Expected,
                    db.Select(() => GeometryEditors.STRemovePoint(GeometryInput.STGeomFromText(InputWkt), 2).STAsText()));

                Assert.AreEqual(
                    Expected,
                    db.Select(() => GeometryEditors.STRemovePoint(InputWkt, 2).STAsText()));

                Assert.IsNull(db.Select(() => GeometryEditors.STRemovePoint((NTSG)null, 0)));
            }
        }

        [Test]
        public void TestSTRemoveRepeatedPoints()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(0 5, 0 0, 0 0, 0 10)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRemoveRepeatedPoints(1).AsText())
                    .Single();

                Assert.AreEqual("LINESTRING (0 5, 0 0, 0 10)", result);

                Assert.IsNull(db.Select(() => GeometryEditors.STRemoveRepeatedPoints((NTSG)null, 0)));
            }
        }

        [Test]
        public void TestSTReverse()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakeLine(
                        GeometryConstructors.STMakePoint(1, 2),
                        GeometryConstructors.STMakePoint(1, 10)))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STReverse().AsText())
                    .Single();

                Assert.AreEqual("LINESTRING (1 10, 1 2)", result);

                Assert.IsNull(db.Select(() => GeometryEditors.STReverse((NTSG)null)));

                Assert.AreEqual(
                    "LINESTRING(1 10,1 2)",
                    db.Select(() => GeometryEditors.STReverse("LINESTRING(1 2,1 10)").STAsText()));
            }
        }

        public void TestSTSegmentize()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string InputWkt = "LINESTRING(0 0, 100 0)";
                const string Expected = "LINESTRING(0 0,50 0,100 0)";
                Assert.AreEqual(
                    Expected,
                    db.Select(() => GeometryEditors.STSegmentize(GeometryInput.STGeomFromText(InputWkt), 50).STAsText()));

                Assert.AreEqual(
                    Expected,
                    db.Select(() => GeometryEditors.STSegmentize(InputWkt, 50).STAsText()));

                Assert.IsNull(db.Select(() => GeometryEditors.STSegmentize((NTSG)null, 0)));
            }
        }

        [Test]
        public void TestSTSetPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText("LINESTRING(-1 2,-1 3)"))
                    .Insert();

                db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Set(g => g.Geometry, g => g.Geometry.STSetPoint(0, GeometryInput.STGeomFromText("POINT(-1 1)")))
                    .Update();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STAsText())
                    .Single();

                Assert.AreEqual("LINESTRING(-1 1,-1 3)", result);

                Assert.IsNull(db.Select(() => GeometryEditors.STSetPoint((NTSG)null, 0, null)));
            }
        }

        [Test]
        public void TestSTShiftLongitude()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Ewkt1 = "SRID=4326;POINT(-118.58 38.38 10)";
                const string Ewkt2 = "SRID=4326;POINT(241.42 38.38 10)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt1))
                    .Insert();
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt2))
                    .Insert();

                var result1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STShiftLongitude())
                    .Single() as NTSGS.Point;

                var result2 = db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STShiftLongitude())
                    .Single() as NTSGS.Point;

                Assert.AreEqual(241.42, result1.X, 1.0E-2);
                Assert.AreEqual(38.38, result1.Y, 1.0E-2);

                Assert.AreEqual(-118.58, result2.X, 1.0E-2);
                Assert.AreEqual(38.38, result2.Y, 1.0E-2);
            }
        }

        [Test]
        public void TestSTSnapToGrid()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                Assert.AreEqual(
                    "LINESTRING(1.112 2.123,4.111 3.237)",
                    db.Select(() => GeometryInput.STGeomFromText("LINESTRING(1.1115678 2.123, 4.111111 3.2374897, 4.11112 3.23748667)")
                        .STSnapToGrid(0.001)
                        .STAsText()));

                Assert.AreEqual(
                    "LINESTRING(-1.08 2.12 2.3 1.1144,4.12 3.22 3.1 1.1144,-1.08 2.12 2.3 1.1144)",
                    db.Select(() => GeometryInput.STGeomFromEWKT("LINESTRING(-1.1115678 2.123 2.3456 1.11111, 4.111111 3.2374897 3.1234 1.1111, -1.11111112 2.123 2.3456 1.1111112)")
                        .STSnapToGrid(GeometryInput.STGeomFromEWKT("POINT(1.12 2.22 3.2 4.4444)"), 0.1, 0.1, 0.1, 0.01)
                        .STAsEWKT()));

                Assert.AreEqual(
                    "LINESTRING(-1.11 2.12 3 2.3456,4.11 3.24 3.1234 1.1111)",
                    db.Select(() => GeometryInput.STGeomFromEWKT("LINESTRING(-1.1115678 2.123 3 2.3456, 4.111111 3.2374897 3.1234 1.1111)")
                        .STSnapToGrid(0.01)
                        .STAsEWKT()));
            }
        }

        [Test]
        public void TestSTSnap()
        {
            const string LinestringWkt = "LINESTRING (5 107, 54 84, 101 100)";
            const string MultiPolygonWkt = "MULTIPOLYGON(((26 125, 26 200, 126 200, 126 125, 26 125), (51 150, 101 150, 76 175, 51 150 )), ((151 100, 151 200, 176 175, 151 100 )))";

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(MultiPolygonWkt))
                    .Insert();

                var line = db.Select(() => GeometryInput.STGeomFromText(LinestringWkt));

                var snapped = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STSnap(line, g.Geometry.STDistance(line).Value * 1.01).STAsText())
                    .Single();

                Assert.AreEqual(snapped, "MULTIPOLYGON(((26 125,26 200,126 200,126 125,101 100,26 125),(51 150,101 150,76 175,51 150)),((151 100,151 200,176 175,151 100)))");
            }
        }

        [Test]
        public void TestSTSwapOrdinates()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                Assert.AreEqual(
                    "POINT(2 1)",
                    db.Select(() => GeometryInput
                        .STGeomFromText("POINT(1 2)")
                        .STSwapOrdinates("xy")
                        .STAsText()));

                Assert.AreEqual(
                    "POINT(2 1)",
                    db.Select(() => GeometryEditors
                        .STSwapOrdinates("POINT(1 2)", "xy")
                        .STAsText()));

                Assert.AreEqual(
                    "POINT ZM (0 0 0 4)",
                    db.Select(() => GeometryInput
                        .STGeomFromText("POINT ZM (0 0 0 2)")
                        .STSwapOrdinates("xm")
                        .STScale(2, 1)
                        .STSwapOrdinates("xm")
                        .STAsText()));

                Assert.IsNull(db.Select(() => GeometryEditors.STSwapOrdinates((NTSGS.Geometry)null, null)));
                Assert.IsNull(db.Select(() => GeometryEditors.STSwapOrdinates((NTSGS.Geometry)null, String.Empty)));
                Assert.IsNull(db.Select(() => GeometryEditors.STSwapOrdinates((string)null, null)));
            }
        }
    }
}
