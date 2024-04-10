using System.Data;
using System.Net.Http.Headers;
using CompanyApplication.Models;
using System.Text;
using ConsumeWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ConsumeMVCApp.Models.DTOs;
using System.Net.Http.Formatting;

namespace ConsumeMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string baseURL;
		private static readonly HttpClient client = new HttpClient();

		public EmployeeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            baseURL = configuration.GetValue<string>("AppSettings:EmployeeBaseUrl");
        }
        public async Task<IActionResult> GetAllEmployees()
        {
            DataTable dt = new DataTable();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("GetAllEmployee");

                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    dt = JsonConvert.DeserializeObject<DataTable>(results);
                }
                else
                {
                    Console.WriteLine("Error calling web API");
                }
                ViewData.Model = dt;
            }
            return View();
        }

		public ActionResult AddNewEmployee()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddNewEmployee(Employee employee)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(baseURL);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string jsonEmployee = JsonConvert.SerializeObject(employee);
				HttpResponseMessage response = await client.PostAsync("AddNewEmployee", new StringContent(jsonEmployee, Encoding.UTF8, "application/json"));

				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("GetAllEmployees", "Employee"); 
				}
				else
				{
					Console.WriteLine("Error adding new employee via web API");
					ModelState.AddModelError("", "Error adding new employee. Please try again later.");
					return View(); 
				}
			}
		}

        public ActionResult UpdateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string jsonEmployee = JsonConvert.SerializeObject(employee);
                HttpResponseMessage response = await client.PutAsync("UpdateEmployee", new StringContent(jsonEmployee, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllEmployees", "Employee");
                }
                else
                {
                    Console.WriteLine("Error updating employee via web API");
                    ModelState.AddModelError("", "Error updating employee. Please try again later.");
                    return View();
                }
            }
        }

        public ActionResult DeleteEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync($"DeleteEmployee/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllEmployees", "Employee");
                }
                else
                {
                    Console.WriteLine("Error deleting employee via web API");
                    ModelState.AddModelError("", "Error deleting employee. Please try again later.");
                    return View();
                }
            }
        }
    }
}
