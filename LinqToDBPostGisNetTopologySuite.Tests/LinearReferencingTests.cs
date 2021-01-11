using System.Linq;

using LinqToDB;
using NUnit.Framework;
using NTSG = NetTopologySuite.Geometries;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class LinearReferencingTests : TestsBase
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
        public void TestSTLineInterpolatePoint()
        {
            var geomText = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(geomText))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STLineInterpolatePoint(0.20))
                .Single() as NTSG.Point;

                Assert.AreEqual(51.5974135047432, result.X, 1.0E-8);
                Assert.AreEqual(76.5974135047432, result.Y, 1.0E-8);
            }
        }

        [Test]
        public void TESTST3DLineInterpolatePoint()
        {
            var geomText = "LINESTRING(25 50 70, 100 125 90, 150 190 200)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(geomText))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.ST3DLineInterpolatePoint(0.20))
                .Single() as NTSG.Point;

                Assert.IsNotNull(result);
                Assert.AreEqual(59.0675892910822, result.X, 1.0E-8);
                Assert.AreEqual(84.0675892910822, result.Y, 1.0E-8);
                Assert.AreEqual(79.0846904776219, result.Z, 1.0E-8);
            }
        }

        [Test]
        public void TESTSTLineInterpolatePoints()
        {
            var geomText = "LINESTRING(25 50, 100 125, 150 190)";
            var expected = new double[][]
            {
                new double[]{51.5974135047432, 76.5974135047432},
                new double[]{78.1948270094864, 103.194827009486},
                new double[]{104.132163186446, 130.37181214238},
                new double[]{127.066081593223, 160.18590607119},
                new double[]{150.0 ,190.0},
            };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(geomText))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STLineInterpolatePoints(0.20, true))
                .Single() as NTSG.MultiPoint;

                Assert.IsNotNull(result);
                Assert.AreEqual(expected.Length, result.NumPoints);
                for (int i = 0; i < expected.Length; i++)
                {
                    var exp = expected[i];
                    var res = result.Geometries[i] as NTSG.Point;

                    Assert.AreEqual(exp[0], res.X, 1.0E-8);
                    Assert.AreEqual(exp[1], res.Y, 1.0E-8);
                }
            }
        }

        [Test]
        public void TESTSTLineLocatePoint()
        {
            var geomText = "LINESTRING(1 2, 4 5, 6 7)";
            var givenPointText = "POINT(4 3)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(geomText))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STLineLocatePoint(GeometryInput.STGeomFromEWKT(givenPointText)))
                .Single() as double?;

                Assert.IsNotNull(result);
                Assert.AreEqual(0.4, result.Value, 1.0E-8);
            }
        }

        [Test]
        public void TESTSTLineSubstring()
        {
            var geomText = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(geomText))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STLineSubstring(0.333, 0.666))
                .Single() as NTSG.LineString;

                Assert.IsNotNull(result);
                Assert.AreEqual(3.0, result.Coordinates.Length, 1.0E-8);

                Assert.AreEqual(69.28469348539744, result.GetCoordinateN(0).X, 1.0E-8);
                Assert.AreEqual(94.28469348539744, result.GetCoordinateN(0).Y, 1.0E-8);

                Assert.AreEqual(100.0, result.GetCoordinateN(1).X, 1.0E-8);
                Assert.AreEqual(125.0, result.GetCoordinateN(1).Y, 1.0E-8);


                Assert.AreEqual(111.70035626068274, result.GetCoordinateN(2).X, 1.0E-8);
                Assert.AreEqual(140.21046313888758, result.GetCoordinateN(2).Y, 1.0E-8);
            }
        }

        [Test]
        public void TESTSTLocateAlong()
        {
            var geomText = "MULTILINESTRINGM((1 2 3, 3 4 2, 9 4 3),(1 2 3, 5 4 5))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(geomText))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STLocateAlong(3, 0.0))
                .Single() as NTSG.MultiPoint;

                Assert.IsNotNull(result);
                Assert.AreEqual(3, result.NumPoints);

                Assert.AreEqual(1.0, result.Coordinates[0].X, 1.0E-8);
                Assert.AreEqual(2.0, result.Coordinates[0].Y, 1.0E-8);
                Assert.AreEqual(3.0, result.Coordinates[0].M, 1.0E-8);

                Assert.AreEqual(9.0, result.Coordinates[1].X, 1.0E-8);
                Assert.AreEqual(4.0, result.Coordinates[1].Y, 1.0E-8);
                Assert.AreEqual(3.0, result.Coordinates[1].M, 1.0E-8);

                Assert.AreEqual(1.0, result.Coordinates[2].X, 1.0E-8);
                Assert.AreEqual(2.0, result.Coordinates[2].Y, 1.0E-8);
                Assert.AreEqual(3.0, result.Coordinates[2].M, 1.0E-8);
            }
        }

        [Test]
        public void TESTSTLocateBetween()
        {
            var geomText = "MULTILINESTRING M ((1 2 3, 3 4 2, 9 4 3),(1 2 3, 5 4 5))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(geomText))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STLocateBetween(1.5, 3.0, 0.0))
                .Single() as NTSG.GeometryCollection;

                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.NumGeometries);

                var geom1 = result.Geometries[0];
                var geom2 = result.Geometries[1];

                Assert.IsInstanceOf<NTSG.LineString>(geom1);
                Assert.IsInstanceOf<NTSG.Point>(geom2);

                var resLineString = geom1 as NTSG.LineString;
                var resPoint = geom2 as NTSG.Point;

                Assert.AreEqual(1.0, resLineString.Coordinates[0].X, 1.0E-8);
                Assert.AreEqual(2.0, resLineString.Coordinates[0].Y, 1.0E-8);
                Assert.AreEqual(3.0, resLineString.Coordinates[0].M, 1.0E-8);

                Assert.AreEqual(3.0, resLineString.Coordinates[1].X, 1.0E-8);
                Assert.AreEqual(4.0, resLineString.Coordinates[1].Y, 1.0E-8);
                Assert.AreEqual(2.0, resLineString.Coordinates[1].M, 1.0E-8);

                Assert.AreEqual(9.0, resLineString.Coordinates[2].X, 1.0E-8);
                Assert.AreEqual(4.0, resLineString.Coordinates[2].Y, 1.0E-8);
                Assert.AreEqual(3.0, resLineString.Coordinates[2].M, 1.0E-8);

                Assert.AreEqual(1.0, resPoint.X, 1.0E-8);
                Assert.AreEqual(2.0, resPoint.Y, 1.0E-8);
                Assert.AreEqual(3.0, resPoint.M, 1.0E-8);
            }
        }

        [Test]
        public void TESTSTLocateBetweenElevations()
        {
            var geomText = "LINESTRING(1 2 3, 4 5 6)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(geomText))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STLocateBetweenElevations(2.0, 4.0))
                .Single() as NTSG.MultiLineString;

                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.NumGeometries);

                Assert.AreEqual(1.0, result.Coordinates[0].X, 1.0E-8);
                Assert.AreEqual(2.0, result.Coordinates[0].Y, 1.0E-8);
                Assert.AreEqual(3.0, result.Coordinates[0].Z, 1.0E-8);

                Assert.AreEqual(2.0, result.Coordinates[1].X, 1.0E-8);
                Assert.AreEqual(3.0, result.Coordinates[1].Y, 1.0E-8);
                Assert.AreEqual(4.0, result.Coordinates[1].Z, 1.0E-8);
            }
        }

        [Test]
        public void TESTSTInterpolatePoint()
        {
            var geomLineText = "LINESTRING M (0 0 0, 10 0 20)";
            var geomPointText = "POINT(5 5)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(geomLineText))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STInterpolatePoint(GeometryInput.STGeomFromEWKT(geomPointText)))
                .Single() as double?;

                Assert.IsNotNull(result);
                Assert.AreEqual(10.0, result.Value, 1.0E-8);
            }
        }

        [Test]
        public void TESTSTAddMeasure()
        {
            var geomLineText = "LINESTRING(1 0, 2 0, 4 0)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(geomLineText))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STAddMeasure(1.0, 4.0))
                .Single() as NTSG.LineString;

                Assert.IsNotNull(result);

                Assert.AreEqual(1.0, result.Coordinates[0].X, 1.0E-8);
                Assert.AreEqual(0.0, result.Coordinates[0].Y, 1.0E-8);
                Assert.AreEqual(1.0, result.Coordinates[0].M, 1.0E-8);

                Assert.AreEqual(2.0, result.Coordinates[1].X, 1.0E-8);
                Assert.AreEqual(0.0, result.Coordinates[1].Y, 1.0E-8);
                Assert.AreEqual(2.0, result.Coordinates[1].M, 1.0E-8);

                Assert.AreEqual(4.0, result.Coordinates[2].X, 1.0E-8);
                Assert.AreEqual(0.0, result.Coordinates[2].Y, 1.0E-8);
                Assert.AreEqual(4.0, result.Coordinates[2].M, 1.0E-8);
            }
        }
    }
}