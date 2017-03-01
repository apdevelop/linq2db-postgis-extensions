using System;
using System.Configuration;
using System.Linq;

using NUnit.Framework;

namespace Linq2db.Postgis.Extensions.DemoApp
{
    class Program
    {
        private static PostGisTestDataConnection dbPostGis;

        private const int SRID_WGS_84 = 4326;

        private const int SRID_WGS84_Web_Mercator = 3857;

        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["postgistest"];
            dbPostGis = new PostGisTestDataConnection(connectionString.ProviderName, connectionString.ConnectionString);

            Console.WriteLine("Version: {0}", dbPostGis.GetPostGisVersion());
            Console.WriteLine("Full version: {0}", dbPostGis.GetPostGisFullVersion());

            var result = dbPostGis.PostgisGeometries
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
                    // TODO: ST_IsRing() should only be called on a linear feature IsRing = gt.Geometry.StIsRing(),
                    GeometryType = gt.Geometry.GeometryType(),
                    NDims = gt.Geometry.StNDims(),
                    Area = gt.Geometry.StArea(),
                    Perimeter = gt.Geometry.StPerimeter(),
                    Centroid = gt.Geometry.StCentroid(),
                    Distance = gt.Geometry.StDistance(gt.Geometry),
                    NumPoints = gt.Geometry.StNPoints(),
                    Envelope = gt.Geometry.StEnvelope(),
                    RawGeometry = gt.Geometry,
                })
                .ToArray();

            foreach (var e in result)
            {
                Console.WriteLine("{0} '{1}' '{2}' WKB[{3}] SRID={4} NPoints={5}", e.Id, e.Name, e.GeomEWKT, e.Wkb.Length, e.SrId, e.NumPoints);
            }

            Console.ReadKey();
        }
    }
}
