using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Editors
    /// </summary>
    /// <remarks>
    /// 8.5. Geometry Editors https://postgis.net/docs/manual-3.0/reference.html#Geometry_Editors
    /// </remarks>
    public static class GeometryEditors
    {
        /// <summary>
        /// Forces the geometries into a "2-dimensional mode" so that all output representations will only have the X and Y coordinates
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Force2D.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry in XY mode</returns>
        [Sql.Function("ST_Force2D", ServerSideOnly = true)]
        public static NTSG STForce2D(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces the geometries into XYZ mode. This is an alias for ST_Force_3DZ. If a geometry has no Z component, then a 0 Z coordinate is tacked on
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Force_3D.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry in XYZ mode</returns>
        [Sql.Function("ST_Force3D", ServerSideOnly = true)]
        public static NTSG STForce3D(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces the geometries into XYZ mode. This is a synonym for ST_Force3DZ. If a geometry has no Z component, then a 0 Z coordinate is tacked on
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Force_3DZ.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry in XYZ mode</returns>
        [Sql.Function("ST_Force3DZ", ServerSideOnly = true)]
        public static NTSG STForce3DZ(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces the geometries into XYM mode. If a geometry has no M component, then a 0 M coordinate is tacked on. If it has a Z component, then Z is removed
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Force_3DM.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry in XYM mode</returns>
        [Sql.Function("ST_Force3DM", ServerSideOnly = true)]
        public static NTSG STForce3DM(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces the geometries into XYZM mode. 0 is tacked on for missing Z and M dimensions.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Force_4D.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry in XYZM mode</returns>
        [Sql.Function("ST_Force4D", ServerSideOnly = true)]
        public static NTSG STForce4D(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry in its normalized/canonical form.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Normalize.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Normalized geometry</returns>
        [Sql.Function("ST_Normalize", ServerSideOnly = true)]
        public static NTSG STNormalize(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry with reversed order of the vertexes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Reverse.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry with reversed order of the vertexes</returns>
        [Sql.Function("ST_Reverse", ServerSideOnly = true)]
        public static NTSG STReverse(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }
    }
}