namespace HR_management.Application.Models.Timekeeping
{
    public class TimekeepingForEmployee
    {
        public Guid EmployeeId { get; set; }

        public Guid TimekeepingId { get; set; }
        public int? In { get; set; }
        public int? Out { get; set; }

        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public string Status { get; set; }
    }
}
