using LinqToDB.Data;
using LinqToDB.Mapping;
using Npgsql;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Utility class with methods for registering PostGIS types mappings.
    /// </summary>
    public static class PostGisTypesMapper
    {
        /// <summary>
        /// Registers PostGIS types mappings for given <paramref name="dataConnection"/>.
        /// </summary>
        /// <param name="dataConnection">Database connection.</param>
        public static void RegisterPostGisMappings(this DataConnection dataConnection)
        {
            var typeMapper = (dataConnection.Connection as NpgsqlConnection).TypeMapper;
            typeMapper.MapComposite<ValidDetail>(ValidDetail.CompositeTypeName);

            dataConnection.MappingSchema.SetConverter<object[], GeometryProcessing.MaximumInscribedCircleResult>(objs => CreateMaximumInscribedCircleResult(objs));
        }

        /// <summary>
        /// Registers PostGIS types mappings globally for all database connections.
        /// </summary>
        public static void RegisterPostGisMappingsGlobally()
        {
            NpgsqlConnection.GlobalTypeMapper.MapComposite<ValidDetail>(ValidDetail.CompositeTypeName);

            MappingSchema.Default.SetConverter<object[], GeometryProcessing.MaximumInscribedCircleResult>(objs => CreateMaximumInscribedCircleResult(objs));
        }

        private static GeometryProcessing.MaximumInscribedCircleResult CreateMaximumInscribedCircleResult(object[] objs) =>
            new GeometryProcessing.MaximumInscribedCircleResult
            {
                Center = objs[0] as NTSG,
                Nearest = objs[1] as NTSG,
                Radius = (double)objs[2],
            };
    }
}
