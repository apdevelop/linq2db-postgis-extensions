using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

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
            }
        }

        [Test]
        public void TestSTGeomCollFromText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "GEOMETRYCOLLECTION (POINT (1 2), LINESTRING (1 2, 3 4))";

                var g1 = db.Select(() => GeometryInput.STGeomCollFromText(wkt1, SRID3857));

                Assert.AreEqual(wkt1, g1.AsText());
                Assert.AreEqual(SRID3857, g1.SRID);

                Assert.IsNull(db.Select(() => GeometryInput.STGeomCollFromText(null)));
            }
        }

        [Test]
        public void TestSTGeomFromText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT(100 250)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();

                var srid1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STSrId()).Single();
                Assert.AreEqual(0, srid1);

                var ewkt1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("POINT(100 250)", ewkt1);

                const string wkt2 = "POINT(100 250)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2, SRID3857)).Insert();

                var srid2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STSrId()).Single();
                Assert.AreEqual(SRID3857, srid2);

                var ewkt2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("SRID=3857;POINT(100 250)", ewkt2);

                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();
                var srid3 = db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STSrId()).Single();
                Assert.IsNull(srid3);
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

                Assert.IsNull(db.Select(() => GeometryInput.STGeomFromEWKB(null)));
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
                const string geoHash = "9qqj7nmxncgyy4d0dbxqz0";

                var wkt1 = db.Select(() => GeometryInput.STGeomFromGeoHash(geoHash).STAsText());
                Assert.AreEqual("POLYGON((-115.172816 36.114646,-115.172816 36.114646,-115.172816 36.114646,-115.172816 36.114646,-115.172816 36.114646))", wkt1);

                var wkt2 = db.Select(() => GeometryInput.STGeomFromGeoHash(geoHash, 4).STAsText());
                Assert.AreEqual("POLYGON((-115.3125 36.03515625,-115.3125 36.2109375,-114.9609375 36.2109375,-114.9609375 36.03515625,-115.3125 36.03515625))", wkt2);

                var wkt3 = db.Select(() => GeometryInput.STGeomFromGeoHash(geoHash, 10).STAsText());
                Assert.AreEqual("POLYGON((-115.17282128334 36.1146408319473,-115.17282128334 36.1146461963654,-115.172810554504 36.1146461963654,-115.172810554504 36.1146408319473,-115.17282128334 36.1146408319473))", wkt3);

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
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STLineFromEncodedPolyline(ep1)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STLineFromEncodedPolyline(ep1, 6)).Insert();

                var ewkt1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("SRID=4326;LINESTRING(-120.2 38.5,-120.95 40.7,-126.453 43.252)", ewkt1);

                var ewkt2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("SRID=4326;LINESTRING(-12.02 3.85,-12.095 4.07,-12.6453 4.3252)", ewkt2);

                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => GeometryInput.STLineFromEncodedPolyline(String.Empty)).Insert();
                db.TestGeometries.Value(g => g.Id, 4).Value(p => p.Geometry, () => GeometryInput.STLineFromEncodedPolyline(null)).Insert();

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
                const string geohash1 = "9qqj7nmxncgyy4d0dbxqz0";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STPointFromGeoHash(geohash1)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STPointFromGeoHash(geohash1, 4)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => GeometryInput.STPointFromGeoHash(geohash1, 10)).Insert();

                var wkt1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual("POINT(-115.172816 36.114646)", wkt1);

                var wkt2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual("POINT(-115.13671875 36.123046875)", wkt2);

                var wkt3 = db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual("POINT(-115.172815918922 36.1146435141563)", wkt3);

                db.TestGeometries.Value(g => g.Id, 4).Value(p => p.Geometry, () => GeometryInput.STPointFromGeoHash(String.Empty)).Insert();
                db.TestGeometries.Value(g => g.Id, 5).Value(p => p.Geometry, () => GeometryInput.STPointFromGeoHash(null)).Insert();

                var wkt4 = db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STAsText()).Single();
                Assert.AreEqual("POINT(0 0)", wkt4);

                var wkt5 = db.TestGeometries.Where(g => g.Id == 5).Select(g => g.Geometry.STAsText()).Single();
                Assert.IsNull(wkt5);
            }
        }
    }
}