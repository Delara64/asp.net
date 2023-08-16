using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public int DepartmentId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}