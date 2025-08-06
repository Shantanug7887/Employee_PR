using Employee_Portal.Data;
using Employee_Portal.Models;
using Employee_Portal.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Portal.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);


        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            DepartmentVM departmentViewModel = new DepartmentVM();
            departmentViewModel.DptName = await _context.Departments.ToListAsync();

            EmployeeVM employeeViewModel = new EmployeeVM();
            employeeViewModel.DepartmentView = departmentViewModel; // Default value for the dropdown

            return View(employeeViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeVM VM)
        {


            Models.Employee employee = new Models.Employee();

            employee.FullName = VM.FullName;
            employee.Email = VM.Email;
            employee.JoinDate = VM.JoinDate;
            employee.DepartmentId = VM.DepartmentView.SelectedDptID;



            await _context.AddAsync(employee);
            _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            DepartmentVM departmentViewModel = new DepartmentVM();
            departmentViewModel.DptName = await _context.Departments.ToListAsync();
            departmentViewModel.SelectedDptID = employee.DepartmentId;

            EmployeeVM employeeViewModel = new EmployeeVM();


            employeeViewModel.FullName = employee.FullName;
            employeeViewModel.Email = employee.Email;
            employeeViewModel.JoinDate = employee.JoinDate;
            employeeViewModel.DepartmentView = departmentViewModel;

            return View(employeeViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeVM employeeViewModel)
        {
            var employee = await _context.Employees.FindAsync(employeeViewModel.Id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.FullName = employeeViewModel.FullName;
            employee.Email = employeeViewModel.Email;
            employee.JoinDate = employeeViewModel.JoinDate;
            employee.DepartmentId = employeeViewModel.DepartmentView.SelectedDptID;
            _context.Update(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var employee = await _context.Employees.FindAsync(Id);
            if (employee == null)
            {
                return NotFound();
            }


            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Models.Employee employee)
        {

            if (employee != null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}

