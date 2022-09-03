using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Affine Transformations.
    /// </summary>
    /// <remarks>
    /// 5.15. Affine Transformations 
    /// https://postgis.net/docs/reference.html#Affine_Transformation
    /// </remarks>
    public static class AffineTransformations
    {
#pragma warning disable IDE0060
        /// <summary>
        /// Applies the 3D affine transformation to input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Affine.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="a">A of transformation matrix.</param>
        /// <param name="b">B of transformation matrix.</param>
        /// <param name="c">C of transformation matrix.</param>
        /// <param name="d">D of transformation matrix.</param>
        /// <param name="e">E of transformation matrix.</param>
        /// <param name="f">F of transformation matrix.</param>
        /// <param name="g">G of transformation matrix.</param>
        /// <param name="h">H of transformation matrix.</param>
        /// <param name="i">I of transformation matrix.</param>
        /// <param name="xoff">XOff of transformation matrix.</param>
        /// <param name="yoff">YOff of transformation matrix.</param>
        /// <param name="zoff">ZOff of transformation matrix.</param>
        /// <returns>Transformed geometry.</returns>
        [Sql.Function("ST_Affine", ServerSideOnly = true)]
        public static NTSG STAffine(this NTSG geometry, double a, double b, double c, double d, double e, double f, double g, double h, double i, double xoff, double yoff, double zoff) => throw new InvalidOperationException();

        /// <summary>
        /// Applies the 3D affine transformation to input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Affine.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="a">A of transformation matrix.</param>
        /// <param name="b">B of transformation matrix.</param>
        /// <param name="c">C of transformation matrix.</param>
        /// <param name="d">D of transformation matrix.</param>
        /// <param name="e">E of transformation matrix.</param>
        /// <param name="f">F of transformation matrix.</param>
        /// <param name="g">G of transformation matrix.</param>
        /// <param name="h">H of transformation matrix.</param>
        /// <param name="i">I of transformation matrix.</param>
        /// <param name="xoff">XOff of transformation matrix.</param>
        /// <param name="yoff">YOff of transformation matrix.</param>
        /// <param name="zoff">ZOff of transformation matrix.</param>
        /// <returns>Transformed geometry.</returns>
        [Sql.Function("ST_Affine", ServerSideOnly = true)]
        public static NTSG STAffine(string geometry, double a, double b, double c, double d, double e, double f, double g, double h, double i, double xoff, double yoff, double zoff) => throw new InvalidOperationException();

        /// <summary>
        /// Applies the 2D affine transformation to input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Affine.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="a">A of transformation matrix.</param>
        /// <param name="b">B of transformation matrix.</param>
        /// <param name="d">D of transformation matrix.</param>
        /// <param name="e">E of transformation matrix.</param>
        /// <param name="xoff">XOff.</param>
        /// <param name="yoff">YOff.</param>
        /// <returns>Transformed geometry.</returns>
        [Sql.Function("ST_Affine", ServerSideOnly = true)]
        public static NTSG STAffine(this NTSG geometry, double a, double b, double d, double e, double xoff, double yoff) => throw new InvalidOperationException();

        /// <summary>
        /// Applies the 2D affine transformation to input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Affine.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="a">A of transformation matrix.</param>
        /// <param name="b">B of transformation matrix.</param>
        /// <param name="d">D of transformation matrix.</param>
        /// <param name="e">E of transformation matrix.</param>
        /// <param name="xoff">XOff.</param>
        /// <param name="yoff">YOff.</param>
        /// <returns>Transformed geometry.</returns>
        [Sql.Function("ST_Affine", ServerSideOnly = true)]
        public static NTSG STAffine(string geometry, double a, double b, double d, double e, double xoff, double yoff) => throw new InvalidOperationException();

        /// <summary>
        /// Rotates input <paramref name="geometry"/> counter-clockwise around origin point (0, 0).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Rotate.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        /// <returns>Rotated geometry.</returns>
        [Sql.Function("ST_Rotate", ServerSideOnly = true)]
        public static NTSG STRotate(this NTSG geometry, double angle) => throw new InvalidOperationException();

        /// <summary>
        /// Rotates input <paramref name="geometry"/> counter-clockwise around origin point (0, 0).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Rotate.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        /// <returns>Rotated geometry.</returns>
        [Sql.Function("ST_Rotate", ServerSideOnly = true)]
        public static NTSG STRotate(string geometry, double angle) => throw new InvalidOperationException();

        /// <summary>
        /// Rotates input <paramref name="geometry"/> counter-clockwise around origin point (<paramref name="x0"/>, <paramref name="y0"/>).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Rotate.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        /// <param name="x0">X coordinate of rotate origin point.</param>
        /// <param name="y0">Y coordinate of rotate origin point.</param>
        /// <returns>Rotated geometry.</returns>
        [Sql.Function("ST_Rotate", ServerSideOnly = true)]
        public static NTSG STRotate(this NTSG geometry, double angle, double x0, double y0) => throw new InvalidOperationException();

        /// <summary>
        /// Rotates input <paramref name="geometry"/> counter-clockwise around origin point (<paramref name="x0"/>, <paramref name="y0"/>).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Rotate.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        /// <param name="x0">X coordinate of rotate origin point.</param>
        /// <param name="y0">Y coordinate of rotate origin point.</param>
        /// <returns>Rotated geometry.</returns>
        [Sql.Function("ST_Rotate", ServerSideOnly = true)]
        public static NTSG STRotate(string geometry, double angle, double x0, double y0) => throw new InvalidOperationException();

        /// <summary>
        /// Rotates input <paramref name="geometry"/> counter-clockwise around <paramref name="origin"/> point. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Rotate.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        /// <param name="origin">Origin point.</param>
        /// <returns>Rotated geometry.</returns>
        [Sql.Function("ST_Rotate", ServerSideOnly = true)]
        public static NTSG STRotate(this NTSG geometry, double angle, NTSG origin) => throw new InvalidOperationException();

        /// <summary>
        /// Rotates input <paramref name="geometry"/> counter-clockwise around <paramref name="origin"/> point. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Rotate.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        /// <param name="origin">Origin point.</param>
        /// <returns>Rotated geometry.</returns>
        [Sql.Function("ST_Rotate", ServerSideOnly = true)]
        public static NTSG STRotate(string geometry, double angle, NTSG origin) => throw new InvalidOperationException();

        /// <summary>
        /// Rotates input <paramref name="geometry"/> around the X axis.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_RotateX.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        /// <returns>Rotated geometry.</returns>
        [Sql.Function("ST_RotateX", ServerSideOnly = true)]
        public static NTSG STRotateX(this NTSG geometry, double angle) => throw new InvalidOperationException();

        /// <summary>
        /// Rotates input <paramref name="geometry"/> around the X axis.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_RotateX.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        /// <returns>Rotated geometry.</returns>
        [Sql.Function("ST_RotateX", ServerSideOnly = true)]
        public static NTSG STRotateX(string geometry, double angle) => throw new InvalidOperationException();

        /// <summary>
        /// Rotates input <paramref name="geometry"/> around the Y axis.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_RotateY.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        /// <returns>Rotated geometry.</returns>
        [Sql.Function("ST_RotateY", ServerSideOnly = true)]
        public static NTSG STRotateY(this NTSG geometry, double angle) => throw new InvalidOperationException();

        /// <summary>
        /// Rotates input <paramref name="geometry"/> around the Y axis.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_RotateY.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        /// <returns>Rotated geometry.</returns>
        [Sql.Function("ST_RotateY", ServerSideOnly = true)]
        public static NTSG STRotateY(string geometry, double angle) => throw new InvalidOperationException();

        /// <summary>
        /// Rotates input <paramref name="geometry"/> around the Z axis.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_RotateZ.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        /// <returns>Rotated geometry.</returns>
        [Sql.Function("ST_RotateZ", ServerSideOnly = true)]
        public static NTSG STRotateZ(this NTSG geometry, double angle) => throw new InvalidOperationException();

        /// <summary>
        /// Rotates input <paramref name="geometry"/> around the Z axis.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_RotateZ.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="angle">Rotation angle in radians.</param>
        /// <returns>Rotated geometry.</returns>
        [Sql.Function("ST_RotateZ", ServerSideOnly = true)]
        public static NTSG STRotateZ(string geometry, double angle) => throw new InvalidOperationException();

        /// <summary>
        /// Scales input <paramref name="geometry"/> to new size by multiplying ordinates with corresponding factor parameters.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Scale.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="xFactor">Scale factor for X axis.</param>
        /// <param name="yFactor">Scale factor for Y axis.</param>
        /// <param name="zFactor">Scale factor for Z axis.</param>
        /// <returns>Scaled geometry.</returns>
        [Sql.Function("ST_Scale", ServerSideOnly = true)]
        public static NTSG STScale(this NTSG geometry, double xFactor, double yFactor, double zFactor) => throw new InvalidOperationException();

        /// <summary>
        /// Scales input <paramref name="geometry"/> to new size by multiplying ordinates with corresponding factor parameters.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Scale.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="xFactor">Scale factor for X axis.</param>
        /// <param name="yFactor">Scale factor for Y axis.</param>
        /// <param name="zFactor">Scale factor for Z axis.</param>
        /// <returns>Scaled geometry.</returns>
        [Sql.Function("ST_Scale", ServerSideOnly = true)]
        public static NTSG STScale(string geometry, double xFactor, double yFactor, double zFactor) => throw new InvalidOperationException();

        /// <summary>
        /// Scales input <paramref name="geometry"/> to new size by multiplying ordinates with corresponding factor parameters.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Scale.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="xFactor">Scale factor for X axis.</param>
        /// <param name="yFactor">Scale factor for Y axis.</param>
        /// <returns>Scaled geometry.</returns>
        [Sql.Function("ST_Scale", ServerSideOnly = true)]
        public static NTSG STScale(this NTSG geometry, double xFactor, double yFactor) => throw new InvalidOperationException();

        /// <summary>
        /// Scales input <paramref name="geometry"/> to new size by multiplying ordinates with corresponding factor parameters.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Scale.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="xFactor">Scale factor for X axis.</param>
        /// <param name="yFactor">Scale factor for Y axis.</param>
        /// <returns>Scaled geometry.</returns>
        [Sql.Function("ST_Scale", ServerSideOnly = true)]
        public static NTSG STScale(string geometry, double xFactor, double yFactor) => throw new InvalidOperationException();

        /// <summary>
        /// Scales input <paramref name="geometry"/> to new size by multiplying ordinates with corresponding factor parameters.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Scale.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="factor">Scale factor point.</param>
        /// <returns>Scaled geometry.</returns>
        [Sql.Function("ST_Scale", ServerSideOnly = true)]
        public static NTSG STScale(this NTSG geometry, NTSG factor) => throw new InvalidOperationException();

        /// <summary>
        /// Scales input <paramref name="geometry"/> to new size by multiplying ordinates with corresponding factor parameters.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Scale.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="factor">Scale factor point.</param>
        /// <returns>Scaled geometry.</returns>
        [Sql.Function("ST_Scale", ServerSideOnly = true)]
        public static NTSG STScale(string geometry, NTSG factor) => throw new InvalidOperationException();

        /// <summary>
        /// Scales input <paramref name="geometry"/> to new size by multiplying ordinates with corresponding factor parameters.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Scale.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="factor">Scale factor point.</param>
        /// <param name="origin">Scale origin point.</param>
        /// <returns>Scaled geometry.</returns>
        [Sql.Function("ST_Scale", ServerSideOnly = true)]
        public static NTSG STScale(this NTSG geometry, NTSG factor, NTSG origin) => throw new InvalidOperationException();

        /// <summary>
        /// Scales input <paramref name="geometry"/> to new size by multiplying ordinates with corresponding factor parameters.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Scale.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="factor">Scale factor point.</param>
        /// <param name="origin">Scale origin point.</param>
        /// <returns>Scaled geometry.</returns>
        [Sql.Function("ST_Scale", ServerSideOnly = true)]
        public static NTSG STScale(string geometry, NTSG factor, NTSG origin) => throw new InvalidOperationException();

        /// <summary>
        /// Returns new geometry whose coordinates are translated along axes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Translate.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="deltaX">Translate value along X axis.</param>
        /// <param name="deltaY">Translate value along Y axis.</param>
        /// <returns>Translated geometry.</returns>
        [Sql.Function("ST_Translate", ServerSideOnly = true)]
        public static NTSG STTranslate(this NTSG geometry, double deltaX, double deltaY) => throw new InvalidOperationException();

        /// <summary>
        /// Returns new geometry whose coordinates are translated along axes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Translate.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="deltaX">Translate value along X axis.</param>
        /// <param name="deltaY">Translate value along Y axis.</param>
        /// <returns>Translated geometry.</returns>
        [Sql.Function("ST_Translate", ServerSideOnly = true)]
        public static NTSG STTranslate(string geometry, double deltaX, double deltaY) => throw new InvalidOperationException();

        /// <summary>
        /// Translates input <paramref name="geometry"/> along axes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Translate.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="deltaX">Translate value along X axis.</param>
        /// <param name="deltaY">Translate value along Y axis.</param>
        /// <param name="deltaZ">Translate value along Z axis.</param>
        /// <returns>Translated geometry.</returns>
        [Sql.Function("ST_Translate", ServerSideOnly = true)]
        public static NTSG STTranslate(this NTSG geometry, double deltaX, double deltaY, double deltaZ) => throw new InvalidOperationException();

        /// <summary>
        /// Translates input <paramref name="geometry"/> along axes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Translate.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="deltaX">Translate value along X axis.</param>
        /// <param name="deltaY">Translate value along Y axis.</param>
        /// <param name="deltaZ">Translate value along Z axis.</param>
        /// <returns>Translated geometry.</returns>
        [Sql.Function("ST_Translate", ServerSideOnly = true)]
        public static NTSG STTranslate(string geometry, double deltaX, double deltaY, double deltaZ) => throw new InvalidOperationException();

        /// <summary>
        /// Translates input <paramref name="geometry"/> using the deltaX and deltaY args, then scales it using the XFactor, YFactor args, working in 2D only.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_TransScale.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="deltaX">Translate value along X axis.</param>
        /// <param name="deltaY">Translate value along Y axis.</param>
        /// <param name="xFactor">Scale factor for X axis.</param>
        /// <param name="yFactor">Scale factor for Y axis.</param>
        /// <returns>Translated geometry.</returns>
        [Sql.Function("ST_TransScale", ServerSideOnly = true)]
        public static NTSG STTransScale(this NTSG geometry, double deltaX, double deltaY, double xFactor, double yFactor) => throw new InvalidOperationException();

        /// <summary>
        /// Translates input <paramref name="geometry"/> using the deltaX and deltaY args, then scales it using the XFactor, YFactor args, working in 2D only.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_TransScale.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="deltaX">Translate value along X axis.</param>
        /// <param name="deltaY">Translate value along Y axis.</param>
        /// <param name="xFactor">Scale factor for X axis.</param>
        /// <param name="yFactor">Scale factor for Y axis.</param>
        /// <returns>Translated geometry.</returns>
        [Sql.Function("ST_TransScale", ServerSideOnly = true)]
        public static NTSG STTransScale(string geometry, double deltaX, double deltaY, double xFactor, double yFactor) => throw new InvalidOperationException();
#pragma warning restore IDE0060
    }
}
