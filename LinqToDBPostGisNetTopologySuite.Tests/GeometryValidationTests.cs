using System.Linq;

using LinqToDB;
using NUnit.Framework;

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
                const string wkt1 = "LINESTRING(0 0, 1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POLYGON((0 0, 1 1, 1 2, 1 1, 0 0))";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsValid()).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsValid()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsValid()).Single());
            }
        }

        [Test]
        public void TestSTIsValidReason()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(0 0, 1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POLYGON((0 0, 1 1, 1 2, 1 1, 0 0))";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                Assert.AreEqual("Valid Geometry", db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsValidReason()).Single());
                Assert.AreEqual("Self-intersection[0 0]", db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsValidReason()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsValidReason()).Single());
            }
        }
    }
}