using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSGS = NetTopologySuite.Geometries;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class SpatialReferenceSystemFunctionsTests : TestsBase
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
        public void TestSTSetSrId()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePoint(-123.365556, 48.428611).STSetSrId(SRID4326))
                    .Insert();
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePoint(-123.365556, 48.428611).STSetSrId(SRID4326).STTransform(3785))
                    .Insert();

                var ewkt1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STAsEWKT())
                    .Single();
                StringAssert.StartsWith("SRID=4326;POINT", ewkt1);

                var srid1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STSrId())
                    .Single();
                Assert.AreEqual(SRID4326, srid1);

                var point2 = db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry)
                    .Single() as NTSGS.Point;
                Assert.AreEqual(3785, point2.SRID);
                Assert.AreEqual(-13732990.8753491, point2.X, 1.0E-6);
                Assert.AreEqual(6178458.96425423, point2.Y, 1.0E-6);

                var srid2 = db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STSrId())
                    .Single();
                Assert.AreEqual(3785, srid2);
            }
        }

        [Test]
        public void TestSTTransform()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "POLYGON((743238 2967416,743238 2967450, 743265 2967450,743265.625 2967416,743238 2967416))";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt, 2249))
                    .Insert();

                var result = db.TestGeometries
                    .Select(g => g.Geometry.STTransform(SRID4326))
                    .Single() as NTSGS.Polygon;

                var expected = new double[][]
                {
                    new[]{ -71.1776848522251, 42.3902896512902 },
                    new[]{ -71.1776843766326, 42.3903829478009 },
                    new[]{ -71.1775844305465, 42.3903826677917 },
                    new[]{ -71.1775825927231, 42.3902893647987 },
                    new[]{ -71.1776848522251, 42.3902896512902 },
                };

                Assert.AreEqual(expected.Length, result.Coordinates.Length);
                for (var i = 0; i < expected.Length; i++)
                {
                    Assert.AreEqual(expected[i][0], result.Coordinates[i].X, 1.0E-12);
                    Assert.AreEqual(expected[i][1], result.Coordinates[i].Y, 1.0E-12);
                }
            }
        }

        [Test]
        public void TestSTTransformText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Gnom = "+proj=gnom +ellps=WGS84 +lat_0=70 +lon_0=-160 +no_defs";
                const string Wkt1 = "POLYGON((170 50,170 72,-130 72,-130 50,170 50))";
                const string Wkt2 = "POLYGON((-170 68,-170 90,-141 90,-141 68,-170 68))";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1, SRID4326)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2, SRID4326)).Insert();

                var result = db.TestGeometries
                    .Select(g => OverlayFunctions
                        .STIntersection(
                            db.TestGeometries.Where(g1 => g1.Id == 1).Single().Geometry.STTransform(Gnom),
                            db.TestGeometries.Where(g2 => g2.Id == 2).Single().Geometry.STTransform(Gnom))
                        .STTransform(Gnom, SRID4326))
                    .First() as NTSGS.Polygon;

                var expected = new double[][]
                {
                    new[] { -170, 74.053793645338 },
                    new[] { -141, 73.4268621378904 },
                    new[] { -141, 68.0 },
                    new[] { -170, 68.0 },
                    new[] { -170, 74.053793645338 },
                };

                Assert.AreEqual(expected.Length, result.Coordinates.Length);
                for (var i = 0; i < expected.Length; i++)
                {
                    Assert.AreEqual(expected[i][0], result.Coordinates[i].X, 1.0E-12);
                    Assert.AreEqual(expected[i][1], result.Coordinates[i].Y, 1.0E-12);
                }
            }
        }
    }
}
