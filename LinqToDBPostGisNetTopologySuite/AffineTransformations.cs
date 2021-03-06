using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;


namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Affine Transformations
    /// </summary>
    /// <remarks>
    /// 8.13. Affine Transformations https://postgis.net/docs/manual-3.0/reference.html#Affine_Transformation
    /// </remarks>
    public static class AffineTransformations
    {
        /// <summary>
        /// Applies 3D affine transformation to input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Affine.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="a">A of transformation matrix</param>
        /// <param name="b">B of transformation matrix</param>
        /// <param name="c">C of transformation matrix</param>
        /// <param name="d">D of transformation matrix</param>
        /// <param name="e">E of transformation matrix</param>
        /// <param name="f">F of transformation matrix</param>
        /// <param name="g">G of transformation matrix</param>
        /// <param name="h">H of transformation matrix</param>
        /// <param name="i">I of transformation matrix</param>
        /// <param name="xoff">XOff</param>
        /// <param name="yoff">YOff</param>
        /// <param name="zoff">ZOff</param>
        /// <returns>Affined Geometry</returns>
        [Sql.Function("ST_Affine", ServerSideOnly = true)]
        public static NTSG STAffine(this NTSG geometry, double a, double b, double c, double d, double e, double f, double g, double h, double i, double xoff, double yoff, double zoff)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Applies 2D affine transformation to input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Affine.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <param name="d">D</param>
        /// <param name="e">E</param>
        /// <param name="xoff">XOff</param>
        /// <param name="yoff">YOff</param>
        /// <returns>Affined geometry</returns>
        [Sql.Function("ST_Affine", ServerSideOnly = true)]
        public static NTSG STAffine(this NTSG geometry, double a, double b, double d, double e, double xoff, double yoff)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Rotates input geometry counter-clockwise about the origin point(0 0).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Rotate.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="rotRadians">Rotate radians</param>
        /// <returns>Rotated geometry</returns>
        [Sql.Function("ST_Rotate", ServerSideOnly = true)]
        public static NTSG STRotate(this NTSG geometry, double rotRadians)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Rotates input geometry counter-clockwise about the origin point(x0,y0).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Rotate.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="rotRadians">Rotate radian</param>
        /// <param name="x0">X of rotate origin</param>
        /// <param name="y0">Y of rotate origin</param>
        /// <returns>Rotated geometry</returns>
        [Sql.Function("ST_Rotate", ServerSideOnly = true)]
        public static NTSG STRotate(this NTSG geometry, double rotRadians, double x0, double y0)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Rotates input geometry counter-clockwise about origin point. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Rotate.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="rotRadians">Rotate radian</param>
        /// <param name="pointOrigin">Rotate origin</param>
        /// <returns>Rotated geometry</returns>
        [Sql.Function("ST_Rotate", ServerSideOnly = true)]
        public static NTSG STRotate(this NTSG geometry, double rotRadians, NTSG pointOrigin)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Rotates input geometry about the X axis.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_RotateX.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="rotRadians">Rotate radian</param>
        /// <returns>Rotated geometry</returns>
        [Sql.Function("ST_RotateX", ServerSideOnly = true)]
        public static NTSG STRotateX(this NTSG geometry, double rotRadians)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Rotates input geometry about the Y axis.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_RotateY.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="rotRadians">Rotate radian</param>
        /// <returns>Rotated geometry</returns>
        [Sql.Function("ST_RotateY", ServerSideOnly = true)]
        public static NTSG STRotateY(this NTSG geometry, double rotRadians)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Rotates input geometry about the Z axis.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_RotateZ.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="rotRadians">Rotate radian</param>
        /// <returns>Rotated geometry</returns>
        [Sql.Function("ST_RotateZ", ServerSideOnly = true)]
        public static NTSG STRotateZ(this NTSG geometry, double rotRadians)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Scales input geometry to new size by multiplying ordinates with corresponding factor parameters.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Scale.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="xFactor">Scale factor of X axis</param>
        /// <param name="yFactor">Scale factor of Y axis</param>
        /// <param name="zFactor">Scale factor of Z axis</param>
        /// <returns>Scaled geometry</returns>
        [Sql.Function("ST_Scale", ServerSideOnly = true)]
        public static NTSG STScale(this NTSG geometry, double xFactor, double yFactor, double zFactor)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Scales input geometry to new size by multiplying ordinates with corresponding factor parameters.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Scale.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="xFactor">Scale factor of X axis</param>
        /// <param name="yFactor">Scale factor of Y axis</param>
        /// <returns>Scaled geometry</returns>
        [Sql.Function("ST_Scale", ServerSideOnly = true)]
        public static NTSG STScale(this NTSG geometry, double xFactor, double yFactor)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Scales input geometry to new size by multiplying ordinates with corresponding factor parameters.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Scale.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="factor">Scale factor point</param>
        /// <returns>Scaled geometry</returns>
        [Sql.Function("ST_Scale", ServerSideOnly = true)]
        public static NTSG STScale(this NTSG geometry, NTSG factor)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Scales input geometry to new size by multiplying ordinates with corresponding factor parameters.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Scale.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="factor">Scale factor point</param>
        /// <param name="origin">Scale origin point</param>
        /// <returns>Scaled geometry</returns>
        [Sql.Function("ST_Scale", ServerSideOnly = true)]
        public static NTSG STScale(this NTSG geometry, NTSG factor, NTSG origin)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns new geometry whose coordinates are translated along axes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Translate.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="deltaX">Translate value along X axis</param>
        /// <param name="deltaY">Translate value along Y axis</param>
        /// <returns>Translated geometry</returns>
        [Sql.Function("ST_Translate", ServerSideOnly = true)]
        public static NTSG STTranslate(this NTSG geometry, double deltaX, double deltaY)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a new geometry whose coordinates are translated along axes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Translate.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="deltaX">Translate value along X axis</param>
        /// <param name="deltaY">Translate value along Y axis</param>
        /// <param name="deltaZ">Translate value along Z axis</param>
        /// <returns>Translated geometry</returns>
        [Sql.Function("ST_Translate", ServerSideOnly = true)]
        public static NTSG STTranslate(this NTSG geometry, double deltaX, double deltaY, double deltaZ)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Translates input geometry using the deltaX and deltaY args, then scales it using the XFactor, YFactor args, working in 2D only.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_TransScale.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="deltaX">DeltaX</param>
        /// <param name="deltaY">DeltaY</param>
        /// <param name="xFactor">XFactor</param>
        /// <param name="yFactor">YFactor</param>
        /// <returns>Translated geometry</returns>
        [Sql.Function("ST_TransScale", ServerSideOnly = true)]
        public static NTSG STTransScale(this NTSG geometry, double deltaX, double deltaY, double xFactor, double yFactor)
        {
            throw new InvalidOperationException();
        }
    }
}
