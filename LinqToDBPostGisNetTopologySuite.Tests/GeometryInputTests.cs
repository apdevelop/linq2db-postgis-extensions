using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;
using NTSG = NetTopologySuite.Geometries;

using LinqToDBPostGisNetTopologySuite.Tests.Entities;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryInputTests : TestsBase
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
        public void TestSTGeomFromText()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT(100 250)";
                db.Insert(new TestGeometryEntity(1, null));
                var geometry1 = db.TestGeometries.Select(g => GeometryInput.STGeomFromText(wkt1)).Single();
                db.Update(new TestGeometryEntity(1, geometry1));

                var srid1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STSrId()).Single();
                Assert.AreEqual(0, srid1);

                var ewkt1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("POINT(100 250)", ewkt1);

                const string wkt2 = "POINT(100 250)";
                db.Insert(new TestGeometryEntity(2, null));
                var geometry2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => GeometryInput.STGeomFromText(wkt2, SRID3857)).Single();
                db.Update(new TestGeometryEntity(2, geometry2));

                var srid2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STSrId()).Single();
                Assert.AreEqual(SRID3857, srid2);

                var ewkt2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STAsEWKT()).Single();
                Assert.AreEqual("SRID=3857;POINT(100 250)", ewkt2);
            }
        }
    }
}