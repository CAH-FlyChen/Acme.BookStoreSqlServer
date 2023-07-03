using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.BookStoreSqlServer;

[Dependency(ReplaceServices = true)]
public class BookStoreSqlServerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BookStoreSqlServer";
}
