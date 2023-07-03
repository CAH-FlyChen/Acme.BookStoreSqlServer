using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Acme.BookStore.Entities
{
    public class XOrganizationUnit : FullAuditedEntity<Guid>, IMultiTenant, IHasEntityVersion, IHasConcurrencyStamp, IMayHaveCreator, IHasCreationTime, IHasModificationTime, IHasDeletionTime, IDeletionAuditedObject, IModificationAuditedObject
    {
        public virtual string ConcurrencyStamp { get; set; }

        public virtual DateTime CreationTime { get; set; }

        /// <inheritdoc />
        public virtual Guid? CreatorId { get; set; }

        public virtual DateTime? LastModificationTime { get; set; }

        /// <inheritdoc />
        public virtual Guid? LastModifierId { get; set; }

        /// <inheritdoc />
        public virtual bool IsDeleted { get; set; }

        /// <inheritdoc />
        public virtual Guid? DeleterId { get; set; }

        /// <inheritdoc />
        public virtual DateTime? DeletionTime { get; set; }


        public virtual Guid? TenantId { get; protected set; }

        /// <summary>
        /// Parent <see cref="OrganizationUnit"/> Id.
        /// Null, if this OU is a root.
        /// </summary>
        public virtual Guid? ParentId { get; internal set; }

        /// <summary>
        /// Hierarchical Code of this organization unit.
        /// Example: "00001.00042.00005".
        /// This is a unique code for an OrganizationUnit.
        /// It's changeable if OU hierarchy is changed.
        /// </summary>
        public virtual string Code { get; internal set; }

        /// <summary>
        /// Display name of this OrganizationUnit.
        /// </summary>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// A version value that is increased whenever the entity is changed.
        /// </summary>
        public virtual int EntityVersion { get; set; }

        public XOrganizationUnit(Guid id, string code, string displayName, int entityVersion) : base(id)
        {
            this.Code = code;
            this.DisplayName = displayName;
            this.EntityVersion = entityVersion;
        }
    }
}
