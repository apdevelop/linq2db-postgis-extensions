using System;
using System.Configuration;
using System.Linq;

using NTSG = NetTopologySuite.Geometries;
using Npgsql;
using LinqToDB;

namespace LinqToDBPostGisNetTopologySuite.DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NpgsqlConnection.GlobalTypeMapper.UseNetTopologySuite();

            ReadCities();

            Console.ReadKey();
        }

        private static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["postgistest"].ConnectionString;
            }
        }

        static void ReadCities()
        {
            using (var db = new Tests.PostGisTestDataConnection(ConnectionString))
            {
                var point = new NTSG.Point(new NTSG.Coordinate(0, 7200000)) { SRID = 3857 };

                var nearestCity = db.OwmCities
                    .OrderBy(c => c.Geometry.STDistance(point))
                    .First();
                Console.WriteLine($"Nearest city: [{nearestCity.Id}] '{nearestCity.Name}'");

                var query = db.OwmCities
                    .Select(c =>
                        new
                        {
                            Id = c.Id,
                            Name = c.Name,
                            NumPoints = c.Geometry.STNPoints(),
                            Srid = c.Geometry.STSrId(),
                            Area = c.Geometry.STArea(),
                            Distance = c.Geometry.STDistance(point),
                            Wkt = c.Geometry.STAsText(),
                            EWkt = c.Geometry.STAsEWKT(),
                        });

                var list = query.ToList();
                foreach (var c in list)
                {
                    Console.WriteLine($"[{c.Id}] '{c.Name}'\tDistance: {c.Distance:0}\tSRID={c.Srid}\t{c.Wkt}");
                }
            }
        }
    }
}
