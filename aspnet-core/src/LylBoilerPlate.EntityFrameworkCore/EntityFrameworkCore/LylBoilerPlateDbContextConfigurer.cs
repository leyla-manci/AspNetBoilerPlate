using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LylBoilerPlate.EntityFrameworkCore
{
    public static class LylBoilerPlateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LylBoilerPlateDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LylBoilerPlateDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
