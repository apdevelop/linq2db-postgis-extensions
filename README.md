# Linq2db PostGIS Extensions
C# .NET Standard 2.0 library with OGC extensions methods on geometry (`NpgsqlTypes.PostgisGeometry`) instances, providing access to [PostGIS](http://postgis.net/) functions while using [linq2db](https://github.com/linq2db/linq2db) LINQ to database provider.

### Sample usage
`NpgsqlTypes.PostgisGeometry` gets additional methods, similar to `Microsoft.SqlServer.Types.SqlGeometry` [OGC Methods on Geometry Instances](https://docs.microsoft.com/sql/t-sql/spatial-geometry/ogc-methods-on-geometry-instances?view=sql-server-2016).
Using extensions methods inside LINQ expression:

```c#
using LinqToDBPostGisNpgsqlTypes;

using (var db = new PostGisTestDataConnection())
{
    NpgsqlTypes.PostgisGeometry point = db.STGeomFromEWKT("SRID=3857;POINT(0 5)");
    List<NpgsqlTypes.PostgisGeometry> selected = db.Polygons
        .Where(p => p.Geometry.STArea() > 150.0)
        .OrderBy(p => p.Geometry.STDistance(point))
        .ToList();

	NpgsqlTypes.PostgisGeometry nearestCity = db.Cities
		.OrderBy(c => c.Geometry.STDistance(point))
		.FirstOrDefault();
}
```

```c#
[Table(Schema = "public", Name = "test_polygons")]
public class PolygonEntity
{
    [Column("geom"), NotNull]
    public NpgsqlTypes.PostgisGeometry Geometry { get; set; }
}

[Table(Schema = "public", Name = "owm_cities")]
public class CityEntity
{
    [Column("geom"), NotNull]
    public NpgsqlTypes.PostgisGeometry Geometry { get; set; }
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

### Known issues and limitations
* This project will be stalled soon, further development (targeting Npgsql 4.0) will be based on using [Npgsql.NetTopologySuite](https://www.npgsql.org/doc/types/nts.html), which is recommended way now.
* Not all of the PostGIS functions wrappers are currently implemented.
* Using of spatial index is not checked.
* Some functions need to be implemented in DataConnection context, not inside the LINQ expressions.

### References
* [PostGIS Reference](http://postgis.refractions.net/documentation/manual-1.5/reference.html)
* [How to teach LINQ to DB convert custom .NET methods and objects to SQL - Sql.Function attribute](http://blog.linq2db.com/2016/06/how-to-teach-linq-to-db-convert-custom.html)