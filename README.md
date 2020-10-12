# Linq2db PostGIS Extensions
C# .NET Standard 2.0 library with OGC extensions methods on geometry (`NpgsqlTypes.PostgisGeometry` or `NetTopologySuite.Geometries.Geometry`) instances, providing access to [PostGIS](http://postgis.net/) functions on server side while using [linq2db](https://github.com/linq2db/linq2db) LINQ to database provider (lightweight ORM).

### Two implementations

| Property       | LinqToDBPostGisNpgsqlTypes  | LinqToDBPostGisNetTopologySuite      |
| -------------- |:---------------------------:|:------------------------------------:|
| Extending type | `NpgsqlTypes.PostgisGeometry` | `NetTopologySuite.Geometries.Geometry` |
| Npgsql version | 3.x                         | 4.x                                  |
| Status         | Legacy                      | Recommended way                      |
| Dependencies   | linq2db, Npgsql           | linq2db, Npgsql, NetTopologySuite, Npgsql.NetTopologySuite, NetTopologySuite.IO.PostGis |

### Usage
`NpgsqlTypes.PostgisGeometry` or `NetTopologySuite.Geometries.Geometry` gets additional methods, similar to `Microsoft.SqlServer.Types.SqlGeometry` 
[OGC Methods on Geometry Instances](https://docs.microsoft.com/sql/t-sql/spatial-geometry/ogc-methods-on-geometry-instances?view=sql-server-2016) or 
[NetTopologySuite plugin for Entity Framework Core for PostgreSQL](https://www.npgsql.org/efcore/mapping/nts.html).
These methods will be translated into PostGIS SQL operations, so evaluation will happen on the server side. Siple calling these methods on client side generates `InvalidOperationException`.
Naming convention follows OGC methods names, starting with `ST*` prefix.

Using extensions methods inside LINQ expression:

```c#
using LinqToDBPostGisNpgsqlTypes; // or LinqToDBPostGisNetTopologySuite

using (var db = new PostGisTestDataConnection())
{
    NpgsqlTypes.PostgisGeometry point = db.STGeomFromEWKT("SRID=3857;POINT(0 5)"); // For Npgsql 3.x
    NetTopologySuite.Geometries.Point point = new Point(new Coordinate(0, 5)) { SRID = 3857 }; // For Npgsql 4.x

    var selected = db.Polygons
        .Where(p => p.Geometry.STArea() > 150.0)
        .OrderBy(p => p.Geometry.STDistance(point))
        .ToList();

    var nearestCity = db.Cities
        .OrderBy(c => c.Geometry.STDistance(point))
        .FirstOrDefault();

    var stats = db.Cities
        .Select(c =>
             new
             {
                 Id = c.Id,
                 Name = c.Name,
                 Area = c.Geometry.STArea(),
                 Distance = c.Geometry.STDistance(point),
                 NumPoints = c.Geometry.STNPoints(),
                 Srid = c.Geometry.STSrId(),
                 Wkt = c.Geometry.STAsText(),
             })
        .ToList();;
}
```

```c#
[Table(Schema = "public", Name = "test_polygons")]
public class PolygonEntity
{
    [Column("geom"), NotNull]
    public NpgsqlTypes.PostgisGeometry Geometry { get; set; } // For Npgsql 3.x
    public NetTopologySuite.Geometries.Geometry Geometry { get; set; } // For Npgsql 4.x
}

[Table(Schema = "public", Name = "owm_cities")]
public class CityEntity
{
    [Column("geom"), NotNull]
    public NpgsqlTypes.PostgisGeometry Geometry { get; set; } // For Npgsql 3.x
    public NetTopologySuite.Geometries.Geometry Geometry { get; set; } // For Npgsql 4.x
}

class PostGisTestDataConnection : LinqToDB.Data.DataConnection
{
    public ITable<PolygonEntity> Polygons { get { return GetTable<PolygonEntity>(); } }
    public ITable<CityEntity> Cities { get { return GetTable<CityEntity>(); } }
}
```

### Technologies
Developed using MS Visual Studio 2017, .NET Core 2.1.
Tested on PostgreSQL version 9.6, PostGIS version 2.3.1.
Depends on [linq2db](https://github.com/linq2db/linq2db), [Npgsql](https://github.com/npgsql/npgsql).

### Getting started with demo application
* Make sure you have PostgreSQL DBMS with PostGIS geospatial extension installed.
* Create new database named "postgistest" (or any other name), add support of spatial features for this database.
* Execute SQL scripts `Sql\create_tables.sql` and `Sql\insert_data.sql` in this database.
* Open solution `LinqToDBPostGis.sln` in Visual Studio.
* Check database connection string in `App.config` of `LinqToDBPostGisNpgsqlTypes.DemoApp` project.
* Run application, view table data along with PostGIS functions results in console output.
* Add wrappers for more PostGIS functions in `LinqToDBPostGisNpgsqlTypes` classes as needed.

### TODOs
 * Implement more of PostGIS spatial methods.
 * Support of PostGIS `geography` data type.
 * Nuget package.
 
### References
* [PostGIS Reference](https://postgis.net/docs/manual-3.0/reference.html)
* [PostGIS/NetTopologySuite Type Plugin](https://www.npgsql.org/doc/types/nts.html)
* [How to teach LINQ to DB convert custom .NET methods and objects to SQL - Sql.Function attribute](http://blog.linq2db.com/2016/06/how-to-teach-linq-to-db-convert-custom.html)