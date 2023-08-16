using EmployeeDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB.Interface
{
    public interface IEmployeeRepository : IDisposable
    {
        IQueryable<Employee> GetEmployee();
        bool IsEmployeeExist(string fName, string lName);
        bool AddEmployee(string fName, string lName, string email, string occupation, int departmnet);
    }
}
