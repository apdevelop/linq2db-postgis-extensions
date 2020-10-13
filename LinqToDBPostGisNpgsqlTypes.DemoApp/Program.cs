using System;
using System.Configuration;
using System.Linq;

namespace LinqToDBPostGisNpgsqlTypes.DemoApp
{
    class Program
    {
        private static Tests.PostGisTestDataConnection dbPostGis;

        private const int SRID_WGS_84 = 4326;

        private const int SRID_WGS84_Web_Mercator = 3857;

        static void Main(string[] args)
        {
            (new Tests.TestsBase()).InsertTestData();

            var connectionString = ConfigurationManager.ConnectionStrings["postgistest"];
            using (dbPostGis = new Tests.PostGisTestDataConnection(connectionString.ProviderName, connectionString.ConnectionString))
            {
                Console.WriteLine($"PostGIS Version: {dbPostGis.GetPostGisVersion()}");
                Console.WriteLine($"PostGIS full version: {dbPostGis.GetPostGisFullVersion()}");

                var result = dbPostGis.PostgisGeometries
                    .Select(gt => new
                    {
                        Id = gt.Id,
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
                    Console.WriteLine($"{e.Id} '{e.GeomEWKT}' WKB[{e.Wkb.Length}] SRID={e.SrId} NPoints={e.NumPoints}");
                }
            }

            Console.ReadKey();
        }
    }
}