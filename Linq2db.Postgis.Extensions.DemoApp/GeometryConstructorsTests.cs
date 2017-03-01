using System.Linq;

using NUnit.Framework;

namespace Linq2db.Postgis.Extensions.DemoApp
{
    [TestFixture]
    class GeometryConstructorsTests : TestsBase
    {
        [Test]
        public void TestGeometryConstructors()
        {
            using (var db = GetDbConnection())
            {
                var point1 = db.PostgisGeometries.Select(g => GeometryEditors.StSetSrId(GeometryConstructors.StPoint(-71.064544, 42.28787), SRID_WGS_84));

                // Execute on DB context, not specific table (exclude FROM <table> from generated SQL statement)
                var point2 = db.StGeomFromText("POINT(-71.064544 42.28787)", SRID_WGS_84);
                var point3 = db.StGeomFromEWKT("SRID=" + SRID_WGS_84.ToString() + ";POINT(-71.064544 42.28787)");

                Assert.IsTrue(point1.Select(g => g.StEquals(point2)).First());
                Assert.IsTrue(point1.Select(g => g.StEquals(point3)).First());

                var pointNoSrId = db.StGeomFromText("POINT(-71.064544 42.28787)");
                Assert.AreEqual(0, pointNoSrId.SRID);
            }
        }
    }
}
