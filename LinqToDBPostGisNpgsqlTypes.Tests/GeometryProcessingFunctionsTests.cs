using System.Linq;

using NUnit.Framework;

namespace LinqToDBPostGisNpgsqlTypes.Tests
{
    [TestFixture]
    class GeometryProcessingFunctionsTests : TestsBase
    {
        [Test]
        public void STBufferForPoint()
        {
            using (var db = GetDbConnection())
            {
                var point = db.STGeomFromText("POINT(100 90)");

                var result = db.PostgisGeometries // TODO: use DB context, not specific table
                    .Select(_ => point.STBuffer(50.0))
                    .Select(buffer =>
                            new
                            {
                                GeometryType = buffer.GeometryType(),
                                NDims = buffer.STNDims(),
                                NPoints = buffer.STNPoints(),
                            })
                    .First();

                Assert.AreEqual(2, result.NDims);
                Assert.AreEqual(8 * 4 + 1, result.NPoints); // Default is 8 segments for quarter circle
                Assert.AreEqual("POLYGON", result.GeometryType);
            }
        }

        [Test]
        public void STMinimumBoundingCircleForQuad()
        {
            using (var db = GetDbConnection())
            {
                var poly = db.STGeomFromText("POLYGON((0 0, 10 0, 10 10, 0 10, 0 0))");

                var result = db.PostgisGeometries // TODO: use DB context, not specific table
                    .Select(_ => poly.STMinimumBoundingCircle())
                    .Select(bcircle =>
                            new
                            {
                                GeometryType = bcircle.GeometryType(),
                                NPoints = bcircle.STNPoints(),
                                NumRings = bcircle.STNRings(),
                            })
                    .First();

                Assert.AreEqual(4 * 48 + 1, result.NPoints); // Default is 48 segments per quarter circle.
                Assert.AreEqual(1, result.NumRings);
                Assert.AreEqual("POLYGON", result.GeometryType);
            }
        }

        [Test]
        public void STUnionPointsToMultipoint()
        {
            using (var db = GetDbConnection())
            {
                var point1 = db.STGeomFromText("POINT(1 2)");
                var point2 = db.STGeomFromText("POINT(-2 3)");

                var result = db.PostgisGeometries // TODO: use DB context, not specific table
                    .Select(_ => point1.STUnion(point2))
                    .Select(union =>
                            new
                            {
                                GeometryType = union.GeometryType(),
                                NumGeometries = union.STNumGeometries(),
                            })
                    .First();

                Assert.AreEqual(2, result.NumGeometries);
                Assert.AreEqual("MULTIPOINT", result.GeometryType);
            }
        }

        [Test]
        public void STUnionPolygonsToPolygon()
        {
            using (var db = GetDbConnection())
            {
                var point1 = db.STGeomFromText("POLYGON((0 0, 10 0, 10 10, 0 10, 0 0))");
                var point2 = db.STGeomFromText("POLYGON((10 0, 20 0, 20 10, 10 10, 10 0))");

                var result = db.PostgisGeometries // TODO: use DB context, not specific table
                    .Select(_ => point1.STUnion(point2))
                    .Select(union =>
                            new
                            {
                                GeometryType = union.GeometryType(),
                                NumGeometries = union.STNumGeometries(),
                                NumPoints = union.STNPoints(),
                            })
                    .First();

                Assert.AreEqual(7, result.NumPoints);
                Assert.AreEqual(1, result.NumGeometries);
                Assert.AreEqual("POLYGON", result.GeometryType);
            }
        }
    }
}
