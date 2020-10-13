using System;
using System.Diagnostics;
using System.Linq;

using LinqToDB;
using NpgsqlTypes;
using NUnit.Framework;

using LinqToDBPostGisNpgsqlTypes.Tests.Entities;

namespace LinqToDBPostGisNpgsqlTypes.Tests
{
    [TestFixture]
    class CitiesPointsTests : TestsBase
    {
        [OneTimeSetUp]
        public void Setup()
        {
            using (var db = GetDbConnection())
            {
                db.Cities.Delete();

                var list = new string[][]
                {
                    new[] { "Paris", "SRID=4326;POINT(2.348800 48.853409)" },
                    new[] { "Berlin", "SRID=4326;POINT(13.410530 52.524368)" },
                    new[] { "London", "SRID=4326;POINT(-0.091840 51.512791)" },
                    new[] { "Prague", "SRID=4326;POINT(14.420760 50.088039)" },
                    new[] { "Moscow", "SRID=4326;POINT(37.615555 55.752220)" },
                    new[] { "Minsk", "SRID=4326;POINT(27.566668 53.900002)" },
                    new[] { "Madrid", "SRID=4326;POINT(-3.702560 40.416500)" },
                    new[] { "Warsaw", "SRID=4326;POINT(21.011780 52.229771)" },
                    new[] { "Vienna", "SRID=4326;POINT(16.372080 48.208488)" },
            };

                var id = 1;
                foreach (var item in list)
                {
                    // TODO: ? simplify, less queries
                    // TODO: spatial index
                    var geom = db.STGeomFromEWKT(item[1]);
                    db.Insert(new CityEntity
                    {
                        Id = id,
                        Name = item[0],
                        Geometry = geom,
                    });

                    var projected = db.Cities
                        .Where(c => c.Id == id)
                        .Select(c => c.Geometry.STTransform(3857))
                        .Single();

                    db.Cities
                        .Where(c => c.Id == id)
                        .Set(c => c.Geometry, projected)
                        .Update();

                    id++;
                }
            }
        }

        [Test]
        public void ReadCities()
        {
            using (var db = GetDbConnection())
            {
                var cities = db.Cities
                    .Select(gt => new
                    {
                        Id = gt.Id,
                        Name = gt.Name,
                        SrId = gt.Geometry.STSrId(),
                        GeomEWKT = gt.Geometry.STAsEWKT(),
                        Wkb = gt.Geometry.STAsBinary(),
                        Wkt = gt.Geometry.STAsText(),
                        GeoJSON = gt.Geometry.STAsGeoJSON(),
                        X = gt.Geometry.STX(),
                        Y = gt.Geometry.STY(),
                        IsSimple = gt.Geometry.STIsSimple(),
                        IsValid = gt.Geometry.STIsValid(),
                        GeometryType = gt.Geometry.GeometryType(),
                        STGeometryType = gt.Geometry.STGeometryType(),
                        NDims = gt.Geometry.STNDims(),
                        CoordDim = gt.Geometry.STCoordDim(),
                        Dimension = gt.Geometry.STDimension(),
                        Area = gt.Geometry.STArea(),
                        Perimeter = gt.Geometry.STPerimeter(),
                        Centroid = gt.Geometry.STCentroid(),
                        Distance = gt.Geometry.STDistance(gt.Geometry),
                        NumPoints = gt.Geometry.STNPoints(),
                        Envelope = gt.Geometry.STEnvelope(),
                        RawGeometry = gt.Geometry,
                    })
                    .ToList();

                foreach (var c in cities)
                {
                    Assert.IsFalse(String.IsNullOrEmpty(c.Name));
                    Assert.AreEqual(SRID_WGS84_Web_Mercator, c.SrId);
                    Assert.AreEqual("POINT", c.GeometryType);
                    Assert.AreEqual("ST_Point", c.STGeometryType);
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
                var paris = db.Cities.Where(gt => gt.Name == "Paris");
                var berlin = db.Cities.Where(gt => gt.Name == "Berlin");
                var distanceInMeters = paris.Select(gt => gt.Geometry.STDistance(berlin.Select(gt1 => gt1.Geometry).First())).First();
                Assert.AreEqual(1390305.0, distanceInMeters, 1.0);

                var parisUnProjected = paris.Select(gt => new PostgisGeometryEntity { Geometry = gt.Geometry.STTransform(SRID_WGS_84), Id = gt.Id, });
                var berlinUnProjected = berlin.Select(gt => new PostgisGeometryEntity { Geometry = gt.Geometry.STTransform(SRID_WGS_84), Id = gt.Id, });
                var straightLine = parisUnProjected.Select(gt => gt.Geometry.STShortestLine(berlinUnProjected.Select(gt1 => gt1.Geometry).First()));
                var straightLineEwkt = straightLine.Select(gt => gt.STAsEWKT()).First();
                var distanceInDegrees = straightLine.Select(gt => gt.STLength()).First();
                Assert.AreEqual(11.655, distanceInDegrees, 0.001);
            }
        }

        [Test]
        public void FindNearestNeighbor()
        {
            using (var db = GetDbConnection())
            {
                var point = new PostgisPoint(13.72, 51.07) { SRID = (uint)SRID_WGS_84 }; // Or point = db.StGeomFromText("POINT(13.72 51.07)", SRID_WGS_84);
                var pointProjected = db.Cities.Select(gt => point.STTransform(SRID_WGS84_Web_Mercator)).First();

                var nearest = db.Cities
                    .OrderBy(gt => gt.Geometry.STDistance(pointProjected))  // Or GeometryConstructors.StGeomFromText("POINT(1527303 6633685)", 3857)
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
                    })
                {
                    SRID = (uint)SRID_WGS_84,
                };

                // TODO: Optimize and speed-up query, takes now ~400ms
                var areaProjected = db.Cities
                    .Select(gt => area.STTransform(SRID_WGS84_Web_Mercator))
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
                var list = db.Cities
                    .Where(gt => areaProjected.STContains(gt.Geometry))
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
                var point = db.Cities
                    .Where(gt => gt.Name == "Moscow")
                    .Select(gt => gt.Geometry.STTranslate(+delta, -delta))
                    .Select(gt => new { X = gt.STX(), Y = gt.STY(), })
                    .First();

                Assert.AreEqual(4187344.0 + delta, point.X, 1.0);
                Assert.AreEqual(7509247.0 - delta, point.Y, 1.0);
            }
        }
    }
}