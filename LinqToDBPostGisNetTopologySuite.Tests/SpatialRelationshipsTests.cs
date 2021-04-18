using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSGS = NetTopologySuite.Geometries;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class SpatialRelationshipsTests : TestsBase
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
        public void TestST3DIntersects()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string line1 = "LINESTRING(0 0 1, 0 0 2, 0 0 3)";
                const string line2 = "LINESTRING(0 0 1, 0 0 4, 0 0 5)";

                const string line3 = "LINESTRING(0 0 1, 0 0 2, 0 0 3)";
                const string line4 = "LINESTRING(9 9 0, 9 9 1, 9 9 2)";

                var result1 = db.Select(() => GeometryInput.STGeomFromText(line1).ST3DIntersects(GeometryInput.STGeomFromText(line2)));
                var result2 = db.Select(() => GeometryInput.STGeomFromText(line3).ST3DIntersects(GeometryInput.STGeomFromText(line4)));
                var result3 = db.Select(() => SpatialRelationships.ST3DIntersects((NTSGS.Geometry)null,(NTSGS.Geometry)null));

                Assert.IsNotNull(result1);
                Assert.IsNotNull(result2);
                Assert.IsNull(result3);

                Assert.AreEqual(true, result1);
                Assert.AreEqual(false, result2);
            }
        }

        [Test]
        public void TestSTContainsSTCoversSTExteriorRing()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT(1 2)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1).STBuffer(10)).Insert();
                var smallc = db.TestGeometries.Single(g => g.Id == 1).Geometry;
                const string wkt2 = "POINT(1 2)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2).STBuffer(20)).Insert();
                var bigc = db.TestGeometries.Single(g => g.Id == 2).Geometry;
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCovers(smallc)).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCovers(bigc)).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STCovers(bigc.STExteriorRing())).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STContains(bigc.STExteriorRing())).Single());

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCoveredBy(smallc)).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCoveredBy(bigc)).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STExteriorRing().STCoveredBy(bigc)).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STExteriorRing().STWithin(bigc)).Single());

                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STContains(null)).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCovers(null)).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCoveredBy(null)).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STExteriorRing()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STExteriorRing().STWithin(null)).Single());
            }
        }

        [Test]
        public void TestSTContainsProperly()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string point1 = "POINT(1 1)";

                var query1 = from g1 in db.SelectQuery(() => GeometryProcessing.STBuffer(GeometryInput.STGeomFromText(point1), 3))
                             from g2 in db.SelectQuery(() => GeometryProcessing.STBuffer(GeometryInput.STGeomFromText(point1), 10))
                             select g2.STContainsProperly(g1);
                var result1 = query1.FirstOrDefault();
                Assert.IsNotNull(result1);
                Assert.AreEqual(true, result1);

                var query2 = from g1 in db.TestGeometries.Where(g => g.Id == 1)
                             from g2 in db.TestGeometries.Where(g => g.Id == 1)
                             select g2.Geometry.STContainsProperly(g1.Geometry);
                var result2 = query2.FirstOrDefault();
                Assert.IsNull(result2);
            }
        }

        [Test]
        public void TestSTLineCrossingDirection()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string line1 = "LINESTRING(25 169,89 114,40 70,86 43)";
                const string line2 = "LINESTRING(171 154,20 140,71 74,161 53)";

                var res1 = db
                            .Select
                            (
                                () =>
                                    GeometryInput
                                        .STGeomFromText(line1)
                                        .STLineCrossingDirection(GeometryInput.STGeomFromText(line2))
                            );
                Assert.IsNotNull(res1);
                Assert.AreEqual(-3, res1);

                var res2 = db.TestGeometries
                             .Where(g => g.Id == 1)
                             .Select(g => g.Geometry)
                             .Select(g => g.STLineCrossingDirection(GeometryInput.STGeomFromText(line2)))
                             .FirstOrDefault();
                Assert.IsNull(res2);
            }
        }

        [Test]
        public void TestSTDisjoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING ( 2 0, 0 2 )";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "LINESTRING ( 0 0, 0 2 )";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var point = new NTSGS.Point(new NTSGS.Coordinate(0, 0));
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STDisjoint(point)).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STDisjoint(point)).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STDisjoint(null)).Single());
            }
        }

        [Test]
        public void TestSTEquals()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(0 0, 10 10)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "LINESTRING(0 0, 5 5, 10 10)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Single().Geometry;
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STEquals(geometry2)).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STReverse().STEquals(geometry2)).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STReverse().STEquals(null)).Single());
            }
        }

        [Test]
        public void TestSTIntersects()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING ( 2 0, 0 2 )";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "LINESTRING ( 0 0, 0 2 )";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var point = new NTSGS.Point(new NTSGS.Coordinate(0, 0));

                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIntersects(point)).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIntersects(point)).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIntersects(null)).Single());
            }
        }

        [Test]
        public void TestSTOrderingEquals()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(0 0, 10 10, 20 20)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "LINESTRING(0 0, 10 10, 20 20)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var geometry2 = db.TestGeometries.Single(g => g.Id == 2).Geometry;
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STOrderingEquals(geometry2)).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STReverse().STOrderingEquals(geometry2)).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STReverse().STOrderingEquals(null)).Single());
            }
        }

        [Test]
        public void TestSTPointInsideCircle()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string point1 = "POINT(1 1)";
                const string point2 = "POINT(100 100)";

                const double circleX = 1.0;
                const double circleY = 1.0;

                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(point1))
                    .Insert();
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(point2))
                    .Insert();
                var result1 = db.TestGeometries.Where(t => t.Id == 1)
                                .Select(t => t.Geometry)
                                .Select(g => g.STPointInsideCircle(circleX, circleY, 11))
                                .Single();

                var result2 = db.TestGeometries.Where(t => t.Id == 2)
                                .Select(t => t.Geometry)
                                .Select(g => g.STPointInsideCircle(circleX, circleY, 11))
                                .Single();

                Assert.NotNull(result1);
                Assert.NotNull(result2);

                Assert.AreEqual(true, result1);
                Assert.AreEqual(false, result2);

                var result3 = db
                                .TestGeometries.Where(t => t.Id == 3)
                                .Select(t => t.Geometry)
                                .Select(g => g.STPointInsideCircle(circleX,circleY,11))
                                .FirstOrDefault();
                                
                Assert.IsNull(result3);
            }
        }

        [Test]
        public void TestSTRelateBool()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string geom1 = "POINT(1 2)";
                const string geom2 = "POINT(1 2)";

                var result = db.Select
                        (
                            () =>
                                GeometryInput
                                .STGeomFromText(geom1)
                                .STRelate(
                                    GeometryProcessing.STBuffer(GeometryInput.STGeomFromText(geom2), 2)
                                    ,
                                    "0FFFFF212")
                        );
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);

                var result1 = db.TestGeometries
                                .Where(g => g.Id == 1)
                                .Select(g => g.Geometry)
                                .Select(
                                        g =>
                                            g.STRelate(
                                                       GeometryProcessing.STBuffer(GeometryInput.STGeomFromText(geom2), 2),
                                                        "0FFFFF212"
                                                       )
                                        )
                                .FirstOrDefault();
                Assert.IsNull(result1);
            }
        }

        [Test]
        public void TestSTRelateDE9IM()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string geom1 = "POINT(1 2)";
                const string geom2 = "POINT(3 4)";

                var result1 = db.Select
                        (
                            () =>
                                GeometryInput
                                .STGeomFromText(geom1)
                                .STRelate(GeometryInput.STGeomFromText(geom2))
                        );
                Assert.IsFalse(string.IsNullOrEmpty(result1));

                var result2 = (
                                from g1 in db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry)
                                from g2 in db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry)
                                select SpatialRelationships.STRelate(g1, g2)
                            ).FirstOrDefault();
                Assert.IsTrue(string.IsNullOrEmpty(result2));
            }
        }

        [Test]
        public void TestSTRelateWithBoundaryRule()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string geom1 = "POINT(1 2)";
                const string geom2 = "POINT(3 4)";

                var result1 = db.Select
                        (
                            () =>
                                GeometryInput
                                .STGeomFromText(geom1)
                                .STRelate(GeometryInput.STGeomFromText(geom2), 1)
                        );
                var result2 = db.Select
                        (
                            () =>
                                GeometryInput
                                .STGeomFromText(geom1)
                                .STRelate(GeometryInput.STGeomFromText(geom2), 2)
                        );
                var result3 = db.Select
                        (
                            () =>
                                GeometryInput
                                .STGeomFromText(geom1)
                                .STRelate(GeometryInput.STGeomFromText(geom2), 3)
                        );
                var result4 = db.Select
                        (
                            () =>
                                GeometryInput
                                .STGeomFromText(geom1)
                                .STRelate(GeometryInput.STGeomFromText(geom2), 4)
                        );
                var result5 = (
                                from g1 in db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry)
                                from g2 in db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry)
                                select SpatialRelationships.STRelate(g1, g2, 1)
                            ).FirstOrDefault();

                Assert.IsFalse(string.IsNullOrEmpty(result1));
                Assert.IsFalse(string.IsNullOrEmpty(result2));
                Assert.IsFalse(string.IsNullOrEmpty(result3));
                Assert.IsFalse(string.IsNullOrEmpty(result4));

                Assert.AreEqual("FF0FFF0F2", result1);
                Assert.AreEqual("FF0FFF0F2", result2);
                Assert.AreEqual("FF0FFF0F2", result3);
                Assert.AreEqual("FF0FFF0F2", result4);

                Assert.IsTrue(string.IsNullOrEmpty(result5));
            }
        }

        [Test]
        public void TestSTRelateMatch()
        {
            const string matrix = "101202FFF";
            const string matrixPattern = "TTTTTTFFF";

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var result1 = db.Select(() => SpatialRelationships.STRelateMatch(matrix, matrixPattern));
                Assert.IsFalse(string.IsNullOrEmpty(result1));
            }
        }

        [Test]
        public void TestST3DDWithin()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT(1 1 2)";
                const string wkt2 = "LINESTRING(1 5 2, 2 7 20, 1 9 100, 14 12 3)";
                //srid 0 means default to EPSG:4326
                var dWithin = db.Select(
                    () =>
                            SpatialRelationships
                            .ST3DDWithin
                            (
                                GeometryInput.STGeomFromEWKT(wkt1),
                                GeometryInput.STGeomFromEWKT(wkt2),
                                10
                            )
                        );
                var fullyDWithin = db.Select(
                    () =>
                            SpatialRelationships
                            .ST3DDFullyWithin
                            (
                                GeometryInput.STGeomFromEWKT(wkt1),
                                GeometryInput.STGeomFromEWKT(wkt2),
                                10
                            )
                        );
                Assert.NotNull(dWithin);
                Assert.NotNull(fullyDWithin);

                Assert.AreEqual(true, dWithin);
                Assert.AreEqual(false, fullyDWithin);
            }
        }

        [Test]
        public void TestSTWithin()
        {
            const string wkt1 = "POINT(1 1)";
            const string wkt2 = "LINESTRING(1 5, 2 7, 1 9, 14 12)";
            //srid 0 means default to EPSG:4326
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var dFullyWithin10 = db.Select(
                    () =>
                            SpatialRelationships
                            .STDFullyWithin
                            (
                                GeometryInput.STGeomFromEWKT(wkt1),
                                GeometryInput.STGeomFromEWKT(wkt2),
                                10
                            )
                        );
                var dFullyWithin20 = db.Select(
                    () =>
                            SpatialRelationships
                            .STDFullyWithin
                            (
                                GeometryInput.STGeomFromEWKT(wkt1),
                                GeometryInput.STGeomFromEWKT(wkt2),
                                20
                            )
                        );
                var dWithin10 = db.Select(
                    () =>
                            SpatialRelationships
                            .STDWithin
                            (
                                GeometryInput.STGeomFromEWKT(wkt1),
                                GeometryInput.STGeomFromEWKT(wkt2),
                                10
                            )
                        );
                Assert.NotNull(dFullyWithin10);
                Assert.NotNull(dFullyWithin20);
                Assert.NotNull(dWithin10);

                Assert.AreEqual(false, dFullyWithin10);
                Assert.AreEqual(true, dFullyWithin20);
                Assert.AreEqual(true, dWithin10);
            }
        }

    }
}