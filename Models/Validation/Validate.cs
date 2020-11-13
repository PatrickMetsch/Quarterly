using System;
using System.Linq;

namespace Quarterly.Models.Validation
{
    public static class Validate
    {
        public static string CheckEmployee(SalesContext context, Employee employee)
        {
            Employee searchEmployee = context.Employees.FirstOrDefault(e =>
                e.FirstName == employee.FirstName
                && e.LastName == employee.LastName
                && e.DateOfBirth == employee.DateOfBirth
            );

            return searchEmployee == null
                ? string.Empty
                : $"{searchEmployee.LastName}, {searchEmployee.FirstName} (DOB: {searchEmployee.DateOfBirth.ToShortDateString()}) is already in the database";
        }

        public static string CheckManagerEmployeeMatch(SalesContext context, Employee employee)
        {
            Employee manager = context.Employees.Find(employee.ManagerId);

            return
                manager != null
                && manager.FirstName == employee.FirstName
                && manager.LastName == employee.LastName
                && manager.DateOfBirth == employee.DateOfBirth
            ? "Manager and Employee can't be the same person"
            : string.Empty;
        }

        public static string CheckSales(SalesContext context, Sales sale)
        {
            Sales sales = context.Sales.FirstOrDefault(
                s => s.EmployeeId == sale.EmployeeId
                && s.Year == sale.Year
                && s.Quarter == sale.Year
            );

            if(sales == null)
            {
                return string.Empty;
            }

            Employee employee = context.Employees.Find(sale.EmployeeId);

            return sales == null
                ? string.Empty
                : $"Sales for {employee.FirstName} { employee.LastName}, Quarter {sale.Quarter} of Year {sale.Year} already exists.";
        }
    }
}
