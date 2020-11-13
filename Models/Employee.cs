using System;
using System.ComponentModel.DataAnnotations;
using Quarterly.Models.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Quarterly.Models
{
    public class Employee
    {
        public int EmployeeId {get; set;}

        [Required(ErrorMessage = "Please enter a First Name")]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name")]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName  { get; set; }

        [Required(ErrorMessage = "Please ebter a Birth Date")]
        [PastDate(ErrorMessage = "Birth Date must be a valid past date.")]
        [Remote("CheckEmployee", "Validation", AdditionalFields = "FirstName, LastName")]
        [Display(Name = "Birth Date")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter a Hire Date")]
        [PastDate(ErrorMessage = "Hire Date must be a valid past date.")]
        [GreaterThan("1/1/1995", ErrorMessage = "Hire Date must be after company was formed in 1995.")]
        [Display(Name = "Hire Date")]
        public DateTime DateOfHire { get; set; }

        [GreaterThan(0, ErrorMessage = "Please select a Manager")]
        [Remote("CheckManager", "Validation", AdditionalFields = "FirstName, LastName, DateOfBirth")]
        [Display(Name = "Manager")]
        public int ManagerId { get; set; }
    }
}
