using HR_management.Domain.Commons;

namespace HR_management.Domain.Entities
{
    public class Timekeeping : EntityAuditBase
    {
        // format: ngày/tháng
        public string Time {  get; set; }

        // Tổng số ngày/tháng
        public int Day {  get; set; }
    }
}
