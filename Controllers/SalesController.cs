using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quarterly.Models;
using Quarterly.Models.Validation;

namespace Quarterly.Controllers
{
    public class SalesController : Controller
    {
        private SalesContext context { get; set; }

        public SalesController(SalesContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index() => RedirectToAction("Index", "Home");


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Sales sale)
        {
            string message = Validate.CheckSales(context, sale);

            if (!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(Sales.EmployeeId), message);
            }

            if (ModelState.IsValid)
            {
                context.Sales.Add(sale);
                context.SaveChanges();

                TempData["message"] = "Sale added!";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();

                return View();
            }
        }
    }
}
