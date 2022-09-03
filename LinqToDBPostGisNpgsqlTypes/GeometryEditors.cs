using System;

using LinqToDB;
using NpgsqlTypes;

namespace LinqToDBPostGisNpgsqlTypes
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Geometry_Editors
#pragma warning disable IDE0060
    public static class GeometryEditors
    {
        /// <summary>
        /// Return the geometry with vertex order reversed.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Reverse.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns></returns>
        [Sql.Function("ST_Reverse", ServerSideOnly = true)]
        public static PostgisGeometry STReverse(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Sets the SRID on a geometry to a particular integer value.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_SetSRID.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <param name="srid">Spatial Reference System Identifier</param>
        /// <returns></returns>
        [Sql.Function("ST_SetSRID", ServerSideOnly = true)]
        public static PostgisGeometry STSetSrid(this PostgisGeometry geom, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Return a new geometry with its coordinates transformed to the SRID referenced by the integer parameter.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Transform.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <param name="srid">Spatial Reference System Identifier</param>
        /// <returns>Transformed geometry</returns>
        [Sql.Function("ST_Transform", ServerSideOnly = true)]
        public static PostgisGeometry STTransform(this PostgisGeometry geom, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Translates the geometry to a new location using the numeric parameters as offsets.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Translate.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <param name="deltax"></param>
        /// <param name="deltay"></param>
        /// <returns>New geometry whose coordinates are translated deltax and deltay units.</returns>
        [Sql.Function("ST_Translate", ServerSideOnly = true)]
        public static PostgisGeometry STTranslate(this PostgisGeometry geom, double deltax, double deltay) => throw new InvalidOperationException();
    }
#pragma warning restore IDE0060
}
