using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryOutputTests : TestsBase
    {
        private Version CurrentVersion;

        [SetUp]
        public void Setup()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                this.CurrentVersion = new Version(db.Select(() => VersionFunctions.PostGISLibVersion()));
                db.TestGeometries.Delete();
            }
        }

        [Test]
        public void TestSTAsEWKT()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                Assert.AreEqual(
                    "SRID=4326;POLYGON((0 0,0 1,1 1,1 0,0 0))",
                    db.Select(() => GeometryOutput.STAsEWKT("0103000020E61000000100000005000000000000000000000000000000000000000000000000000000000000000000F03F000000000000F03F000000000000F03F000000000000F03F000000000000000000000000000000000000000000000000")));

                Assert.AreEqual(
                    "CIRCULARSTRING(220268 150415 1,220227 150505 2,220227 150406 3)",
                    db.Select(() => GeometryOutput.STAsEWKT("0108000080030000000000000060E30A4100000000785C0241000000000000F03F0000000018E20A4100000000485F024100000000000000400000000018E20A4100000000305C02410000000000000840")));

                Assert.IsNull(db.Select(() => GeometryOutput.STAsEWKT((NTSG)null)));
            }
        }

        [Test]
        public void TestSTAsText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var g1 = db.Select(() => GeometryConstructors.STMakePoint(-71.064544, 42.28787));

                Assert.AreEqual("POINT(-71.064544 42.28787)", db.Select(() => GeometryOutput.STAsText(g1)));
                Assert.AreEqual("POINT(-71.065 42.288)", db.Select(() => GeometryOutput.STAsText(g1, 3)));
                Assert.AreEqual("POINT(-71 42)", db.Select(() => GeometryOutput.STAsText(g1, 0)));

                Assert.AreEqual(
                    "POLYGON((0 0,0 1,1 1,1 0,0 0))",
                    db.Select(() => GeometryOutput.STAsText("01030000000100000005000000000000000000000000000000000000000000000000000000000000000000F03F000000000000F03F000000000000F03F000000000000F03F000000000000000000000000000000000000000000000000")));

                Assert.AreEqual(
                    "POINT(111.11 1.11)",
                    db.Select(() => GeometryOutput.STAsText(GeometryInput.STGeomFromEWKT("SRID=4326;POINT(111.1111111 1.1111111)"), 2)));

                Assert.IsNull(db.Select(() => GeometryOutput.STAsText((NTSG)null)));
            }
        }

        [Test]
        public void TestSTAsBinary()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POINT(2.0 4.0)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                var wkb = db.TestGeometries.Select(g => g.Geometry.STAsBinary()).Single();

                Assert.AreEqual(21, wkb.Length);
                Assert.AreEqual(1, wkb[0]); // TODO: depends on server machine endianness
                Assert.AreEqual(1, BitConverter.ToUInt32(wkb, 1));
                Assert.AreEqual(2, BitConverter.ToDouble(wkb, 5));
                Assert.AreEqual(4, BitConverter.ToDouble(wkb, 13));

                const string Wkt2 = "POLYGON((0 0,0 1,1 1,1 0,0 0))";

                var wkbLittleEndian = db.Select(() => GeometryInput.STGeometryFromText(Wkt2).STAsBinary(EndiannessEncoding.LittleEndian));
                Assert.AreEqual(1, wkbLittleEndian[0]);
                Assert.AreEqual(3, wkbLittleEndian[1]);

                var wkbBigEndian = db.Select(() => GeometryInput.STGeometryFromText(Wkt2).STAsBinary(EndiannessEncoding.BigEndian));
                Assert.AreEqual(0, wkbBigEndian[0]);
                Assert.AreEqual(3, wkbBigEndian[4]);

                Assert.IsNull(db.Select(() => GeometryOutput.STAsBinary(null, EndiannessEncoding.BigEndian)));
            }
        }

        [Test]
        public void TestSTAsHEXEWKB()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "POLYGON((0 0,0 1,1 1,1 0,0 0))";
                const string HexEwkb = "0103000020E61000000100000005000000000000000000000000000000000000000000000000000000000000000000F03F000000000000F03F000000000000F03F000000000000F03F000000000000000000000000000000000000000000000000";
                var g1 = db.Select(() => GeometryInput.STGeometryFromText(Wkt, 4326));

                var hexewkb = db.Select(() => GeometryOutput.STAsHEXEWKB(g1));
                Assert.AreEqual(HexEwkb, hexewkb);

                Assert.AreEqual(HexEwkb, db.Select(() => GeometryOutput.STAsHEXEWKB("SRID=4326;" + Wkt)));

                Assert.AreEqual(
                    "000000000140000000000000004010000000000000",
                    db.Select(() => GeometryOutput.STAsHEXEWKB(GeometryConstructors.STMakePoint(2, 4), EndiannessEncoding.BigEndian)));

                Assert.AreEqual(
                    "000000000140000000000000004010000000000000",
                    db.Select(() => GeometryOutput.STAsHEXEWKB("POINT(2.0 4.0)", EndiannessEncoding.BigEndian)));

                Assert.IsNull(db.Select(() => GeometryOutput.STAsHEXEWKB((NTSG)null)));
            }
        }

        [Test]
        public void TestSTAsEncodedPolyline()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Ewkt = "SRID=4326;LINESTRING(-120.2 38.5,-120.95 40.7,-126.453 43.252)";
                var g1 = db.Select(() => GeometryInput.STGeomFromEWKT(Ewkt));
                var ep = db.Select(() => GeometryOutput.STAsEncodedPolyline(g1));
                Assert.AreEqual("_p~iF~ps|U_ulLnnqC_mqNvxq`@", ep);

                Assert.AreEqual(
                    "_p~iF~ps|U_ulLnnqC_mqNvxq`@",
                    db.Select(() => GeometryOutput.STAsEncodedPolyline(Ewkt)));

                Assert.IsNull(db.Select(() => GeometryOutput.STAsEncodedPolyline((NTSG)null)));
            }
        }

        [Test]
        public void TestSTAsGeoJSON()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "POINT(2.48 4.75)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                var geojson1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsGeoJSON()).Single();
                Assert.AreEqual("{\"type\":\"Point\",\"coordinates\":[2.48,4.75]}", geojson1);

                var geojson1crs = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsGeoJSON(1, 4)).Single();
                Assert.AreEqual("{\"type\":\"Point\",\"coordinates\":[2.5,4.8]}", geojson1crs);


                const string Wkt2 = "LINESTRING(1 2 3, 4 5 6)";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();

                var geojson2 = db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STAsGeoJSON())
                    .Single();
                Assert.AreEqual("{\"type\":\"LineString\",\"coordinates\":[[1,2,3],[4,5,6]]}", geojson2);


                const string Ewkt3 = "SRID=3857;POINT(2.48 4.75)";
                db.TestGeometries
                    .Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt3))
                    .Insert();


                var geojson3 = db.TestGeometries
                    .Where(g => g.Id == 3)
                    .Select(g => g.Geometry.STAsGeoJSON())
                    .Single();

                if (this.CurrentVersion >= new Version("3.0.0"))
                {
                    Assert.AreEqual(
                    "{\"type\":\"Point\",\"crs\":{\"type\":\"name\",\"properties\":{\"name\":\"EPSG:3857\"}},\"coordinates\":[2.48,4.75]}",
                    geojson3);
                }
                else
                {
                    Assert.AreEqual(
                        "{\"type\":\"Point\",\"coordinates\":[2.48,4.75]}",
                        geojson3);
                }

                var geojson3crs = db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STAsGeoJSON(1, 4)).Single();
                Assert.AreEqual("{\"type\":\"Point\",\"crs\":{\"type\":\"name\",\"properties\":{\"name\":\"urn:ogc:def:crs:EPSG::3857\"}},\"coordinates\":[2.5,4.8]}", geojson3crs);

                Assert.IsNull(db.Select(() => GeometryOutput.STAsGeoJSON(null)));
            }
        }

        [Test]
        public void TestSTAsGML()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var g1 = db.Select(() => GeometryInput.STGeomFromText("POLYGON((0 0,0 1,1 1,1 0,0 0))", 4326));
                var gml1 = db.Select(() => GeometryOutput.STAsGML(g1));
                Assert.AreEqual("<gml:Polygon srsName=\"EPSG:4326\"><gml:outerBoundaryIs><gml:LinearRing><gml:coordinates>0,0 0,1 1,1 1,0 0,0</gml:coordinates></gml:LinearRing></gml:outerBoundaryIs></gml:Polygon>", gml1);

                // TODO:  Version 3
                ////var g2 = db.Select(() => GeometryInput.STGeomFromText("POINT(5.234234233242 6.34534534534)", 4326));
                ////var gml2 = db.Select(() => GeometryOutput.STAsGML(3, g2, 5, 16 | 1));
                ////Assert.AreEqual("<gml:Point srsName=\"urn:ogc:def:crs:EPSG::4326\"><gml:pos>6.34535 5.23423</gml:pos></gml:Point>", gml2);

                Assert.IsNull(db.Select(() => GeometryOutput.STAsGML(null)));
            }
        }

        [Test]
        public void TestSTAsKML()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var g1 = db.Select(() => GeometryInput.STGeomFromText("POLYGON((0 0,0 1,1 1,1 0,0 0))", 4326));

                var kml1 = db.Select(() => GeometryOutput.STAsKML(g1));
                Assert.AreEqual("<Polygon><outerBoundaryIs><LinearRing><coordinates>0,0 0,1 1,1 1,0 0,0</coordinates></LinearRing></outerBoundaryIs></Polygon>", kml1);

                Assert.IsNull(db.Select(() => GeometryOutput.STAsKML(null)));
            }
        }

        [Test]
        public void TestSTAsLatLonText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var g1 = db.Select(() => GeometryInput.STGeomFromText("POINT (-3.2342342 -2.32498)"));

                var dms1 = db.Select(() => GeometryOutput.STAsLatLonText(g1));
                Assert.AreEqual("2°19'29.928\"S 3°14'3.243\"W", dms1);

                var dms2 = db.Select(() => GeometryOutput.STAsLatLonText(g1, "D°M'S.SSS\""));
                Assert.AreEqual("-2°19'29.928\" -3°14'3.243\"", dms2);

                Assert.IsNull(db.Select(() => GeometryOutput.STAsLatLonText(null)));
            }
        }

        [Test]
        public void TestSTAsMVTGeom()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ExpectedWkt = "MULTIPOLYGON(((5 4096,10 4091,10 4096,5 4096)),((5 4096,0 4101,0 4096,5 4096)))";
                const string BoxWkt = "BOX(0 0,4096 4096)";

                var poly = db.Select(() => GeometryInput.STGeomFromText("POLYGON ((0 0, 10 0, 10 5, 0 -5, 0 0))"));

                var mvt1 = db.Select(() => poly.STAsMVTGeom(BoxWkt).STAsText());
                Assert.AreEqual(ExpectedWkt, mvt1);

                var mvt2 = db.Select(() => poly.STAsMVTGeom(BoxWkt, 4096, 0, false).STAsText());
                Assert.AreEqual(ExpectedWkt, mvt2);

                Assert.IsNull(db.Select(() => GeometryOutput.STAsMVTGeom(null, null)));
            }
        }

        [Test]
        public void TestSTAsSVG()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var g1 = db.Select(() => GeometryInput.STGeomFromText("POLYGON((0 0,0 1,1 1,1 0,0 0))"));

                var svg1 = db.Select(() => GeometryOutput.STAsSVG(g1));
                Assert.AreEqual("M 0 0 L 0 -1 1 -1 1 0 Z", svg1);

                Assert.IsNull(db.Select(() => GeometryOutput.STAsSVG(null)));
            }
        }

        [Test]
        public void TestSTAsTWKB()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var line = db.Select(() => GeometryInput.STGeomFromText("LINESTRING(1 1,5 5)"));

                var twkb1 = db.Select(() => GeometryOutput.STAsTWKB(line));
                Assert.AreEqual(7, twkb1.Length);
                Assert.IsTrue(twkb1.SequenceEqual(new byte[] { 0x02, 0x00, 0x02, 0x02, 0x02, 0x08, 0x08 }));

                var twkb2 = db.Select(() => GeometryOutput.STAsTWKB(line, 0, 0, 0, false, false));
                Assert.AreEqual(7, twkb2.Length);
                Assert.IsTrue(twkb2.SequenceEqual(new byte[] { 0x02, 0x00, 0x02, 0x02, 0x02, 0x08, 0x08 }));

                Assert.IsNull(db.Select(() => GeometryOutput.STAsBinary(null, EndiannessEncoding.BigEndian)));
            }
        }

        [Test]
        public void TestSTAsX3D()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                Assert.AreEqual(
                    "1 2",
                    db.Select(() => GeometryInput.STGeomFromText("POINT (1 2)").STAsX3D()));

                Assert.AreEqual(
                    "<LineSet  vertexCount='2'><Coordinate point='1 1 5 5' /></LineSet>",
                    db.Select(() => GeometryInput.STGeomFromText("LINESTRING(1 1,5 5)").STAsX3D()));

                Assert.IsNull(db.Select(() => GeometryOutput.STAsX3D(null)));
            }
        }

        [Test]
        public void TestSTGeoHash()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryConstructors.STMakePoint(-126, 48).STSetSrId(SRID4326)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => null).Insert();

                var geohash1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STGeoHash()).Single();
                Assert.AreEqual("c0w3hf1s70w3hf1s70w3", geohash1);

                var geohash2 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STGeoHash(5)).Single();
                Assert.AreEqual("c0w3h", geohash2);
                var srid2 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STSrId()).Single();
                Assert.AreEqual(SRID4326, srid2);

                var geohash3 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STGeoHash()).Single();
                Assert.IsNull(geohash3);
                var srid3 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STSrId()).Single();
                Assert.IsNull(srid3);
            }
        }
    }
}
