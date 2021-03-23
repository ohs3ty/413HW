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

        [HttpGet("EditMovie")]
        public IActionResult EditMovie(int movieId)
        {
            var dbResponse = from res in context.Responses
                         where res.MovieID == movieId
                         select res;

            ViewBag.dbResponse = dbResponse.FirstOrDefault();
            return View();
        }

        [HttpPost("EditMovie")]
        public IActionResult EditMovie(MovieResponse movieResponse)
        {
            if (ModelState.IsValid)
            {
                //update
                var updateQuery = (from res in context.Responses
                                   where res.MovieID == movieResponse.MovieID
                                   select res).FirstOrDefault();
                updateQuery.Title = movieResponse.Title;
                updateQuery.Category = movieResponse.Category;
                updateQuery.Year = movieResponse.Year;
                updateQuery.Director = movieResponse.Director;
                updateQuery.Rating = movieResponse.Rating;
                updateQuery.Edited = movieResponse.Edited;
                updateQuery.Lent = movieResponse.Lent;
                updateQuery.Notes = movieResponse.Notes;
                
                context.SaveChanges();
                return View("MovieList", context.Responses);
            } 

            ViewBag.dbResponse = movieResponse;
            ViewBag.error = "ERROR";
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
