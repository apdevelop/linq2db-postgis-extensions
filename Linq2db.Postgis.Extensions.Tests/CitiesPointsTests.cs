using System;
using System.Diagnostics;
using System.Linq;

using NpgsqlTypes;
using NUnit.Framework;

using Linq2db.Postgis.Extensions.Tests.Entities;

namespace Linq2db.Postgis.Extensions.Tests
{
    [TestFixture]
    class CitiesPointsTests : TestsBase
    {
        [Test]
        public void ReadCities()
        {
            using (var db = GetDbConnection())
            {
                var cities = db.OwmCities
                    .Select(gt => new
                    {
                        Id = gt.Id,
                        Name = gt.Name,
                        SrId = gt.Geometry.StSrId(),
                        GeomEWKT = gt.Geometry.StAsEWKT(),
                        Wkb = gt.Geometry.StAsBinary(),
                        Wkt = gt.Geometry.StAsText(),
                        GeoJSON = gt.Geometry.StAsGeoJSON(),
                        X = gt.Geometry.StX(),
                        Y = gt.Geometry.StY(),
                        IsSimple = gt.Geometry.StIsSimple(),
                        IsValid = gt.Geometry.StIsValid(),
                        GeometryType = gt.Geometry.GeometryType(),
                        StGeometryType = gt.Geometry.StGeometryType(),
                        NDims = gt.Geometry.StNDims(),
                        CoordDim = gt.Geometry.StCoordDim(),
                        Dimension = gt.Geometry.StDimension(),
                        Area = gt.Geometry.StArea(),
                        Perimeter = gt.Geometry.StPerimeter(),
                        Centroid = gt.Geometry.StCentroid(),
                        Distance = gt.Geometry.StDistance(gt.Geometry),
                        NumPoints = gt.Geometry.StNPoints(),
                        Envelope = gt.Geometry.StEnvelope(),
                        RawGeometry = gt.Geometry,
                    })
                    .ToList();

                foreach (var c in cities)
                {
                    Assert.IsFalse(String.IsNullOrEmpty(c.Name));
                    Assert.AreEqual(SRID_WGS84_Web_Mercator, c.SrId);
                    Assert.AreEqual("POINT", c.GeometryType);
                    Assert.AreEqual("ST_Point", c.StGeometryType);
                    Assert.AreEqual(2, c.NDims);
                    Assert.AreEqual(2, c.CoordDim);
                    Assert.AreEqual(0, c.Dimension);
                    Assert.AreEqual(0.0, c.Area);
                    Assert.AreEqual(0.0, c.Distance);
                    Assert.AreEqual(1, c.NumPoints);
                    Assert.IsTrue(c.IsValid);
                    Assert.IsTrue(c.IsSimple);

                    var point = c.RawGeometry as PostgisPoint;
                    Assert.IsNotNull(point);
                    Assert.AreEqual(point.X, c.X);
                    Assert.AreEqual(point.Y, c.Y);
                }
            }
        }

        [Test]
        public void MeasureDistance()
        {
            using (var db = GetDbConnection())
            {
                // Prepare select expressions as IQueryable, do not materialize
                var paris = db.OwmCities.Where(gt => gt.Name == "Paris");
                var berlin = db.OwmCities.Where(gt => gt.Name == "Berlin");
                var distanceInMeters = paris.Select(gt => gt.Geometry.StDistance(berlin.Select(gt1 => gt1.Geometry).First())).First();
                Assert.AreEqual(1390305.0, distanceInMeters, 1.0);

                var parisUnProjected = paris.Select(gt => new PostgisGeometryEntity { Geometry = gt.Geometry.StTransform(SRID_WGS_84), Id = gt.Id, Name = gt.Name, });
                var berlinUnProjected = berlin.Select(gt => new PostgisGeometryEntity { Geometry = gt.Geometry.StTransform(SRID_WGS_84), Id = gt.Id, Name = gt.Name, });
                var straightLine = parisUnProjected.Select(gt => gt.Geometry.StShortestLine(berlinUnProjected.Select(gt1 => gt1.Geometry).First()));
                var straightLineEwkt = straightLine.Select(gt => gt.StAsEWKT()).First();
                var distanceInDegrees = straightLine.Select(gt => gt.StLength()).First();
                Assert.AreEqual(11.655, distanceInDegrees, 0.001);
            }
        }

        [Test]
        public void FindNearestNeighbor()
        {
            using (var db = GetDbConnection())
            {
                var point = new PostgisPoint(13.72, 51.07) { SRID = (uint)SRID_WGS_84 }; // Or point = db.StGeomFromText("POINT(13.72 51.07)", SRID_WGS_84);
                var pointProjected = db.OwmCities.Select(gt => point.StTransform(SRID_WGS84_Web_Mercator)).First();

                var nearest = db.OwmCities
                    .OrderBy(gt => gt.Geometry.StDistance(pointProjected))  // Or GeometryConstructors.StGeomFromText("POINT(1527303 6633685)", 3857)
                    .First();

                Assert.AreEqual("Prague", nearest.Name);
                // TODO: Check if spatial index was used
            }
        }

        [Test]
        public void FindInRectangle()
        {
            using (var db = GetDbConnection())
            {
                var area = new PostgisPolygon(
                    new[]
                    {
                        new[]
                        {
                            new Coordinate2D(12, 49),
                            new Coordinate2D(17, 49),
                            new Coordinate2D(17, 54),
                            new Coordinate2D(12, 54),
                            new Coordinate2D(12, 49),
                        }
                    }) { SRID = (uint)SRID_WGS_84 };

                // TODO: Optimize and speed-up query, takes now ~400ms
                var areaProjected = db.OwmCities
                    .Select(gt =>
                        area.StTransform(SRID_WGS84_Web_Mercator))
                    .First();

                ////var areaProjected = new PostgisPolygon(
                ////    new[]
                ////    {
                ////        new[]
                ////        {
                ////            new Coordinate2D(1335833.88951928, 6274861.39400658),
                ////            new Coordinate2D(1892431.34348565, 6274861.39400658),
                ////            new Coordinate2D(1892431.34348565, 7170156.29399995),
                ////            new Coordinate2D(1335833.88951928, 7170156.29399995),
                ////            new Coordinate2D(1335833.88951928, 6274861.39400658),
                ////        }
                ////    }) { SRID = SRID_WGS84_Web_Mercator };

                var sw = Stopwatch.StartNew();
                var list = db.OwmCities
                    .Where(gt => areaProjected.StContains(gt.Geometry))
                    .OrderBy(gt => gt.Name)
                    .ToList();
                sw.Stop();

                Console.WriteLine(sw.ElapsedMilliseconds);

                Assert.AreEqual(2, list.Count);
                Assert.IsTrue(list.Any(c => c.Name == "Berlin"));
                Assert.IsTrue(list.Any(c => c.Name == "Prague"));
                // TODO: Check if spatial index was used
                // http://postgis.net/docs/manual-1.3/ch03.html
                // https://gis.stackexchange.com/questions/130856/postgis-doesnt-use-spatial-index-with-st-intersects
            }
        }

        [Test]
        public void Translate()
        {
            using (var db = GetDbConnection())
            {
                const double delta = 1000.0;
                var point = db.OwmCities
                    .Where(gt => gt.Name == "Moscow")
                    .Select(gt => gt.Geometry.StTranslate(+delta, -delta))
                    .Select(gt => new { X = gt.StX(), Y = gt.StY(), })
                    .First();

                Assert.AreEqual(4187344.0 + delta, point.X, 1.0);
                Assert.AreEqual(7509247.0 - delta, point.Y, 1.0);
            }
        }
    }
}
