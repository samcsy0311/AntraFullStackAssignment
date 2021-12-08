using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
     public class MoviesController : Controller
     {
        public IActionResult Details(int id)
          {
               // call the MovieService wuth DI to get the movie details information
               return View();
          }
     }
}
