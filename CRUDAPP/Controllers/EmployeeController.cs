using CRUDAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CRUDAPP.Controllers
{
    public class EmployeeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44385/api");
        private readonly HttpClient UserClient;


        public EmployeeController()
        {
            UserClient = new HttpClient();

            UserClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            HttpResponseMessage Response = UserClient.GetAsync(UserClient.BaseAddress + "/" + "Employee").Result;

            if (Response.IsSuccessStatusCode)
            { 
                string data=Response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            }

            return View(employees);
        }
       


    }
}
