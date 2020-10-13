using System.Linq;

using LinqToDB;
using NUnit.Framework;
using NTSG = NetTopologySuite.Geometries;

using LinqToDBPostGisNetTopologySuite.Tests.Entities;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class MeasurementFunctionsTests : TestsBase
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
        public void TestSTArea()
        {
            // https://postgis.net/docs/manual-3.0/ST_Area.html

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                // Test data
                const string ewkt = "SRID=2249;POLYGON((743238 2967416,743238 2967450, 743265 2967450,743265.625 2967416,743238 2967416))";
                db.Insert(new TestGeometryEntity(1, null));
                var geometry = db.TestGeometries
                    .Select(g => GeometryInput.STGeomFromEWKT(ewkt))
                    .Single();
                db.Update(new TestGeometryEntity(1, geometry));

                var area = db.TestGeometries
                    .Select(g => g.Geometry.STArea())
                    .Single();

                Assert.AreEqual(928.625, area);
            }
        }

        [Test]
        public void TestSTDistance()
        {
            // https://postgis.net/docs/manual-3.0/ST_Distance.html

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                // Test data
                var point = new NTSG.Point(new NTSG.Coordinate(-72.1235, 42.3521)) { SRID = SRID4326 };
                var lineString = new NTSG.LineString(new[] { new NTSG.Coordinate(-72.1260, 42.45), new NTSG.Coordinate(-72.123, 42.1546) }) { SRID = SRID4326 };
                db.Insert(new TestGeometryEntity(1, point));
                db.Insert(new TestGeometryEntity(2, lineString));

                // Geometry example - units in planar degrees 4326 is WGS 84 long lat, units are degrees.
                var distances4326 = db.TestGeometries
                    .Select(g => g.Geometry.STDistance(point))
                    .ToList();

                Assert.AreEqual(2, distances4326.Count);
                Assert.AreEqual(0.0, distances4326[0]);
                Assert.AreEqual(0.00150567726382822, distances4326[1], 1.0E9);

                // Geometry example - units in meters (SRID:3857, proportional to pixels on popular web maps).
                var distances3857 = db.TestGeometries
                    .Select(g => g.Geometry.STTransform(SRID3857).STDistance(point.STTransform(SRID3857)))
                    .ToList();

                Assert.AreEqual(2, distances3857.Count);
                Assert.AreEqual(0.0, distances3857[0]);
                Assert.AreEqual(167.441410065196, distances3857[1], 1.0E9);
            }
        }
    }
}