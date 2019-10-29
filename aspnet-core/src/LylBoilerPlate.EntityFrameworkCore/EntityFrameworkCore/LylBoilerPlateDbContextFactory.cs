using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using LylBoilerPlate.Configuration;
using LylBoilerPlate.Web;

namespace LylBoilerPlate.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LylBoilerPlateDbContextFactory : IDesignTimeDbContextFactory<LylBoilerPlateDbContext>
    {
        public LylBoilerPlateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LylBoilerPlateDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            LylBoilerPlateDbContextConfigurer.Configure(builder, configuration.GetConnectionString(LylBoilerPlateConsts.ConnectionStringName));

            return new LylBoilerPlateDbContext(builder.Options);
        }
    }
}
