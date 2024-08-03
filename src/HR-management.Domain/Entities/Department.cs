using HR_management.Domain.Commons;

namespace HR_management.Domain.Entities
{
    public class Department : EntityAuditBase
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
