using Npgsql;
using System.Data;

namespace LinqToDBPostGisNetTopologySuite
{
    public static class PostGisCompositeTypeMapper
    {
        public static void RegisterPostGisCompositeTypes(this IDbConnection connection)
        {
            var typeMapper = (connection as NpgsqlConnection).TypeMapper;

            typeMapper.MapComposite<ValidDetail>(ValidDetail.CompositeTypeName);
        }

        public static void RegisterPostGisCompositeTypesGlobally()
        {
            NpgsqlConnection.GlobalTypeMapper.MapComposite<ValidDetail>(ValidDetail.CompositeTypeName);
        }
    }
}
