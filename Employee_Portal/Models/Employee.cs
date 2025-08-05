namespace Employee_Portal.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate{ get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } // Navigation property to Department
    }
}
