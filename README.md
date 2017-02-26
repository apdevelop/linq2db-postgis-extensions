# Linq2db Postgis Extensions
Demo application with minimal set of utility methods (in separate assembly), providing access to Postgis functions while working with spatial (geometry) data type using [linq2db](https://github.com/linq2db/linq2db)

### Technologies
Developed using MS Visual Studio 2013, C# .NET 4.5.
Based on current versions of PostgreSQL (9.6), Postgis (2.3.1), linq2db (1.0.7.4), linq2db.PostgreSQL (1.0.7.3).

### Getting started
* Make sure you have PostgreSQL RDBMS with Postgis extension installed.
* Create new database named "postgistest" (or any other name), add support of spatial features for this database.
* Execute SQL scripts `Sql\create_tables.sql` and `Sql\insert_data.sql` in this database.
* Open solution `Linq2db.Postgis.Extensions.sln` in Visual Studio.
* Check database connection string in `App.config` of `Linq2db.Postgis.Extensions.DemoApp` project.
* Run application, view table data along with Postgis functions results in console output.
* Add wrappers for more Postgis functions in `Linq2db.Postgis.Extensions` classes as needed.