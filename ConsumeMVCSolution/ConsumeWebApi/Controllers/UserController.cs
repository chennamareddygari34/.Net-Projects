using System.Net.Http.Headers;
using ConsumeMVCApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeMVCApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly string baseURL;

        public UserController(ILogger<UserController> logger, IConfiguration configuration)
        {
            _logger = logger;
            baseURL = configuration.GetValue<string>("AppSettings:UserLoginBaseUrl");
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/User/Login", userDTO);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<UserDTO>(responseData);

                        // Clear ModelState if needed
                        ModelState.Clear();

                        // Redirect to LoggedInAction passing user data
                        return RedirectToAction("LoggedInAction", "LoggedInController", result);
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError("", errorMessage);
                        return View("Login");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP Request error occurred.");
                ModelState.AddModelError("", "Error occurred while processing your request.");
                return View("Login");
            }
        }
    }
}


//        [HttpPost]
//        public async Task<IActionResult> Login(UserDTO userDTO)
//        {
//            try
//            {
//                using (var client = new HttpClient())
//                {
//                    client.BaseAddress = new Uri(baseURL);
//                    client.DefaultRequestHeaders.Accept.Clear();
//                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                    HttpResponseMessage response = await client.PostAsJsonAsync("api/User/Login", userDTO);

//                    if (response.IsSuccessStatusCode)
//                    {
//                        var responseData = await response.Content.ReadAsStringAsync();
//                        var result = JsonConvert.DeserializeObject<UserDTO>(responseData);

//                        // Clear ModelState if needed
//                        ModelState.Clear();

//                        return RedirectToAction("LoggedInAction", "LoggedInController");
//                    }
//                    else
//                    {
//                        var errorMessage = await response.Content.ReadAsStringAsync();
//                        ModelState.AddModelError("", errorMessage);
//                        return View("Login");
//                    }
//                }
//            }
//            catch (HttpRequestException ex)
//            {
//                _logger.LogError(ex, "HTTP Request error occurred.");
//                ModelState.AddModelError("", "Error occurred while processing your request.");
//                return View("Login");
//            }
//        }
//    }
//}

//        //public IActionResult Register()
//        //{
//        //    return View();
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> Register(UserDTO userDTO)
//        //{
//        //    try
//        //    {
//        //        using (var client = new HttpClient())
//        //        {
//        //            client.BaseAddress = new Uri(baseURL);
//        //            client.DefaultRequestHeaders.Accept.Clear();
//        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//        //            HttpResponseMessage response = await client.PostAsJsonAsync("api/User/Register", userDTO);

//        //            if (response.IsSuccessStatusCode)
//        //            {
//        //                var responseData = await response.Content.ReadAsStringAsync();
//        //                var result = JsonConvert.DeserializeObject<UserDTO>(responseData);

//        //                // Clear ModelState if needed
//        //                ModelState.Clear();

//        //                return RedirectToAction("RegistrationSuccess", "RegistrationController");
//        //            }
//        //            else
//        //            {
//        //                var errorMessage = await response.Content.ReadAsStringAsync();
//        //                ModelState.AddModelError("", errorMessage);
//        //                return View("Register");
//        //            }
//        //        }
//        //    }
//        //    catch (HttpRequestException ex)
//        //    {
//        //        _logger.LogError(ex, "HTTP Request error occurred.");
//        //        ModelState.AddModelError("", "Error occurred while processing your request.");
//        //        return View("Register");
//        //    }
//        //}
//    }
//}
