using System;
using System.Configuration;
using System.Linq;

namespace Linq2db.Postgis.Extensions.DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["postgistest"];
            var dbPostGis = new PostGisTestDataConnection(connectionString.ProviderName, connectionString.ConnectionString);

            var result = dbPostGis.PostgisGeometries
                .Select(gt => new
                {
                    Id = gt.Id,
                    Name = gt.Name,
                    SrId = gt.Geometry.StSrId(),
                    GeomEWKT = gt.Geometry.StAsEWKT(),
                    // TODO: for Point type X = gt.Geometry.StX(),
                    // TODO: for Point type Y = gt.Geometry.StY(),
                    Area = gt.Geometry.StArea(),
                    Perimeter = gt.Geometry.StPerimeter(),
                    Centroid = gt.Geometry.StCentroid(),
                    NumPoints = gt.Geometry.StNPoints(),
                    RawGeometry = gt.Geometry,
                })
                .ToArray();

            foreach (var e in result)
            {
                Console.WriteLine("{0} '{1}' '{2}' SRID={3} NPoints={4}", e.Id, e.Name, e.GeomEWKT, e.SrId, e.NumPoints);
            }

            var paris = dbPostGis.PostgisGeometries.Where(gt => gt.Name == "Paris").First();
            var berlin = dbPostGis.PostgisGeometries.Where(gt => gt.Name == "Berlin").First();

            Console.ReadKey();
        }
    }
}
