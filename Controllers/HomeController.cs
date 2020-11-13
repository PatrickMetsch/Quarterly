using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Quarterly.Models;

namespace Quarterly.Controllers
{
    public class HomeController : Controller
    {
        private SalesContext context { get; set; }

        public HomeController(SalesContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            IQueryable<Sales> query = context.Sales
                .Include(s => s.Employee)
                .OrderBy(s => s.Employee.LastName)
                .ThenBy(s => s.Employee.FirstName)
                .ThenBy(s => s.Year)
                .ThenBy(s => s.Quarter);

            if(id > 0)
            {
                query = query.Where(s => s.EmployeeId == id);
            }

            SalesListViewModel vm = new SalesListViewModel
            {
                Sales = query.ToList(),
                EmployeeId = id,
                Employees = context.Employees.OrderBy(a => a.LastName).ThenBy(a => a.LastName).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(Employee employee)
        {
            if(employee.EmployeeId > 0)
            {
                return RedirectToAction("Index", new { id = employee.EmployeeId });
            } else
            {
                return RedirectToAction("Index", new { id = string.Empty });
            }
        }
    }
}
