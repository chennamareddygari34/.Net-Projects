using System.Diagnostics;
using System.Net.Http.Headers;
using ConsumeMVCApp.Models.DTOs;
using ConsumeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeWebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly string baseURL;


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
			baseURL = configuration.GetValue<string>("AppSettings:BaseUrl");
		}

        public async Task<IActionResult> Index()
        {
            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}