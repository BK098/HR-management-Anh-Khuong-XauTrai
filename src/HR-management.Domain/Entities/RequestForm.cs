using HR_management.Domain.Commons;
using HR_management.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_management.Domain.Entities
{
    public class RequestForm : EntityAuditBase
    {
        public string Name { get; set; }

        public string Reason { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId {  get; set; }
        public Employee? Employee { get; set; }

        public DateTimeOffset Day { get; set; }

        public int CheckIn {  get; set; }

        public int CheckOut { get; set; }

        public RequestFormStatus Status { get; set; }
    }
}
