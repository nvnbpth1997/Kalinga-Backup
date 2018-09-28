using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDetails.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<EmpDetails> employees { get; set; }

        public static implicit operator List<object>(Department v)
        {
            throw new NotImplementedException();
        }
    }
}