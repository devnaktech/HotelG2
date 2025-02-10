using Microsoft.EntityFrameworkCore;
using LMC103.Models;

namespace LMC103.Data
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Customer> Customers { get; set; }  

        public DbSet<Employee> Employees { get; set; }
    }
        
}
