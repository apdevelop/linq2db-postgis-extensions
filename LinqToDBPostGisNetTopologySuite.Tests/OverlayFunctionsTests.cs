using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSG = NetTopologySuite.Geometries.Geometry;
using NTSGS = NetTopologySuite.Geometries;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class OverlayFunctionsTests : TestsBase
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
        public void TestSTClipByBox2D()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var geom1 = db.Select(() => GeometryInput.STGeomFromText("LINESTRING(0 0, 20 20)"));
                var box1 = db.Select(() => GeometryConstructors.STMakeEnvelope(0, 0, 10, 10));

                var clipped1 = db.Select(() => OverlayFunctions.STClipByBox2D(geom1, box1).STAsText());
                Assert.AreEqual("LINESTRING(0 0,10 10)", clipped1);

                Assert.IsNull(db.Select(() => OverlayFunctions.STClipByBox2D(null, null)));
            }
        }

        [Test]
        public void TestSTSymDifference()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(50 100, 50 200)";
                const string Wkt2 = "LINESTRING(50 50, 50 150)";

                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeometryFromText(Wkt1))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeometryFromText(Wkt2))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STSymDifference(db.TestGeometries.Where(g2 => g2.Id == 2).Single().Geometry))
                    .Single() as NTSGS.MultiLineString;

                // Order of portions was changed in PostGIS 3.1.1 Assert.AreEqual("MULTILINESTRING((50 150,50 200),(50 50,50 100))", result);

                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.Geometries.Length);
                Assert.IsTrue(result.Geometries.All(g => g.NumPoints == 2));
                Assert.IsTrue(result.Geometries.All(g => g.Coordinates[0][0] == 50));
            }
        }

        [Test]
        public void TestSTUnaryUnion()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POLYGON((0 1, 0 3, 2 3, 2 1, 0 1))";
                const string Wkt2 = "POLYGON((1 0, 1 2, 3 2, 3 0, 1 0))";

                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1, SRID4326))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2, SRID4326))
                    .Insert();

                var result1 = db.TestGeometries
                    .Select(g => GeometryConstructors.STCollect(
                            db.TestGeometries.Where(g1 => g1.Id == 1).Single().Geometry,
                            db.TestGeometries.Where(g2 => g2.Id == 2).Single().Geometry)
                        .STUnaryUnion())
                    .First() as NTSGS.Polygon;

                // "POLYGON((1 0,1 1,0 1,0 3,2 3,2 2,3 2,3 0,1 0))"
                Assert.IsNotNull(result1);
                Assert.AreEqual(9, result1.Coordinates.Length);

                var result2 = db.Select(() => OverlayFunctions.STUnaryUnion("MULTIPOLYGON(((0 1,0 3,2 3,2 1,0 1)),((1 0,1 2,3 2,3 0,1 0)))")) as NTSGS.Polygon;
                Assert.IsNotNull(result2);
                Assert.AreEqual(9, result2.Coordinates.Length);

                Assert.IsNull(db.Select(() => OverlayFunctions.STUnaryUnion((NTSG)null)));
            }
        }
    }
}
