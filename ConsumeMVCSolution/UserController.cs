using System.Net.Http.Headers;
using System.Text;
using ConsumeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeMVCApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly string _baseURL;
        private readonly IHttpClientFactory _clientFactory;

        public UserController(ILogger<UserController> logger, IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _baseURL = configuration.GetValue<string>("AppSettings:BaseUrl");
            _clientFactory = clientFactory;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(User user)
        {
            try
            {
                var client = _clientFactory.CreateClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string jsonLogin = JsonConvert.SerializeObject(user);
                HttpResponseMessage response = await client.PostAsync("Login", new StringContent(jsonLogin, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _logger.LogError("Error adding new Login via web API");
                    ModelState.AddModelError("", "Error adding new Login. Please try again later.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing login request.");
                ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
                return View();
            }
        }
    



        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                var client = _clientFactory.CreateClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string jsonUser = JsonConvert.SerializeObject(user);
                HttpResponseMessage response = await client.PostAsync("Register", new StringContent(jsonUser, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    _logger.LogError("Error registering new user via web API");
                    ModelState.AddModelError("", "Error registering new user. Please try again later.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing registration request.");
                ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
                return View();
            }
        }



        public IActionResult SuccessAction()
        {
            return View();
        }
    }
}

