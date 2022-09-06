using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSGS = NetTopologySuite.Geometries;
using NTSG = NetTopologySuite.Geometries.Geometry;

using LinqToDBPostGisNetTopologySuite.Tests.Entities;

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
                db.TestGeographies.Delete();
            }
        }

        [Test]
        public void TestST3DIntersects()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Line1 = "LINESTRING(0 0 1, 0 0 2, 0 0 3)";
                const string Line2 = "LINESTRING(0 0 1, 0 0 4, 0 0 5)";
                const string Line3 = "LINESTRING(0 0 1, 0 0 2, 0 0 3)";
                const string Line4 = "LINESTRING(9 9 0, 9 9 1, 9 9 2)";

                var result1 = db.Select(() => GeometryInput.STGeomFromText(Line1).ST3DIntersects(GeometryInput.STGeomFromText(Line2)));
                var result2 = db.Select(() => GeometryInput.STGeomFromText(Line3).ST3DIntersects(GeometryInput.STGeomFromText(Line4)));
                var result3 = db.Select(() => SpatialRelationships.ST3DIntersects((NTSG)null, (NTSG)null));

                Assert.IsNotNull(result1);
                Assert.IsNotNull(result2);
                Assert.IsNull(result3);

                Assert.IsTrue(result1);
                Assert.IsFalse(result2);

                if (base.CurrentVersion >= base.Version300)
                {
                    Assert.IsTrue(
                        db.Select(() => SpatialRelationships.ST3DIntersects(
                            "TIN(((0 0 0,1 0 0,0 1 0,0 0 0)))",
                            "POINT(.1 .1 0)")));
                }
            }
        }

        [Test]
        public void TestSTContainsSTCoversSTExteriorRing()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POINT(1 2)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1).STBuffer(10)).Insert();
                var smallc = db.TestGeometries.Single(g => g.Id == 1).Geometry;

                const string Wkt2 = "POINT(1 2)";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2).STBuffer(20)).Insert();

                var bigc = db.TestGeometries.Single(g => g.Id == 2).Geometry;
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

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

                Assert.IsTrue(db.Select(() => SpatialRelationships.STCovers(
                    "POLYGON((0 0,1 0,1 1,0 1, 0 0))",
                    "LINESTRING(0.2 0.2, 0.8 0.8)")));

                Assert.IsFalse(db.Select(() => SpatialRelationships.STCovers(
                    "POLYGON((0 0,1 0,1 1,0 1, 0 0))",
                    "LINESTRING(0.2 0.2, 1.2 1.2)")));

                Assert.IsTrue(db.Select(() => SpatialRelationships.STCoveredBy(
                    "LINESTRING(0.2 0.2, 0.8 0.8)",
                    "POLYGON((0 0,1 0,1 1,0 1, 0 0))")));

                Assert.IsFalse(db.Select(() => SpatialRelationships.STCoveredBy(
                    "LINESTRING(0.2 0.2, 1.2 1.2)",
                    "POLYGON((0 0,1 0,1 1,0 1, 0 0))")));


                db.TestGeographies
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geography, () => GeometryInput.STGeogFromText("SRID=4326;POINT(-99.327 31.4821)"))
                    .Insert();

                db.TestGeographies
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geography, () => GeometryInput.STGeogFromText("SRID=4326;POINT(-99.33 31.483)"))
                    .Insert();

                var polyCoversPoint = db.TestGeographies
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geography
                        .STBuffer(300)
                        .STCovers(db.TestGeographies.Where(g0 => g0.Id == 2).Single().Geography))
                    .Single();

                Assert.IsFalse(polyCoversPoint);

                var buffer10mCoversPoint = db.TestGeographies
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geography
                        .STBuffer(10)
                        .STCovers(db.TestGeographies.Where(g0 => g0.Id == 2).Single().Geography))
                    .Single();

                Assert.IsTrue(buffer10mCoversPoint);
            }
        }

        [Test]
        public void TestSTContainsProperly()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Point1 = "POINT(1 1)";

                var query1 = from g1 in db.SelectQuery(() => GeometryProcessing.STBuffer(GeometryInput.STGeomFromText(Point1), 3))
                             from g2 in db.SelectQuery(() => GeometryProcessing.STBuffer(GeometryInput.STGeomFromText(Point1), 10))
                             select g2.STContainsProperly(g1);

                var result1 = query1.FirstOrDefault();
                Assert.IsNotNull(result1);
                Assert.IsTrue(result1);

                var query2 = from g1 in db.TestGeometries.Where(g => g.Id == 1)
                             from g2 in db.TestGeometries.Where(g => g.Id == 1)
                             select g2.Geometry.STContainsProperly(g1.Geometry);
                var result2 = query2.FirstOrDefault();
                Assert.IsNull(result2);

                // TODO: need explicit cast text to geometry
                if (base.CurrentVersion >= base.Version300)
                {
                    Assert.IsTrue(
                        db.Select(() => SpatialRelationships.STContainsProperly(
                            "POLYGON((0 0,1 0,1 1,0 1, 0 0))",
                            "LINESTRING(0.2 0.2, 0.8 0.8)")));

                    Assert.IsFalse(
                        db.Select(() => SpatialRelationships.STContainsProperly(
                            "POLYGON((0 0,1 0,1 1,0 1, 0 0))",
                            "LINESTRING(0.2 0.2, 1.2 1.2)")));
                }
            }
        }

        [Test]
        public void TestSTCrosses()
        {
            const string Wkt1 = "POLYGON((1 1, 4 1, 4 4, 1 4, 1 1))";
            const string Wkt2 = "MULTIPOINT((2 3), (4 5), (5 1))";

            const string Wkt3 = "POLYGON((1 1, 4 1, 4 4, 1 4, 1 1))";
            const string Wkt4 = "POLYGON((2 2, 5 2, 5 5, 2 5, 2 2))";

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                Assert.IsTrue(db.Select(() =>
                    GeometryInput.STGeomFromText(Wkt1)
                        .STCrosses(GeometryInput.STGeomFromText(Wkt2))));

                Assert.IsFalse(db.Select(() =>
                    GeometryInput.STGeomFromText(Wkt3)
                        .STCrosses(GeometryInput.STGeomFromText(Wkt4))));

                Assert.IsTrue(db.Select(() => SpatialRelationships.STCrosses(Wkt1, Wkt2)));
                Assert.IsFalse(db.Select(() => SpatialRelationships.STCrosses(Wkt3, Wkt4)));
            }
        }

        [Test]
        public void TestSTLineCrossingDirection()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Line1 = "LINESTRING(25 169,89 114,40 70,86 43)";
                const string Line2 = "LINESTRING(171 154,20 140,71 74,161 53)";

                Assert.AreEqual(
                        -3,
                        db.Select(() => GeometryInput.STGeomFromText(Line1)
                            .STLineCrossingDirection(GeometryInput.STGeomFromText(Line2))));

                Assert.AreEqual(
                    -3,
                    db.Select(() => SpatialRelationships.STLineCrossingDirection(Line1, Line2)));

                Assert.IsNull(db.TestGeometries
                                 .Where(g => g.Id == 1)
                                 .Select(g => g.Geometry)
                                 .Select(g => g.STLineCrossingDirection(GeometryInput.STGeomFromText(Line2)))
                                 .FirstOrDefault());
            }
        }

        [Test]
        public void TestSTDisjoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING ( 2 0, 0 2 )";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "LINESTRING ( 0 0, 0 2 )";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();

                const string PointWkt = "POINT(0 0)";
                var point = new NTSGS.Point(new NTSGS.Coordinate(0, 0));
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STDisjoint(point)).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STDisjoint(point)).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STDisjoint(null)).Single());


                // TODO: need explicit cast text to geometry
                if (base.CurrentVersion >= base.Version300)
                {
                    Assert.IsTrue(db.Select(() => SpatialRelationships.STDisjoint(Wkt1, PointWkt)));
                    Assert.IsFalse(db.Select(() => SpatialRelationships.STDisjoint(Wkt2, PointWkt)));
                }
            }
        }

        [Test]
        public void TestSTEquals()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(0 0, 10 10)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "LINESTRING(0 0, 5 5, 10 10)";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();

                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Single().Geometry;
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STEquals(geometry2)).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STReverse().STEquals(geometry2)).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STReverse().STEquals(null)).Single());

                Assert.IsTrue(db.Select(() => SpatialRelationships.STEquals(Wkt1, Wkt2)));
                Assert.IsNull(db.Select(() => SpatialRelationships.STEquals((string)null, (string)null)));
            }
        }

        [Test]
        public void TestSTIntersects()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING ( 2 0, 0 2 )";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "LINESTRING ( 0 0, 0 2 )";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();

                const string PointWkt = "POINT(0 0)";
                var point = new NTSGS.Point(new NTSGS.Coordinate(0, 0));

                Assert.IsFalse(db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STIntersects(point))
                    .Single());

                Assert.IsTrue(db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STIntersects(point))
                    .Single());

                Assert.IsNull(db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STIntersects(null))
                    .Single());

                Assert.IsFalse(db.Select(() => SpatialRelationships.STIntersects(Wkt1, PointWkt)));
                Assert.IsTrue(db.Select(() => SpatialRelationships.STIntersects(Wkt2, PointWkt)));
                Assert.IsNull(db.Select(() => SpatialRelationships.STIntersects((string)null, (string)null)));

                // geography
                var lineGeography = new NTSGS.LineString(new[] { new NTSGS.Coordinate(-43.23456, 72.4567), new NTSGS.Coordinate(-43.23456, 72.4568) }) { SRID = SRID4326 };
                db.Insert(new TestGeographyEntity(1, lineGeography));

                var pointGeography = new NTSGS.Point(-43.23456, 72.4567) { SRID = SRID4326 };
                db.Insert(new TestGeographyEntity(2, pointGeography));

                var intersects = db.TestGeographies
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geography.STIntersects(db.TestGeographies.Where(g0 => g0.Id == 2).Single().Geography))
                    .Single();

                Assert.IsTrue(intersects);
            }
        }

        [Test]
        public void TestSTOrderingEquals()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(0 0, 10 10, 20 20)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1))
                    .Insert();

                const string Wkt2 = "LINESTRING(0 0, 10 10, 20 20)";
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2))
                    .Insert();

                var geometry2 = db.TestGeometries.Single(g => g.Id == 2).Geometry;
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STOrderingEquals(geometry2)).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STReverse().STOrderingEquals(geometry2)).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STReverse().STOrderingEquals(null)).Single());

                Assert.IsTrue(db.Select(() => SpatialRelationships.STOrderingEquals(Wkt1, Wkt2)));
                Assert.IsNull(db.Select(() => SpatialRelationships.STOrderingEquals((string)null, (string)null)));
            }
        }

        [Test]
        public void TestSTOverlaps()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POLYGON((0 0, 0 1, 1 1, 0 0))";
                const string Wkt2 = "POLYGON((0.5 0.5, 0.7 0.5, 0.7 0.7, 0.5 0.7, 0.5 0.5))";
                const string Wkt3 = "LINESTRING(2 2,4 4)";
                const string Wkt4 = "POINT(3 3)";

                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2))
                    .Insert();

                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Single().Geometry;

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STOverlaps(geometry2)).Single());

                // TODO: need explicit cast text to geometry
                if (base.CurrentVersion >= base.Version300)
                {
                    Assert.IsFalse(db.Select(() => SpatialRelationships.STOverlaps(Wkt3, Wkt4)));
                }
            }
        }

        [Test]
        public void TestSTRelateBool()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POINT(1 2)";
                const string Wkt2 = "POINT(1 2)";

                Assert.IsTrue(db.Select(() =>
                            GeometryInput.STGeomFromText(Wkt1)
                                .STRelate(
                                GeometryProcessing.STBuffer(GeometryInput.STGeomFromText(Wkt2), 2),
                                "0FFFFF212")));

                Assert.IsNull(db.TestGeometries
                                .Where(g => g.Id == 1)
                                .Select(g => g.Geometry)
                                .Select(g => g.STRelate(
                                    GeometryProcessing.STBuffer(GeometryInput.STGeomFromText(Wkt2), 2),
                                    "0FFFFF212"
                                   )).FirstOrDefault());
            }
        }

        [Test]
        public void TestSTRelateDE9IM()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POINT(1 2)";
                const string Wkt2 = "POINT(3 4)";

                var result1 = db.Select(() =>
                    GeometryInput
                    .STGeomFromText(Wkt1)
                    .STRelate(GeometryInput.STGeomFromText(Wkt2)));
                Assert.IsFalse(string.IsNullOrEmpty(result1));

                var result2 = (
                                from g1 in db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry)
                                from g2 in db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry)
                                select SpatialRelationships.STRelate(g1, g2)
                            ).FirstOrDefault();

                Assert.IsTrue(String.IsNullOrEmpty(result2));
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

                Assert.IsFalse(String.IsNullOrEmpty(result1));
                Assert.IsFalse(String.IsNullOrEmpty(result2));
                Assert.IsFalse(String.IsNullOrEmpty(result3));
                Assert.IsFalse(String.IsNullOrEmpty(result4));

                Assert.AreEqual("FF0FFF0F2", result1);
                Assert.AreEqual("FF0FFF0F2", result2);
                Assert.AreEqual("FF0FFF0F2", result3);
                Assert.AreEqual("FF0FFF0F2", result4);

                Assert.IsTrue(String.IsNullOrEmpty(result5));
            }
        }

        [Test]
        public void TestSTRelateMatch()
        {
            const string Matrix = "101202FFF";
            const string MatrixPattern = "TTTTTTFFF";

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                Assert.IsTrue(db.Select(() => SpatialRelationships.STRelateMatch(Matrix, MatrixPattern)));
            }
        }

        [Test]
        public void TestSTTouches()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(0 0, 1 1, 0 2)";
                const string Wkt2 = "POINT(1 1)";
                const string Wkt3 = "POINT(0 2)";

                Assert.IsFalse(db.Select(() => SpatialRelationships.STTouches(
                    GeometryInput.STGeomFromText(Wkt1),
                    GeometryInput.STGeomFromText(Wkt2))));

                Assert.IsTrue(db.Select(() => SpatialRelationships.STTouches(
                    GeometryInput.STGeomFromText(Wkt1),
                    GeometryInput.STGeomFromText(Wkt3))));

                // TODO: need explicit cast text to geometry
                if (base.CurrentVersion >= base.Version300)
                {
                    Assert.IsFalse(db.Select(() => SpatialRelationships.STTouches(Wkt1, Wkt2)));
                    Assert.IsTrue(db.Select(() => SpatialRelationships.STTouches(Wkt1, Wkt3)));

                    Assert.IsNull(db.Select(() => SpatialRelationships.STTouches((NTSG)null, (NTSG)null)));
                    Assert.IsNull(db.Select(() => SpatialRelationships.STTouches((string)null, (string)null)));
                }
            }
        }

        [Test]
        public void TestST3DDWithin()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POINT(1 1 2)";
                const string Wkt2 = "LINESTRING(1 5 2, 2 7 20, 1 9 100, 14 12 3)";

                Assert.IsTrue(db.Select(() => SpatialRelationships.ST3DDWithin(
                                    GeometryInput.STGeomFromEWKT(Wkt1),
                                    GeometryInput.STGeomFromEWKT(Wkt2),
                                    10)));

                Assert.IsFalse(db.Select(() => SpatialRelationships.ST3DDFullyWithin(
                                    GeometryInput.STGeomFromEWKT(Wkt1),
                                    GeometryInput.STGeomFromEWKT(Wkt2),
                                    10)));

                Assert.IsTrue(db.Select(() => SpatialRelationships.ST3DDWithin(Wkt1, Wkt2, 10)));
                Assert.IsNull(db.Select(() => SpatialRelationships.ST3DDWithin((NTSG)null, (NTSG)null, 10)));
                Assert.IsNull(db.Select(() => SpatialRelationships.ST3DDWithin((string)null, (string)null, 10)));

                Assert.IsFalse(db.Select(() => SpatialRelationships.ST3DDFullyWithin(Wkt1, Wkt2, 10)));
                Assert.IsNull(db.Select(() => SpatialRelationships.ST3DDFullyWithin((NTSG)null, (NTSG)null, 10)));
                Assert.IsNull(db.Select(() => SpatialRelationships.ST3DDFullyWithin((string)null, (string)null, 10)));
            }
        }

        [Test]
        public void TestSTWithin()
        {
            const string Wkt1 = "POINT(1 1)";
            const string Wkt2 = "LINESTRING(1 5, 2 7, 1 9, 14 12)";

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                Assert.IsFalse(db.Select(() => SpatialRelationships.STDFullyWithin(
                                    GeometryInput.STGeomFromEWKT(Wkt1),
                                    GeometryInput.STGeomFromEWKT(Wkt2),
                                    10)));

                Assert.IsTrue(db.Select(() => SpatialRelationships.STDFullyWithin(
                                   GeometryInput.STGeomFromEWKT(Wkt1),
                                   GeometryInput.STGeomFromEWKT(Wkt2),
                                   20)));

                Assert.IsTrue(db.Select(() => SpatialRelationships.STDWithin(
                                    GeometryInput.STGeomFromEWKT(Wkt1),
                                    GeometryInput.STGeomFromEWKT(Wkt2),
                                    10)));

                // TODO: need explicit cast text to geometry
                if (base.CurrentVersion >= base.Version300)
                {
                    Assert.IsFalse(db.Select(() => SpatialRelationships.STDFullyWithin(Wkt1, Wkt2, 10)));
                    Assert.IsTrue(db.Select(() => SpatialRelationships.STDFullyWithin(Wkt1, Wkt2, 20)));
                    Assert.IsTrue(db.Select(() => SpatialRelationships.STDWithin(Wkt1, Wkt2, 10)));
                }
            }
        }

        [Test]
        public void TestSTPointInsideCircle()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Point1 = "POINT(1 1)";
                const string Point2 = "POINT(100 100)";
                const double CircleX = 1.0;
                const double CircleY = 1.0;

                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Point1))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Point2))
                    .Insert();

                Assert.IsTrue(db.TestGeometries
                                .Where(t => t.Id == 1)
                                .Select(t => t.Geometry)
                                .Select(g => g.STPointInsideCircle(CircleX, CircleY, 11))
                                .Single());

                Assert.IsFalse(db.TestGeometries
                                .Where(t => t.Id == 2)
                                .Select(t => t.Geometry)
                                .Select(g => g.STPointInsideCircle(CircleX, CircleY, 11))
                                .Single());

                Assert.IsNull(db.TestGeometries
                                .Where(g => g.Id == 3)
                                .Select(g => g.Geometry)
                                .Select(g => g.STPointInsideCircle(CircleX, CircleY, 11))
                                .FirstOrDefault());

                Assert.IsTrue(db.Select(() => SpatialRelationships.STPointInsideCircle("POINT(1 2)", 0.5, 2, 3)));
                Assert.IsNull(db.Select(() => SpatialRelationships.STPointInsideCircle("LINESTRING(0 0, 10 10)", 0.5, 2, 3)));
            }
        }
    }
}
