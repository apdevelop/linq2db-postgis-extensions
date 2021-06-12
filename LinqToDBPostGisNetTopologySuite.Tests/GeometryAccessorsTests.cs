using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSGS = NetTopologySuite.Geometries;
using NTSG = NetTopologySuite.Geometries.Geometry;
using System;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryAccessorsTests : TestsBase
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
        public void TestGeometryType()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(77.29 29.07,77.42 29.26,77.27 29.31,77.29 29.07)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(wkt1))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => null)
                    .Insert();

                Assert.AreEqual(
                    "LINESTRING",
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.GeometryType())
                        .Single());

                Assert.AreEqual(
                    "ST_LineString",
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STGeometryType())
                        .Single());

                Assert.IsNull(db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.GeometryType())
                    .Single());

                Assert.IsNull(db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STGeometryType())
                    .Single());
            }
        }

        [Test]
        public void TestSTBoundary()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(100 150,50 60, 70 80, 160 170)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(wkt1))
                    .Insert();

                const string wkt2 = "POLYGON ((10 130, 50 190, 110 190, 140 150, 150 80, 100 10, 20 40, 10 130), (70 40, 100 50, 120 80, 80 110, 50 90, 70 40))";
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(wkt2))
                    .Insert();

                const string wkt3 = "MULTILINESTRING((1 1 1,0 0 0.5, -1 1 1),(1 1 0.5,0 0 0.5, -1 1 0.5, 1 1 0.5) )";
                db.TestGeometries
                    .Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(wkt3))
                    .Insert();

                Assert.AreEqual(
                    "MULTIPOINT(100 150,160 170)",
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STBoundary().STAsText())
                        .Single());

                Assert.AreEqual(
                    "MULTILINESTRING((10 130,50 190,110 190,140 150,150 80,100 10,20 40,10 130),(70 40,100 50,120 80,80 110,50 90,70 40))",
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STBoundary().STAsText())
                        .Single());

                Assert.AreEqual(
                    "MULTIPOINT Z (-1 1 1,1 1 0.75)",
                    db.TestGeometries
                        .Where(g => g.Id == 3)
                        .Select(g => g.Geometry.STBoundary().STAsText())
                        .Single());

                Assert.IsNull(db.Select(() => GeometryAccessors.STBoundary((NTSG)null)));
                Assert.AreEqual("MULTIPOINT(100 150,160 170)", db.Select(() => GeometryAccessors.STBoundary(wkt1).STAsText()));
            }
        }

        [Test]
        public void TestSTCoordDim()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "CIRCULARSTRING(1 2 3, 1 3 4, 5 6 7, 8 9 10, 11 12 13)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                Assert.AreEqual(
                    3,
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STCoordDim())
                        .Single());

                Assert.IsNull(db.Select(() => GeometryAccessors.STCoordDim((NTSG)null)));
                Assert.AreEqual(3, db.Select(() => GeometryAccessors.STCoordDim("CIRCULARSTRING(1 2 3, 1 3 4, 5 6 7, 8 9 10, 11 12 13)")));
            }
        }

        [Test]
        public void TestSTDimension()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "GEOMETRYCOLLECTION(LINESTRING(1 1,0 0),POINT(0 0))";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(wkt1))
                    .Insert();

                const string wkt2 = "POINT(0 0)";
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(wkt2))
                    .Insert();

                var dimension1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STDimension())
                    .Single();
                Assert.AreEqual(1, dimension1);

                var dimension2 = db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STDimension())
                    .Single();
                Assert.AreEqual(0, dimension2);

                Assert.IsNull(db.Select(() => GeometryAccessors.STDimension((NTSG)null)));
                Assert.AreEqual(1, db.Select(() => GeometryAccessors.STDimension("GEOMETRYCOLLECTION(LINESTRING(1 1,0 0),POINT(0 0))")));
            }
        }

        [Test]
        public void TestSTEndPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(1 1, 2 2, 3 3)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1))
                    .Insert();

                const string Wkt2 = "POINT(1 1)";
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2))
                    .Insert();

                var endPoint1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STEndPoint().STAsText())
                    .Single();
                Assert.AreEqual("POINT(3 3)", endPoint1);

                var endPoint2 = db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STEndPoint())
                    .Single();
                Assert.IsNull(endPoint2);

                Assert.IsNull(db.Select(() => GeometryAccessors.STEndPoint((NTSG)null)));

                Assert.IsNotNull(db.Select(() => GeometryAccessors.STEndPoint(Wkt1)));
                Assert.AreEqual(
                    "POINT(3 3)",
                    db.Select(() => GeometryAccessors.STEndPoint(Wkt1).STAsText()));
                Assert.IsNull(db.Select(() => GeometryAccessors.STEndPoint(Wkt2)));
            }
        }

        [Test]
        public void TestSTEnvelope()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(0 0, 1 3)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                var envelope = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STEnvelope().STAsText())
                    .Single();
                Assert.AreEqual("POLYGON((0 0,0 3,1 3,1 0,0 0))", envelope);

                Assert.AreEqual(
                    "POLYGON((0 0,0 3,1 3,1 0,0 0))",
                    db.Select(() => GeometryAccessors.STEnvelope(Wkt).STAsText()));

                Assert.IsNull(db.Select(() => GeometryAccessors.STEnvelope((NTSG)null)));
            }
        }

        [Test]
        public void TestSTBoundingDiagonal()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePoint(0, 0).STBuffer(10))
                    .Insert();

                var bbBoxDiagonal1 = db.TestGeometries
                    .Select(g => g.Geometry.STBoundingDiagonal().STAsText())
                    .Single();
                Assert.AreEqual("LINESTRING(-10 -10,10 10)", bbBoxDiagonal1);

                var bbBoxDiagonal2 = db.TestGeometries
                    .Select(g => GeometryAccessors.STBoundingDiagonal(g.Geometry.STAsText()).STAsText())
                    .Single();
                Assert.AreEqual("LINESTRING(-10 -10,10 10)", bbBoxDiagonal2);

                Assert.IsNull(db.Select(() => GeometryAccessors.STBoundingDiagonal((NTSG)null)));
            }
        }

        [Test]
        public void TestSTBoundingDiagonalWithFits()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePoint(0, 0).STBuffer(10))
                    .Insert();

                var bbBoxDiagonal1 = db.TestGeometries
                    .Select(g => g.Geometry.STBoundingDiagonal(false).STAsText())
                    .Single();
                Assert.AreEqual("LINESTRING(-10 -10,10 10)", bbBoxDiagonal1);

                var bbBoxDiagonal2 = db.TestGeometries
                    .Select(g => GeometryAccessors.STBoundingDiagonal(g.Geometry.STAsText(), false).STAsText())
                    .Single();
                Assert.AreEqual("LINESTRING(-10 -10,10 10)", bbBoxDiagonal2);

                Assert.IsNull(db.Select(() => GeometryAccessors.STBoundingDiagonal((NTSG)null, false)));
            }
        }

        [Test]
        public void TestSTExteriorRing()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                Assert.AreEqual(
                    "LINESTRING(0 0 1,1 1 1,1 2 1,1 1 1,0 0 1)",
                    db.Select(() => GeometryInput
                        .STGeomFromEWKT("POLYGON((0 0 1, 1 1 1, 1 2 1, 1 1 1, 0 0 1))")
                        .STExteriorRing()
                        .STAsEWKT()));

                Assert.AreEqual(
                    "LINESTRING(0 0 1,1 1 1,1 2 1,1 1 1,0 0 1)",
                    db.Select(() => GeometryAccessors
                        .STExteriorRing("POLYGON((0 0 1, 1 1 1, 1 2 1, 1 1 1, 0 0 1))")
                        .STAsEWKT()));

                Assert.IsNull(db.Select(() => GeometryAccessors.STExteriorRing((NTSG)null)));
            }
        }

        [Test]
        public void TestSTGeometryN()
        {
            const string Ewkt =
                        @"TIN (((
                            0 0 0,
                            0 0 1,
                            0 1 0,
                            0 0 0
                        )), ((
                            0 0 0,
                            0 1 0,
                            1 1 0,
                            0 0 0
                        )))";

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                Assert.AreEqual(
                    "TRIANGLE((0 0 0,0 1 0,1 1 0,0 0 0))",
                    db.Select(() => GeometryInput.STGeomFromEWKT(Ewkt)
                        .STGeometryN(2)
                        .STAsEWKT()));

                Assert.AreEqual(
                    "TRIANGLE((0 0 0,0 1 0,1 1 0,0 0 0))",
                    db.Select(() => GeometryAccessors.STGeometryN(Ewkt, 2)
                        .STAsEWKT()));

                Assert.IsNull(db.Select(() => GeometryAccessors.STGeometryN((NTSG)null, 1)));
            }
        }

        [Test]
        public void TestSTGeometryType()
        {
            const string Wkt = "LINESTRING(77.29 29.07,77.42 29.26,77.27 29.31,77.29 29.07)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                Assert.AreEqual(
                    "ST_LineString",
                    db.Select(() => GeometryInput.STGeomFromText(Wkt)
                        .STGeometryType()));

                Assert.AreEqual(
                    "ST_LineString",
                    db.Select(() => GeometryAccessors.STGeometryType(Wkt)));

                Assert.IsNull(db.Select(() => GeometryAccessors.STGeometryType((NTSG)null)));
            }
        }

        [Test]
        public void TestSTHasArc()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () =>
                    GeometryConstructors.STCollect(
                        GeometryInput.STGeomFromText("LINESTRING(1 2, 3 4, 5 6)"),
                        GeometryInput.STGeomFromText("CIRCULARSTRING(1 1, 2 3, 4 5, 6 7, 5 6)")))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => null)
                    .Insert();

                Assert.IsTrue(db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STHasArc())
                    .Single());

                Assert.IsNull(db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STHasArc())
                    .Single());

                Assert.IsTrue(db.Select(() => GeometryAccessors.STHasArc("CIRCULARSTRING(1 1, 2 3, 4 5, 6 7, 5 6)")));
            }
        }

        [Test]
        public void TestSTInteriorRingN()
        {
            const string Wkt = "POLYGON((0 0 1,0 5 1,5 0 1,0 0 1),(1 1 1,3 1 1,1 3 1,1 1 1))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                var result = db.TestGeometries
                                .Where(g => g.Id == 1)
                                .Select(g => g.Geometry.STInteriorRingN(1))
                                .Single() as NTSGS.LineString;

                var result2 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => GeometryAccessors.STInteriorRingN(g.Geometry.STAsText(), 1))
                    .Single() as NTSGS.LineString;

                var emptyResult = db.TestGeometries
                                .Where(g => g.Id == 1)
                                .Select(g => g.Geometry.STInteriorRingN(2))
                                .Single() as NTSGS.LineString;

                Assert.IsNotNull(result);
                Assert.IsNull(emptyResult);

                Assert.AreEqual(1, result.Coordinates[0].X);
                Assert.AreEqual(1, result.Coordinates[0].Y);
                Assert.AreEqual(1, result.Coordinates[0].Z);

                Assert.AreEqual(3, result.Coordinates[1].X);
                Assert.AreEqual(1, result.Coordinates[1].Y);
                Assert.AreEqual(1, result.Coordinates[1].Z);

                Assert.AreEqual(1, result.Coordinates[2].X);
                Assert.AreEqual(3, result.Coordinates[2].Y);
                Assert.AreEqual(1, result.Coordinates[2].Z);

                Assert.AreEqual(1, result.Coordinates[3].X);
                Assert.AreEqual(1, result.Coordinates[3].Y);
                Assert.AreEqual(1, result.Coordinates[3].Z);

                Assert.IsTrue(result2.CompareTo(result) == 0);

                Assert.IsNull(db.Select(() => GeometryAccessors.STInteriorRingN((NTSG)null, 1)));
            }
        }

        [Test]
        public void TestSTIsPolygonCCW()
        {
            const string Wkt = "POLYGON((0 0 1,5 0 1,0 5 1,0 0 1),(1 1 1,1 3 1,3 1 1,1 1 1))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                var result1 = db.TestGeometries
                                .Where(g => g.Id == 1)
                                .Select(g => g.Geometry.STIsPolygonCCW())
                                .Single();

                Assert.IsTrue(result1.HasValue);
                Assert.IsTrue(result1);

                var result2 = db.TestGeometries
                                .Where(g => g.Id == 1)
                                .Select(g => GeometryAccessors.STIsPolygonCCW(g.Geometry.STAsText()))
                                .Single();

                Assert.IsTrue(result2.HasValue);
                Assert.IsTrue(result2);

                Assert.IsNull(db.Select(() => GeometryAccessors.STIsPolygonCCW((NTSG)null)));
            }
        }

        [Test]
        public void TestSTIsPolygonCW()
        {
            const string Wkt = "POLYGON((0 0 1,0 5 1,5 0 1,0 0 1),(1 1 1,3 1 1,1 3 1,1 1 1))";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                var result1 = db.TestGeometries
                                .Where(g => g.Id == 1)
                                .Select(g => g.Geometry.STIsPolygonCW())
                                .Single();

                Assert.IsTrue(result1.HasValue);
                Assert.IsTrue(result1);

                var result2 = db.TestGeometries
                                .Where(g => g.Id == 1)
                                .Select(g => GeometryAccessors.STIsPolygonCW(g.Geometry.STAsText()))
                                .Single();

                Assert.IsTrue(result2.HasValue);
                Assert.IsTrue(result2);

                Assert.IsNull(db.Select(() => GeometryAccessors.STIsPolygonCW((NTSG)null)));
            }
        }

        [Test]
        public void TestSTIsClosed()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(0 0, 1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "LINESTRING(0 0, 0 1, 1 1, 0 0)";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => null).Insert();

                Assert.IsFalse(db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STIsClosed())
                    .Single());
                Assert.IsTrue(db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STIsClosed())
                    .Single());

                Assert.IsFalse(db.Select(() => GeometryAccessors.STIsClosed(Wkt1)));
                Assert.IsTrue(db.Select(() => GeometryAccessors.STIsClosed(Wkt2)));

                Assert.IsNull(db.TestGeometries
                    .Where(g => g.Id == 3)
                    .Select(g => g.Geometry.STIsClosed())
                    .Single());
            }
        }

        [Test]
        public void TestSTIsCollection()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText("LINESTRING(0 0, 1 1)")).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT("MULTIPOINT EMPTY")).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT("MULTIPOINT((0 0))")).Insert();
                db.TestGeometries.Value(g => g.Id, 4).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT("MULTIPOINT((0 0), (42 42))")).Insert();
                db.TestGeometries.Value(g => g.Id, 5).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT("GEOMETRYCOLLECTION(POINT(0 0))")).Insert();
                db.TestGeometries.Value(g => g.Id, 6).Value(g => g.Geometry, () => null).Insert();

                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsCollection()).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsCollection()).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsCollection()).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STIsCollection()).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 5).Select(g => g.Geometry.STIsCollection()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 6).Select(g => g.Geometry.STIsCollection()).Single());

                Assert.IsNull(db.Select(() => GeometryAccessors.STIsCollection((NTSG)null)));
                Assert.IsFalse(db.Select(() => GeometryAccessors.STIsCollection("LINESTRING(0 0, 1 1)")));
                Assert.IsTrue(db.Select(() => GeometryAccessors.STIsCollection("MULTIPOINT EMPTY")));
            }
        }

        [Test]
        public void TestSTIsEmpty()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "GEOMETRYCOLLECTION EMPTY";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "POLYGON((1 2, 3 4, 5 6, 1 2))";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => null).Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsEmpty()).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsEmpty()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsEmpty()).Single());

                // TODO: Need some research for reason of error: 
                // function st_isempty(unknown) is not unique. Could not choose a best candidate function. You might need to add explicit type casts.
                var version = new Version(db.Select(() => VersionFunctions.PostGISLibVersion()));
                if (version > new Version("3.0.0"))
                {
                    Assert.IsNull(db.Select(() => GeometryAccessors.STIsEmpty((NTSG)null)));
                    Assert.IsTrue(db.Select(() => GeometryAccessors.STIsEmpty("CIRCULARSTRING EMPTY")));
                    Assert.IsFalse(db.Select(() => GeometryAccessors.STIsEmpty("POINT(0 0)")));
                }
            }
        }

        [Test]
        public void TestSTIsRing()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(0 0, 0 1, 1 1, 1 0, 0 0)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();
                const string Wkt2 = "LINESTRING(0 0, 0 1, 1 0, 1 1, 0 0)";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => null).Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsRing()).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsRing()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsRing()).Single());

                Assert.IsNull(db.Select(() => GeometryAccessors.STIsRing((NTSG)null)));
                Assert.IsTrue(db.Select(() => GeometryAccessors.STIsRing(Wkt1)));
                Assert.IsFalse(db.Select(() => GeometryAccessors.STIsRing(Wkt2)));
            }
        }

        [Test]
        public void TestSTIsSimple()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POLYGON((1 1, 2 1, 2 2, 1 1))";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "LINESTRING(1 1,2 2,2 3.5,1 3,1 2,2 1)";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => null).Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsSimple()).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsSimple()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsSimple()).Single());

                Assert.IsNull(db.Select(() => GeometryAccessors.STIsSimple((NTSG)null)));
                Assert.IsTrue(db.Select(() => GeometryAccessors.STIsSimple(Wkt1)));
                Assert.IsFalse(db.Select(() => GeometryAccessors.STIsSimple(Wkt2)));
            }
        }

        [Test]
        public void TestSTMemSize()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText("POINT(0 0)"))
                    .Insert();
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => null)
                    .Insert();

                Assert.AreEqual(32, db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STMemSize())
                    .Single());

                Assert.IsNull(db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STMemSize())
                    .Single());

                Assert.AreEqual(32, db.Select(() => GeometryAccessors.STMemSize("POINT(0 0)")));
            }
        }

        [Test]
        public void TestSTNDims()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText("POINT(1 1)")).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT("POINT(1 1 2)")).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT("POINTM(1 1 0.5)")).Insert();
                db.TestGeometries.Value(g => g.Id, 4).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT("POINTZM(1 2 3 4)")).Insert();
                db.TestGeometries.Value(g => g.Id, 5).Value(g => g.Geometry, () => null).Insert();

                Assert.AreEqual(2, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNDims()).Single());
                Assert.AreEqual(3, db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STNDims()).Single());
                Assert.AreEqual(3, db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STNDims()).Single());
                Assert.AreEqual(4, db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STNDims()).Single());

                Assert.IsNull(db.TestGeometries
                    .Where(g => g.Id == 5)
                    .Select(g => g.Geometry.STNDims())
                    .Single());

                Assert.AreEqual(4, db.Select(() => GeometryAccessors.STNDims("POINTZM(1 2 3 4)")));
            }
        }

        [Test]
        public void TestSTNPoints()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POINT(77.29 29.07)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "LINESTRING(77.29 29.07 1,77.42 29.26 0,77.27 29.31 -1,77.29 29.07 3)";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();

                const string Wkt3 = "LINESTRING EMPTY";
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt3)).Insert();
                db.TestGeometries.Value(g => g.Id, 4).Value(g => g.Geometry, () => null).Insert();

                var nPoints1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNPoints()).Single();
                Assert.AreEqual(1, nPoints1);

                var nPoints2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STNPoints()).Single();
                Assert.AreEqual(4, nPoints2);

                var nPoints3 = db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STNPoints()).Single();
                Assert.AreEqual(0, nPoints3);

                var nPoints4 = db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STNPoints()).Single();
                Assert.IsNull(nPoints4);

                Assert.IsNull(db.Select(() => GeometryAccessors.STNPoints((NTSG)null)));
                Assert.AreEqual(1, db.Select(() => GeometryAccessors.STNPoints(Wkt1)));
                Assert.AreEqual(4, db.Select(() => GeometryAccessors.STNPoints(Wkt2)));
                Assert.AreEqual(0, db.Select(() => GeometryAccessors.STNPoints(Wkt3)));
            }
        }

        [Test]
        public void TestSTNumGeometries()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(77.29 29.07,77.42 29.26,77.27 29.31,77.29 29.07)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "GEOMETRYCOLLECTION(MULTIPOINT(-2 3 , -2 2), LINESTRING(5 5, 10 10), POLYGON((-7 4.2, -7.1 5, -7.1 4.3, -7 4.2)))";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();

                const string Wkt3 = "POINT EMPTY";
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt3)).Insert();
                db.TestGeometries.Value(g => g.Id, 4).Value(g => g.Geometry, () => null).Insert();

                Assert.AreEqual(
                    1,
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STNumGeometries())
                        .Single());

                Assert.AreEqual(
                    3,
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STNumGeometries())
                        .Single());

                Assert.AreEqual(
                    0,
                    db.TestGeometries
                        .Where(g => g.Id == 3)
                        .Select(g => g.Geometry.STNumGeometries())
                        .Single());

                Assert.IsNull(db.TestGeometries
                    .Where(g => g.Id == 4)
                    .Select(g => g.Geometry.STNumGeometries())
                    .Single());

                Assert.AreEqual(
                    3,
                    db.Select(() => GeometryAccessors.STNumGeometries(Wkt2)));
            }
        }

        [Test]
        public void TestSTNRings()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "POLYGON((1 2, 3 4, 5 6, 1 2))";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => null)
                    .Insert();

                Assert.AreEqual(1, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNRings()).Single());
                Assert.AreEqual(0, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNumInteriorRings()).Single());
                Assert.AreEqual(0, db.Select(() => GeometryAccessors.STNumInteriorRings(Wkt)));

                // STNumInteriorRing is synonym to STNumInteriorRings. See http://postgis.net/docs/manual-1.5/ST_NumInteriorRing.html
                Assert.AreEqual(0, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNumInteriorRing()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STNRings()).Single());

                Assert.IsNull(db.Select(() => GeometryAccessors.STNRings((NTSG)null)));
                Assert.AreEqual(1, db.Select(() => GeometryAccessors.STNRings(Wkt)));
                Assert.AreEqual(0, db.Select(() => GeometryAccessors.STNumInteriorRing(Wkt)));
            }
        }

        [Test]
        public void TestSTNumPatches()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Ewkt = @"POLYHEDRALSURFACE(
                                        ((0 0 0, 0 0 1, 0 1 1, 0 1 0, 0 0 0)),
                                        ((0 0 0, 0 1 0, 1 1 0, 1 0 0, 0 0 0)), ((0 0 0, 1 0 0, 1 0 1, 0 0 1, 0 0 0)),
                                        ((1 1 0, 1 1 1, 1 0 1, 1 0 0, 1 1 0)),
                                        ((0 1 0, 0 1 1, 1 1 1, 1 1 0, 0 1 0)), ((0 0 1, 1 0 1, 1 1 1, 0 1 1, 0 0 1)) )";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText("POINT(1 1)")).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => null).Insert();

                Assert.AreEqual(6, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNumPatches()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STNumPatches()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STNumPatches()).Single());

                Assert.IsNull(db.Select(() => GeometryAccessors.STNumPatches((NTSG)null)));
                Assert.AreEqual(6, db.Select(() => GeometryAccessors.STNumPatches(Ewkt)));
            }
        }

        [Test]
        public void TestSTNumPoints()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(77.29 29.07,77.42 29.26,77.27 29.31,77.29 29.07)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "POINT(77.29 29.07)";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();

                Assert.AreEqual(4, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNumPoints()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STNumPoints()).Single());

                Assert.AreEqual(4, db.Select(() => GeometryAccessors.STNumPoints(Wkt1)));
                Assert.IsNull(db.Select(() => GeometryAccessors.STNumPoints(Wkt2)));
            }
        }

        [Test]
        public void TestSTPatchN()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Ewkt = @"POLYHEDRALSURFACE( 
                                        ((0 0 0, 0 0 1, 0 1 1, 0 1 0, 0 0 0)),
                                        ((0 0 0, 0 1 0, 1 1 0, 1 0 0, 0 0 0)), ((0 0 0, 1 0 0, 1 0 1, 0 0 1, 0 0 0)),
                                        ((1 1 0, 1 1 1, 1 0 1, 1 0 0, 1 1 0)),
                                        ((0 1 0, 0 1 1, 1 1 1, 1 1 0, 0 1 0)), ((0 0 1, 1 0 1, 1 1 1, 0 1 1, 0 0 1)) )";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText("POINT(1 1)")).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => null).Insert();

                Assert.AreEqual("POLYGON((0 0 0,0 1 0,1 1 0,1 0 0,0 0 0))", db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STPatchN(2).STAsEWKT()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STPatchN(1)).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STPatchN(1)).Single());

                Assert.AreEqual("POLYGON((0 0 0,0 1 0,1 1 0,1 0 0,0 0 0))", db.Select(() => GeometryAccessors.STPatchN(Ewkt, 2).STAsEWKT()));
            }
        }

        [Test]
        public void TestSTPointN()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(0 0, 1 1, 2 2)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                Assert.AreEqual(
                    "POINT(0 0)",
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STPointN(1).STAsText())
                        .Single());

                Assert.AreEqual(
                    "POINT(0 0)",
                    db.Select(() => GeometryAccessors.STPointN(Wkt, 1).STAsText()));

                Assert.IsNull(db.Select(() => GeometryAccessors.STPointN((NTSG)null, 1)));
                Assert.IsNull(db.Select(() => GeometryAccessors.STPointN("POINT(0 0)", 1)));
            }
        }

        [Test]
        public void TestSTPoints()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "POLYGON Z ((30 10 4,10 30 5,40 40 6, 30 10 4))";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                const string ExpectedMultiPoint = "MULTIPOINT Z (30 10 4,10 30 5,40 40 6,30 10 4)";
                Assert.AreEqual(ExpectedMultiPoint, db.TestGeometries.Select(g => g.Geometry.STPoints().STAsText()).Single());
                Assert.AreEqual(ExpectedMultiPoint, db.Select(() => GeometryAccessors.STPoints(Wkt).STAsText()));
                Assert.IsNull(db.Select(() => GeometryAccessors.STPoints((NTSG)null)));
            }
        }

        [Test]
        public void TestSTStartPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(0 1, 0 2)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "POINT(0 1)";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();

                Assert.AreEqual(
                                "POINT(0 1)",
                                db.TestGeometries
                                    .Where(g => g.Id == 1)
                                    .Select(g => g.Geometry.STStartPoint().STAsText())
                                    .Single());

                Assert.IsNull(db.TestGeometries
                                    .Where(g => g.Id == 2)
                                    .Select(g => g.Geometry.STStartPoint())
                                    .Single());

                Assert.AreEqual("POINT(0 1)", db.Select(() => GeometryAccessors.STStartPoint(Wkt1).STAsText()));
                Assert.IsNull(db.Select(() => GeometryAccessors.STStartPoint(Wkt2)));
                Assert.IsNull(db.Select(() => GeometryAccessors.STStartPoint((NTSG)null)));
            }
        }

        [Test]
        public void TestSTSummary()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText("LINESTRING(0 0, 1 1)"))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => null)
                    .Insert();

                Assert.AreEqual("LineString[] with 2 points", db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STSummary()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STSummary()).Single());
            }
        }

        [Test]
        public void TestSTXYZM()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POINT(1 2 3 4)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "POINT(1 2)";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();

                const string Wkt3 = "POINT EMPTY";
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt3)).Insert();

                var query1 = db.TestGeometries.Where(g => g.Id == 1);
                Assert.AreEqual(1, query1.Select(g => g.Geometry.STX()).Single());
                Assert.AreEqual(2, query1.Select(g => g.Geometry.STY()).Single());
                Assert.AreEqual(3, query1.Select(g => g.Geometry.STZ()).Single());
                Assert.AreEqual(4, query1.Select(g => g.Geometry.STM()).Single());
                Assert.AreEqual(1, db.Select(() => GeometryAccessors.STX(Wkt1)));
                Assert.AreEqual(2, db.Select(() => GeometryAccessors.STY(Wkt1)));
                Assert.AreEqual(3, db.Select(() => GeometryAccessors.STZ(Wkt1)));
                Assert.AreEqual(4, db.Select(() => GeometryAccessors.STM(Wkt1)));

                var query2 = db.TestGeometries.Where(g => g.Id == 2);
                Assert.AreEqual(1, query2.Select(g => g.Geometry.STX()).Single());
                Assert.AreEqual(2, query2.Select(g => g.Geometry.STY()).Single());
                Assert.IsNull(query2.Select(g => g.Geometry.STZ()).Single());
                Assert.IsNull(query2.Select(g => g.Geometry.STM()).Single());
                Assert.IsNull(db.Select(() => GeometryAccessors.STZ(Wkt2)));
                Assert.IsNull(db.Select(() => GeometryAccessors.STM(Wkt2)));

                var query3 = db.TestGeometries.Where(g => g.Id == 3);
                Assert.IsNull(query3.Select(g => g.Geometry.STX()).Single());
                Assert.IsNull(query3.Select(g => g.Geometry.STY()).Single());
                Assert.IsNull(query2.Select(g => g.Geometry.STZ()).Single());
                Assert.IsNull(query2.Select(g => g.Geometry.STM()).Single());

                Assert.IsNull(db.Select(() => GeometryAccessors.STM((NTSG)null)));
                Assert.AreEqual(4, db.Select(() => GeometryAccessors.STM(Wkt1)));
                Assert.IsNull(db.Select(() => GeometryAccessors.STM(Wkt3)));
            }
        }

        [Test]
        public void TestSTZmflag()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(1 2, 3 4)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt1)).Insert();

                const string Wkt2 = "LINESTRINGM(1 2 3, 3 4 3)";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt2)).Insert();

                const string Wkt3 = "CIRCULARSTRING(1 2 3, 3 4 3, 5 6 3)";
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt3)).Insert();

                const string Wkt4 = "POINT(1 2 3 4)";
                db.TestGeometries.Value(g => g.Id, 4).Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt4)).Insert();
                db.TestGeometries.Value(g => g.Id, 5).Value(g => g.Geometry, () => null).Insert();

                Assert.AreEqual(0, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STZmflag()).Single());
                Assert.AreEqual(1, db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STZmflag()).Single());
                Assert.AreEqual(2, db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STZmflag()).Single());
                Assert.AreEqual(3, db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STZmflag()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 5).Select(g => g.Geometry.STZmflag()).Single());

                Assert.AreEqual(0, db.Select(() => GeometryAccessors.STZmflag(Wkt1)));
                Assert.AreEqual(1, db.Select(() => GeometryAccessors.STZmflag(Wkt2)));
                Assert.AreEqual(2, db.Select(() => GeometryAccessors.STZmflag(Wkt3)));
                Assert.AreEqual(3, db.Select(() => GeometryAccessors.STZmflag(Wkt4)));
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 5).Select(g => g.Geometry.STZmflag()).Single());
            }
        }
    }
}
