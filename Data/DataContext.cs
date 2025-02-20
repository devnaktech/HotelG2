using Microsoft.EntityFrameworkCore;
using HotelG2.Models;

namespace HotelG2.Data
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
