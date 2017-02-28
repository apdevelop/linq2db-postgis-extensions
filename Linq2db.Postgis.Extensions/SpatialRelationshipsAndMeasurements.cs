using System;

using LinqToDB;
using NpgsqlTypes;

namespace Linq2db.Postgis.Extensions
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Spatial_Relationships_Measurements

    public static class SpatialRelationshipsAndMeasurements
    {
        /// <summary>
        /// Return the area of the surface if it is a polygon or multi-polygon. For "geometry" type area is in SRID units.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Area.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Area</returns>
        [Sql.Function("ST_Area", ServerSideOnly = true)]
        public static double StArea(this PostgisGeometry geom)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return the geometric center of a geometry.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Centroid.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Geometric center</returns>
        [Sql.Function("ST_Centroid", ServerSideOnly = true)]
        public static PostgisGeometry StCentroid(this PostgisGeometry geom)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return true if and only if no points of B lie in the exterior of A, and at least one point of the interior of B lies in the interior of A.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Contains.html
        /// </summary>
        /// <param name="geomA">Input geometry A</param>
        /// <param name="geomB">Input geometry B</param>
        /// <returns>Returns true if geometry B is completely inside geometry A.</returns>
        [Sql.Function("ST_Contains", ServerSideOnly = true)]
        public static bool StContains(this PostgisGeometry geomA, PostgisGeometry geomB)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns TRUE if the Geometries do not spatially intersect.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Disjoint.html
        /// </summary>
        /// <param name="geomA">Input geometry A</param>
        /// <param name="geomB">Input geometry B</param>
        /// <returns>True if the geometries do not spatially intersect</returns>
        [Sql.Function("ST_Disjoint", ServerSideOnly = true)]
        public static bool StDisjoint(this PostgisGeometry geomA, PostgisGeometry geomB)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return the 2-dimensional cartesian minimum distance (based on spatial ref) between two geometries in projected units.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Distance.html
        /// </summary>
        /// <param name="geom1">Input geometry 1</param>
        /// <param name="geom2">Input geometry 2</param>
        /// <returns>Distance between two geometries</returns>
        [Sql.Function("ST_Distance", ServerSideOnly = true)]
        public static double StDistance(this PostgisGeometry geom1, PostgisGeometry geom2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if the geometries are within the specified distance of one another.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_DWithin.html
        /// </summary>
        /// <param name="geom1">Input geometry 1</param>
        /// <param name="geom2">Input geometry 2</param>
        /// <param name="distance">Distance in SRID units</param>
        /// <returns></returns>
        [Sql.Function("ST_DWithin", ServerSideOnly = true)]
        public static bool ST_DWithin(this PostgisGeometry geom1, PostgisGeometry geom2, double distance)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return true if the given geometries represent the same geometry. Directionality is ignored.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Equals.html
        /// </summary>
        /// <param name="geomA">Input geometry A</param>
        /// <param name="geomB">Input geometry B</param>
        /// <returns>True if the given geometries represent the same geometry.</returns>
        [Sql.Function("ST_Equals", ServerSideOnly = true)]
        public static bool StEquals(this PostgisGeometry geomA, PostgisGeometry geomB)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns TRUE if the Geometries "spatially intersect" - (share any portion of space) and false if they don't (they are Disjoint).
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Intersects.html
        /// </summary>
        /// <param name="geomA">Input geometry A</param>
        /// <param name="geomB">Input geometry B</param>
        /// <returns></returns>
        [Sql.Function("ST_Intersects", ServerSideOnly = true)]
        public static bool StIntersects(this PostgisGeometry geomA, PostgisGeometry geomB)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2d length of the geometry if it is a linestring or multilinestring. 
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Length.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Cartesian 2D length of the geometry if it is a linestring, multilinestring, ST_Curve, ST_MultiCurve</returns>
        [Sql.Function("ST_Length", ServerSideOnly = true)]
        public static double StLength(this PostgisGeometry geom)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if the Geometries share space, are of the same dimension, but are not completely contained by each other.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Overlaps.html
        /// </summary>
        /// <param name="geomA">Input geometry A</param>
        /// <param name="geomB">Input geometry B</param>
        /// <returns></returns>
        [Sql.Function("ST_Overlaps", ServerSideOnly = true)]
        public static bool StOverlaps(this PostgisGeometry geomA, PostgisGeometry geomB)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return the length measurement of the boundary of an ST_Surface or ST_MultiSurface value. (Polygon, Multipolygon)
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Perimeter.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Perimeter</returns>
        [Sql.Function("ST_Perimeter", ServerSideOnly = true)]
        public static double StPerimeter(this PostgisGeometry geom)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return the 2-dimensional shortest line between two geometries
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_ShortestLine.html
        /// </summary>
        /// <param name="geom1">Input geometry 1</param>
        /// <param name="geom2">Input geometry 2</param>
        /// <returns>2-dimensional shortest line between two geometries.</returns>
        [Sql.Function("ST_ShortestLine", ServerSideOnly = true)]
        public static PostgisGeometry StShortestLine(this PostgisGeometry geom1, PostgisGeometry geom2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return true if the geometries have at least one point in common, but their interiors do not intersect.
        /// </summary>
        /// <param name="geom1">Input geometry 1</param>
        /// <param name="geom2">Input geometry 2</param>
        /// <returns></returns>
        [Sql.Function("ST_Touches", ServerSideOnly = true)]
        public static bool StTouches(this PostgisGeometry geom1, PostgisGeometry geom2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return true if the geometry A is completely inside geometry B
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Within.html
        /// </summary>
        /// <param name="geomA">Input geometry A</param>
        /// <param name="geomB">Input geometry B</param>
        /// <returns></returns>
        [Sql.Function("ST_Within", ServerSideOnly = true)]
        public static bool StWithin(this PostgisGeometry geomA, PostgisGeometry geomB)
        {
            throw new InvalidOperationException();
        }
    }
}
