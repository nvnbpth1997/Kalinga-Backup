using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiAngular.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("Employee")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}