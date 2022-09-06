using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Editors.
    /// </summary>
    /// <remarks>
    /// 5.5. Geometry Editors
    /// https://postgis.net/docs/reference.html#Geometry_Editors
    /// </remarks>
    public static class GeometryEditors
    {
#pragma warning disable IDE0060
        /// <summary>
        /// Appends <paramref name="point"/> to input <paramref name="lineString"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AddPoint.html
        /// </remarks>
        /// <param name="lineString">Input LineString.</param>
        /// <param name="point">Point.</param>
        /// <returns>LineString with point appended.</returns>
        [Sql.Function("ST_AddPoint", ServerSideOnly = true)]
        public static NTSG STAddPoint(this NTSG lineString, NTSG point) => throw new InvalidOperationException();

        /// <summary>
        /// Adds <paramref name="point"/> to input <paramref name="lineString"/> before point at given <paramref name="position"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AddPoint.html
        /// </remarks>
        /// <param name="lineString">Input LineString.</param>
        /// <param name="point">Point.</param>
        /// <param name="position">Insert position (zero based).</param>
        /// <returns>LineString with point added.</returns>
        [Sql.Function("ST_AddPoint", ServerSideOnly = true)]
        public static NTSG STAddPoint(this NTSG lineString, NTSG point, int position) => throw new InvalidOperationException();

        /// <summary>
        /// Extracts multi geometry from <paramref name="collection"/> consisting only elements of the highest coordinate dimension.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_CollectionExtract.html
        /// </remarks>
        /// <param name="collection">Input geometry collection.</param>
        /// <returns>Multi geometry consisting only elements of the highest coordinate dimension.</returns>
        [Sql.Function("ST_CollectionExtract", ServerSideOnly = true)]
        public static NTSG STCollectionExtract(this NTSG collection) => throw new InvalidOperationException();

        /// <summary>
        /// Extracts multi geometry from <paramref name="collection"/> consisting only elements of specified <paramref name="type"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_CollectionExtract.html
        /// </remarks>
        /// <param name="collection">Input geometry collection.</param>
        /// <param name="type">Type (1 - Point, 2 - LineString, 3 - Polygon).</param>
        /// <returns>Multi geometry consisting only elements of specified type.</returns>
        [Sql.Function("ST_CollectionExtract", ServerSideOnly = true)]
        public static NTSG STCollectionExtract(this NTSG collection, int type) => throw new InvalidOperationException(); // TODO: enum for type

        /// <summary>
        /// Returns the simplest representation of input geometry <paramref name="collection"/> contents.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_CollectionHomogenize.html
        /// </remarks>
        /// <param name="collection">Geometry collection.</param>
        /// <returns>Simplest" representation of the geometry collection.</returns>
        [Sql.Function("ST_CollectionHomogenize", ServerSideOnly = true)]
        public static NTSG STCollectionHomogenize(this NTSG collection) => throw new InvalidOperationException();

        /// <summary>
        /// Converts input <paramref name="geometry"/> CircularString to regular LineString or CurvePolygon to Polygon, or MultiSurface to MultiPolygon.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_CurveToLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="tolerance">Tolerance value.</param>
        /// <param name="toleranceType">Tolerance type.</param>
        /// <param name="flags">Output options.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_CurveToLine", ServerSideOnly = true)]
        public static NTSG STCurveToLine(this NTSG geometry, double tolerance, int toleranceType, int flags) => throw new InvalidOperationException();// TODO: enums for arguments

        /// <summary>
        /// Changes the start/end point of a closed LineString to the given vertex point.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Scroll.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="point">Input given vertex point.</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_Scroll", ServerSideOnly = true)]
        public static NTSG STScroll(this NTSG geometry, NTSG point) => throw new InvalidOperationException();

        /// <summary>
        /// Changes the start/end point of a closed LineString to the given vertex point.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Scroll.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="point">Input given vertex point.</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_Scroll", ServerSideOnly = true)]
        public static NTSG STScroll(this NTSG geometry, string point) => throw new InvalidOperationException();

        /// <summary>
        /// Changes the start/end point of a closed LineString to the given vertex point.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Scroll.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="point">Input given vertex point.</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_Scroll", ServerSideOnly = true)]
        public static NTSG STScroll(string geometry, NTSG point) => throw new InvalidOperationException();

        /// <summary>
        /// Changes the start/end point of a closed LineString to the given vertex point.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Scroll.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="point">Input given vertex point.</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_Scroll", ServerSideOnly = true)]
        public static NTSG STScroll(string geometry, string point) => throw new InvalidOperationException();

        /// <summary>
        /// Returns geometry with with flipped X and Y axis of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_FlipCoordinates.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_FlipCoordinates", ServerSideOnly = true)]
        public static NTSG STFlipCoordinates(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces input <paramref name="geometry"/> into 2-dimensional (XY) mode.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force2D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry in 2-dimensional (XY) mode.</returns>
        [Sql.Function("ST_Force2D", ServerSideOnly = true)]
        public static NTSG STForce2D(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces input <paramref name="geometry"/> into 2-dimensional (XY) mode.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force2D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry in 2-dimensional (XY) mode.</returns>
        [Sql.Function("ST_Force2D", ServerSideOnly = true)]
        public static NTSG STForce2D(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces input <paramref name="geometry"/> into 3-dimensional (XYZ) mode (alias for ST_Force3DZ).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_3D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry in 3-dimensional XYZ mode.</returns>
        [Sql.Function("ST_Force3D", ServerSideOnly = true)]
        public static NTSG STForce3D(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces input <paramref name="geometry"/> into 3-dimensional (XYZ) mode (alias for ST_Force3DZ).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_3D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry in 3-dimensional (XYZ) mode.</returns>
        [Sql.Function("ST_Force3D", ServerSideOnly = true)]
        public static NTSG STForce3D(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces input <paramref name="geometry"/> into 3-dimensional (XYZ) mode.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_3DZ.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry in 3-dimensional (XYZ) mode.</returns>
        [Sql.Function("ST_Force3DZ", ServerSideOnly = true)]
        public static NTSG STForce3DZ(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces input <paramref name="geometry"/> into 3-dimensional (XYZ) mode.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_3DZ.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry in 3-dimensional XYZ mode.</returns>
        [Sql.Function("ST_Force3DZ", ServerSideOnly = true)]
        public static NTSG STForce3DZ(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces input <paramref name="geometry"/> into 3-dimensional (XYM) mode.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_3DM.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry in 3-dimensional (XYM) mode.</returns>
        [Sql.Function("ST_Force3DM", ServerSideOnly = true)]
        public static NTSG STForce3DM(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces input <paramref name="geometry"/> into 3-dimensional (XYM) mode.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_3DM.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry in 3-dimensional (XYM) mode.</returns>
        [Sql.Function("ST_Force3DM", ServerSideOnly = true)]
        public static NTSG STForce3DM(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces input <paramref name="geometry"/> into XYZM mode.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_4D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry in XYZM mode.</returns>
        [Sql.Function("ST_Force4D", ServerSideOnly = true)]
        public static NTSG STForce4D(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces input <paramref name="geometry"/> into XYZM mode.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_4D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry in XYZM mode.</returns>
        [Sql.Function("ST_Force4D", ServerSideOnly = true)]
        public static NTSG STForce4D(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces input <paramref name="geometry"/> to use a counter-clockwise orientation for their exterior ring, and a clockwise orientation for their interior rings.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForcePolygonCCW.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry with counter-clockwise/clockwise exterior/interior orientaion ring.</returns>
        [Sql.Function("ST_ForcePolygonCCW", ServerSideOnly = true)]
        public static NTSG STForcePolygonCCW(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Converts input <paramref name="geometry"/> into GeometryCollection.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_Collection.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>GeometryCollection.</returns>
        [Sql.Function("ST_ForceCollection", ServerSideOnly = true)]
        public static NTSG STForceCollection(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Converts input <paramref name="geometry"/> into GeometryCollection.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_Collection.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>GeometryCollection.</returns>
        [Sql.Function("ST_ForceCollection", ServerSideOnly = true)]
        public static NTSG STForceCollection(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces input <paramref name="geometry"/> to use a clockwise orientation for their exterior ring, and a counter-clockwise orientation for their interior rings.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForcePolygonCW.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry with counter-clockwise/clockwise interior/exterior orientaion ring.</returns>
        [Sql.Function("ST_ForcePolygonCW", ServerSideOnly = true)]
        public static NTSG STForcePolygonCW(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces the input <paramref name="geometry"/> to use SFS 1.1 geometry types only.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForceSFS.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_ForceSFS", ServerSideOnly = true)]
        public static NTSG STForceSFS(this NTSG geometry) => throw new InvalidOperationException();

        // TODO: geometry ST_ForceSFS(geometry, version);

        /// <summary>
        /// Forces the input <paramref name="geometry"/> in text representation to use SFS 1.1 geometry types only.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForceSFS.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_ForceSFS", ServerSideOnly = true)]
        public static NTSG STForceSFS(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces the orientation of the vertices of input <paramref name="geometry"/> to follow a Right-Hand-Rule.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForceRHR.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry with vertices following a Right-Hand-Rule.</returns>
        [Sql.Function("ST_ForceRHR", ServerSideOnly = true)]
        public static NTSG STForceRHR(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Forces the orientation of the vertices of input <paramref name="geometry"/> to follow a Right-Hand-Rule.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForceRHR.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry with vertices following a Right-Hand-Rule.</returns>
        [Sql.Function("ST_ForceRHR", ServerSideOnly = true)]
        public static NTSG STForceRHR(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Turns input <paramref name="geometry"/> into its curved representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForceCurve.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry in curved representation.</returns>
        [Sql.Function("ST_ForceCurve", ServerSideOnly = true)]
        public static NTSG STForceCurve(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Turns input <paramref name="geometry"/> into its curved representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForceCurve.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry in curved representation.</returns>
        [Sql.Function("ST_ForceCurve", ServerSideOnly = true)]
        public static NTSG STForceCurve(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns LineStrings formed by sewing together the constituent line work of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineMerge.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>LineStrings.</returns>
        [Sql.Function("ST_LineMerge", ServerSideOnly = true)]
        public static NTSG STLineMerge(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns LineStrings formed by sewing together the constituent line work of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineMerge.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>LineStrings.</returns>
        [Sql.Function("ST_LineMerge", ServerSideOnly = true)]
        public static NTSG STLineMerge(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Converts input <paramref name="geometry"/> to CircularString or CurvePolygon.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineToCurve.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString or Polygon).</param>
        /// <returns>Curved equivalent of input geometry.</returns>
        [Sql.Function("ST_LineToCurve", ServerSideOnly = true)]
        public static NTSG STLineToCurve(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Converts input <paramref name="geometry"/> to Multi* geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Multi.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Multi* geometry.</returns>
        [Sql.Function("ST_Multi", ServerSideOnly = true)]
        public static NTSG STMulti(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Converts input <paramref name="geometry"/> to Multi* geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Multi.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Multi* geometry.</returns>
        [Sql.Function("ST_Multi", ServerSideOnly = true)]
        public static NTSG STMulti(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Converts input <paramref name="geometry"/> to its normalized (canonical) form.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Normalize.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Normalized geometry.</returns>
        [Sql.Function("ST_Normalize", ServerSideOnly = true)]
        public static NTSG STNormalize(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns input <paramref name="geometry"/> with its coordinates quantized.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_QuantizeCoordinates.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="precisionX">Precision for X coordinate.</param>
        /// <param name="precisionY">Precision for Y coordinate.</param>
        /// <param name="precisionZ">Precision for Z coordinate.</param>
        /// <param name="precisionM">Precision for M coordinate.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_QuantizeCoordinates", ServerSideOnly = true)]
        public static NTSG STQuantizeCoordinates(this NTSG geometry, int precisionX, int precisionY, int precisionZ, int precisionM) => throw new InvalidOperationException();

        /// <summary>
        /// Returns input <paramref name="geometry"/> with its coordinates quantized.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_QuantizeCoordinates.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="precision">Precision for X, Y, Z, M coordinates.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_QuantizeCoordinates", ServerSideOnly = true)]
        public static NTSG STQuantizeCoordinates(this NTSG geometry, int precision) => throw new InvalidOperationException();

        /// <summary>
        /// Removes point from input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_RemovePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <param name="index">Index of point to remove (zero-based).</param>
        /// <returns>Geometry with point removed.</returns>
        [Sql.Function("ST_RemovePoint", ServerSideOnly = true)]
        public static NTSG STRemovePoint(this NTSG geometry, int index) => throw new InvalidOperationException();

        /// <summary>
        /// Removes point from input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_RemovePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <param name="index">Index of point to remove (zero-based).</param>
        /// <returns>Geometry with point removed.</returns>
        [Sql.Function("ST_RemovePoint", ServerSideOnly = true)]
        public static NTSG STRemovePoint(string geometry, int index) => throw new InvalidOperationException();

        /// <summary>
        /// Returns input <paramref name="geometry"/> with duplicated points removed.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_RemoveRepeatedPoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="tolerance">Tolerance.</param>
        /// <returns>Geometry with duplicated points removed.</returns>
        [Sql.Function("ST_RemoveRepeatedPoints", ServerSideOnly = true)]
        public static NTSG STRemoveRepeatedPoints(this NTSG geometry, double tolerance) => throw new InvalidOperationException();

        /// <summary>
        /// Returns input <paramref name="geometry"/> with reversed order of vertexes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Reverse.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry with reversed order of vertexes.</returns>
        [Sql.Function("ST_Reverse", ServerSideOnly = true)]
        public static NTSG STReverse(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns input <paramref name="geometry"/> with reversed order of vertexes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Reverse.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry with reversed order of vertexes.</returns>
        [Sql.Function("ST_Reverse", ServerSideOnly = true)]
        public static NTSG STReverse(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns input <paramref name="geometry"/> having no segment longer than the given <paramref name="maxSegmentLength"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Segmentize.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="maxSegmentLength">Max segment length.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_Segmentize", ServerSideOnly = true)]
        public static NTSG STSegmentize(this NTSG geometry, double maxSegmentLength) => throw new InvalidOperationException();

        /// <summary>
        /// Returns modified input <paramref name="geometry"/> in text represenation having no segment longer than the given <paramref name="maxSegmentLength"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Segmentize.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="maxSegmentLength">Max segment length.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_Segmentize", ServerSideOnly = true)]
        public static NTSG STSegmentize(string geometry, double maxSegmentLength) => throw new InvalidOperationException();

        /// <summary>
        /// Replaces point of input <paramref name="geometry"/> with given point.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SetPoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <param name="index">Index of point to remove (zero-based).</param>
        /// <param name="point">New point.</param>
        /// <returns>Geometry with point replaced.</returns>
        [Sql.Function("ST_SetPoint", ServerSideOnly = true)]
        public static NTSG STSetPoint(this NTSG geometry, int index, NTSG point) => throw new InvalidOperationException();

        /// <summary>
        /// Reads every point/vertex in every component of every feature in input <paramref name="geometry"/>, and if the longitude coordinate is less than 0, adds 360 to it.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Shift_Longitude.html
        /// </remarks>
        /// <param name="geometry">Input geometry (in long lat only).</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_ShiftLongitude", ServerSideOnly = true)]
        public static NTSG STShiftLongitude(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Snaps all points of input <paramref name="geometry"/> to the grid defined by its origin and cell size.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SnapToGrid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="originX">X coordinate of grid origin.</param>
        /// <param name="originY">Y coordinate of grid origin.</param>
        /// <param name="sizeX">Grid cell size by X axis.</param>
        /// <param name="sizeY">Grid cell size by Y axis.</param>
        /// <returns>Geometry with all points snapped to grid.</returns>
        [Sql.Function("ST_SnapToGrid", ServerSideOnly = true)]
        public static NTSG STSnapToGrid(this NTSG geometry, double originX, double originY, double sizeX, double sizeY) => throw new InvalidOperationException();

        /// <summary>
        /// Snaps all points of input <paramref name="geometry"/> to the grid defined by its cell size.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SnapToGrid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="sizeX">Grid cell size by X axis.</param>
        /// <param name="sizeY">Grid cell size by Y axis.</param>
        /// <returns>Geometry with all points snapped to grid.</returns>
        [Sql.Function("ST_SnapToGrid", ServerSideOnly = true)]
        public static NTSG STSnapToGrid(this NTSG geometry, double sizeX, double sizeY) => throw new InvalidOperationException();

        /// <summary>
        /// Snaps all points of input <paramref name="geometry"/> to the grid defined by its cell size.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SnapToGrid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="size">Grid cell size.</param>
        /// <returns>Geometry with all points snapped to grid.</returns>
        [Sql.Function("ST_SnapToGrid", ServerSideOnly = true)]
        public static NTSG STSnapToGrid(this NTSG geometry, double size) => throw new InvalidOperationException();

        /// <summary>
        /// Snaps all points of input <paramref name="geometry"/> to the grid defined by its origin point and cell sizes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SnapToGrid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="origin">Grid origin (Point).</param>
        /// <param name="sizeX">Grid cell size by X axis.</param>
        /// <param name="sizeY">Grid cell size by Y axis.</param>
        /// <param name="sizeZ">Grid cell size by Z axis.</param>
        /// <param name="sizeM">Grid cell size by M axis.</param>
        /// <returns>Geometry with all points snapped to grid.</returns>
        [Sql.Function("ST_SnapToGrid", ServerSideOnly = true)]
        public static NTSG STSnapToGrid(this NTSG geometry, NTSG origin, double sizeX, double sizeY, double sizeZ, double sizeM) => throw new InvalidOperationException();

        /// <summary>
        /// Snaps the vertices and segments of input <paramref name="geometry"/> to <paramref name="reference"/> geometry vertices.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Snap.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="reference">Reference geometry.</param>
        /// <param name="tolerance">Snap distance tolerance.</param>
        /// <returns>Geometry with the vertices snapped.</returns>
        [Sql.Function("ST_Snap", ServerSideOnly = true)]
        public static NTSG STSnap(this NTSG geometry, NTSG reference, double tolerance) => throw new InvalidOperationException();

        /// <summary>
        /// Returns a version of input <paramref name="geometry"/> with given ordinates swapped.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SwapOrdinates.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="ordinates">Two-characters string naming the ordinates to swap. Valid names are: x,y,z and m.</param>
        /// <returns>Geometry with given ordinates swapped.</returns>
        [Sql.Function("ST_SwapOrdinates", ServerSideOnly = true)]
        public static NTSG STSwapOrdinates(this NTSG geometry, string ordinates) => throw new InvalidOperationException();

        /// <summary>
        /// Returns a version of input <paramref name="geometry"/> in text representation with given ordinates swapped.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SwapOrdinates.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="ordinates">Two-characters string naming the ordinates to swap. Valid names are: x,y,z and m.</param>
        /// <returns>Geometry with given ordinates swapped.</returns>
        [Sql.Function("ST_SwapOrdinates", ServerSideOnly = true)]
        public static NTSG STSwapOrdinates(string geometry, string ordinates) => throw new InvalidOperationException();

        /// <summary>
        /// Splits the input geometries and then moves every resulting component falling on the right (for negative 'move') or on the left (for positive 'move') of given 'wrap' line in the direction specified by the 'move' parameter, finally re-unioning the pieces togheter.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_WrapX.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="wrap">Wrap line coordinate.</param>
        /// <param name="move">Move offset.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_WrapX", ServerSideOnly = true)]
        public static NTSG STWrapX(this NTSG geometry, double wrap, double move) => throw new InvalidOperationException();
#pragma warning restore IDE0060
    }
}
