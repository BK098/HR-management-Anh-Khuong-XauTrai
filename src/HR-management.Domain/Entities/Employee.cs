using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_management.Domain.Entities
{
    public class Employee : IdentityUser<Guid>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string CMND { get; set; }

        #region Token
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        #endregion
        #region AuditBase
        public DateTimeOffset CreatedBy { get; set; }
        public DateTimeOffset? LastModifiedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? LastModifiedDate { get; set; }
        #endregion
        #region Foreign Key

        [ForeignKey(nameof(DepartmentID))]
        public Guid DepartmentID { get; set; }
        public Department? Department { get; set; }

        [ForeignKey(nameof(ManagerID))]
        public Guid? ManagerID { get; set; }
        public Employee? Manager { get; set; }
        #endregion
    }
}