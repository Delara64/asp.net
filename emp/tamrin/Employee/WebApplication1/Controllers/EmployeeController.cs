using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using WebApplication1.Models;



public class EmployeeController : Controller
{
    private EmpDbContext _db = new EmpDbContext();

    public ActionResult Index(string searchTerm)
    {
        List<Employee> employees;

        if (!string.IsNullOrEmpty(searchTerm))
        {
            employees = _db.Employees
                .Where(e => e.FirstName.Contains(searchTerm) || e.LastName.Contains(searchTerm))
                .ToList();
        }
        else
        {
            employees = _db.Employees.ToList();
        }

        ViewBag.SearchTerm = searchTerm;
        return View(employees);
    }


    public ActionResult Search()
    {
        return View();
    }

    [HttpPost]
   
    public ActionResult Search(string searchTerm)
    {
        var employees = _db.SearchEmployees(searchTerm).ToList();
        return PartialView("_EmployeeList", employees);
    }

}
