using HR_management.Domain.Enums;

namespace HR_management.Application.Models.Timekeeping
{
    public class EmployeeRequestUpdateTimekeepingDto
    {
        public Guid EmployeeId { get; set; }

        public string Reason { get; set; }

        public DateTimeOffset Day { get; set; }

        public int CheckIn { get; set; }

        public int CheckOut { get; set; }

        public RequestFormStatus Status { get; set; } = RequestFormStatus.Pending;
    }
}
