using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace Acme.BookStoreSqlServer.Data;

public class BookStoreSqlServerEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public BookStoreSqlServerEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BookStoreSqlServerDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BookStoreSqlServerDbContext>()
            .Database
            .MigrateAsync();
    }
}
