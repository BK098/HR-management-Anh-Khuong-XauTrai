namespace HR_management.Application.Models.Auth
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CMND { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Guid DepartmentID { get; set; }
        public Guid? ManagerID { get; set; }
    }
}
