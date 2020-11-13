﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quarterly.Models;
using Quarterly.Models.Validation;

namespace Quarterly.Controllers
{
    public class EmployeeController : Controller
    {
        private SalesContext context {get; set;}

        public EmployeeController(SalesContext ctx)
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
        public IActionResult Add(Employee employee)
        {
            string message = Validate.CheckEmployee(context, employee);

            if (!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(Employee.DateOfBirth), message);
            }

            message = Validate.CheckManagerEmployeeMatch(context, employee);

            if (!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(Employee.ManagerId), message);
            }

            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();

                TempData["message"] = $"Employee {employee.FirstName} {employee.LastName} added!";

                return RedirectToAction("Index", "Home");
            } else
            {
                ViewBag.Employees = context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();

                return View();
            }
        }
    }
}
