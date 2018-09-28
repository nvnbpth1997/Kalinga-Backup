using EmployeeDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeDetails.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        public static List<Department> departments;
        public EmployeeAPIController()
        {
            departments = new List<Department>() {
                new Department{ ID = 1,
                                DepartmentName = "SDET",
                                employees = new List<EmpDetails>{
                                                new EmpDetails{ ID = 1, EmployeeName = "Gokul"},
                                                new EmpDetails{ ID = 2, EmployeeName =  "Barath"}
                                                            }
                },

                new Department{ ID = 2,
                                DepartmentName = ".NET",
                                employees = new List<EmpDetails>{
                                                new EmpDetails{ ID = 3, EmployeeName = "Naveen"},
                                                new EmpDetails{ ID = 4, EmployeeName =  "Surya"}
                                                            }
                }
            };
        }

        [System.Web.Mvc.HttpGet]
        public List<Department> GetAllDetails()
        {
            return departments;
        }
    }
}
