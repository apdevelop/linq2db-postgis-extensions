using System;

using LinqToDB;

namespace Linq2db.Postgis.Extensions
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Management_Functions

    public static class ManagementFunctions
    {
        /// <summary>
        /// Return full PostGIS version and build configuration infos.
        /// http://postgis.refractions.net/documentation/manual-1.5/PostGIS_Full_Version.html
        /// </summary>
        /// <returns>Full PostGIS version and build configuration infos.</returns>
        [Sql.Function("PostGIS_Full_Version", ServerSideOnly = true)]
        public static string PostGisFullVersion
        {
            get
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Return PostGIS version number and compile-time options.
        /// http://postgis.refractions.net/documentation/manual-1.5/PostGIS_Version.html
        /// </summary>
        /// <returns>PostGIS version number and compile-time options.</returns>
        [Sql.Function("PostGIS_Version", ServerSideOnly = true)]
        public static string PostGisVersion
        {
            get
            {
                throw new InvalidOperationException();
            }
        }
    }
}
