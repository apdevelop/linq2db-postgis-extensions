﻿using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSGS = NetTopologySuite.Geometries;
using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryConstructorsTests : TestsBase
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
        public void TestSTCollect()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STCollect(
                        GeometryInput.STGeomFromText("POINT(1 2)"),
                        GeometryInput.STGeomFromText("POINT(-2 3)")))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STCollect(
                        GeometryInput.STGeomFromText("POINT(1 2)"),
                        GeometryInput.STGeomFromText("LINESTRING(0 0, 0 1, 1 0, 1 1, 0 0)")))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => GeometryConstructors.STCollect(
                        "POINT(1 2)",
                        "POINT(-2 3)"))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 4)
                    .Value(g => g.Geometry, () => GeometryConstructors.STCollect(
                        "CIRCULARSTRING(220268 150415,220227 150505,220227 150406)",
                        "CIRCULARSTRING(220227 150406,2220227 150407,220227 150406)"))
                    .Insert();

                // WKT output for MULTIPOINT was changed in 3.3
                var collected1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual(
                    base.CurrentVersion < base.Version330 ? "MULTIPOINT(1 2,-2 3)" : "MULTIPOINT((1 2),(-2 3))",
                    collected1);

                var collected2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual("GEOMETRYCOLLECTION(POINT(1 2),LINESTRING(0 0,0 1,1 0,1 1,0 0))", collected2);

                // WKT output for MULTIPOINT was changed in 3.3
                Assert.AreEqual(
                    base.CurrentVersion < base.Version330 ? "MULTIPOINT(1 2,-2 3)" : "MULTIPOINT((1 2),(-2 3))",
                    db.TestGeometries
                        .Where(g => g.Id == 3)
                        .Select(g => g.Geometry.STAsText())
                        .Single());

                // Converting to WKT using STAsText to avoid 'Geometry type not recognized. GeometryCode: 11' error.
                Assert.AreEqual(
                    "MULTICURVE(CIRCULARSTRING(220268 150415,220227 150505,220227 150406),CIRCULARSTRING(220227 150406,2220227 150407,220227 150406))",
                    db.TestGeometries
                        .Where(g => g.Id == 4)
                        .Select(g => g.Geometry.STAsText())
                        .Single());
            }
        }

        [Test]
        public void TestSTLineFromMultiPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STLineFromMultiPoint(GeometryInput.STGeomFromText("MULTIPOINT(1 2 3, 4 5 6, 7 8 9)")))
                    .Insert();

                Assert.AreEqual(
                    "LINESTRING(1 2 3,4 5 6,7 8 9)",
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STLineFromMultiPoint("MULTIPOINT(1 2 3, 4 5 6, 7 8 9)"))
                    .Insert();

                Assert.AreEqual(
                    "LINESTRING(1 2 3,4 5 6,7 8 9)",
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());
            }
        }

        [Test]
        public void TestSTMakeEnvelope()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakeEnvelope(10, 10, 11, 11, SRID4326))
                    .Insert();

                Assert.AreEqual(
                    "SRID=4326;POLYGON((10 10,10 11,11 11,11 10,10 10))",
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakeEnvelope(10, 10, 11, 11))
                    .Insert();

                Assert.AreEqual(
                    "POLYGON((10 10,10 11,11 11,11 10,10 10))",
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());
            }
        }

        [Test]
        public void TestSTMakeLine()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () =>
                        GeometryInput.STGeomFromText("POINT(1 2)")
                            .STMakeLine(GeometryInput.STGeomFromText("POINT(3 4)")))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakeLine(
                        GeometryInput.STGeomFromText("LINESTRING(0 0, 1 1)"),
                        GeometryInput.STGeomFromText("LINESTRING(2 2, 3 3)")))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakeLine(
                        "LINESTRING(0 0, 1 1)",
                        "LINESTRING(2 2, 3 3)"))
                    .Insert();

                Assert.AreEqual(
                    "LINESTRING(1 2,3 4)",
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STAsText())
                        .Single());

                Assert.AreEqual(
                    "LINESTRING(0 0,1 1,2 2,3 3)",
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STAsText())
                        .Single());

                Assert.AreEqual(
                    "LINESTRING(0 0,1 1,2 2,3 3)",
                    db.TestGeometries
                        .Where(g => g.Id == 3)
                        .Select(g => g.Geometry.STAsText())
                        .Single());

                Assert.IsNull(db.Select(() => GeometryConstructors.STMakeLine((NTSG)null, (NTSG)null)));
            }
        }

        [Test]
        public void TestSTMakePoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePoint(-71.1043443253471, 42.3150676015829))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePoint(1, 2, 1.5))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePoint(10, 20, 30, -999))
                    .Insert();

                var point1 = db.TestGeometries.Where(g => g.Id == 1);
                Assert.AreEqual(-71.1043443253471, point1.Select(g => g.Geometry.STX()).Single().Value, 0.0000000000001);
                Assert.AreEqual(42.3150676015829, point1.Select(g => g.Geometry.STY()).Single().Value, 0.0000000000001);

                var point2 = db.TestGeometries.Where(g => g.Id == 2);
                Assert.AreEqual(1, point2.Select(g => g.Geometry.STX()).Single().Value, 0.1);
                Assert.AreEqual(2, point2.Select(g => g.Geometry.STY()).Single().Value, 0.1);
                Assert.AreEqual(1.5, point2.Select(g => g.Geometry.STZ()).Single().Value, 0.1);

                var point3 = db.TestGeometries.Where(g => g.Id == 3);
                Assert.AreEqual(10, point3.Select(g => g.Geometry.STX()).Single().Value, 0.1);
                Assert.AreEqual(20, point3.Select(g => g.Geometry.STY()).Single().Value, 0.1);
                Assert.AreEqual(30, point3.Select(g => g.Geometry.STZ()).Single().Value, 0.1);
                Assert.AreEqual(-999, point3.Select(g => g.Geometry.STM()).Single().Value, 0.1);
            }
        }

        [Test]
        public void TestSTMakePointM()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePointM(10, 20, -999))
                    .Insert();

                var point1 = db.TestGeometries.Where(g => g.Id == 1);
                Assert.AreEqual(10, point1.Select(g => g.Geometry.STX()).Single().Value, 0.1);
                Assert.AreEqual(20, point1.Select(g => g.Geometry.STY()).Single().Value, 0.1);
                Assert.AreEqual(-999, point1.Select(g => g.Geometry.STM()).Single().Value, 0.1);
            }
        }

        [Test]
        public void TestSTMakePolygon()
        {
            const string Wkt1 = "LINESTRING(75.15 29.53 1,77 29 1,77.6 29.5 1, 75.15 29.53 1)";
            const string Wkt2 = "LINESTRINGM(75.15 29.53 1,77 29 1,77.6 29.5 2, 75.15 29.53 2)";

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePolygon(GeometryInput.STGeomFromText(Wkt1)))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STMakePolygon(GeometryInput.STGeomFromText(Wkt2)))
                    .Insert();

                Assert.AreEqual("POLYGON((75.15 29.53 1,77 29 1,77.6 29.5 1,75.15 29.53 1))",
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());

                Assert.AreEqual("POLYGONM((75.15 29.53 1,77 29 1,77.6 29.5 2,75.15 29.53 2))",
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());
            }
        }

        [Test]
        public void TestSTPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STPoint(-71.104, 42.315))
                    .Insert();

                var point1 = db.TestGeometries.Where(g => g.Id == 1);
                Assert.AreEqual(-71.104, point1.Select(g => g.Geometry.STX()).Single().Value, 0.001);
                Assert.AreEqual(42.315, point1.Select(g => g.Geometry.STY()).Single().Value, 0.001);
            }
        }

        [Test]
        public void TestSTPointZ()
        {
            if (base.CurrentVersion >= base.Version320)
            {
                const double X = 1;
                const double Y = 2;
                const double Z = 3;
                const int Srid = 4326;

                NTSG res1;
                NTSG res2;

                using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
                {
                    res1 = db.Select(() => GeometryConstructors.STPointZ(X, Y, Z, Srid));
                    res2 = db.Select(() => GeometryConstructors.STPointZ(X, Y, Z));
                }

                Assert.IsNotNull(res1);
                Assert.AreEqual(X, res1.Coordinates[0].X);
                Assert.AreEqual(Y, res1.Coordinates[0].Y);
                Assert.AreEqual(Z, res1.Coordinates[0].Z);
                Assert.AreEqual(Srid, res1.SRID);

                Assert.IsNotNull(res2);
                Assert.AreEqual(X, res2.Coordinates[0].X);
                Assert.AreEqual(Y, res2.Coordinates[0].Y);
                Assert.AreEqual(Z, res2.Coordinates[0].Z);
                Assert.AreEqual(-1, res2.SRID);
            }
        }

        [Test]
        public void TestSTPointM()
        {
            if (base.CurrentVersion >= base.Version320)
            {
                const double X = 4;
                const double Y = 5;
                const double M = 6;
                const int Srid = 4326;

                NTSG res1;
                NTSG res2;

                using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
                {
                    res1 = db.Select(() => GeometryConstructors.STPointM(X, Y, M, Srid));
                    res2 = db.Select(() => GeometryConstructors.STPointM(X, Y, M));
                }

                Assert.IsNotNull(res1);
                Assert.AreEqual(X, res1.Coordinates[0].X);
                Assert.AreEqual(Y, res1.Coordinates[0].Y);
                Assert.AreEqual(M, res1.Coordinates[0].M);
                Assert.AreEqual(Srid, res1.SRID);

                Assert.IsNotNull(res2);
                Assert.AreEqual(X, res2.Coordinates[0].X);
                Assert.AreEqual(Y, res2.Coordinates[0].Y);
                Assert.AreEqual(M, res2.Coordinates[0].M);
                Assert.AreEqual(-1, res2.SRID);
            }
        }

        [Test]
        public void TestSTPointZM()
        {
            if (base.CurrentVersion >= base.Version320)
            {
                const double X = 23.0;
                const double Y = 41.1;
                const double Z = 2.1;
                const double M = 1;
                const int Srid = 4326;

                NTSG res1;
                NTSG res2;

                using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
                {
                    res1 = db.Select(() => GeometryConstructors.STPointZM(X, Y, Z, M, Srid));
                    res2 = db.Select(() => GeometryConstructors.STPointZM(X, Y, Z, M));
                }

                Assert.IsNotNull(res1);
                Assert.AreEqual(X, res1.Coordinates[0].X);
                Assert.AreEqual(Y, res1.Coordinates[0].Y);
                Assert.AreEqual(Z, res1.Coordinates[0].Z);
                Assert.AreEqual(M, res1.Coordinates[0].M);
                Assert.AreEqual(Srid, res1.SRID);

                Assert.IsNotNull(res2);
                Assert.AreEqual(X, res2.Coordinates[0].X);
                Assert.AreEqual(Y, res2.Coordinates[0].Y);
                Assert.AreEqual(Z, res2.Coordinates[0].Z);
                Assert.AreEqual(M, res2.Coordinates[0].M);
                Assert.AreEqual(-1, res2.SRID);
            }
        }

        [Test]
        public void TestSTPolygon()
        {
            const string Wkt1 = "LINESTRING(75 29, 77 29, 77 29, 75 29)";
            const string Wkt2 = "LINESTRING(75 29 1, 77 29 2, 77 29 3, 75 29 1)";

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryConstructors.STPolygon(GeometryInput.STGeomFromText(Wkt1), SRID4326))
                    .Insert();

                Assert.AreEqual(
                    "POLYGON((75 29,77 29,77 29,75 29))",
                    db.TestGeometries.Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STAsText())
                        .Single());

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryConstructors.STPolygon(GeometryInput.STGeomFromText(Wkt2), SRID4326))
                    .Insert();


                Assert.AreEqual(
                    "SRID=4326;POLYGON((75 29 1,77 29 2,77 29 3,75 29 1))",
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STAsEWKT())
                        .Single());

                // TODO: ? reason of error?  ST_Polygon(text) not works in 2.5 ?
                if (base.CurrentVersion >= base.Version300)
                {
                    db.TestGeometries
                        .Value(g => g.Id, 3)
                        .Value(g => g.Geometry, () => GeometryConstructors.STPolygon(Wkt1, SRID4326))
                        .Insert();

                    Assert.AreEqual(
                        "POLYGON((75 29,77 29,77 29,75 29))",
                        db.TestGeometries.Where(g => g.Id == 3)
                            .Select(g => g.Geometry.STAsText())
                            .Single());
                }
            }
        }

        [Test]
        public void TestSTTileEnvelope()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                if (base.CurrentVersion >= base.Version300)
                {
                    db.TestGeometries
                        .Value(g => g.Id, 1)
                        .Value(g => g.Geometry, () => GeometryConstructors.STTileEnvelope(2, 1, 1))
                        .Insert();

                    db.TestGeometries
                        .Value(g => g.Id, 2)
                        .Value(g => g.Geometry, () => GeometryConstructors.STTileEnvelope(3, 1, 1, GeometryConstructors.STMakeEnvelope(-180, -90, 180, 90, SRID4326)))
                        .Insert();

                    db.TestGeometries
                        .Value(g => g.Id, 3)
                        .Value(g => g.Geometry, () => GeometryConstructors.STTileEnvelope(2, 1, 1, "SRID=3857;LINESTRING(-20037508.342789 -20037508.342789,20037508.342789 20037508.342789)"))
                        .Insert();

                    var result1 = db.TestGeometries.Where(g => g.Id == 1);
                    var poly1 = result1.Select(g => g.Geometry).Single() as NTSGS.Polygon;
                    Assert.AreEqual(-10018754.1713945, poly1.Coordinates[0].X, 1.0E-6);
                    Assert.AreEqual(0, poly1.Coordinates[0].Y, 1.0E-6);
                    Assert.AreEqual(-10018754.1713945, poly1.Coordinates[1].X, 1.0E-6);
                    Assert.AreEqual(10018754.1713945, poly1.Coordinates[1].Y, 1.0E-6);
                    Assert.AreEqual(0, poly1.Coordinates[2].X, 1.0E-6);
                    Assert.AreEqual(10018754.1713945, poly1.Coordinates[2].Y, 1.0E-6);
                    Assert.AreEqual(0, poly1.Coordinates[3].X, 1.0E-6);
                    Assert.AreEqual(0, poly1.Coordinates[3].Y, 1.0E-6);
                    Assert.AreEqual(-10018754.1713945, poly1.Coordinates[4].X, 1.0E-6);
                    Assert.AreEqual(0, poly1.Coordinates[4].Y, 1.0E-6);
                    Assert.AreEqual(SRID3857, poly1.SRID);

                    var result2 = db.TestGeometries.Where(g => g.Id == 2);
                    Assert.AreEqual("POLYGON((-135 45,-135 67.5,-90 67.5,-90 45,-135 45))",
                        result2.Select(g => g.Geometry.STAsText()).Single());
                    Assert.AreEqual(SRID4326,
                        result2.Select(g => g.Geometry.STSrId()).Single());

                    var result3 = db.TestGeometries.Where(g => g.Id == 3);
                    var poly3 = result3.Select(g => g.Geometry).Single() as NTSGS.Polygon;
                    Assert.AreEqual(-10018754.1713945, poly3.Coordinates[0].X, 1.0E-6);
                    Assert.AreEqual(0, poly3.Coordinates[0].Y, 1.0E-6);
                    Assert.AreEqual(-10018754.1713945, poly3.Coordinates[1].X, 1.0E-6);
                    Assert.AreEqual(10018754.1713945, poly3.Coordinates[1].Y, 1.0E-6);
                    Assert.AreEqual(0, poly3.Coordinates[2].X, 1.0E-6);
                    Assert.AreEqual(10018754.1713945, poly3.Coordinates[2].Y, 1.0E-6);
                    Assert.AreEqual(0, poly3.Coordinates[3].X, 1.0E-6);
                    Assert.AreEqual(0, poly3.Coordinates[3].Y, 1.0E-6);
                    Assert.AreEqual(-10018754.1713945, poly3.Coordinates[4].X, 1.0E-6);
                    Assert.AreEqual(0, poly3.Coordinates[4].Y, 1.0E-6);
                    Assert.AreEqual(SRID3857, poly3.SRID);
                }
            }
        }

        [Test]
        public void TestSTHexagon()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                if (base.CurrentVersion >= base.Version310)
                {
                    var origin = db.Select(() => GeometryConstructors.STMakePoint(0, 0));

                    var hexagon1 = db.Select(() => GeometryConstructors.STHexagon(1.0, 0, 0, origin)) as NTSGS.Polygon;
                    Assert.IsNotNull(hexagon1);
                    Assert.AreEqual(7, hexagon1.Coordinates.Length);

                    var hexagon2 = db.Select(() => GeometryConstructors.STHexagon(1.0, 0, 0)) as NTSGS.Polygon;
                    Assert.IsNotNull(hexagon2);
                    Assert.AreEqual(7, hexagon2.Coordinates.Length);
                }
            }
        }

        [Test]
        public void TestSTSquare()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                if (base.CurrentVersion >= Version310)
                {
                    var origin = db.Select(() => GeometryConstructors.STMakePoint(0, 0));

                    var square1 = db.Select(() => GeometryConstructors.STSquare(1.0, 0, 0, origin)) as NTSGS.Polygon;
                    Assert.IsNotNull(square1);
                    Assert.AreEqual(5, square1.Coordinates.Length);

                    var square2 = db.Select(() => GeometryConstructors.STSquare(1.0, 0, 0)) as NTSGS.Polygon;
                    Assert.IsNotNull(square2);
                    Assert.AreEqual(5, square2.Coordinates.Length);
                }
            }
        }
    }
}
