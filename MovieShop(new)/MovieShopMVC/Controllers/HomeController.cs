using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
     public class HomeController : Controller
     {
          private MovieService _movieService;

          public HomeController(ILogger<HomeController> logger)
          {
               _movieService = new MovieService();
          }

          [HttpGet]
          public IActionResult Index()
          {
               // Call movie service to get list of movie cards to show in the index view
               var movieCards = _movieService.GetHighestGrossingMovies();

               // 3 ways to pass data/models from controller action methods to view
               // 1. Pass the models in the view method (Most important)
               // 2. ViewBag
               // 3. ViewData
               return View(movieCards);
          }

          [HttpGet]
          public IActionResult Privacy()
          {
               return View();
          }

          [HttpGet]
          public IActionResult TopMovies()
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