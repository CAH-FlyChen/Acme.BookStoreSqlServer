using Acme.BookStore.Entities;
using Acme.BookStoreSqlServer.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.Data
{
    public interface IXunitRepository : IRepository<XOrganizationUnit, Guid>
    {
        Task MyInsert(XOrganizationUnit data);
    }

    public class XunitRepository : EfCoreRepository<BookStoreSqlServerDbContext, XOrganizationUnit, Guid>, IXunitRepository
    {
        public XunitRepository(IDbContextProvider<BookStoreSqlServerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task MyInsert(XOrganizationUnit entity)
        {
            CheckAndSetId(entity);
            var dbContext = await GetDbContextAsync();

            var cc = await dbContext.Set<XOrganizationUnit>().AddAsync(new XOrganizationUnit(Guid.Empty, "cccc", "aaaa", 1));
            var x = cc.Entity;

            await dbContext.SaveChangesAsync();

        }
    }

}
