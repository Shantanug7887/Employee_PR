using Employee_Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Portal.Data
{
    public class ApplicationDbContext: DbContext

       {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
      
    }
   
}
