using Microsoft.EntityFrameworkCore;

namespace GiftNotation.Data
{
    public class GiftNotationDbContextFactory
    {
        private readonly string _connectionString;

        public GiftNotationDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public GiftNotationDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<GiftNotationDbContext> options = new DbContextOptionsBuilder<GiftNotationDbContext>();

            options.UseSqlite(_connectionString);

            return new GiftNotationDbContext(options.Options);
        }
    }
}
