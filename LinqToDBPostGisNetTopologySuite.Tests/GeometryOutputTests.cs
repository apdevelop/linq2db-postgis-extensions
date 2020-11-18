using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryOutputTests : TestsBase
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
        public void TestSTAsBinary()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "POINT(2.0 4.0)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt)).Insert();

                var wkb = db.TestGeometries.Select(g => g.Geometry.STAsBinary()).Single();

                Assert.AreEqual(21, wkb.Length);
                Assert.AreEqual(1, wkb[0]); // TODO: depends on server machine endianness
                Assert.AreEqual(1, BitConverter.ToUInt32(wkb, 1));
                Assert.AreEqual(2, BitConverter.ToDouble(wkb, 5));
                Assert.AreEqual(4, BitConverter.ToDouble(wkb, 13));
            }
        }

        [Test]
        public void TestSTAsGeoJSON()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT(2.0 4.0)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();

                var geojson1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsGeoJSON()).Single();
                Assert.AreEqual("{\"type\":\"Point\",\"coordinates\":[2,4]}", geojson1);

                const string wkt2 = "LINESTRING(1 2 3, 4 5 6)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var geojson2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsGeoJSON()).Single();
                Assert.AreEqual("{\"type\":\"LineString\",\"coordinates\":[[1,2,3],[4,5,6]]}", geojson2);
            }
        }

        [Test]
        public void TestSTGeoHash()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryConstructors.STMakePoint(-126, 48).STSetSrId(SRID4326)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => null).Insert();

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