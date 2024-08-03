using HR_management.Domain.Commons.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HR_management.Domain.Commons
{
    public abstract class EntityAuditBase : IAuditBase<Guid>
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreatedBy { get ; set ; }
        public DateTimeOffset? LastModifiedBy { get ; set ; }
        public DateTimeOffset CreatedDate { get ; set ; } = DateTimeOffset.Now;
        public DateTimeOffset? LastModifiedDate { get ; set ; }
    }
}
