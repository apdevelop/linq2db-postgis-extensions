using System;
using System.Linq;

using NUnit.Framework;

namespace Linq2db.Postgis.Extensions.Tests
{
    [TestFixture]
    class PolygonsTests : TestsBase
    {
        [Test]
        public void ReadPolygons()
        {
            using (var db = GetDbConnection())
            {
                var polygons = db.Polygons
                    .Select(gt => new
                    {
                        Id = gt.Id,
                        Name = gt.Name,
                        SrId = gt.Geometry.StSrId(),
                        GeomEWKT = gt.Geometry.StAsEWKT(),
                        Wkb = gt.Geometry.StAsBinary(),
                        Wkt = gt.Geometry.StAsText(),
                        GeoJSON = gt.Geometry.StAsGeoJSON(),
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
                        EnvelopeArea = gt.Geometry.StEnvelope().StArea(),
                        ConvexHullArea = gt.Geometry.StConvexHull().StArea(),
                        RawGeometry = gt.Geometry,
                    })
                    .ToList();

                foreach (var p in polygons)
                {
                    Assert.IsFalse(String.IsNullOrEmpty(p.Name));
                    Assert.AreEqual(SRID_WGS84_Web_Mercator, p.SrId);
                    Assert.AreEqual("POLYGON", p.GeometryType);
                    Assert.AreEqual("ST_Polygon", p.StGeometryType);
                    Assert.AreEqual(2, p.NDims);
                    Assert.AreEqual(2, p.CoordDim);
                    Assert.AreEqual(2, p.Dimension);
                    Assert.AreEqual(0.0, p.Distance);
                    Assert.AreEqual(5, p.NumPoints);
                    Assert.AreEqual(p.EnvelopeArea, p.Area);
                    Assert.AreEqual(p.ConvexHullArea, p.Area);
                    Assert.IsTrue(p.IsValid);
                    Assert.IsTrue(p.IsSimple);
                }
            }
        }

        [Test]
        public void SelectAndOrderBy()
        {
            using (var db = GetDbConnection())
            {
                var point = db.StGeomFromEWKT("SRID=3857;POINT(0 5)");
                var selected = db.Polygons
                    .Where(p => p.Geometry.StArea() > 150.0)
                    .OrderBy(p => p.Geometry.StDistance(point))
                    .Select(p => new
                        {
                            Name = p.Name,
                            Area = p.Geometry.StArea(),
                            CenterX = p.Geometry.StCentroid().StX(),
                            CenterY = p.Geometry.StCentroid().StY(),
                        })
                    .ToList();

                Assert.AreEqual(2, selected.Count);
                Assert.AreEqual("Rectangle V", selected[0].Name);
                Assert.AreEqual(300.0, selected[0].Area, 0.1);
                Assert.AreEqual(5.0, selected[0].CenterX, 0.1);
                Assert.AreEqual(35.0, selected[0].CenterY, 0.1);
                Assert.AreEqual("Rectangle H", selected[1].Name);
                Assert.AreEqual(1000.0, selected[1].Area, 0.1);
                Assert.AreEqual(45.0, selected[1].CenterX, 0.1);
                Assert.AreEqual(30.0, selected[1].CenterY, 0.1);
                // TODO: Check if spatial index was used
            }
        }
    }
}
