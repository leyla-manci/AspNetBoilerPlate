using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LylBoilerPlate.Authorization.Roles;
using LylBoilerPlate.Authorization.Users;
using LylBoilerPlate.MultiTenancy;
using LylBoilerPlate.Models.Screens;

namespace LylBoilerPlate.EntityFrameworkCore
{
    public class LylBoilerPlateDbContext : AbpZeroDbContext<Tenant, Role, User, LylBoilerPlateDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Screen> Screens { get; set; }
        public LylBoilerPlateDbContext(DbContextOptions<LylBoilerPlateDbContext> options)
            : base(options)
        {
        }
    }
}
