using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;


namespace EmployeeManagementSystem.Controllers
{
   
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ApplicationDbContext _context;
        public EmployeeController(IEmployeeService employeeService,
    ApplicationDbContext context)
        {
            _employeeService = employeeService;
            _context = context;
        }
        public IActionResult Index(string search)
        {
            var employees = _employeeService.GetAllEmployees();

            if (!string.IsNullOrEmpty(search))
            {
                employees = employees
                    .Where(x => x.Name.Contains(search))
                    .ToList();
            }

            return View(employees);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(employee);
                
                var count = _context.Employees.Count();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _context.Departments.ToList();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.Departments = _context.Departments.ToList();

            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if(ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employee);
                return RedirectToAction("Index");

            }
            return View(employee);
        }
         public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);

            return RedirectToAction("Index");
    }
}


    }

