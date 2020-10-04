# Linq2db PostGIS Extensions
C# .NET Standard 2.0 library with extensions methods for spatial (`NpgsqlTypes.PostgisGeometry`) data type providing access to [PostGIS](http://postgis.net/) functions while using [linq2db](https://github.com/linq2db/linq2db) LINQ to database provider.
Demo application with tests is also included.

### Technologies
Developed using MS Visual Studio 2017, C#.NET 4.7.2.
Tested on PostgreSQL version 9.6, PostGIS version 2.3.1.
Depends on [linq2db](https://github.com/linq2db/linq2db), [Npgsql](https://github.com/npgsql/npgsql).

### Sample usage
Using extensions methods inside LINQ expression:

```c#
using Linq2db.Postgis.Extensions;

using (var db = new PostGisTestDataConnection())
{
    var point = db.StGeomFromEWKT("SRID=3857;POINT(0 5)");
    var selected = db.Polygons
        .Where(p => p.Geometry.StArea() > 150.0)
        .OrderBy(p => p.Geometry.StDistance(point))
        .ToList();
}
```

Where `PolygonEntity` and `PostGisTestDataConnection` entity classes are:

```c#
[Table(Schema = "public", Name = "test_polygons")]
public class PolygonEntity
{
	...

    [Column("geom"), NotNull]
    public NpgsqlTypes.PostgisGeometry Geometry { get; set; }
}

class PostGisTestDataConnection : LinqToDB.Data.DataConnection
{
	...

	public ITable<PolygonEntity> Polygons { get { return GetTable<PolygonEntity>(); } }
}
```

### Getting started with demo application
* Make sure you have PostgreSQL DBMS with PostGIS geospatial extension installed.
* Create new database named "postgistest" (or any other name), add support of spatial features for this database.
* Execute SQL scripts `Sql\create_tables.sql` and `Sql\insert_data.sql` in this database.
* Open solution `Linq2db.Postgis.Extensions.sln` in Visual Studio.
* Check database connection string in `App.config` of `Linq2db.Postgis.Extensions.DemoApp` project.
* Run application, view table data along with PostGIS functions results in console output.
* Add wrappers for more PostGIS functions in `Linq2db.Postgis.Extensions` classes as needed.

### Known issues and limitations
* This project will be stalled soon, further development (targeting Npgsql 4.0) will be based on using [Npgsql.NetTopologySuite](https://www.npgsql.org/doc/types/nts.html), which is recommended way now.
* Not all of the PostGIS functions wrappers are currently implemented.
* Using of spatial index is not checked.
* Some functions need to be implemented in DataConnection context, not inside the LINQ expressions.

### References
* [PostGIS Reference](http://postgis.refractions.net/documentation/manual-1.5/reference.html)
* [How to teach LINQ to DB convert custom .NET methods and objects to SQL - Sql.Function attribute](http://blog.linq2db.com/2016/06/how-to-teach-linq-to-db-convert-custom.html)