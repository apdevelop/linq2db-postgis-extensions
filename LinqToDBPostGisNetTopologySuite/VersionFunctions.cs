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
        public static string PostGISFullVersion() => throw new InvalidOperationException();

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
        public static string PostGISGEOSVersion() => throw new InvalidOperationException();

        /// <summary>
        /// Returns the version number of the liblwgeom library.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/PostGIS_Liblwgeom_Version.html
        /// </remarks>
        /// <returns>
        /// Version number of the liblwgeom library.
        /// </returns>
        [Sql.Function("PostGIS_Liblwgeom_Version", ServerSideOnly = true)]
        public static string PostGISLiblwgeomVersion() => throw new InvalidOperationException();

        /// <summary>
        /// Returns the version number of the libxml library.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/PostGIS_LibXML_Version.html
        /// </remarks>
        /// <returns>
        /// Version number of the libxml library.
        /// </returns>
        [Sql.Function("PostGIS_LibXML_Version", ServerSideOnly = true)]
        public static string PostGISLibXMLVersion() => throw new InvalidOperationException();

        /// <summary>
        /// Returns the build date of the PostGIS library.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/PostGIS_Lib_Build_Date.html
        /// </remarks>
        /// <returns>
        /// Build date of the PostGIS library.
        /// </returns>
        [Sql.Function("PostGIS_Lib_Build_Date", ServerSideOnly = true)]
        public static string PostGISLibBuildDate() => throw new InvalidOperationException();

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
        public static string PostGISLibVersion() => throw new InvalidOperationException();

        /// <summary>
        /// Returns the version number of the PROJ4 library, or null if PROJ4 support is not enabled.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/PostGIS_PROJ_Version.html
        /// </remarks>
        /// <returns>
        /// Version number of the PROJ4 library.
        /// </returns>
        [Sql.Function("PostGIS_PROJ_Version", ServerSideOnly = true)]
        public static string PostGISPROJVersion() => throw new InvalidOperationException();

        /// <summary>
        /// Returns the version number of the internal Wagyu library, or null if Wagyu support is not enabled.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/PostGIS_Wagyu_Version.html
        /// </remarks>
        /// <returns>
        /// Version number of the Wagyu library.
        /// </returns>
        [Sql.Function("PostGIS_Wagyu_Version", ServerSideOnly = true)]
        public static string PostGISWagyuVersion() => throw new InvalidOperationException();

        /// <summary>
        /// Returns the build date of the PostGIS scripts.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/PostGIS_Scripts_Build_Date.html
        /// </remarks>
        /// <returns>
        /// Build date of the PostGIS scripts.
        /// </returns>
        [Sql.Function("PostGIS_Scripts_Build_Date", ServerSideOnly = true)]
        public static string PostGISScriptsBuildDate() => throw new InvalidOperationException();

        /// <summary>
        /// Returns version of the PostGIS scripts installed in this database.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/PostGIS_Scripts_Installed.html
        /// </remarks>
        /// <returns>
        /// Version of the PostGIS scripts.
        /// </returns>
        [Sql.Function("PostGIS_Scripts_Installed", ServerSideOnly = true)]
        public static string PostGISScriptsInstalled() => throw new InvalidOperationException();

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
        public static string PostGISVersion() => throw new InvalidOperationException();
    }
}
