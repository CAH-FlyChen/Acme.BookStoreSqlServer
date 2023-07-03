using Acme.BookStore.Entities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Services
{
    public interface IMyService : IApplicationService
    {
        Task MyInsert();
    }


    public class MyService : ApplicationService, IMyService
    {
        IRepository<XOrganizationUnit> repository => LazyServiceProvider.LazyGetRequiredService<IRepository<XOrganizationUnit>>();

        public MyService()
        {
        }

        public async Task MyInsert()
        {
            var cc = new XOrganizationUnit(Guid.Empty, "cccc", "aaaa", 1);
            await repository.InsertAsync(cc,true);
        }
    }
}
