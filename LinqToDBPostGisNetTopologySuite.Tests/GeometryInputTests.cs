using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSGS = NetTopologySuite.Geometries;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryInputTests : TestsBase
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
        public void TestSTBdPolyFromText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "MULTILINESTRING ((0 0, 0 150, 150 150, 150 0, 0 0), (20 20, 50 20, 50 50, 20 50, 20 20))";
                Assert.AreEqual(
                    "SRID=23030;POLYGON((0 0,0 150,150 150,150 0,0 0),(20 20,50 20,50 50,20 50,20 20))",
                    db.Select(() => GeometryInput.STBdPolyFromText(Wkt1, 23030).STAsEWKT()));

                Assert.IsNull(db.Select(() => GeometryInput.STBdPolyFromText("MULTILINESTRING ((0 0, 0 150, 150 150, 150 0, 20 20))", 0).STAsEWKT()));

                Assert.IsNull(db.Select(() => GeometryInput.STBdPolyFromText(null, 0)));
            }
        }

        [Test]
        public void TestSTBdMPolyFromText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "MULTILINESTRING ((0 0 -10, 1 0 -5, 1 1 -5, 0 1 -5, 0 0 10), (2 2 -3, 4 2 -1, 4 4 -1, 2 4 -1, 2 2 -3))";
                var result = db.Select(() => GeometryInput.STBdMPolyFromText(Wkt1, 23030)) as NTSGS.MultiPolygon;

                // "SRID=23030;MULTIPOLYGON(((0 0 10,0 1 -5,1 1 -5,1 0 -5,0 0 -10)),((2 2 -3,2 4 -1,4 4 -1,4 2 -1,2 2 -3)))"
                Assert.IsNotNull(result);
                Assert.AreEqual(23030, result.SRID);
                Assert.AreEqual(2, result.Geometries.Length);

                Assert.IsNull(db.Select(() => GeometryInput.STBdMPolyFromText(null, 0)));
            }
        }

        [Test]
        public void TestSTGeographyFromText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POINT(177.0092 38.889588)";
                var geography11 = db.Select(() => GeometryInput.STGeographyFromText(Wkt1));

                Assert.IsNotNull(geography11);
                Assert.AreEqual(SRID4326, geography11.SRID);
                Assert.AreEqual("Point", geography11.GeometryType);
                Assert.AreEqual(177.0092, geography11.Coordinates[0].X, 1.0E-4);
                Assert.AreEqual(38.889588, geography11.Coordinates[0].Y, 1.0E-6);

                db.TestGeographies
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geography, () => GeometryInput.STGeographyFromText(Wkt1))
                    .Insert();

                var geography12 = db.TestGeographies
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geography)
                    .Single();

                Assert.IsNotNull(geography12);
                Assert.AreEqual(SRID4326, geography12.SRID);
                Assert.AreEqual("Point", geography12.GeometryType);
                Assert.AreEqual(177.0092, geography12.Coordinates[0].X, 1.0E-4);
                Assert.AreEqual(38.889588, geography12.Coordinates[0].Y, 1.0E-6);


                const string Wkt2 = "SRID=4267;POINT(-77.0092 38.889588)";
                var geography21 = db.Select(() => GeometryInput.STGeographyFromText(Wkt2));

                Assert.IsNotNull(geography21);
                Assert.AreEqual(4267, geography21.SRID);
                Assert.AreEqual("Point", geography21.GeometryType);
                Assert.AreEqual(-77.0092, geography21.Coordinates[0].X, 1.0E-4);
                Assert.AreEqual(38.889588, geography21.Coordinates[0].Y, 1.0E-6);


                // Test for alias ST_GeogFromText = ST_GeographyFromText
                Assert.AreEqual(
                    db.Select(() => GeometryInput.STGeographyFromText(Wkt2).STAsEWKT()),
                    db.Select(() => GeometryInput.STGeogFromText(Wkt2).STAsEWKT()));


                Assert.IsNull(db.Select(() => GeometryInput.STGeographyFromText(null)));
                Assert.IsNull(db.Select(() => GeometryInput.STGeogFromText(null)));
            }
        }

        [Test]
        public void TestSTGeomCollFromText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "GEOMETRYCOLLECTION (POINT (1 2), LINESTRING (1 2, 3 4))";

                var g1 = db.Select(() => GeometryInput.STGeomCollFromText(Wkt1));
                Assert.AreEqual(Wkt1, g1.AsText());
                Assert.AreEqual(-1, g1.SRID);

                var g2 = db.Select(() => GeometryInput.STGeomCollFromText(Wkt1, SRID3857));
                Assert.AreEqual(Wkt1, g2.AsText());
                Assert.AreEqual(SRID3857, g2.SRID);

                Assert.IsNull(db.Select(() => GeometryInput.STGeomCollFromText(null)));
            }
        }

        [Test]
        public void TestSTGeomFromText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POINT(100 250)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1))
                    .Insert();

                var srid1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STSrId()).Single();
                Assert.AreEqual(0, srid1);

                var ewkt1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("POINT(100 250)", ewkt1);

                const string wkt2 = "POINT(100 250)";
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(wkt2, SRID3857))
                    .Insert();

                var srid2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STSrId()).Single();
                Assert.AreEqual(SRID3857, srid2);

                var ewkt2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("SRID=3857;POINT(100 250)", ewkt2);

                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => null).Insert();
                var srid3 = db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STSrId()).Single();
                Assert.IsNull(srid3);

                // TODO: EMPTY geometry issue was fixed in NetTopologySuite >= 5.0.5
                ////var pointEmpty = db.Select(() => GeometryInput.STGeomFromText("POINT EMPTY"));
                ////var polygonEmpty = db.Select(() => GeometryInput.STGeomFromText("POLYGON EMPTY"));
            }
        }

        [Test]
        public void TestSTLineFromText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING (1 2, 3 4)";

                var g1 = db.Select(() => GeometryInput.STLineFromText(wkt1, SRID3857));

                Assert.AreEqual(wkt1, g1.AsText());
                Assert.AreEqual(SRID3857, g1.SRID);

                Assert.IsNull(db.Select(() => GeometryInput.STLineFromText("POINT(1 2)")));
                Assert.IsNull(db.Select(() => GeometryInput.STLineFromText(null)));
            }
        }

        [Test]
        public void TestSTMPointFromText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "MULTIPOINT ((1 2), (3 4))";

                var g1 = db.Select(() => GeometryInput.STMPointFromText(wkt1, SRID3857));

                Assert.AreEqual(wkt1, g1.AsText());
                Assert.AreEqual(SRID3857, g1.SRID);

                Assert.IsNull(db.Select(() => GeometryInput.STMPointFromText("POINT(1 2)")));
                Assert.IsNull(db.Select(() => GeometryInput.STMPointFromText(null)));
            }
        }

        [Test]
        public void TestSTPointFromText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT (-71.064544 42.28787)";

                var g1 = db.Select(() => GeometryInput.STPointFromText(wkt1, SRID3857));

                Assert.AreEqual(wkt1, g1.AsText());
                Assert.AreEqual(SRID3857, g1.SRID);

                Assert.IsNull(db.Select(() => GeometryInput.STPointFromText("LINESTRING (1 2, 3 4)")));
                Assert.IsNull(db.Select(() => GeometryInput.STPointFromText(null)));
            }
        }

        [Test]
        public void TestSTPolygonFromText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "POLYGON((0 0,0 150,150 150,150 0,0 0),(20 20,50 20,50 50,20 50,20 20))";
                Assert.AreEqual(
                    "SRID=3857;" + Wkt,
                    db.Select(() => GeometryInput.STPolygonFromText(Wkt, SRID3857).STAsEWKT()));

                Assert.IsNull(db.Select(() => GeometryInput.STPolygonFromText("LINESTRING (1 2, 3 4)")));
                Assert.IsNull(db.Select(() => GeometryInput.STPolygonFromText(null)));
            }
        }

        [Test]
        public void TestSTWKTToSQL()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING (1 2, 3 4)";

                var g1 = db.Select(() => GeometryInput.STWKTToSQL(Wkt1));
                Assert.AreEqual(Wkt1, g1.AsText());
                Assert.AreEqual(-1, g1.SRID);

                Assert.IsNull(db.Select(() => GeometryInput.STWKTToSQL(null)));
            }
        }

        [Test]
        public void TestSTGeogFromWKB()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                // Binary output of select ST_GeogFromText('POINT(127.0092 38.889588)');
                var wkbPoint = new byte[]
                {
                    0x01,
                    0x01, 0x00, 0x00, 0x20,
                    0xE6, 0x10, 0x00, 0x00,
                    0xE3, 0xC7, 0x98, 0xBB, 0x96, 0xC0, 0x5F, 0x40,
                    0x00, 0x75, 0x03, 0x05, 0xDE, 0x71, 0x43, 0x40
                };

                var geographyPoint = db.Select(() => GeometryInput.STGeomFromEWKB(wkbPoint));

                Assert.IsNotNull(geographyPoint);
                Assert.AreEqual(SRID4326, geographyPoint.SRID);
                Assert.AreEqual("Point", geographyPoint.GeometryType);
                Assert.AreEqual(127.0092, geographyPoint.Coordinates[0].X, 1.0E-4);
                Assert.AreEqual(38.889588, geographyPoint.Coordinates[0].Y, 1.0E-6);

                Assert.IsNull(db.Select(() => GeometryInput.STGeogFromWKB(null)));
            }
        }

        [Test]
        public void TestGeometryFromWKB()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT(2 5)";
                const string wkt2 = "LINESTRING(2 5,2 6)";
                var wkb1 = db.Select(() => GeometryInput.STGeomFromText(wkt1).STAsBinary());
                var wkb2 = db.Select(() => GeometryInput.STGeomFromText(wkt2).STAsBinary());

                Assert.AreEqual(wkt1, db.Select(() => GeometryInput.STWKBToSQL(wkb1).STAsText()));
                Assert.AreEqual(wkt1, db.Select(() => GeometryInput.STGeomFromWKB(wkb1).STAsText()));
                Assert.AreEqual(wkt1, db.Select(() => GeometryInput.STPointFromWKB(wkb1).STAsText()));

                Assert.AreEqual(SRID3857, db.Select(() => GeometryInput.STGeomFromWKB(wkb1, SRID3857).STSrId()));
                Assert.AreEqual(SRID3857, db.Select(() => GeometryInput.STPointFromWKB(wkb1, SRID3857).STSrId()));

                Assert.AreEqual(wkt2, db.Select(() => GeometryInput.STGeomFromWKB(wkb2).STAsText()));
                Assert.AreEqual(wkt2, db.Select(() => GeometryInput.STLineFromWKB(wkb2).STAsText()));
                Assert.AreEqual(wkt2, db.Select(() => GeometryInput.STLinestringFromWKB(wkb2).STAsText()));

                Assert.AreEqual(SRID3857, db.Select(() => GeometryInput.STGeomFromWKB(wkb2, SRID3857).STSrId()));
                Assert.AreEqual(SRID3857, db.Select(() => GeometryInput.STLineFromWKB(wkb2, SRID3857).STSrId()));
                Assert.AreEqual(SRID3857, db.Select(() => GeometryInput.STLinestringFromWKB(wkb2, SRID3857).STSrId()));

                Assert.IsNull(db.Select(() => GeometryInput.STGeomFromWKB(null)));
            }
        }

        [Test]
        public void TestGeometryFromEWKB()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt1 = "SRID=4269;LINESTRING(-71.16028 42.258729,-71.160837 42.259112,-71.161143 42.25932)";
                var ewkb1 = db.Select(() => GeometryInput.STGeomFromEWKT(ewkt1).STAsEWKB());

                var g = db.Select(() => GeometryInput.STGeomFromEWKB(ewkb1));

                Assert.AreEqual(ewkt1, db.Select(() => GeometryInput.STGeomFromEWKB(ewkb1).STAsEWKT()));
                Assert.AreEqual(ewkt1, db.Select(() => GeometryInput.STGeomFromEWKB(ewkb1).STAsEWKT()));

                Assert.IsNull(db.Select(() => GeometryInput.STGeomFromEWKB(null)));
            }
        }

        [Test]
        public void TestSTGeomFromGeoHash()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string GeoHash = "9qqj7nmxncgyy4d0dbxqz0";

                {
                    var result1 = db.Select(() => GeometryInput.STGeomFromGeoHash(GeoHash)) as NTSGS.Polygon;
                    var expected1 = new double[][]
                    {
                        new[]{ -115.172816, 36.114646 },
                        new[]{ -115.172816, 36.114646 },
                        new[]{ -115.172816, 36.114646 },
                        new[]{ -115.172816, 36.114646 },
                        new[]{ -115.172816, 36.114646 },
                    };

                    Assert.AreEqual(expected1.Length, result1.Coordinates.Length);
                    for (var i = 0; i < expected1.Length; i++)
                    {
                        Assert.AreEqual(expected1[i][0], result1.Coordinates[i].X, 1.0E-6);
                        Assert.AreEqual(expected1[i][1], result1.Coordinates[i].Y, 1.0E-6);
                    }
                }

                {
                    var result2 = db.Select(() => GeometryInput.STGeomFromGeoHash(GeoHash, 4)) as NTSGS.Polygon;
                    var expected2 = new double[][]
                    {
                        new[]{ -115.3125, 36.03515625 },
                        new[]{ -115.3125, 36.2109375 },
                        new[]{ -114.9609375, 36.2109375 },
                        new[]{ -114.9609375, 36.03515625 },
                        new[]{ -115.3125, 36.03515625 },
                    };

                    Assert.AreEqual(expected2.Length, result2.Coordinates.Length);
                    for (var i = 0; i < expected2.Length; i++)
                    {
                        Assert.AreEqual(expected2[i][0], result2.Coordinates[i].X, 1.0E-6);
                        Assert.AreEqual(expected2[i][1], result2.Coordinates[i].Y, 1.0E-6);
                    }
                }

                {
                    var result3 = db.Select(() => GeometryInput.STGeomFromGeoHash(GeoHash, 10)) as NTSGS.Polygon;
                    var expected3 = new double[][]
                    {
                        new[]{ -115.17282128334, 36.1146408319473 },
                        new[]{ -115.17282128334, 36.1146461963654 },
                        new[]{ -115.172810554504, 36.1146461963654 },
                        new[]{ -115.172810554504, 36.1146408319473 },
                        new[]{ -115.17282128334, 36.1146408319473 },
                    };

                    Assert.AreEqual(expected3.Length, result3.Coordinates.Length);
                    for (var i = 0; i < expected3.Length; i++)
                    {
                        Assert.AreEqual(expected3[i][0], result3.Coordinates[i].X, 1.0E-6);
                        Assert.AreEqual(expected3[i][1], result3.Coordinates[i].Y, 1.0E-6);
                    }
                }

                Assert.IsNull(db.Select(() => GeometryInput.STGeomFromGeoHash(null)));
            }
        }

        [Test]
        public void TestSTGeomFromGML()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var ewkt1 = db.Select(() => GeometryInput.STGeomFromGML("<gml:LineString srsName=\"EPSG:4269\"><gml:coordinates>-71.16028,42.258729 -71.160837,42.259112 -71.161143,42.25932</gml:coordinates></gml:LineString>").STAsEWKT());
                Assert.AreEqual("SRID=4269;LINESTRING(-71.16028 42.258729,-71.160837 42.259112,-71.161143 42.25932)", ewkt1);

                Assert.IsNull(db.Select(() => GeometryInput.STGeomFromGML(null)));
            }
        }

        [Test]
        public void TestSTGeomFromGeoJSON()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var wkt1 = db.Select(() => GeometryInput.STGeomFromGeoJSON("{\"type\":\"Point\",\"coordinates\":[-48.23456,20.12345]}").STAsText());
                Assert.AreEqual("POINT(-48.23456 20.12345)", wkt1);

                var wkt2 = db.Select(() => GeometryInput.STGeomFromGeoJSON("{\"type\":\"LineString\",\"coordinates\":[[1,2,3],[4,5,6],[7,8,9]]}").STAsText());
                Assert.AreEqual("LINESTRING Z (1 2 3,4 5 6,7 8 9)", wkt2);

                var wkt3 = db.Select(() => GeometryInput.STGeomFromGeoJSON(null).STAsText());
                Assert.IsNull(wkt3);
            }
        }

        [Test]
        public void TestSTGeomFromKML()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var ewkt1 = db.Select(() => GeometryInput.STGeomFromKML("<LineString><coordinates>-71.1663, 42.2614 -71.1667, 42.2616</coordinates></LineString>").STAsEWKT());
                Assert.AreEqual("SRID=4326;LINESTRING(-71.1663 42.2614,-71.1667 42.2616)", ewkt1);

                var ewkt2 = db.Select(() => GeometryInput.STGeomFromKML(null).STAsEWKT());
                Assert.IsNull(ewkt2);
            }
        }

        [Test]
        public void TestSTGeomFromTWKB()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var ewkt1 = db.Select(() => GeometryInput.STGeomFromTWKB(new byte[] { 0x62, 0x00, 0x02, 0xf7, 0xf4, 0x0d, 0xbc, 0xe4, 0x04, 0x01, 0x05 }).STAsEWKT());
                Assert.AreEqual("LINESTRING(-113.98 39.198,-113.981 39.195)", ewkt1);

                var ewkt2 = db.Select(() => GeometryInput.STGeomFromTWKB(null).STAsEWKT());
                Assert.IsNull(ewkt2);
            }
        }

        [Test]
        public void TestSTLineFromEncodedPolyline()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ep1 = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STLineFromEncodedPolyline(ep1)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STLineFromEncodedPolyline(ep1, 6)).Insert();

                var ewkt1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("SRID=4326;LINESTRING(-120.2 38.5,-120.95 40.7,-126.453 43.252)", ewkt1);

                var ewkt2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("SRID=4326;LINESTRING(-12.02 3.85,-12.095 4.07,-12.6453 4.3252)", ewkt2);

                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => GeometryInput.STLineFromEncodedPolyline(String.Empty)).Insert();
                db.TestGeometries.Value(g => g.Id, 4).Value(g => g.Geometry, () => GeometryInput.STLineFromEncodedPolyline(null)).Insert();

                var ewkt3 = db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("SRID=4326;LINESTRING EMPTY", ewkt3);

                var ewkt4 = db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.IsNull(ewkt4);
            }
        }

        [Test]
        public void TestSTPointFromGeoHash()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string GeoHash = "9qqj7nmxncgyy4d0dbxqz0";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STPointFromGeoHash(GeoHash)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STPointFromGeoHash(GeoHash, 4)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => GeometryInput.STPointFromGeoHash(GeoHash, 10)).Insert();

                var point1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry).Single() as NTSGS.Point;
                Assert.AreEqual(-115.172816, point1.X, 1.0E-6);
                Assert.AreEqual(36.114646, point1.Y, 1.0E-6);

                var point2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry).Single() as NTSGS.Point;
                Assert.AreEqual(-115.13671875, point2.X, 1.0E-8);
                Assert.AreEqual(36.123046875, point2.Y, 1.0E-8);

                var point3 = db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry).Single() as NTSGS.Point;
                Assert.AreEqual(-115.172815918922, point3.X, 1.0E-12);
                Assert.AreEqual(36.1146435141563, point3.Y, 1.0E-12);

                db.TestGeometries.Value(g => g.Id, 4).Value(g => g.Geometry, () => GeometryInput.STPointFromGeoHash(String.Empty)).Insert();
                db.TestGeometries.Value(g => g.Id, 5).Value(g => g.Geometry, () => GeometryInput.STPointFromGeoHash(null)).Insert();

                var wkt4 = db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual("POINT(0 0)", wkt4);

                var wkt5 = db.TestGeometries.Where(g => g.Id == 5).Select(g => g.Geometry.STAsText()).Single();
                Assert.IsNull(wkt5);
            }
        }
    }
}
