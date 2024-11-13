using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Data
{
    public class GiftNotationDbContextFactory : IDesignTimeDbContextFactory<GiftNotationDbContext>
    {
        public GiftNotationDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<GiftNotationDbContext>();
            string connectionString = "Data Source=C:\\Users\\Haier\\source\\repos\\GiftNotation\\notes.db";
            options.UseSqlite(connectionString);
            return new GiftNotationDbContext(options.Options);
        }
    }
}
