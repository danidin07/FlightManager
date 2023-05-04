using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UiFlightManager.Models;
using FlightManagerProjectSela;
using System.Collections;
using FlightManagerApi.Models;

namespace UiFlightManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client = new() { BaseAddress = new Uri("http://localhost:5219") };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var loggerList = await client.GetFromJsonAsync<IEnumerable<LoggerDto>>("api/flight");
            return View(loggerList);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}