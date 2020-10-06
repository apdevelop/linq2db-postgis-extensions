using System;
using System.Configuration;
using System.Linq;

namespace Linq2db.Postgis.Extensions.DemoApp
{
    class Program
    {
        private static Tests.PostGisTestDataConnection dbPostGis;

        private const int SRID_WGS_84 = 4326;

        private const int SRID_WGS84_Web_Mercator = 3857;

        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["postgistest"];
            using (dbPostGis = new Tests.PostGisTestDataConnection(connectionString.ProviderName, connectionString.ConnectionString))
            {
                Console.WriteLine($"PostGIS Version: {dbPostGis.GetPostGisVersion()}");
                Console.WriteLine($"PostGIS full version: {dbPostGis.GetPostGisFullVersion()}");

                var result = dbPostGis.PostgisGeometries
                    .Select(gt => new
                    {
                        Id = gt.Id,
                        Name = gt.Name,
                        SrId = gt.Geometry.STSrId(),
                        GeomEWKT = gt.Geometry.STAsEWKT(),
                        Wkb = gt.Geometry.STAsBinary(),
                        Wkt = gt.Geometry.STAsText(),
                        GeoJSON = gt.Geometry.STAsGeoJSON(),
                        IsSimple = gt.Geometry.STIsSimple(),
                        IsValid = gt.Geometry.STIsValid(),
                        // TODO: ST_IsRing() should only be called on a linear feature IsRing = gt.Geometry.StIsRing(),
                        GeometryType = gt.Geometry.GeometryType(),
                        NDims = gt.Geometry.STNDims(),
                        Area = gt.Geometry.STArea(),
                        Perimeter = gt.Geometry.STPerimeter(),
                        Centroid = gt.Geometry.STCentroid(),
                        Distance = gt.Geometry.STDistance(gt.Geometry),
                        NumPoints = gt.Geometry.STNPoints(),
                        Envelope = gt.Geometry.STEnvelope(),
                        RawGeometry = gt.Geometry,
                        Buffer = gt.Geometry.STBuffer(10.0),
                    })
                    .ToArray();

                foreach (var e in result)
                {
                    Console.WriteLine("{0} '{1}' '{2}' WKB[{3}] SRID={4} NPoints={5}", e.Id, e.Name, e.GeomEWKT, e.Wkb.Length, e.SrId, e.NumPoints);
                }
            }

            Console.ReadKey();
        }
    }
}