using LinqToDB;
using System;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Version Functions.
    /// </summary>
    /// <remarks>
    /// 5.22. Version Functions
    /// https://postgis.net/docs/reference.html#Version_Functions
    /// </remarks>
    public static class VersionFunctions
    {
        /// <summary>
        /// Returns full PostGIS version and build configuration information.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/PostGIS_Full_Version.html
        /// </remarks>
        /// <returns>
        /// Full PostGIS version and build configuration information.
        /// </returns>
        [Sql.Function("PostGIS_Full_Version", ServerSideOnly = true)]
        public static string PostGISFullVersion()
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the version number of the GEOS library, or null if GEOS support is not enabled.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/PostGIS_GEOS_Version.html
        /// </remarks>
        /// <returns>
        /// Version number of the GEOS library.
        /// </returns>
        [Sql.Function("PostGIS_GEOS_Version", ServerSideOnly = true)]
        public static string PostGISGEOSVersion()
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the version number of the PostGIS library.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/PostGIS_Lib_Version.html
        /// </remarks>
        /// <returns>
        /// Version number of the PostGIS library.
        /// </returns>
        [Sql.Function("PostGIS_Lib_Version", ServerSideOnly = true)]
        public static string PostGISLibVersion()
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns PostGIS version number and compile-time options.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/PostGIS_Version.html
        /// </remarks>
        /// <returns>
        /// PostGIS version number and compile-time options.
        /// </returns>
        [Sql.Function("PostGIS_Version", ServerSideOnly = true)]
        public static string PostGISVersion()
        {
            throw new InvalidOperationException();
        }
    }
}
