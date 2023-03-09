using Microsoft.AspNetCore.Mvc;
using MvcModelBindingApp.Models;
using System.Diagnostics;

namespace MvcModelBindingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*
             ?person.Name=Bob&person.Age=23&person.Company.Title=Yandex
             * 
             * 
            Request.Form["Name"]
            RouteData.Values["Name"]
            Request.Query["Name"]
            */
            //return Content($"Name: {employe.Name}, Age: {employe.Age}, Company: {employe.Company.Title}");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // FromHeader
        // FromQuery
        // FromRoute
        // FromForm
        // FromBody - 

        //public IActionResult UserInfo([Bind("Name", "Age")] User user)
        
        public IActionResult UserInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserInfo([Bind("Name", "Age")][FromForm] User user)
        {
            if (this.ModelState.IsValid)
                return Content($"Id: {user.Id}, Name: {user.Name}, Age: {user.Age}, Admin: {user.IsAdmin}");

            string result = $"Errors count: {ModelState.ErrorCount}, errors:\n";
            foreach (var prop in ModelState.Keys)
                result += $"{prop}\n";

            return Content(result);
        }

        public IActionResult UserAgent([FromHeader(Name = "User-Agent")] string agent)
        {
            return Content(agent);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}