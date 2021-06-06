using System;

using LinqToDB;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Table Management Functions.
    /// </summary>
    /// <remarks>
    /// 5.2. Table Management Functions
    /// https://postgis.net/docs/reference.html#Management_Functions
    /// </remarks>
    public static class TableManagementFunctions
    {
        /// <summary>
        /// Adds a geometry column to an existing table of attributes. If you require the old behavior of constraints use the default use_typmod, but set useTypMod to false.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/AddGeometryColumn.html
        /// </remarks>
        /// <param name="tableName">Table name.</param>
        /// <param name="columnName">Column name.</param>
        /// <param name="srid">Spatial Reference Identifier.</param>
        /// <param name="type">Geometry type.</param>
        /// <param name="dimension">Dimension.</param>
        /// <param name="useTypMod">Use typmod.</param>
        /// <returns>Information about added column.</returns>
        [Sql.Function("AddGeometryColumn", ServerSideOnly = true)]
        public static string AddGeometryColumn(string tableName, string columnName, int srid, string type, int dimension, bool useTypMod)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Adds a geometry column to an existing table of attributes.If you require the old behavior of constraints use the default use_typmod, but set useTypMod to false.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/AddGeometryColumn.html
        /// </remarks>
        /// <param name="schemaName">Schema name.</param>
        /// <param name="tableName">Table name.</param>
        /// <param name="columnName">Column name.</param>
        /// <param name="srid">Spatial Reference Identifier.</param>
        /// <param name="type">Geometry type.</param>
        /// <param name="dimension">Dimension.</param>
        /// <param name="useTypMod">Use typmod.</param>
        /// <returns>Information about added column.</returns>
        [Sql.Function("AddGeometryColumn", ServerSideOnly = true)]
        public static string AddGeometryColumn(string schemaName, string tableName, string columnName, int srid, string type, int dimension, bool useTypMod)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Adds a geometry column to an existing table of attributes.If you require the old behavior of constraints use the default use_typmod, but set useTypMod to false.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/AddGeometryColumn.html
        /// </remarks>
        /// <param name="catalogName">Catalog name.</param>
        /// <param name="schemaName">Schema name.</param>
        /// <param name="tableName">Table name.</param>
        /// <param name="columnName">Column name.</param>
        /// <param name="srid">Spatial Reference Identifier.</param>
        /// <param name="type">Geometry type.</param>
        /// <param name="dimension">Dimension.</param>
        /// <param name="useTypMod">Use typmod.</param>
        /// <returns>Information about added column.</returns>
        [Sql.Function("AddGeometryColumn", ServerSideOnly = true)]
        public static string AddGeometryColumn(string catalogName, string schemaName, string tableName, string columnName, int srid, string type, int dimension, bool useTypMod)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Removes a geometry column from a spatial table. Schema_name will need to match the f_table_schema field of the table's row in the geometry_columns table.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/DropGeometryColumn.html
        /// </remarks>
        /// <param name="tableName">Table name.</param>
        /// <param name="columnName">Column name.</param>
        /// <returns>Information about dropped column.</returns>
        [Sql.Function("DropGeometryColumn", ServerSideOnly = true)]
        public static string DropGeometryColumn(string tableName, string columnName)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Removes a geometry column from a spatial table. Schema_name will need to match the f_table_schema field of the table's row in the geometry_columns table.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/DropGeometryColumn.html
        /// </remarks>
        /// <param name="schemaName">Schema name.</param>
        /// <param name="tableName">Table name.</param>
        /// <param name="columnName">Column name.</param>
        /// <returns>Information about dropped column.</returns>
        [Sql.Function("DropGeometryColumn", ServerSideOnly = true)]
        public static string DropGeometryColumn(string schemaName, string tableName, string columnName)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Removes a geometry column from a spatial table. Schema_name will need to match the f_table_schema field of the table's row in the geometry_columns table.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/DropGeometryColumn.html
        /// </remarks>
        /// <param name="catalogName">Catalog name.</param>
        /// <param name="schemaName">Schema name.</param>
        /// <param name="tableName">Table name.</param>
        /// <param name="columnName">Column name.</param>
        /// <returns>Information about dropped column.</returns>
        [Sql.Function("DropGeometryColumn", ServerSideOnly = true)]
        public static string DropGeometryColumn(string catalogName, string schemaName, string tableName, string columnName)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Drops a table and all its references in geometry_columns.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/DropGeometryTable.html
        /// </remarks>
        /// <param name="tableName">Table name.</param>
        /// <returns>Table dropped.</returns>
        [Sql.Function("DropGeometryTable", ServerSideOnly = true)]
        public static string DropGeometryTable(string tableName)//returning bool will get error
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Drops a table and all its references in geometry_columns.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/DropGeometryTable.html
        /// </remarks>
        /// <param name="schemaName">Schema name.</param>
        /// <param name="tableName">Table name.</param>
        /// <returns>Table dropped.</returns>
        [Sql.Function("DropGeometryTable", ServerSideOnly = true)]
        public static string DropGeometryTable(string schemaName, string tableName)//returning bool will get error
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Drops a table and all its references in geometry_columns.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/DropGeometryTable.html
        /// </remarks>
        /// <param name="catalogName">Catalog name.</param>
        /// <param name="schemaName">Schema name.</param>
        /// <param name="tableName">Table name.</param>
        /// <returns>Table dropped.</returns>
        [Sql.Function("DropGeometryTable", ServerSideOnly = true)]
        public static string DropGeometryTable(string catalogName, string schemaName, string tableName)//returning bool will get error
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the integer SRID of the specified geometry column by searching through the GEOMETRY_COLUMNS table. If the geometry column has not been properly added (e.g. with the AddGeometryColumn function), this function will not work.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/Find_SRID.html
        /// </remarks>
        /// <param name="schemaName">Schema name.</param>
        /// <param name="tableName">Table name.</param>
        /// <param name="geomFieldName">Geometry field name.</param>
        /// <returns>The integer SRID of the specified geometry column.</returns>
        [Sql.Function("Find_SRID", ServerSideOnly = true)]
        public static int? FindSrid(string schemaName, string tableName, string geomFieldName)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Ensures geometry columns have appropriate type modifiers or spatial constraints to ensure they are registered correctly in the geometry_columns view. By default will convert all geometry columns with no type modifier to ones with type modifiers.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/Populate_Geometry_Columns.html
        /// </remarks>
        /// <param name="useTypeMod">Use type modifiers.</param>
        /// <returns>Populate result.</returns>
        [Sql.Function("Populate_Geometry_Columns", ServerSideOnly = true)]
        public static string PopulateGeometryColumns(bool useTypeMod)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Ensures geometry columns have appropriate type modifiers or spatial constraints to ensure they are registered correctly in the geometry_columns view. By default will convert all geometry columns with no type modifier to ones with type modifiers.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/Populate_Geometry_Columns.html
        /// </remarks>
        /// <param name="oId">OId.</param>
        /// <param name="useTypeMod">Use type modifiers.</param>
        /// <returns>Populate result.</returns>
        [Sql.Function("Populate_Geometry_Columns", ServerSideOnly = true)]
        public static int PopulateGeometryColumns(int oId, bool useTypeMod)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Updates the SRID of all features in a geometry column, updating constraints and reference in geometry_columns. If the column was enforced by a type definition, the type definition will be changed.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/UpdateGeometrySRID.html
        /// </remarks>
        /// <param name="tableName">Table name.</param>
        /// <param name="columnName">Column name.</param>
        /// <param name="srid">Spatial Reference System Identifier.</param>
        /// <returns>SRID update information.</returns>
        [Sql.Function("UpdateGeometrySRID", ServerSideOnly = true)]
        public static string UpdateGeometrySRID(string tableName, string columnName, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Updates the SRID of all features in a geometry column, updating constraints and reference in geometry_columns. If the column was enforced by a type definition, the type definition will be changed.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/UpdateGeometrySRID.html
        /// </remarks>
        /// <param name="schemaName">Schema name.</param>
        /// <param name="tableName">Table name.</param>
        /// <param name="columnName">Column name.</param>
        /// <param name="srid">Spatial Reference System Identifier.</param>
        /// <returns>SRID update information.</returns>
        [Sql.Function("UpdateGeometrySRID", ServerSideOnly = true)]
        public static string UpdateGeometrySRID(string schemaName, string tableName, string columnName, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Updates the SRID of all features in a geometry column, updating constraints and reference in geometry_columns. If the column was enforced by a type definition, the type definition will be changed.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/UpdateGeometrySRID.html
        /// </remarks>
        /// <param name="catalogName">Catalog name.</param>
        /// <param name="schemaName">Schema name.</param>
        /// <param name="tableName">Table name.</param>
        /// <param name="columnName">Column name.</param>
        /// <param name="srid">Spatial Reference System Identifier.</param>
        /// <returns>SRID update information.</returns>
        [Sql.Function("UpdateGeometrySRID", ServerSideOnly = true)]
        public static string UpdateGeometrySRID(string catalogName, string schemaName, string tableName, string columnName, int srid)
        {
            throw new InvalidOperationException();
        }
    }
}
