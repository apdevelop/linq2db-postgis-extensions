using LinqToDB.Data;

namespace Linq2db.Postgis.Extensions
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Management_Functions

    public static class ManagementFunctions
    {
        private const string SqlSelectStatement = "SELECT";

        private const string PostGISFullVersion = "PostGIS_Full_Version";

        private const string PostGISVersion = "PostGIS_Version";

        /// <summary>
        /// Return full PostGIS version and build configuration infos.
        /// http://postgis.refractions.net/documentation/manual-1.5/PostGIS_Full_Version.html
        /// </summary>
        /// <returns>Full PostGIS version and build configuration infos.</returns>
        public static string GetPostGisFullVersion(this DataConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"{SqlSelectStatement} {PostGISFullVersion}()";
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    var version = reader.GetString(0);
                    return version;
                }
            }
        }

        /// <summary>
        /// Return PostGIS version number and compile-time options.
        /// http://postgis.refractions.net/documentation/manual-1.5/PostGIS_Version.html
        /// </summary>
        /// <returns>PostGIS version number and compile-time options.</returns>
        public static string GetPostGisVersion(this DataConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"{SqlSelectStatement} {PostGISVersion}()";
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    var version = reader.GetString(0);
                    return version;
                }
            }
        }
    }
}