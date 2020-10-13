using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

namespace LinqToDBPostGisNpgsqlTypes.Tests
{
    [TestFixture]
    class PolygonsTests : TestsBase
    {
        [SetUp]
        public void Setup()
        {
            using (var db = GetDbConnection())
            {
                db.Polygons.Delete();

                var list = new[] 
                {
                    "SRID=3857;POLYGON((0 0, 10 0, 10 10, 0 10, 0 0))",
                    "SRID=3857;POLYGON((20 20, 70 20, 70 40, 20 40, 20 20))",
                    "SRID=3857;POLYGON((0 20, 10 20, 10 50, 0 50, 0 20))",
                };

                var id = 1;
                foreach (var ewkt in list)
                {
                    var geom = db.STGeomFromEWKT(ewkt);
                    db.Insert(new Entities.PolygonEntity
                    {
                        Id = id,
                        Geometry = geom,
                    });

                    id++;
                }
            }
        }

        [Test]
        public void ReadPolygons()
        {
            using (var db = GetDbConnection())
            {
                var polygons = db.Polygons
                    .Select(gt => new
                    {
                        SrId = gt.Geometry.STSrId(),
                        GeomEWKT = gt.Geometry.STAsEWKT(),
                        Wkb = gt.Geometry.STAsBinary(),
                        Wkt = gt.Geometry.STAsText(),
                        GeoJSON = gt.Geometry.STAsGeoJSON(),
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
                        EnvelopeArea = gt.Geometry.STEnvelope().STArea(),
                        ConvexHullArea = gt.Geometry.STConvexHull().STArea(),
                        RawGeometry = gt.Geometry,
                    })
                    .ToList();

                foreach (var p in polygons)
                {
                    Assert.AreEqual(SRID_WGS84_Web_Mercator, p.SrId);
                    Assert.AreEqual("POLYGON", p.GeometryType);
                    Assert.AreEqual("ST_Polygon", p.STGeometryType);
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
                var point = db.STGeomFromEWKT("SRID=3857;POINT(0 5)");
                var selected = db.Polygons
                    .Where(p => p.Geometry.STArea() > 150.0)
                    .OrderBy(p => p.Geometry.STDistance(point))
                    .Select(p => new
                        {
                            Area = p.Geometry.STArea(),
                            CenterX = p.Geometry.STCentroid().STX(),
                            CenterY = p.Geometry.STCentroid().STY(),
                        })
                    .ToList();

                Assert.AreEqual(2, selected.Count);
                Assert.AreEqual(300.0, selected[0].Area, 0.1);
                Assert.AreEqual(5.0, selected[0].CenterX, 0.1);
                Assert.AreEqual(35.0, selected[0].CenterY, 0.1);
                Assert.AreEqual(1000.0, selected[1].Area, 0.1);
                Assert.AreEqual(45.0, selected[1].CenterX, 0.1);
                Assert.AreEqual(30.0, selected[1].CenterY, 0.1);
                // TODO: Check if spatial index was used
            }
        }
    }
}