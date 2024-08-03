namespace HR_management.Application.Models.Timekeeping
{
    public class EmployeeTimekeepingDto
    {
        public Guid EmployeeId { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public int Time {  get; set; }
    }
}
