using Employee_Portal.Models;
using System.ComponentModel.DataAnnotations;

namespace Employee_Portal.ViewModel
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Full Name is Required")]
        [StringLength(100,ErrorMessage = "Full Name cannot be exist 100 characters.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is Reduired")]
        [EmailAddress(ErrorMessage = "Invalid email adress")]
        public string Email { get; set; }


        [Required(ErrorMessage = "join date is Required")]
         [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        public DateTime JoinDate { get; set; }= DateTime.Today;

        [Required(ErrorMessage = "please select the department")]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        public DepartmentVM DepartmentView { get; set; }
    }
}
