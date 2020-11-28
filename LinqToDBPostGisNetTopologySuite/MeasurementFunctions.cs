using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Measurement Functions
    /// </summary>
    /// <remarks>
    /// 8.12. Measurement Functions https://postgis.net/docs/manual-3.0/reference.html#Measurement_Functions
    /// </remarks>
    public static class MeasurementFunctions
    {
        /// <summary>
        /// Returns area of input polygonal geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Area.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Area (in SRID units)</returns>
        [Sql.Function("ST_Area", ServerSideOnly = true)]
        public static double? STArea(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Area(geography)

        /// <summary>
        /// Returns azimuth (in radians) of segment defined by given POINT input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Azimuth.html
        /// </remarks>
        /// <param name="point1">Input point 1</param>
        /// <param name="point2">Input point 2</param>
        /// <returns>Azimuth (in radians)</returns>
        [Sql.Function("ST_Azimuth", ServerSideOnly = true)]
        public static double? STAzimuth(this NTSG point1, NTSG point2)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Azimuth(geography)

        /// <summary>
        /// Returns angle (in radians) measured clockwise of input points P1P2P3.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Angle.html
        /// </remarks>
        /// <param name="point1">Input point 1</param>
        /// <param name="point2">Input point 2</param>
        /// <param name="point3">Input point 3</param>
        /// <returns>Angle (in radians)</returns>
        [Sql.Function("ST_Angle", ServerSideOnly = true)]
        public static double? STAngle(this NTSG point1, NTSG point2, NTSG point3)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns angle (in radians) measured clockwise of input points P1P2,P3P4.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Angle.html
        /// </remarks>
        /// <param name="point1">Input point 1</param>
        /// <param name="point2">Input point 2</param>
        /// <param name="point3">Input point 3</param>
        /// <param name="point4">Input point 4</param>  
        /// <returns>Angle (in radians)</returns>
        [Sql.Function("ST_Angle", ServerSideOnly = true)]
        public static double? STAngle(this NTSG point1, NTSG point2, NTSG point3, NTSG point4)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns angle (in radians) measured clockwise of input lines.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Angle.html
        /// </remarks>
        /// <param name="line1">Input line 1</param>
        /// <param name="line2">Input line 2</param>
        /// <returns>Angle (in radians)</returns>
        [Sql.Function("ST_Angle", ServerSideOnly = true)]
        public static double? STAngle(this NTSG line1, NTSG line2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns 2D Point on input geometry 1 that is closest to geometry 2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_ClosestPoint.html
        /// </remarks>
        /// <param name="geometry1">Input geometry 1</param>
        /// <param name="geometry2">Input geometry 2</param>
        /// <returns>Geometry (POINT)</returns>
        [Sql.Function("ST_ClosestPoint", ServerSideOnly = true)]
        public static NTSG STClosestPoint(this NTSG geometry1, NTSG geometry2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns 3D Point on input geometry 1 that is closest to geometry 2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_3DClosestPoint.html
        /// </remarks>
        /// <param name="geometry1">Input geometry 1</param>
        /// <param name="geometry2">Input geometry 2</param>
        /// <returns>Geometry (POINT)</returns>
        [Sql.Function("ST_3DClosestPoint", ServerSideOnly = true)]
        public static NTSG ST3DClosestPoint(this NTSG geometry1, NTSG geometry2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns minimum 2D Cartesian (planar) distance between two input geometries, in projected units (spatial ref units).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Distance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Distance, in projected units</returns>
        [Sql.Function("ST_Distance", ServerSideOnly = true)]
        public static double? STDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Distance(geography, geography)

        /// <summary>
        /// Returns minimum 3D Cartesian distance between two input geometries, in projected units (spatial ref units).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_3DDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Distance between two geometries</returns>
        [Sql.Function("ST_3DDistance", ServerSideOnly = true)]
        public static double? ST3DDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns minimum distance (in meters) between input geometries (lon/lat).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_DistanceSphere.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Distance (in meters)</returns>
        [Sql.Function("ST_DistanceSphere", ServerSideOnly = true)]
        public static double? STDistanceSphere(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns minimum distance (in meters) between two input geometries (lon/lat) on particular spheroid.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Distance_Spheroid.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <param name="spheroid">Measurement spheroid</param>
        /// <returns>Distance (in meters)</returns>
        [Sql.Function("ST_DistanceSpheroid", ServerSideOnly = true)]
        public static double? STDistanceSpheroid(this NTSG geometry, NTSG other, string spheroid) // TODO: ? spheroid type cast
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Fréchet distance restricted to discrete points for input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_FrechetDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Fréchet distance</returns>
        [Sql.Function("ST_FrechetDistance", ServerSideOnly = true)]
        public static double? STFrechetDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Fréchet distance restricted to discrete points for input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_FrechetDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <param name="densifyFrac">Fraction by which to densify each segment</param>
        /// <returns>Fréchet distance</returns>
        [Sql.Function("ST_FrechetDistance", ServerSideOnly = true)]
        public static double? STFrechetDistance(this NTSG geometry, NTSG other, double densifyFrac)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Hausdorff distance between input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_HausdorffDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Hausdorff distance</returns>
        [Sql.Function("ST_HausdorffDistance", ServerSideOnly = true)]
        public static double? STHausdorffDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Hausdorff distance between input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_HausdorffDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <param name="densifyFrac">Fraction by which to densify each segment</param>
        /// <returns>Hausdorff distance</returns>
        [Sql.Function("ST_HausdorffDistance", ServerSideOnly = true)]
        public static double? STHausdorffDistance(this NTSG geometry, NTSG other, double densifyFrac)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns 2D Cartesian length of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Length.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Length, in SRS units</returns>
        [Sql.Function("ST_Length", ServerSideOnly = true)]
        public static double? STLength(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Length(geography)

        /// <summary>
        /// Returns 2D Cartesian length of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Length2D.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Length, in SRS units</returns>
        [Sql.Function("ST_Length2D", ServerSideOnly = true)]
        public static double? STLength2D(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns 3D or 2D length of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_3DLength.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Length, in SRS units</returns>
        [Sql.Function("ST_3DLength", ServerSideOnly = true)]
        public static double? ST3DLength(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns length or perimeter of input geometry on given spheroid.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Length_Spheroid.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="spheroid">Measurement spheroid</param>
        /// <returns>Length</returns>
        [Sql.Function("ST_LengthSpheroid", ServerSideOnly = true)]
        public static double? STLengthSpheroid(this NTSG geometry, string spheroid) // TODO: ? spheroid type cast
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns 2D longest line between points of input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LongestLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Geometry (LINESTRING)</returns>
        [Sql.Function("ST_LongestLine", ServerSideOnly = true)]
        public static NTSG STLongestLine(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns 3D longest line between points of input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_3DLongestLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_3DLongestLine", ServerSideOnly = true)]
        public static NTSG ST3DLongestLine(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns 2D maximum distance between input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MaxDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Distance, in SRS units</returns>
        [Sql.Function("ST_MaxDistance", ServerSideOnly = true)]
        public static double? STMaxDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns 3D maximum distance between input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MaxDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Distance, in SRS units</returns>
        [Sql.Function("ST_3DMaxDistance", ServerSideOnly = true)]
        public static double? ST3DMaxDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns minimum clearance of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MinimumClearance.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Minimum clearance</returns>
        [Sql.Function("ST_MinimumClearance", ServerSideOnly = true)]
        public static double? STMinimumClearance(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns line spanning minimum clearance of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MinimumClearanceLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry (LINESTRING)</returns>
        [Sql.Function("ST_MinimumClearanceLine", ServerSideOnly = true)]
        public static NTSG STMinimumClearanceLine(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns 2D perimeter of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Perimeter.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Perimeter, in SRS units</returns>
        [Sql.Function("ST_Perimeter", ServerSideOnly = true)]
        public static double? STPerimeter(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Perimeter(geography)

        /// <summary>
        /// Returns 2D perimeter of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Perimeter2D.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Perimeter</returns>
        [Sql.Function("ST_Perimeter2D", ServerSideOnly = true)]
        public static double? STPerimeter2D(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns 3D perimeter of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_3DPerimeter.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Perimeter</returns>
        [Sql.Function("ST_3DPerimeter", ServerSideOnly = true)]
        public static double? ST3DPerimeter(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Project(geography)

        /// <summary>
        /// Returns 2D shortest line between input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_ShortestLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Geometry (LINESTRING)</returns>
        [Sql.Function("ST_ShortestLine", ServerSideOnly = true)]
        public static NTSG STShortestLine(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns 3D shortest line between input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_ShortestLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_3DShortestLine", ServerSideOnly = true)]
        public static NTSG ST3DShortestLine(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }
    }
}