namespace HR_management.Application.Models.Employee
{
    public class UpdateEmployeeDto
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string CMND { get; set; }

        public string Email { get; set; }
        public Guid DepartmentID { get; set; }

        public Guid? ManagerID { get; set; }
    }
}
