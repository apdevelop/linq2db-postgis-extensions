using System.Linq;

using NUnit.Framework;

namespace Linq2db.Postgis.Extensions.Tests
{
    [TestFixture]
    class GeometryProcessingFunctionsTests : TestsBase
    {
        [Test]
        public void StBufferForPoint()
        {
            using (var db = GetDbConnection())
            {
                var point = db.StGeomFromText("POINT(100 90)");

                var result = db.PostgisGeometries // TODO: use DB context, not specific table
                    .Select(_ => point.StBuffer(50.0))
                    .Select(buffer =>
                            new
                            {
                                GeometryType = buffer.GeometryType(),
                                NPoints = buffer.StNPoints(),
                            })
                    .First();

                Assert.AreEqual(8 * 4 + 1, result.NPoints); // Default is 8 segments for quarter circle
                Assert.AreEqual("POLYGON", result.GeometryType);
            }
        }

        [Test]
        public void StMinimumBoundingCircleForQuad()
        {
            using (var db = GetDbConnection())
            {
                var poly = db.StGeomFromText("POLYGON((0 0, 10 0, 10 10, 0 10, 0 0))");

                var result = db.PostgisGeometries // TODO: use DB context, not specific table
                    .Select(_ => poly.StMinimumBoundingCircle())
                    .Select(bcircle =>
                            new
                            {
                                GeometryType = bcircle.GeometryType(),
                                NPoints = bcircle.StNPoints(),
                            })
                    .First();

                Assert.AreEqual(4 * 48 + 1, result.NPoints); // Default is 48 segments per quarter circle.
                Assert.AreEqual("POLYGON", result.GeometryType);
            }
        }

        [Test]
        public void StUnionPointsToMultipoint()
        {
            using (var db = GetDbConnection())
            {
                var point1 = db.StGeomFromText("POINT(1 2)");
                var point2 = db.StGeomFromText("POINT(-2 3)");

                var result = db.PostgisGeometries // TODO: use DB context, not specific table
                    .Select(_ => point1.StUnion(point2))
                    .Select(union =>
                            new
                            {
                                GeometryType = union.GeometryType(),
                                NumGeometries = union.StNumGeometries(),
                            })
                    .First();

                Assert.AreEqual(2, result.NumGeometries);
                Assert.AreEqual("MULTIPOINT", result.GeometryType);
            }
        }

        [Test]
        public void StUnionPolygonsToPolygon()
        {
            using (var db = GetDbConnection())
            {
                var point1 = db.StGeomFromText("POLYGON((0 0, 10 0, 10 10, 0 10, 0 0))");
                var point2 = db.StGeomFromText("POLYGON((10 0, 20 0, 20 10, 10 10, 10 0))");

                var result = db.PostgisGeometries // TODO: use DB context, not specific table
                    .Select(_ => point1.StUnion(point2))
                    .Select(union =>
                            new
                            {
                                GeometryType = union.GeometryType(),
                                NumGeometries = union.StNumGeometries(),
                                NumPoints = union.StNPoints(),
                            })
                    .First();

                Assert.AreEqual(7, result.NumPoints);
                Assert.AreEqual(1, result.NumGeometries);
                Assert.AreEqual("POLYGON", result.GeometryType);
            }
        }
    }
}
