# Linq2db PostGIS Extensions
.NET Standard 2.0 library with OGC extensions methods on geometry (`NpgsqlTypes.PostgisGeometry` or `NetTopologySuite.Geometries.Geometry`) instances, providing strongly typed access to [PostGIS](http://postgis.net/) functions on server side while using [linq2db](https://github.com/linq2db/linq2db) LINQ to database provider.

### Two implementations

| Property       | LinqToDBPostGisNpgsqlTypes  | LinqToDBPostGisNetTopologySuite      |
| -------------- |:---------------------------:|:------------------------------------:|
| Extending type | `NpgsqlTypes.PostgisGeometry` | `NetTopologySuite.Geometries.Geometry` |
| Npgsql version | 3.x                         | 4.x                                  |
| PostGIS reference version     | 1.5                      | 3.0                      |
| Status         | Legacy                      | Recommended way                      |
| NuGet          |   &mdash;       |  [![NuGet](https://img.shields.io/nuget/v/LinqToDBPostGisNTS.svg)](https://www.nuget.org/packages/LinqToDBPostGisNTS/) |
| Dependencies   | linq2db, Npgsql           | linq2db, Npgsql, NetTopologySuite, Npgsql.NetTopologySuite, NetTopologySuite.IO.PostGis |

### Usage
`NpgsqlTypes.PostgisGeometry` or `NetTopologySuite.Geometries.Geometry` gets additional methods, similar to `Microsoft.SqlServer.Types.SqlGeometry` 
[OGC Methods on Geometry Instances](https://docs.microsoft.com/sql/t-sql/spatial-geometry/ogc-methods-on-geometry-instances?view=sql-server-2016) or 
[NetTopologySuite plugin for Entity Framework Core for PostgreSQL](https://www.npgsql.org/efcore/mapping/nts.html).
These methods will be translated into PostGIS SQL operations, so evaluation will happen on the server side. Calling these methods on client side results in throwing `InvalidOperationException`.
Naming convention follows OGC methods names, starting with `ST*` prefix.

Using extensions methods inside LINQ expression (Npgsql 4):

```c#
using LinqToDBPostGisNetTopologySuite

using (var db = new PostGisTestDataConnection())
{
    NetTopologySuite.Geometries.Point point = new Point(new Coordinate(1492853, 6895498)) { SRID = 3857 };

    var dms = db.Select(() => GeometryOutput.STAsLatLonText(point));

    var nearestCity = db.Cities
        .OrderBy(c => c.Geometry.STDistance(point))
        .FirstOrDefault();

    var selected = db.Polygons
        .Where(p => p.Geometry.STArea() > 150.0)
        .OrderBy(p => p.Geometry.STDistance(point))
        .ToList();

    var stats = db.Polygons
        .Select(c => new
             {
                 Id = c.Id,
                 Name = c.Name,
                 Area = c.Geometry.STArea(),
                 Distance = c.Geometry.STDistance(point),
                 NumPoints = c.Geometry.STNPoints(),
                 Srid = c.Geometry.STSrId(),
                 Wkt = c.Geometry.STAsText(),
             })
        .ToList();
}
```

```c#
[Table("test_geometry", Schema = "public")]
public class PolygonEntity
{
    [Column("geom")]
    public NetTopologySuite.Geometries.Geometry Geometry { get; set; }
}

[Table("owm_cities", Schema = "public")]
public class CityEntity
{
    [Column("geom")]
    public NetTopologySuite.Geometries.Geometry Geometry { get; set; }
}

class PostGisTestDataConnection : LinqToDB.Data.DataConnection
{
    public ITable<PolygonEntity> Polygons { get { return GetTable<PolygonEntity>(); } }
    public ITable<CityEntity> Cities { get { return GetTable<CityEntity>(); } }
}
```

### Technologies
Developed using MS Visual Studio 2017.
Tested on PostgreSQL version 9.6.1, PostGIS version 3.0.2.
Depends on [linq2db](https://github.com/linq2db/linq2db), [Npgsql](https://github.com/npgsql/npgsql).

### Getting started with demo application
* Make sure you have PostgreSQL DBMS with PostGIS extension installed. Execute `SELECT PostGIS_Full_Version()` query to check PostGIS version.
* Create new database named "postgistest" (or any other name), add support of spatial features for this database.
* Execute SQL script `Sql\create_tables.sql` in this database.
* Open solution `LinqToDBPostGis.sln` in Visual Studio.
* Check database connection string in `App.config` of all projects.
* Run application, view table data along with PostGIS functions results in console output.

### TODOs
 * Implement full set of PostGIS methods (Currently implemented `215` of `303` methods, counted without overloads).
 * Add support for PostGIS `geography` data type.
 * Test on various versions of PostgreSQL/PostGIS and platforms (including .NET 5).
 * More tests for corner cases.
 
### References
* [PostGIS Reference](https://postgis.net/docs/manual-3.0/reference.html)
* [PostGIS/NetTopologySuite Type Plugin](https://www.npgsql.org/doc/types/nts.html)
* [Spatial Mapping with NetTopologySuite in Entity Framework Core](https://www.npgsql.org/efcore/mapping/nts.html)
* [How to teach LINQ to DB convert custom .NET methods and objects to SQL - Sql.Function attribute](http://blog.linq2db.com/2016/06/how-to-teach-linq-to-db-convert-custom.html)
