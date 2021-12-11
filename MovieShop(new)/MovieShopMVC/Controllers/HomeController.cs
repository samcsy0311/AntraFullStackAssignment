﻿using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
     public class HomeController : Controller
     {
          // C# readonly
          private readonly IMovieService _movieService;

          // need to tell MVC MovieService class needs to be "injected"
          public HomeController(IMovieService movieService)      
          {
               _movieService = movieService;
          }

          // u1, u2, u3...100 => 
          // Thread Pool => Collection of threads => 100 T1...T100, T1000
          // Thread Starvation
          // Thread => worker in a factory => 
          // calling this same method at 10:00 AM
          // U 101 =>
          // U 102 => 

          [HttpGet]
          public async Task<IActionResult> Index()
          {
               // Call movie service to get list of movie cards to show in the index view

               // 3 ways to pass data/models from controller action methods to view
               // 1. Pass the models in the view method (Most important)
               // 2. ViewBag
               // 3. ViewData

               // value types we can make nullable by ?

               //string x = null;

               //var leng = x.Length;

               // I/O bound operation => Database calls, File calls, Http Call
               // 10 ms, 100 ms, 1 sec, 10 sec, 
               // CPU bound operation => Resizing an image, rading pixel image, calucalting Pi number 
               // calilcating some algorthm, oan interest, 
               // Thread 1 is waiting for the I/O bound operation to finish
               var movieCards = await _movieService.GetHighestGrossingMovies();

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