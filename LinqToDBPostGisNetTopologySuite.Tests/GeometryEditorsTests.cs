using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSG = NetTopologySuite.Geometries;

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
            }
        }

        [Test]
        public void TestSTAddPoint()
        {
            const string wkt = "LINESTRING(0 0 1, 0 0 2)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STAddPoint(GeometryConstructors.STMakePoint(0, 0, 3)))
                .Single() as NTSG.LineString;

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
            }
        }

        [Test]
        public void TestSTAddPointWithPosition()
        {
            const string wkt = "LINESTRING(0 0 1, 0 0 3)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STAddPoint(GeometryConstructors.STMakePoint(0, 0, 2), 1))
                .Single() as NTSG.LineString;

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
            }
        }

        [Test]
        public void TestSTCollectionExtract()
        {
            const string wkt = "GEOMETRYCOLLECTION(GEOMETRYCOLLECTION(LINESTRING(0 0, 1 1)),LINESTRING(2 2, 3 3))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STCollectionExtract(2))
                    .Single();

                Assert.IsInstanceOf<NTSG.MultiLineString>(result);
                var multiLine = result as NTSG.MultiLineString;

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
            const string wkt = "GEOMETRYCOLLECTION(POINT(0 0),POINT(1 1))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STCollectionHomogenize())
                .Single();

                Assert.IsInstanceOf<NTSG.MultiPoint>(result);
                var multiPoint = result as NTSG.MultiPoint;

                var point1 = multiPoint.GetGeometryN(0);
                Assert.AreEqual(0, point1.Coordinates[0].X);
                Assert.AreEqual(0, point1.Coordinates[0].Y);

                var point2 = multiPoint.GetGeometryN(1);
                Assert.AreEqual(1, point2.Coordinates[0].X);
                Assert.AreEqual(1, point2.Coordinates[0].Y);
            }
        }

        [Test]
        public void TestSTForce2D()
        {
            const string wkt = "LINESTRING(25 50 1, 100 125 1, 150 190 1)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STForce2D())
                .Single() as NTSG.LineString;

                Assert.AreEqual(2, result.CoordinateSequence.Dimension);
                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
            }
        }

        [Test]
        public void TestSTForce3D()
        {
            const string wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STForce3D())
                .Single() as NTSG.LineString;

                Assert.AreEqual(3, result.CoordinateSequence.Dimension);

                var nonExistM = result.GetCoordinateN(0).M;
                var existZ = result.GetCoordinateN(0).Z;

                Assert.AreEqual(false, Double.IsNaN(existZ));
                Assert.AreEqual(true, Double.IsNaN(nonExistM));

                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(0, result.GetCoordinateN(0).Z);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(0, result.GetCoordinateN(1).Z);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
                Assert.AreEqual(0, result.GetCoordinateN(2).Z);
            }
        }

        [Test]
        public void TestSTForce3DZ()
        {
            const string wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STForce3DZ())
                .Single() as NTSG.LineString;

                Assert.AreEqual(3, result.CoordinateSequence.Dimension);
                var nonExistM = result.GetCoordinateN(0).M;
                var existZ = result.GetCoordinateN(0).Z;

                Assert.AreEqual(false, Double.IsNaN(existZ));
                Assert.AreEqual(true, Double.IsNaN(nonExistM));

                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(0, result.GetCoordinateN(0).Z);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(0, result.GetCoordinateN(1).Z);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
                Assert.AreEqual(0, result.GetCoordinateN(2).Z);
            }
        }

        [Test]
        public void TestSTForce3DM()
        {
            const string wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STForce3DM())
                .Single() as NTSG.LineString;

                Assert.AreEqual(3, result.CoordinateSequence.Dimension);
                var existM = result.GetCoordinateN(0).M;
                var nonExistZ = result.GetCoordinateN(0).Z;

                Assert.AreEqual(false, Double.IsNaN(existM));
                Assert.AreEqual(true, Double.IsNaN(nonExistZ));

                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(0, result.GetCoordinateN(0).M);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(0, result.GetCoordinateN(1).M);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
                Assert.AreEqual(0, result.GetCoordinateN(2).M);
            }
        }

        [Test]
        public void TestSTForce4D()
        {
            const string wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STForce4D())
                .Single() as NTSG.LineString;

                Assert.AreEqual(4, result.CoordinateSequence.Dimension);
                var existM = result.GetCoordinateN(0).M;
                var existZ = result.GetCoordinateN(0).Z;
                Assert.AreEqual(false, Double.IsNaN(existM));
                Assert.AreEqual(false, Double.IsNaN(existZ));

                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(0, result.GetCoordinateN(0).M);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(0, result.GetCoordinateN(1).M);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
                Assert.AreEqual(0, result.GetCoordinateN(2).M);
            }
        }

        [Test]
        public void TestSTForcePolygonCCW()
        {
            const string wkt = "POLYGON((0 0 1,0 5 1,5 0 1,0 0 1),(1 1 1,3 1 1,1 3 1,1 1 1))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var ccwGeom = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STForcePolygonCCW())
                .Single() as NTSG.Polygon;

                var originGeom = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry)
                .Single() as NTSG.Polygon;

                //Assertion about interior ring
                var originInteriorRing = originGeom.InteriorRings[0];
                var ccwInteriorRing = ccwGeom.InteriorRings[0];
                var numCoordinates = originInteriorRing.Coordinates.Length;

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
                var numCoords = originExteriorRing.Coordinates.Length;

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
        public void TestSTForceCollection()
        {
            const string wkt = "POINT(0 0)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                    .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STForceCollection())
                .Single() as NTSG.GeometryCollection;

                Assert.AreEqual(1, result.NumGeometries);
                Assert.IsInstanceOf<NTSG.Point>(result.Geometries[0]);

                Assert.AreEqual(0, result.Geometries[0].Coordinates[0].X);
                Assert.AreEqual(0, result.Geometries[0].Coordinates[0].Y);
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
            }
        }
    }
}
