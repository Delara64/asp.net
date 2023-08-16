using Employee.Models;
using EmployeeDB.Interface;
using EmployeeDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeRepository _Repo;
        ModelMapping _ModelMapping;

        public HomeController(IEmployeeRepository Repo, ModelMapping ModelMapping)
        {
            _Repo = Repo;
            _ModelMapping = ModelMapping;
        }

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            SelectLists ddlFilter = new SelectLists();
            ddlFilter.EmployeeList = new SelectList((from a in _Repo.GetEmployee()
                                                     select new
                                                     {
                                                         Value = a.Id,
                                                         Text = a.FirstName.Trim() + "" + a.LastName.Trim()
                                                     }).Distinct(), "Value", "Text");
            return View(ddlFilter);
        }
        [HttpGet]
        public ActionResult GetEmployee(int pageIndex, int pageSize, string sortField = "Id", string sortOrder = "desc")
        {

            IEnumerable<EmployeeDB.Employee> EmployeeList = null;
            IQueryable<EmployeeDB.Employee> Query = null;
            IEnumerable<EmployeeDB.Model.Employee> ResultList = null;

            int itemsCount = 0;
            var param = sortField;
            var propertyInfo = typeof(EmployeeDB.Employee).GetProperty(param);
            int skip = (pageIndex - 1) * pageSize;

            try
            {
                using (_Repo)
                {

                    Query = _Repo.GetEmployee();
                    itemsCount = Query.Count();

                    switch (sortField)
                    {
                        case "FirstName":
                            if (sortOrder == "asc")
                            {
                                EmployeeList = Query.OrderBy(S => S.FirstName);
                            }
                            else if (sortOrder == "desc")
                            {
                                EmployeeList = Query.OrderByDescending(S => S.FirstName);
                            }
                            break;
                        case "LastName":
                            if (sortOrder == "asc")
                            {
                                EmployeeList = Query.OrderBy(S => S.LastName);
                            }
                            else if (sortOrder == "desc")
                            {
                                EmployeeList = Query.OrderByDescending(S => S.LastName);
                            }
                            break;

                        default:
                            EmployeeList = Query.OrderByDescending(S => S.Id);
                            break;
                    }
                    // CommentsList = Query.OrderByDescending(S => S.CommentDate);

                    ResultList = EmployeeList.Skip(skip)
                           .Take(pageSize).ToList().ToList()
                           .Select(T => _ModelMapping.LoadEmployee(T));

                    var res = EmployeeList.GroupBy(x => x.Id).Select(y => y.First());
                }
            }
            catch (Exception ex)
            {
                //
            }
            var Result = new { data = ResultList, itemsCount = itemsCount };

            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public class ResultNames
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
        [HttpPost]

        public ActionResult SearchEmployee(string term)
        {
            IEnumerable<AutoComplete> AutoCompleteResult = null;
            using (_Repo)
            {
                AutoCompleteResult = _Repo.SearchEmployee(term).Select(a => new AutoComplete()
                {
                    value = a.Id.ToString(),
                    lable = a.FirstName + " " + a.LastName,  // Removed the assignment operator "="
                    desc = a.departamentId.ToString()
                }).ToList();
            }
            return Json(AutoCompleteResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddEmployee(string fName, string lName, string email, string occupation, int departmnet, int employeeId)
        {
            GlobalObject GlobalResultObj = new GlobalObject();
            try
            {
                using (_Repo)
                {
                    if (!_Repo.IsEmployeeExist(fName, lName)) //or ID
                    {
                        GlobalResultObj.isValid = _Repo.AddEmployee(fName, lName, email, occupation, departmnet);
                        if (!GlobalResultObj.isValid)
                            GlobalResultObj.Message = "Unexpected error occured";
                    }
                    else
                    {
                        GlobalResultObj.isValid = false;
                        GlobalResultObj.Message = "Category with the same frequency and technician type already exists";  // Fixed the message text
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalResultObj.isValid = false;
                GlobalResultObj.Message = "Unexpected error occured";
            }
            return Json(GlobalResultObj, JsonRequestBehavior.AllowGet);
        }

        public ViewResult About()
        {
            throw new NotImplementedException();
        }

        public ViewResult Contact()
        {
            throw new NotImplementedException();
        }
    }
}