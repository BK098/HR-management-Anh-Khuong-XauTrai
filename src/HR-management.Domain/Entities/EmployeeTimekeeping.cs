using HR_management.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_management.Domain.Entities
{
    public class EmployeeTimekeeping : EntityAuditBase
    {
        public int CheckIn { get; set; }
        public int CheckOut { get; set; }
        public int WorkHours { get; set; }

        #region Relationship
        [ForeignKey(nameof(TimekeepingId))]
        public Guid TimekeepingId { get; set; }
        public Timekeeping? Timekeeping { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; } 
        #endregion
    }
}
