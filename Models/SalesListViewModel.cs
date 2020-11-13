using System;
using System.Collections.Generic;

namespace Quarterly.Models
{
    public class SalesListViewModel
    {
        public List<Employee> Employees { get; set; }

        public List<Sales> Sales { get; set; }

        public int EmployeeId { get; set; }
    }
}
