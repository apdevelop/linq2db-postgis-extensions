using System.Linq;

using LinqToDB;
using NUnit.Framework;
using NTSG = NetTopologySuite.Geometries;

using LinqToDBPostGisNetTopologySuite.Tests.Entities;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryValidationTests : TestsBase
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
        public void TestSTIsValid()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                // TODO: shared method
                const string wkt1 = "LINESTRING(0 0, 1 1)";
                db.Insert(new TestGeometryEntity(1, null));
                var geometry1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => GeometryInput.STGeomFromText(wkt1)).Single();
                db.Update(new TestGeometryEntity(1, geometry1));

                const string wkt2 = "POLYGON((0 0, 1 1, 1 2, 1 1, 0 0))";
                db.Insert(new TestGeometryEntity(2, null));
                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => GeometryInput.STGeomFromText(wkt2)).Single();
                db.Update(new TestGeometryEntity(2, geometry2));

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsValid()).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsValid()).Single());
            }
        }
    }
}