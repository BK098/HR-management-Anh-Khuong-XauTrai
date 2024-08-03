using HR_management.Domain.Commons;
using HR_management.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_management.Domain.Entities
{
    public class EmployeeTask : EntityAuditBase
    {
        public string Name { get; set; }
        
        public EmployeeTaskStatus Status { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        #region Relationship
        [ForeignKey(nameof(AssignedBy))]
        public Guid AssignedBy { get; set; }
        public Employee? Assigner { get; set; }
        //public Guid AssignedTo { get; set; }
        //public Employee Assignee { get; set; }
        [ForeignKey(nameof(DepartmentID))]
        public Guid DepartmentID { get; set; }
        public Department? Department { get; set; } 
        #endregion
    }
}
