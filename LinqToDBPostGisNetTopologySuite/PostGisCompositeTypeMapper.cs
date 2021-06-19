using Npgsql;
using System.Data;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Utility class with methods for registering PostGIS composite types mappings.
    /// </summary>
    public static class PostGisCompositeTypeMapper
    {
        /// <summary>
        /// Registers PostGIS composite types mappings for given <paramref name="connection"/>.
        /// </summary>
        /// <param name="connection">Database connection.</param>
        public static void RegisterPostGisCompositeTypes(this IDbConnection connection)
        {
            var typeMapper = (connection as NpgsqlConnection).TypeMapper;

            typeMapper.MapComposite<ValidDetail>(ValidDetail.CompositeTypeName);
        }

        /// <summary>
        /// Globally registers PostGIS composite types mappings for all database connections.
        /// </summary>
        public static void RegisterPostGisCompositeTypesGlobally()
        {
            NpgsqlConnection.GlobalTypeMapper.MapComposite<ValidDetail>(ValidDetail.CompositeTypeName);
        }
    }
}
