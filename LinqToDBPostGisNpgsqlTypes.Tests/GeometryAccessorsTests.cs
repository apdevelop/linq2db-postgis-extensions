using System.Linq;

using NUnit.Framework;

namespace LinqToDBPostGisNpgsqlTypes.Tests
{
    [TestFixture]
    class GeometryAccessorsTests : TestsBase
    {
        [SetUp]
        public void Setup()
        {
            InsertTestData();
        }

        [Test]
        public void LinestringProperties()
        {
            using (var db = GetDbConnection())
            {
                var linestring = db.STGeomFromText("LINESTRING (1 2, 3 4, 5 6, 7 8, 9 10)");
                var result = db.PostgisGeometries // TODO: use DB context, not specific table
                    .Select(_ => new
                    {
                        GeometryType = linestring.GeometryType(),
                        X1 = linestring.STStartPoint().STX(),
                        Y1 = linestring.STStartPoint().STY(),
                        X2 = linestring.STEndPoint().STX(),
                        Y2 = linestring.STEndPoint().STY(),
                        Xc = linestring.STPointN(3).STX(),
                        Yc = linestring.STPointN(3).STY(),
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
                var emptyPoint = db.STGeomFromText("POINT EMPTY");
                var emptyPolygon = db.STGeomFromText("POLYGON EMPTY");
                var result = db.PostgisGeometries // TODO: use DB context, not specific table
                    .Select(p => new[]
                    {
                        emptyPoint.STIsEmpty(),
                        emptyPolygon.STIsEmpty(),
                    })
                    .First();

                Assert.IsTrue(result.All(c => c));
            }
        }
    }
}
