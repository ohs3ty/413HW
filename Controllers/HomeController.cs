using HW3_413.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HW3_413.Controllers
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
            return View("Index", new string[] { "one", "two", "three" });
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet("AddMovie")]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost("AddMovie")]
        [ValidateAntiForgeryToken]
        public IActionResult AddMovie(MovieResponse movieResponse)
        {
            if (ModelState.IsValid)
            {
                TempStorage.AddApplication(movieResponse);
                return View("MovieList", TempStorage.MovieResponses);
            }
            return View("AddMovie");
        }
        public IActionResult MovieList()
        {
            return View(TempStorage.MovieResponses);
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
