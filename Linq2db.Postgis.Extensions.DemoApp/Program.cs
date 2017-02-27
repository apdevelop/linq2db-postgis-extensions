using System;
using System.Configuration;
using System.Linq;

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

            Console.WriteLine("Version: {0}", dbPostGis.PostgisGeometries.Select(c => ManagementFunctions.PostGisVersion).First());
            Console.WriteLine("Full version: {0}", dbPostGis.PostgisGeometries.Select(c => ManagementFunctions.PostGisFullVersion).First());

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
                    // TODO: for Point type X = gt.Geometry.StX(),
                    // TODO: for Point type Y = gt.Geometry.StY(),
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

            // TODO: Add asserts for results checking (using NUnit)

            TestLinearMeasurements();
            TestGeometryConstructors();
            TestFindNearestNeighbor();

            Console.ReadKey();
        }

        static void TestLinearMeasurements()
        {
            // Prepare select expressions as IQueryable, do not materialize
            var paris = dbPostGis.PostgisGeometries.Where(gt => gt.Name == "Paris");
            var berlin = dbPostGis.PostgisGeometries.Where(gt => gt.Name == "Berlin");
            var distanceInDegrees = paris.Select(gt => gt.Geometry.StDistance(berlin.Select(gt1 => gt1.Geometry).First())).First();
            // 11.656217225155°

            var parisProjected = paris.Select(gt => new PostgisGeometryEntity { Geometry = gt.Geometry.StTransform(SRID_WGS84_Web_Mercator), Id = gt.Id, Name = gt.Name, });
            var berlinProjected = berlin.Select(gt => new PostgisGeometryEntity { Geometry = gt.Geometry.StTransform(SRID_WGS84_Web_Mercator), Id = gt.Id, Name = gt.Name, });

            var straightLine = parisProjected.Select(gt => gt.Geometry.StShortestLine(berlinProjected.Select(gt1 => gt1.Geometry).First()));
            var straightLineEwkt = straightLine.Select(gt => gt.StAsEWKT()).First();
            var distanceInMeters = straightLine.Select(gt => gt.StLength()).First();
            // Checked with MSSQL = 1389451.13191426 (But shortest distance actually is 879989.866996421)
        }

        static void TestGeometryConstructors()
        {
            // TODO: Execute on DB context, not specific table (exclude FROM <table> from generated SQL statement)
            var point1 = dbPostGis.PostgisGeometries.Select(g => GeometryEditors.StSetSrId(GeometryConstructors.StPoint(-71.064544, 42.28787), SRID_WGS_84));
            var point2 = dbPostGis.PostgisGeometries.Select(g => GeometryConstructors.StGeomFromText("POINT(-71.064544 42.28787)", SRID_WGS_84));
            var point3 = dbPostGis.PostgisGeometries.Select(g => GeometryConstructors.StGeomFromEWKT("SRID=" + SRID_WGS_84.ToString() + ";POINT(-71.064544 42.28787)"));

            var equals12 = point1.Select(g => g.StEquals(point2.First())).First();
            var equals13 = point1.Select(g => g.StEquals(point3.First())).First();
            //TODO: Assert points are equal
        }

        static void TestFindNearestNeighbor()
        {
            var point = new NpgsqlTypes.PostgisPoint(60, 30) { SRID = SRID_WGS84_Web_Mercator };
            var nearest = dbPostGis.PostgisGeometries
                .Where(gt => gt.Geometry.StSrId() == SRID_WGS84_Web_Mercator) // TODO: Use separate table
                .OrderBy(gt => gt.Geometry.StDistance(point))
                .First();

            // TODO: Check if using spatial index
        }
    }
}
