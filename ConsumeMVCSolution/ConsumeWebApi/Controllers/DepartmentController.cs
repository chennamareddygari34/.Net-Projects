using CompanyApplication.Models;
using ConsumeWebApi.Controllers;
using System.Data;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeMVCApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string baseURL;
        private static readonly HttpClient client = new HttpClient();

        public DepartmentController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            baseURL = configuration.GetValue<string>("AppSettings:DepartmentBaseUrl");
        }
        public async Task<IActionResult> GetAllDepartment()
        {
            DataTable dt = new DataTable();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("GetAllDepartment");

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

        public ActionResult AddNewDepartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDepartment(Department department)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string jsonDepartment = JsonConvert.SerializeObject(department);
                HttpResponseMessage response = await client.PostAsync("AddNewDepartment", new StringContent(jsonDepartment, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllDepartment", "Department");
                }
                else
                {
                    Console.WriteLine("Error adding new Department via web API");
                    ModelState.AddModelError("", "Error adding new Department. Please try again later.");
                    return View();
                }
            }
        }

        public ActionResult UpdateDepartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string jsonDepartment = JsonConvert.SerializeObject(department);
                HttpResponseMessage response = await client.PutAsync("UpdateDepartment", new StringContent(jsonDepartment, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllDepartment", "Department");
                }
                else
                {
                    Console.WriteLine("Error updating Department via web API");
                    ModelState.AddModelError("", "Error updating Department. Please try again later.");
                    return View();
                }
            }
        }

        public ActionResult DeleteDepartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDepartment(int DepartmentNumber)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync($"DeleteDepartment/{DepartmentNumber}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllDepartment", "Department");
                }
                else
                {
                    Console.WriteLine("Error deleting Department via web API");
                    ModelState.AddModelError("", "Error deleting Department. Please try again later.");
                    return View();
                }
            }
        }
    }
}
