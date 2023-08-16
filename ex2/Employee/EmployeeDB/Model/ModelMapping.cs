using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB.Model
{
    public class ModelMapping
    {
        public Employee LoadEmployee(EmployeeDB.Employee empl)
        {
            return new Employee
            {
                Id = empl.Id,
                FirstName = empl.FirstName,
                LastName = empl.LastName,

                FullName = empl.FirstName.Trim() + " " + empl.LastName.Trim(),

                occupation = empl.occupation,
                email = empl.email
            };
        }
        public Employee GetEmployee(EmployeeDB.Employee empl)
        {
            return new Employee
            {
                Id = empl.Id,
                FullName = empl.FirstName.Trim() + " " + empl.LastName.Trim(),

                occupation = empl.occupation,
                email = empl.email,
                phoneNumber = empl.phoneNumber
            };
        }
    }
}
