using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;
using NTSG = NetTopologySuite.Geometries;

using LinqToDBPostGisNetTopologySuite.Tests.Entities;

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
                db.Insert(new TestGeometryEntity(1, null));
                var geometry = db.TestGeometries.Select(g => GeometryInput.STGeomFromText(wkt)).Single();
                db.Update(new TestGeometryEntity(1, geometry));

                var wkb = db.TestGeometries.Select(g => g.Geometry.STAsBinary()).Single();

                Assert.AreEqual(21, wkb.Length);
                Assert.AreEqual(1, wkb[0]); // Depends on server machine endianness
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
                db.Insert(new TestGeometryEntity(1, null));
                var geometry1 = db.TestGeometries.Select(g => GeometryInput.STGeomFromText(wkt1)).Single();
                db.Update(new TestGeometryEntity(1, geometry1));

                var geojson1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsGeoJSON()).Single();

                Assert.AreEqual("{\"type\":\"Point\",\"coordinates\":[2,4]}", geojson1);

                const string wkt2 = "LINESTRING(1 2 3, 4 5 6)";
                db.Insert(new TestGeometryEntity(2, null));
                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => GeometryInput.STGeomFromText(wkt2)).Single();
                db.Update(new TestGeometryEntity(2, geometry2));

                var geojson2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsGeoJSON()).Single();

                Assert.AreEqual("{\"type\":\"LineString\",\"coordinates\":[[1,2,3],[4,5,6]]}", geojson2);
            }
        }
    }
}