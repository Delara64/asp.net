using EmployeeDB.Interface;
using EmployeeDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeContext _Ctx;

        public EmployeeRepository(EmployeeContext Context)
        {
            _Ctx = Context;
            _Ctx.Context.Configuration.LazyLoadingEnabled = false;
            _Ctx.Context.Configuration.ProxyCreationEnabled = false;


        }
        //Start Method development
        public IQueryable<Employee> GetEmployee()
        {
            return _Ctx.Context.Employees;
        }

        //End Method development

        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }

        public bool IsEmployeeExist(string fName, string lName)
        {
            throw new NotImplementedException();
        }

        public bool AddEmployee(string fName, string lName, string email, string occupation, int departmnet)
        {
            throw new NotImplementedException();
        }
    }
}
