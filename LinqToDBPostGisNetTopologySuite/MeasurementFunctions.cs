using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Measurement Functions.
    /// </summary>
    /// <remarks>
    /// 5.12. Measurement Functions 
    /// https://postgis.net/docs/reference.html#Measurement_Functions
    /// </remarks>
    public static class MeasurementFunctions
    {
        /// <summary>
        /// Returns the area of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Area.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Area (in SRS units).</returns>
        [Sql.Function("ST_Area", ServerSideOnly = true)]
        public static double? STArea(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the area of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Area.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Area (in SRS units).</returns>
        [Sql.Function("ST_Area", ServerSideOnly = true)]
        public static double? STArea(string geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Area(geography)

        /// <summary>
        /// Returns the azimuth of segment defined by input points P1P2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Azimuth.html
        /// </remarks>
        /// <param name="point1">Input point 1.</param>
        /// <param name="point2">Input point 2.</param>
        /// <returns>Azimuth (in radians).</returns>
        [Sql.Function("ST_Azimuth", ServerSideOnly = true)]
        public static double? STAzimuth(this NTSG point1, NTSG point2)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Azimuth(geography)

        /// <summary>
        /// Returns the angle measured clockwise of input points P1P2P3.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Angle.html
        /// </remarks>
        /// <param name="point1">Input point 1.</param>
        /// <param name="point2">Input point 2.</param>
        /// <param name="point3">Input point 3.</param>
        /// <returns>Angle (in radians).</returns>
        [Sql.Function("ST_Angle", ServerSideOnly = true)]
        public static double? STAngle(this NTSG point1, NTSG point2, NTSG point3)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the angle measured clockwise of input points P1P2,P3P4.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Angle.html
        /// </remarks>
        /// <param name="point1">Input point 1.</param>
        /// <param name="point2">Input point 2.</param>
        /// <param name="point3">Input point 3.</param>
        /// <param name="point4">Input point 4.</param>  
        /// <returns>Angle (in radians).</returns>
        [Sql.Function("ST_Angle", ServerSideOnly = true)]
        public static double? STAngle(this NTSG point1, NTSG point2, NTSG point3, NTSG point4)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the angle measured clockwise of input lines.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Angle.html
        /// </remarks>
        /// <param name="line1">Input line 1.</param>
        /// <param name="line2">Input line 2.</param>
        /// <returns>Angle (in radians).</returns>
        [Sql.Function("ST_Angle", ServerSideOnly = true)]
        public static double? STAngle(this NTSG line1, NTSG line2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns point on input <paramref name="geometry1"/> that is closest to <paramref name="geometry2"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ClosestPoint.html
        /// </remarks>
        /// <param name="geometry1">Input geometry 1.</param>
        /// <param name="geometry2">Input geometry 2.</param>
        /// <returns>Geometry (Point).</returns>
        [Sql.Function("ST_ClosestPoint", ServerSideOnly = true)]
        public static NTSG STClosestPoint(this NTSG geometry1, NTSG geometry2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D point on input <paramref name="geometry1"/> that is closest to <paramref name="geometry2"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ClosestPoint.html
        /// </remarks>
        /// <param name="geometry1">Input geometry 1 in text representation.</param>
        /// <param name="geometry2">Input geometry 2 in text representation.</param>
        /// <returns>Geometry (Point).</returns>
        [Sql.Function("ST_ClosestPoint", ServerSideOnly = true)]
        public static NTSG STClosestPoint(string geometry1, string geometry2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 3D point on input <paramref name="geometry1"/> that is closest to <paramref name="geometry2"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DClosestPoint.html
        /// </remarks>
        /// <param name="geometry1">Input geometry 1.</param>
        /// <param name="geometry2">Input geometry 2.</param>
        /// <returns>Geometry (3D Point).</returns>
        [Sql.Function("ST_3DClosestPoint", ServerSideOnly = true)]
        public static NTSG ST3DClosestPoint(this NTSG geometry1, NTSG geometry2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 3D point on input <paramref name="geometry1"/> that is closest to <paramref name="geometry2"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DClosestPoint.html
        /// </remarks>
        /// <param name="geometry1">Input geometry 1 in text representation.</param>
        /// <param name="geometry2">Input geometry 2 in text representation.</param>
        /// <returns>Geometry (3D Point).</returns>
        [Sql.Function("ST_3DClosestPoint", ServerSideOnly = true)]
        public static NTSG ST3DClosestPoint(string geometry1, string geometry2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the minimum 2D Cartesian (planar) distance between two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Distance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Distance (in SRS units).</returns>
        [Sql.Function("ST_Distance", ServerSideOnly = true)]
        public static double? STDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the minimum 2D Cartesian (planar) distance between two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Distance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 in text representation.</param>
        /// <param name="other">Input geometry 2 in text representation.</param>
        /// <returns>Distance (in SRS units).</returns>
        [Sql.Function("ST_Distance", ServerSideOnly = true)]
        public static double? STDistance(string geometry, string other)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Distance(geography, geography)

        /// <summary>
        /// Returns minimum 3D Cartesian distance between two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Distance (in SRS units).</returns>
        [Sql.Function("ST_3DDistance", ServerSideOnly = true)]
        public static double? ST3DDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns minimum 3D Cartesian distance between two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 in text representation.</param>
        /// <param name="other">Input geometry 2 in text representation.</param>
        /// <returns>Distance (in SRS units).</returns>
        [Sql.Function("ST_3DDistance", ServerSideOnly = true)]
        public static double? ST3DDistance(string geometry, string other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the minimum distance between two input geometries on sphere.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_DistanceSphere.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Distance (in meters).</returns>
        [Sql.Function("ST_DistanceSphere", ServerSideOnly = true)]
        public static double? STDistanceSphere(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the minimum distance between two input geometries on sphere.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_DistanceSphere.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 in text representation.</param>
        /// <param name="other">Input geometry 2 in text representation.</param>
        /// <returns>Distance (in meters).</returns>
        [Sql.Function("ST_DistanceSphere", ServerSideOnly = true)]
        public static double? STDistanceSphere(string geometry, string other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the minimum distance between two input geometries on particular spheroid.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Distance_Spheroid.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="spheroid">Measurement spheroid.</param>
        /// <returns>Distance (in meters).</returns>
        [Sql.Function("ST_DistanceSpheroid", ServerSideOnly = true)]
        public static double? STDistanceSpheroid(this NTSG geometry, NTSG other, string spheroid) // TODO: ? spheroid type cast
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the minimum distance between two input geometries on particular spheroid.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Distance_Spheroid.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 in text representation.</param>
        /// <param name="other">Input geometry 2 in text representation.</param>
        /// <param name="spheroid">Measurement spheroid.</param>
        /// <returns>Distance (in meters).</returns>
        [Sql.Function("ST_DistanceSpheroid", ServerSideOnly = true)]
        public static double? STDistanceSpheroid(string geometry, string other, string spheroid) // TODO: ? spheroid type cast
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Fréchet distance restricted to discrete points for input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_FrechetDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Fréchet distance (in SRS units).</returns>
        [Sql.Function("ST_FrechetDistance", ServerSideOnly = true)]
        public static double? STFrechetDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Fréchet distance restricted to discrete points for input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_FrechetDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="densifyFrac">Fraction by which to densify each segment.</param>
        /// <returns>Fréchet distance (in SRS units).</returns>
        [Sql.Function("ST_FrechetDistance", ServerSideOnly = true)]
        public static double? STFrechetDistance(this NTSG geometry, NTSG other, double densifyFrac)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Fréchet distance restricted to discrete points for input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_FrechetDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 in text representation.</param>
        /// <param name="other">Input geometry 2 in text representation.</param>
        /// <param name="densifyFrac">Fraction by which to densify each segment.</param>
        /// <returns>Fréchet distance (in SRS units).</returns>
        [Sql.Function("ST_FrechetDistance", ServerSideOnly = true)]
        public static double? STFrechetDistance(string geometry, string other, double densifyFrac)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Hausdorff distance between input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_HausdorffDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Hausdorff distance (in SRS units).</returns>
        [Sql.Function("ST_HausdorffDistance", ServerSideOnly = true)]
        public static double? STHausdorffDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Hausdorff distance between input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_HausdorffDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="densifyFrac">Fraction by which to densify each segment.</param>
        /// <returns>Hausdorff distance (in SRS units).</returns>
        [Sql.Function("ST_HausdorffDistance", ServerSideOnly = true)]
        public static double? STHausdorffDistance(this NTSG geometry, NTSG other, double densifyFrac)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Hausdorff distance between input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_HausdorffDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 in text representation.</param>
        /// <param name="other">Input geometry 2 in text representation.</param>
        /// <param name="densifyFrac">Fraction by which to densify each segment.</param>
        /// <returns>Hausdorff distance (in SRS units).</returns>
        [Sql.Function("ST_HausdorffDistance", ServerSideOnly = true)]
        public static double? STHausdorffDistance(string geometry, string other, double densifyFrac)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D Cartesian length of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Length.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Length (in SRS units).</returns>
        [Sql.Function("ST_Length", ServerSideOnly = true)]
        public static double? STLength(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D Cartesian length of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Length.html
        /// </remarks>
        /// <param name="geometry">Input geometry in text representation.</param>
        /// <returns>Length (in SRS units).</returns>
        [Sql.Function("ST_Length", ServerSideOnly = true)]
        public static double? STLength(string geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Length(geography)

        /// <summary>
        /// Returns the 2D Cartesian length of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Length2D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Length (in SRS units).</returns>
        [Sql.Function("ST_Length2D", ServerSideOnly = true)]
        public static double? STLength2D(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D Cartesian length of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Length2D.html
        /// </remarks>
        /// <param name="geometry">Input geometry in text representation.</param>
        /// <returns>Length (in SRS units).</returns>
        [Sql.Function("ST_Length2D", ServerSideOnly = true)]
        public static double? STLength2D(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 3D or 2D length of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DLength.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Length (in SRS units).</returns>
        [Sql.Function("ST_3DLength", ServerSideOnly = true)]
        public static double? ST3DLength(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 3D or 2D length of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DLength.html
        /// </remarks>
        /// <param name="geometry">Input geometry in text representation.</param>
        /// <returns>Length (in SRS units).</returns>
        [Sql.Function("ST_3DLength", ServerSideOnly = true)]
        public static double? ST3DLength(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the length or perimeter of input <paramref name="geometry"/> on given spheroid.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Length_Spheroid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="spheroid">Measurement spheroid.</param>
        /// <returns>Length.</returns>
        [Sql.Function("ST_LengthSpheroid", ServerSideOnly = true)]
        public static double? STLengthSpheroid(this NTSG geometry, string spheroid) // TODO: ? spheroid type cast
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the length or perimeter of input <paramref name="geometry"/> on given spheroid.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Length_Spheroid.html
        /// </remarks>
        /// <param name="geometry">Input geometry in text representation.</param>
        /// <param name="spheroid">Measurement spheroid.</param>
        /// <returns>Length.</returns>
        [Sql.Function("ST_LengthSpheroid", ServerSideOnly = true)]
        public static double? STLengthSpheroid(string geometry, string spheroid) // TODO: ? spheroid type cast
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D longest line between points of two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LongestLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Geometry (LineString).</returns>
        [Sql.Function("ST_LongestLine", ServerSideOnly = true)]
        public static NTSG STLongestLine(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D longest line between points of two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LongestLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 in text representation.</param>
        /// <param name="other">Input geometry 2 in text representation.</param>
        /// <returns>Geometry (LineString).</returns>
        [Sql.Function("ST_LongestLine", ServerSideOnly = true)]
        public static NTSG STLongestLine(string geometry, string other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 3D longest line between points of two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DLongestLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_3DLongestLine", ServerSideOnly = true)]
        public static NTSG ST3DLongestLine(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 3D longest line between points of two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DLongestLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 in text representation.</param>
        /// <param name="other">Input geometry 2 in text representation.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_3DLongestLine", ServerSideOnly = true)]
        public static NTSG ST3DLongestLine(string geometry, string other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D maximum distance between two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MaxDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Distance (in SRS units).</returns>
        [Sql.Function("ST_MaxDistance", ServerSideOnly = true)]
        public static double? STMaxDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D maximum distance between two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MaxDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 in text representation.</param>
        /// <param name="other">Input geometry 2 in text representation.</param>
        /// <returns>Distance (in SRS units).</returns>
        [Sql.Function("ST_MaxDistance", ServerSideOnly = true)]
        public static double? STMaxDistance(string geometry, string other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 3D maximum distance between two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DMaxDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Distance (in SRS units).</returns>
        [Sql.Function("ST_3DMaxDistance", ServerSideOnly = true)]
        public static double? ST3DMaxDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 3D maximum distance between two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DMaxDistance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 in text representation.</param>
        /// <param name="other">Input geometry 2 in text representation.</param>
        /// <returns>Distance (in SRS units).</returns>
        [Sql.Function("ST_3DMaxDistance", ServerSideOnly = true)]
        public static double? ST3DMaxDistance(string geometry, string other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the minimum clearance of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MinimumClearance.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Minimum clearance.</returns>
        [Sql.Function("ST_MinimumClearance", ServerSideOnly = true)]
        public static double? STMinimumClearance(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the minimum clearance of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MinimumClearance.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Minimum clearance.</returns>
        [Sql.Function("ST_MinimumClearance", ServerSideOnly = true)]
        public static double? STMinimumClearance(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the line spanning minimum clearance of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MinimumClearanceLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry (LineString).</returns>
        [Sql.Function("ST_MinimumClearanceLine", ServerSideOnly = true)]
        public static NTSG STMinimumClearanceLine(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the line spanning minimum clearance of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MinimumClearanceLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry (LineString).</returns>
        [Sql.Function("ST_MinimumClearanceLine", ServerSideOnly = true)]
        public static NTSG STMinimumClearanceLine(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D perimeter of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Perimeter.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Perimeter (in SRS units).</returns>
        [Sql.Function("ST_Perimeter", ServerSideOnly = true)]
        public static double? STPerimeter(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Perimeter(geography)

        /// <summary>
        /// Returns 2D perimeter of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Perimeter2D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Perimeter (in SRS units).</returns>
        [Sql.Function("ST_Perimeter2D", ServerSideOnly = true)]
        public static double? STPerimeter2D(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D perimeter of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Perimeter2D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Perimeter (in SRS units).</returns>
        [Sql.Function("ST_Perimeter2D", ServerSideOnly = true)]
        public static double? STPerimeter2D(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 3D perimeter of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DPerimeter.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Perimeter (in SRS units).</returns>
        [Sql.Function("ST_3DPerimeter", ServerSideOnly = true)]
        public static double? ST3DPerimeter(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 3D perimeter of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DPerimeter.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Perimeter (in SRS units).</returns>
        [Sql.Function("ST_3DPerimeter", ServerSideOnly = true)]
        public static double? ST3DPerimeter(string geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Project(geography)

        /// <summary>
        /// Returns the 2D shortest line between two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ShortestLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Geometry (LineString).</returns>
        [Sql.Function("ST_ShortestLine", ServerSideOnly = true)]
        public static NTSG STShortestLine(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D shortest line between two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ShortestLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 in text representation.</param>
        /// <param name="other">Input geometry 2 in text representation.</param>
        /// <returns>Geometry (LineString).</returns>
        [Sql.Function("ST_ShortestLine", ServerSideOnly = true)]
        public static NTSG STShortestLine(string geometry, string other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 3D shortest line between two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DShortestLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_3DShortestLine", ServerSideOnly = true)]
        public static NTSG ST3DShortestLine(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 3D shortest line between two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DShortestLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 in text representation.</param>
        /// <param name="other">Input geometry 2 in text representation.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_3DShortestLine", ServerSideOnly = true)]
        public static NTSG ST3DShortestLine(string geometry, string other)
        {
            throw new InvalidOperationException();
        }
    }
}
