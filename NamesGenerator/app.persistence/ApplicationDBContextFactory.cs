using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace app.persistence
{

    // Design-time services will automatically discover implementations of this interface that are in the same assembly as the derived context.
    // Exemple de Design-time services: Update-Database
    // https://docs.efproject.net/en/latest/miscellaneous/configuring-dbcontext.html#use-idbcontextfactory

    public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new ConfigurationBuilder();
            builder.AddEnvironmentVariables();
            var configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
             optionsBuilder.UseNpgsql(configuration["WEBAPP_DATABASE_CONNECTIONSTRING"]);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
