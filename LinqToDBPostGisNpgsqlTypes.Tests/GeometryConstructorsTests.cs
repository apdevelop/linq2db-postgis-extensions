using System.Linq;

using NUnit.Framework;

namespace LinqToDBPostGisNpgsqlTypes.Tests
{
    [TestFixture]
    class GeometryConstructorsTests : TestsBase
    {
        [SetUp]
        public void Setup()
        {
            InsertTestData();
        }

        [Test]
        public void TestGeometryConstructors()
        {
            using (var db = GetDbConnection())
            {
                var point1 = db.PostgisGeometries.Select(g => GeometryEditors.STSetSrid(GeometryConstructors.STPoint(-71.064544, 42.28787), SRID_WGS_84));

                // Execute on DB context, not specific table (exclude FROM <table> from generated SQL statement)
                var point2 = db.STGeomFromText("POINT(-71.064544 42.28787)", SRID_WGS_84);
                var point3 = db.STGeomFromEWKT("SRID=" + SRID_WGS_84.ToString() + ";POINT(-71.064544 42.28787)");

                Assert.IsTrue(point1.Select(g => g.STEquals(point2)).First());
                Assert.IsTrue(point1.Select(g => g.STEquals(point3)).First());

                var pointNoSrId = db.STGeomFromText("POINT(-71.064544 42.28787)");
                Assert.AreEqual(0, pointNoSrId.SRID);
            }
        }
    }
}
