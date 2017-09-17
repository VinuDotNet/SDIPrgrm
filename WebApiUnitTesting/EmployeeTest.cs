using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using WebApi.Controllers;

namespace WebApiUnitTesting
{
    [TestClass]
    public class EmployeeTest
    {
        //All of the methods that are marked with the TestMethod attribute will be tested.
        [TestMethod]
        //It should pass if database has total 5 records
        public void GetAllEmployees_ShouldReturnAllEmployees()
        {
            
            var testEmployee = new EmployeeApiController();            
            var result = testEmployee.Get() as List<Employee>;
            Assert.AreEqual(5, result.Count);
        }

        //private List<Employee> GetAllEmployees()
        //{
        //    var testEmployee = new List<Employee>();
        //    testEmployee.Add(new Employee
        //    {
        //        FirstName = "abc",
        //        LastName = "xyz",
        //        DateOfBirth = Convert.ToDateTime("01/01/2017"),
        //        GPA = Convert.ToDecimal("4.0")
        //    });
        //    testEmployee.Add(new Employee
        //    {
        //        FirstName = "vhjj",
        //        LastName = "xyz",
        //        DateOfBirth = Convert.ToDateTime("01/01/2017"),
        //        GPA = Convert.ToDecimal("4.0")
        //    });
        //    return testEmployee;
        //}
    }
}
