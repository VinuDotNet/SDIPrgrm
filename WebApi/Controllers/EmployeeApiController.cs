using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;

namespace WebApi.Controllers
{
    //In this solution I have used only GET and POST methods to create list and save the data into DB.
    public class EmployeeApiController : ApiController
    {
        //GET api/employeeapi
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            using (SDIEntities employeeDbEntities = new SDIEntities())
            {
                return employeeDbEntities.Employees.ToList();
            }
        }
        // GET record api/employeeapi/id
        [HttpGet]
        public Employee Get(int sno)
        {
            using (SDIEntities employeeDbEntities = new SDIEntities())
            {
                return employeeDbEntities.Employees.FirstOrDefault(e => e.SNo == sno);
            }
        }
        // POST api/employeeapi
        [HttpPost]
        public void Post([FromBody]Employee value)
        {
            using (SDIEntities employeeDbEntities = new SDIEntities())
            {
                employeeDbEntities.Employees.Add(value);
                employeeDbEntities.SaveChanges();
            }
        }
        //PUT api/employeeapi
        [HttpPut]
        public void Put(int id, [FromBody]Employee value)
        {
            using (SDIEntities employeeDbEntities = new SDIEntities())
            {
                Employee employee = employeeDbEntities.Employees.FirstOrDefault(e => e.SNo == id);
                employee.FirstName = value.FirstName;
                employeeDbEntities.SaveChanges();
            }
        }
        //DELETE api/employeeapi
        [HttpDelete]
        public void Delete(int id)
        {
            using (SDIEntities employeeDbEntities = new SDIEntities())
            {
                Employee employee = employeeDbEntities.Employees.FirstOrDefault(e => e.SNo == id);
                employeeDbEntities.Employees.Remove(employee);
                employeeDbEntities.SaveChanges();
            }
        }
    }
}
