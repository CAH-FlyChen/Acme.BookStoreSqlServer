using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Acme.BookStoreSqlServer.Data;

public class BookStoreSqlServerDbContextFactory : IDesignTimeDbContextFactory<BookStoreSqlServerDbContext>
{
    public BookStoreSqlServerDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BookStoreSqlServerDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new BookStoreSqlServerDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
