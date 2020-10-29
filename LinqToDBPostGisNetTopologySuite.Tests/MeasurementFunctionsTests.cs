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
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "SRID=2249;POLYGON((743238 2967416,743238 2967450, 743265 2967450,743265.625 2967416,743238 2967416))";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();

                var area = db.TestGeometries.Select(g => g.Geometry.STArea()).Single();
                Assert.AreEqual(928.625, area);
            }
        }

        [Test]
        public void TestSTDistance()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var point = new NTSG.Point(new NTSG.Coordinate(-72.1235, 42.3521)) { SRID = SRID4326 };
                var lineString = new NTSG.LineString(new[] { new NTSG.Coordinate(-72.1260, 42.45), new NTSG.Coordinate(-72.123, 42.1546) }) { SRID = SRID4326 };
                db.Insert(new TestGeometryEntity(1, point));
                db.Insert(new TestGeometryEntity(2, lineString));

                // Geometry example - units in planar degrees 4326 is WGS 84 long lat, units are degrees.
                var distances4326 = db.TestGeometries.Select(g => g.Geometry.STDistance(point)).ToList();

                Assert.AreEqual(2, distances4326.Count);
                Assert.AreEqual(0.0, distances4326[0]);
                Assert.AreEqual(0.00150567726382822, distances4326[1], 1.0E9);

                // Geometry example - units in meters (SRID:3857, proportional to pixels on popular web maps).
                var distances3857 = db.TestGeometries.Select(g => g.Geometry.STTransform(SRID3857).STDistance(point.STTransform(SRID3857))).ToList();

                Assert.AreEqual(2, distances3857.Count);
                Assert.AreEqual(0.0, distances3857[0]);
                Assert.AreEqual(167.441410065196, distances3857[1], 1.0E9);
            }
        }

        [Test]
        public void TestSTLength()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "SRID=2249;LINESTRING(743238 2967416,743238 2967450,743265 2967450, 743265.625 2967416,743238 2967416)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();

                var length = db.TestGeometries.Select(g => g.Geometry.STLength()).Single();

                Assert.AreEqual(122.630744000095, length, 0.000000000001);
            }
        }

        [Test]
        public void TestSTPerimeter()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt1 = "SRID=2249;POLYGON((743238 2967416,743238 2967450,743265 2967450, 743265.625 2967416,743238 2967416))";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt1)).Insert();

                const string ewkt2 = @"SRID=2249;
                    MULTIPOLYGON(((763104.471273676 2949418.44119003,
                        763104.477769673 2949418.42538203,
                        763104.189609677 2949418.22343004,763104.471273676 2949418.44119003)),
                        ((763104.471273676 2949418.44119003,763095.804579742 2949436.33850239,
                        763086.132105649 2949451.46730207,763078.452329651 2949462.11549407,
                        763075.354136904 2949466.17407812,763064.362142565 2949477.64291974,
                        763059.953961626 2949481.28983009,762994.637609571 2949532.04103014,
                        762990.568508415 2949535.06640477,762986.710889563 2949539.61421415,
                        763117.237897679 2949709.50493431,763235.236617789 2949617.95619822,
                        763287.718121842 2949562.20592617,763111.553321674 2949423.91664605,
                        763104.471273676 2949418.44119003)))";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt2)).Insert();

                var perimeter1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STPerimeter())
                    .Single();
                Assert.AreEqual(122.630744000095, perimeter1, 0.000000000001);

                var perimeter2 = db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STPerimeter())
                    .Single();
                Assert.AreEqual(845.227713366825, perimeter2, 0.000000000001);
            }
        }
    }
}