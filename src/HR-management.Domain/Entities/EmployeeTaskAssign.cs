using HR_management.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_management.Domain.Entities
{
    public class EmployeeTaskAssign : EntityAuditBase
    {
        public Guid EmployeeId { get; set; }
        public Guid TaskId { get; set; }
    }
}
