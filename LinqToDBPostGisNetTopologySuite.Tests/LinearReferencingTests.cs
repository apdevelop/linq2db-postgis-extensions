using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSGS = NetTopologySuite.Geometries;
using NTSG = NetTopologySuite.Geometries.Geometry;

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
            const string Wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STLineInterpolatePoint(0.20))
                    .Single() as NTSGS.Point;

                Assert.AreEqual(51.5974135047432, result.X, 1.0E-8);
                Assert.AreEqual(76.5974135047432, result.Y, 1.0E-8);

                Assert.IsNull(db.Select(() => LinearReferencing.STLineInterpolatePoint((NTSG)null, 0.5)));
                Assert.IsNull(db.Select(() => LinearReferencing.STLineInterpolatePoint((string)null, 0.5)));

                var result2 = db.Select(() => LinearReferencing.STLineInterpolatePoint(Wkt, 0.20)) as NTSGS.Point;
                Assert.AreEqual(51.5974135047432, result2.X, 1.0E-8);
                Assert.AreEqual(76.5974135047432, result2.Y, 1.0E-8);
            }
        }

        [Test]
        public void TestST3DLineInterpolatePoint()
        {
            const string Wkt = "LINESTRING(25 50 70, 100 125 90, 150 190 200)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var version = new Version(db.Select(() => VersionFunctions.PostGISLibVersion()));
                if (version >= new Version("3.0.0"))
                {
                    db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                    var result = db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.ST3DLineInterpolatePoint(0.20))
                        .Single() as NTSGS.Point;

                    Assert.AreEqual(59.0675892910822, result.X, 1.0E-8);
                    Assert.AreEqual(84.0675892910822, result.Y, 1.0E-8);
                    Assert.AreEqual(79.0846904776219, result.Z, 1.0E-8);

                    Assert.IsNull(db.Select(() => LinearReferencing.ST3DLineInterpolatePoint((NTSG)null, 0.5)));

                    var result2 = db.Select(() => LinearReferencing.ST3DLineInterpolatePoint(Wkt, 0.20)) as NTSGS.Point;
                    Assert.AreEqual(59.0675892910822, result2.X, 1.0E-8);
                    Assert.AreEqual(84.0675892910822, result2.Y, 1.0E-8);
                    Assert.AreEqual(79.0846904776219, result2.Z, 1.0E-8);
                }
            }
        }

        [Test]
        public void TestSTLineInterpolatePoints()
        {
            const string Wkt = "LINESTRING(25 50, 100 125, 150 190)";
            var expected = new double[][]
            {
                new []{ 51.5974135047432, 76.5974135047432 },
                new []{ 78.1948270094864, 103.194827009486 },
                new []{ 104.132163186446, 130.37181214238 },
                new []{ 127.066081593223, 160.18590607119 },
                new []{ 150.0, 190.0 },
            };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STLineInterpolatePoints(0.20, true))
                    .Single() as NTSGS.MultiPoint;

                Assert.AreEqual(expected.Length, result.NumPoints);
                for (var i = 0; i < expected.Length; i++)
                {
                    var exp = expected[i];
                    var res = result.Geometries[i] as NTSGS.Point;
                    Assert.AreEqual(exp[0], res.X, 1.0E-8);
                    Assert.AreEqual(exp[1], res.Y, 1.0E-8);
                }

                var result2 = db.Select(() => LinearReferencing.STLineInterpolatePoints(Wkt, 0.20, true)) as NTSGS.MultiPoint;
                Assert.AreEqual(expected.Length, result2.NumPoints);

                Assert.IsNull(db.Select(() => LinearReferencing.STLineInterpolatePoints((NTSG)null, 0.5, true)));
            }
        }

        [Test]
        public void TestSTLineLocatePoint()
        {
            const string LineWkt = "LINESTRING(1 2, 4 5, 6 7)";
            const string PointWkt = "POINT(4 3)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(LineWkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STLineLocatePoint(GeometryInput.STGeomFromText(PointWkt)))
                    .Single();

                Assert.AreEqual(0.4, result.Value, 1.0E-8);

                Assert.AreEqual(0.4, db.Select(() => LinearReferencing.STLineLocatePoint(LineWkt, PointWkt)).Value, 1.0E-8);

                Assert.IsNull(db.Select(() => LinearReferencing.STLineLocatePoint((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestSTLineSubstring()
        {
            const string Wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeometryFromText(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STLineSubstring(0.333, 0.666))
                    .Single() as NTSGS.LineString;

                Assert.AreEqual(3, result.Coordinates.Length);

                Assert.AreEqual(69.28469348539744, result.GetCoordinateN(0).X, 1.0E-8);
                Assert.AreEqual(94.28469348539744, result.GetCoordinateN(0).Y, 1.0E-8);

                Assert.AreEqual(100.0, result.GetCoordinateN(1).X, 1.0E-8);
                Assert.AreEqual(125.0, result.GetCoordinateN(1).Y, 1.0E-8);

                Assert.AreEqual(111.70035626068274, result.GetCoordinateN(2).X, 1.0E-8);
                Assert.AreEqual(140.21046313888758, result.GetCoordinateN(2).Y, 1.0E-8);

                Assert.IsNull(db.Select(() => LinearReferencing.STLineSubstring((NTSG)null, 0, 0)));

                Assert.AreEqual(
                    3,
                    (db.Select(() => LinearReferencing.STLineSubstring(Wkt, 0.333, 0.666)) as NTSGS.LineString).Coordinates.Length);
            }
        }

        [Test]
        public void TestSTLocateAlong()
        {
            const string Wkt = "MULTILINESTRINGM((1 2 3, 3 4 2, 9 4 3),(1 2 3, 5 4 5))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeometryFromText(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STLocateAlong(3, 0.0))
                    .Single() as NTSGS.MultiPoint;

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

                Assert.IsNull(db.Select(() => LinearReferencing.STLocateAlong((NTSG)null, 0, 0)));

                Assert.AreEqual(
                    3,
                    (db.Select(() => LinearReferencing.STLocateAlong(Wkt, 3, 0.0)) as NTSGS.MultiPoint).Coordinates.Length);
            }
        }

        [Test]
        public void TestSTLocateBetween()
        {
            const string Wkt = "MULTILINESTRING M ((1 2 3, 3 4 2, 9 4 3),(1 2 3, 5 4 5))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeometryFromText(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STLocateBetween(1.5, 3.0, 0.0))
                    .Single() as NTSGS.GeometryCollection;

                Assert.AreEqual(2, result.NumGeometries);

                var geom1 = result.Geometries[0];
                var geom2 = result.Geometries[1];

                Assert.IsInstanceOf<NTSGS.LineString>(geom1);
                Assert.IsInstanceOf<NTSGS.Point>(geom2);

                var resLineString = geom1 as NTSGS.LineString;
                var resPoint = geom2 as NTSGS.Point;

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

                Assert.IsNull(db.Select(() => LinearReferencing.STLocateBetween((NTSG)null, 0, 0, 0)));

                Assert.AreEqual(
                    2,
                    (db.Select(() => LinearReferencing.STLocateBetween(Wkt, 1.5, 3.0, 0.0)) as NTSGS.GeometryCollection).NumGeometries);
            }
        }

        [Test]
        public void TestSTLocateBetweenElevations()
        {
            const string Wkt = "LINESTRING(1 2 3, 4 5 6)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STLocateBetweenElevations(2.0, 4.0))
                    .Single() as NTSGS.MultiLineString;

                Assert.AreEqual(1, result.NumGeometries);

                Assert.AreEqual(1.0, result.Coordinates[0].X, 1.0E-8);
                Assert.AreEqual(2.0, result.Coordinates[0].Y, 1.0E-8);
                Assert.AreEqual(3.0, result.Coordinates[0].Z, 1.0E-8);

                Assert.AreEqual(2.0, result.Coordinates[1].X, 1.0E-8);
                Assert.AreEqual(3.0, result.Coordinates[1].Y, 1.0E-8);
                Assert.AreEqual(4.0, result.Coordinates[1].Z, 1.0E-8);

                Assert.IsNull(db.Select(() => LinearReferencing.STLocateBetweenElevations((NTSG)null, 0, 0)));

                Assert.AreEqual(
                    1,
                    (db.Select(() => LinearReferencing.STLocateBetweenElevations(Wkt, 2.0, 4.0)) as NTSGS.MultiLineString).NumGeometries);
            }
        }

        [Test]
        public void TestSTInterpolatePoint()
        {
            const string LineWkt = "LINESTRING M (0 0 0, 10 0 20)";
            const string PointWkt = "POINT(5 5)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeometryFromText(LineWkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STInterpolatePoint(GeometryInput.STGeometryFromText(PointWkt)))
                    .Single();

                Assert.AreEqual(10.0, result.Value, 1.0E-8);

                Assert.IsNull(db.Select(() => LinearReferencing.STInterpolatePoint((NTSG)null, (NTSG)null)));

                Assert.AreEqual(
                    10.0,
                    db.Select(() => LinearReferencing.STInterpolatePoint(LineWkt, PointWkt)));
            }
        }

        [Test]
        public void TestSTAddMeasure()
        {
            const string Wkt = "LINESTRING(1 0, 2 0, 4 0)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STAddMeasure(1.0, 4.0))
                    .Single() as NTSGS.LineString;

                Assert.AreEqual(1.0, result.Coordinates[0].X, 1.0E-8);
                Assert.AreEqual(0.0, result.Coordinates[0].Y, 1.0E-8);
                Assert.AreEqual(1.0, result.Coordinates[0].M, 1.0E-8);

                Assert.AreEqual(2.0, result.Coordinates[1].X, 1.0E-8);
                Assert.AreEqual(0.0, result.Coordinates[1].Y, 1.0E-8);
                Assert.AreEqual(2.0, result.Coordinates[1].M, 1.0E-8);

                Assert.AreEqual(4.0, result.Coordinates[2].X, 1.0E-8);
                Assert.AreEqual(0.0, result.Coordinates[2].Y, 1.0E-8);
                Assert.AreEqual(4.0, result.Coordinates[2].M, 1.0E-8);

                Assert.IsNull(db.Select(() => LinearReferencing.STAddMeasure((NTSG)null, 0, 0)));

                Assert.IsNotNull(db.Select(() => LinearReferencing.STAddMeasure(Wkt, 0, 0)));
            }
        }
    }
}
