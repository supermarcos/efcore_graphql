using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstSample.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options)
            : base(options)
        {
            //// these are mutually exclusive, migrations cannot be used with EnsureCreated()
            //// Database.EnsureCreated();
            //Database.Migrate();
        }

        // tables here:
        public DbSet<Employee> Employees { get; set; }
    }
}