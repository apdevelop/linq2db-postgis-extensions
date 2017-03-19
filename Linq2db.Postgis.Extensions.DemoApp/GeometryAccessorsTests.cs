using System.Linq;

using NUnit.Framework;

namespace Linq2db.Postgis.Extensions.DemoApp
{
    [TestFixture]
    class GeometryAccessorsTests : TestsBase
    {
        [Test]
        public void LinestringProperties()
        {
            using (var db = GetDbConnection())
            {
                var linestring = db.StGeomFromText("LINESTRING (1 2, 3 4, 5 6, 7 8, 9 10)");
                var result = db.PostgisGeometries // TODO: use DB context, not specific table
                    .Select(_ => new
                    {
                        GeometryType = linestring.GeometryType(),
                        X1 = linestring.StStartPoint().StX(),
                        Y1 = linestring.StStartPoint().StY(),
                        X2 = linestring.StEndPoint().StX(),
                        Y2 = linestring.StEndPoint().StY(),
                        Xc = linestring.StPointN(3).StX(),
                        Yc = linestring.StPointN(3).StY(),
                    })
                    .First();

                Assert.AreEqual("LINESTRING", result.GeometryType);
                Assert.AreEqual(1, result.X1);
                Assert.AreEqual(2, result.Y1);
                Assert.AreEqual(9, result.X2);
                Assert.AreEqual(10, result.Y2);
                Assert.AreEqual(5, result.Xc);
                Assert.AreEqual(6, result.Yc);
            }
        }

        [Test]
        public void EmptyGeometries()
        {
            using (var db = GetDbConnection())
            {
                var emptyPoint = db.StGeomFromText("POINT EMPTY");
                var emptyPolygon = db.StGeomFromText("POLYGON EMPTY");
                var result = db.PostgisGeometries // TODO: use DB context, not specific table
                    .Select(p => new[]
                    {
                        emptyPoint.StIsEmpty(),
                        emptyPolygon.StIsEmpty(),
                    })
                    .First();

                Assert.IsTrue(result.All(c => c));
            }
        }
    }
}
