﻿using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
     [Authorize]    // Filters
     public class UserController : Controller
     {
          private readonly IUserService _userService;

          public UserController(IUserService userService)
          {
               _userService = userService;
          }

          [HttpGet]
          public async Task<IActionResult> Purchases()
          {
               // go to User Service and call User Repository and get the Movies Purchased by user who logged in
               var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
               // pass above user id to service
               var purchases = await _userService.GetUserPurchasedMovies(userId);
               return View(purchases);
          }

          [HttpGet]
          public async Task<IActionResult> Favorites()
          {
               // go to User Service and call User Repository and get the Movies Purchased by user who logged in
               var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
               // pass above user id to service
               var favorites = await _userService.GetUserFavoritedMovies(userId);
               return View(favorites);
          }

          [HttpGet]
          public async Task<IActionResult> Profile()
          {
               return View();
          }

          [HttpGet]
          public async Task<IActionResult> EditProfile()
          {
               return View();
          }

     }
}
