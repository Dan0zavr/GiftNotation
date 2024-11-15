using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Data
{
    public class GiftNotationDbContextFactory : IDesignTimeDbContextFactory<GiftNotationDbContext>
    {
        public GiftNotationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<GiftNotationDbContext>();
            var connectionString = configuration.GetConnectionString("default");
            optionsBuilder.UseSqlite(connectionString);

            return new GiftNotationDbContext(optionsBuilder.Options);
        }
    }
}
