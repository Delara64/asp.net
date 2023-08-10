using EmployeeDB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _Ctx;

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
    }
}
