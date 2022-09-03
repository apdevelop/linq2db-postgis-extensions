using System;

using LinqToDB;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Mathematical Functions.
    /// </summary>
    /// <remarks>
    /// 9.3. Mathematical Functions and Operators
    /// https://www.postgresql.org/docs/9.1/functions-math.html
    /// </remarks>
    public static class MathematicalFunctions
    {
#pragma warning disable IDE0060
        /// <summary>
        /// Convert radians to degrees.
        /// </summary>
        /// <param name="radians">Radians.</param>
        /// <returns>Degrees.</returns>
        [Sql.Function("degrees", ServerSideOnly = true)]
        public static double? Degrees(double? radians) => throw new InvalidOperationException();

        /// <summary>
        /// Convert degrees to radians.
        /// </summary>
        /// <param name="degrees">Degrees.</param>
        /// <returns>Radians.</returns>
        [Sql.Function("radians", ServerSideOnly = true)]
        public static double? Radians(double? degrees) => throw new InvalidOperationException();
#pragma warning restore IDE0060
    }
}
