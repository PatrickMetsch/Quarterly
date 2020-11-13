using System;
using Microsoft.EntityFrameworkCore;

namespace Quarterly.Models
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) :base(options) { }

        public DbSet<Sales> Sales { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Tommy",
                    LastName = "Creo",
                    DateOfBirth = new DateTime(1968, 10, 12),
                    DateOfHire = new DateTime(2010, 3, 17),
                    ManagerId = 0
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Izzy",
                    LastName = "Creo",
                    DateOfBirth = new DateTime(1970, 3, 7),
                    DateOfHire = new DateTime(2010, 3, 18),
                    ManagerId = 1
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Donovan",
                    LastName = "Sapien",
                    DateOfBirth = new DateTime(2001, 2, 19),
                    DateOfHire = new DateTime(2013, 3, 17),
                    ManagerId = 1
                }
            );

            modelBuilder.Entity<Sales>().HasData(
                new Sales
                {
                    SalesId = 1,
                    Quarter = 3,
                    Year = 2018,
                    Amount = 87192,
                    EmployeeId = 2
                },
                new Sales
                {
                    SalesId = 2,
                    Quarter = 2,
                    Year = 2013,
                    Amount = 6715,
                    EmployeeId = 1
                },
                new Sales
                {
                    SalesId = 3,
                    Quarter = 4,
                    Year = 2015,
                    Amount = 44511,
                    EmployeeId = 3
                },
                new Sales
                {
                    SalesId = 4,
                    Quarter = 4,
                    Year = 2016,
                    Amount = 76141,
                    EmployeeId = 1
                },
                new Sales
                {
                    SalesId = 5,
                    Quarter = 1,
                    Year = 2017,
                    Amount = 91671,
                    EmployeeId = 3
                },
                new Sales
                {
                    SalesId = 6,
                    Quarter = 1,
                    Year = 2013,
                    Amount = 11341,
                    EmployeeId = 2
                }
            );
        }
    }
}
