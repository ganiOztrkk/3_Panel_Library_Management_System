using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;
using Microsoft.Ajax.Utilities;

namespace LibraryProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DbLibraryEntities _db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var employees = _db.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employees employee)
        {
            if (!ModelState.IsValid) return View();
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee != null) _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employees employee)
        {
            if (!ModelState.IsValid) return View();
            var updateEmployee = _db.Employees.Find(employee.EmployeeId);
            if (updateEmployee != null) updateEmployee.EmployeeName = employee.EmployeeName;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}