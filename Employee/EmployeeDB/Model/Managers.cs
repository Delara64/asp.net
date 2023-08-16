using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB.Model
{
    public class Managers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }

        public string email { get; set; }
        public string occupation { get; set; }
        public int departamentId { get; set; }

    }
}
