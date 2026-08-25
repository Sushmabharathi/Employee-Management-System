using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models

{
        public class Employee
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Name is required")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Salary is required")]
            public decimal Salary { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress]
            public string Email { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "Please select a department")]
            public int DepartmentId { get; set; }

            [ForeignKey("DepartmentId")]
            public Department? Department { get; set; }
        }
    }
