using HR_management.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_management.Domain.Entities
{
    public class Employee : EntityAuditBase
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string CMND {  get; set; }

        public string Email { get; set; }

        [ForeignKey(nameof(DepartmentID))]
        public Guid DepartmentID { get; set; }
        public Department? Department { get; set; }

        [ForeignKey(nameof(ManagerID))]
        public Guid? ManagerID { get; set; }
        public Employee? Manager { get; set; }
    }
}
