using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class EmpDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } // DbSet for your Employee entity

        // Define the SearchEmployees method
        public List<Employee> SearchEmployees(string searchTerm)
        {
            // Execute the stored procedure
            var parameters = new SqlParameter("@term", searchTerm);
            var result = Database.SqlQuery<Employee>("SearchEmployee @term", parameters);
            return result.ToList();
        }
    }

        
    }
