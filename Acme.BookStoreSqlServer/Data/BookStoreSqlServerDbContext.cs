using Acme.BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Acme.BookStoreSqlServer.Data;

public class BookStoreSqlServerDbContext : AbpDbContext<BookStoreSqlServerDbContext>
{
    public DbSet<XOrganizationUnit> XOrganizationUnits { get; set; }

    public BookStoreSqlServerDbContext(DbContextOptions<BookStoreSqlServerDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */
        builder.Entity<XOrganizationUnit>(b =>
        {
            b.ToTable("AbpOrganizationUnits", AbpCommonDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(t => t.Id);

            b.Property(t => t.DisplayName).HasColumnName(nameof(XOrganizationUnit.DisplayName));
            b.Property(t => t.Code).HasColumnName(nameof(XOrganizationUnit.Code));

            b.Property(t => t.TenantId).HasColumnName(nameof(XOrganizationUnit.TenantId));

            b.Property(t => t.EntityVersion).HasColumnName(nameof(XOrganizationUnit.EntityVersion));
            b.Property(ou => ou.ParentId).HasColumnName(nameof(XOrganizationUnit.ParentId));

            b.HasOne<OrganizationUnit>().WithOne().HasForeignKey<XOrganizationUnit>(t => t.Id);

        });
    }
}
