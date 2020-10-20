using System.Linq;

using LinqToDB;
using NUnit.Framework;
using NTSG = NetTopologySuite.Geometries;

using LinqToDBPostGisNetTopologySuite.Tests.Entities;

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
        public void TestSTArea()
        {
            // https://postgis.net/docs/manual-3.0/ST_Envelope.html

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "LINESTRING(0 0, 1 3)";
                db.Insert(new TestGeometryEntity(1, null));
                var geometry = db.TestGeometries.Select(g => GeometryInput.STGeomFromText(wkt)).Single();
                db.Update(new TestGeometryEntity(1, geometry));

                var envelope = db.TestGeometries
                    .Select(g => g.Geometry.STEnvelope().STAsText())
                    .Single();

                Assert.AreEqual("POLYGON((0 0,0 3,1 3,1 0,0 0))", envelope);
            }
        }
    }
}