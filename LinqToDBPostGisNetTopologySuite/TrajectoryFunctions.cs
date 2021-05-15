using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Trajectory Functions.
    /// </summary>
    /// <remarks>
    /// 5.19. Trajectory Functions
    /// https://postgis.net/docs/reference.html#Temporal
    /// </remarks>
    public static class TrajectoryFunctions
    {
        /// <summary>
        /// Tests if input <paramref name="geometry"/> represents valid trajectory - LineString with measures (M values), which increase from each vertex to the next.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValidTrajectory.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>True if input <paramref name="geometry"/> is a valid trajectory.</returns>
        [Sql.Function("ST_IsValidTrajectory", ServerSideOnly = true)]
        public static bool? STIsValidTrajectory(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Tests if input <paramref name="geometry"/> represents valid trajectory - LineString with measures (M values), which increase from each vertex to the next.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValidTrajectory.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>True if input <paramref name="geometry"/> is a valid trajectory.</returns>
        [Sql.Function("ST_IsValidTrajectory", ServerSideOnly = true)]
        public static bool? STIsValidTrajectory(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the smallest measure at which points interpolated along the given trajectories are at the smallest distance.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ClosestPointOfApproach.html
        /// </remarks>
        /// <param name="track1">Input geometry for trajectory 1.</param>
        /// <param name="track2">Input geometry for trajectory 2.</param>
        /// <returns>Smallest measure at the smallest distance.</returns>
        [Sql.Function("ST_ClosestPointOfApproach", ServerSideOnly = true)]
        public static double? STClosestPointOfApproach(this NTSG track1, NTSG track2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the smallest measure at which points interpolated along the given trajectories are at the smallest distance.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ClosestPointOfApproach.html
        /// </remarks>
        /// <param name="track1">Input geometry for trajectory 1.</param>
        /// <param name="track2">Input geometry for trajectory 2.</param>
        /// <returns>Smallest measure at the smallest distance.</returns>
        [Sql.Function("ST_ClosestPointOfApproach", ServerSideOnly = true)]
        public static double? STClosestPointOfApproach(string track1, string track2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the minimum distance two input geometries have ever been each other.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_DistanceCPA.html
        /// </remarks>
        /// <param name="track1">Input geometry for trajectory 1.</param>
        /// <param name="track2">Input geometry for trajectory 2.</param>
        /// <returns>Minimum distance.</returns>
        [Sql.Function("ST_DistanceCPA", ServerSideOnly = true)]
        public static double? STDistanceCPA(this NTSG track1, NTSG track2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the minimum distance two input geometries have ever been each other.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_DistanceCPA.html
        /// </remarks>
        /// <param name="track1">Input geometry for trajectory 1.</param>
        /// <param name="track2">Input geometry for trajectory 2.</param>
        /// <returns>Minimum distance.</returns>
        [Sql.Function("ST_DistanceCPA", ServerSideOnly = true)]
        public static double? STDistanceCPA(string track1, string track2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Checks whether two input geometries have ever been within given maximum distance.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_CPAWithin.html
        /// </remarks>
        /// <param name="track1">Input geometry for trajectory 1.</param>
        /// <param name="track2">Input geometry for trajectory 2.</param>
        /// <param name="maxDistance">Maximum distance.</param>
        /// <returns>True, if two input geometries have ever been within given maximum distance.</returns>
        [Sql.Function("ST_CPAWithin", ServerSideOnly = true)]
        public static bool? STCPAWithin(this NTSG track1, NTSG track2, double maxDistance)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Checks whether two input geometries have ever been within given maximum distance.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_CPAWithin.html
        /// </remarks>
        /// <param name="track1">Input geometry for trajectory 1.</param>
        /// <param name="track2">Input geometry for trajectory 2.</param>
        /// <param name="maxDistance">Maximum distance.</param>
        /// <returns>True, if two input geometries have ever been within given maximum distance.</returns>
        [Sql.Function("ST_CPAWithin", ServerSideOnly = true)]
        public static bool? STCPAWithin(string track1, string track2, double maxDistance)
        {
            throw new InvalidOperationException();
        }
    }
}
