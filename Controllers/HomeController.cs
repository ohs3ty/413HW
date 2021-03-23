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
        private MovieListContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieListContext con)
        {
            _logger = logger;
            context = con;
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
            //access the database
            if (ModelState.IsValid)
            {
                context.Responses.Add(movieResponse);
                context.SaveChanges();
                return View("MovieList", context.Responses);
            }
            return View();
        }
        public IActionResult MovieList()
        {
            return View(context.Responses);
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
