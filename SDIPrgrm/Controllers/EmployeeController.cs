using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Globalization;

namespace SDIPrgrm.Controllers
{
    public class EmployeeController : Controller
    {
        //Making Employee Details Secure
        [Authorize]
        // GET: Employee
        public ActionResult EmployeeUI()
        {
            return View();
        }


        //Calling Web Api to post/save data.
#region
        //The HttpClient Class,  will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:64810/api/employeeapi";

        
        public EmployeeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult Create()
        {
            return View();
        }

        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(Employee Emp)
        {
            
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, Emp);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Message"]= "Employee Created Successfully";
                return RedirectToAction("EmployeeUI");
            }
            return RedirectToAction("Error");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
#endregion
}