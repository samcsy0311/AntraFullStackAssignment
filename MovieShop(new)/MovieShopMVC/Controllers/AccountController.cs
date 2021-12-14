using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
     public class AccountController : Controller
     {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
               _accountService = accountService;
        }

        // account/register
        [HttpGet]
          public async Task<IActionResult> Register()
          {
               return View();
          }

          [HttpPost]
          public async Task<IActionResult> Register(UserRegisterRequestModel registerRequestModel)
          {
               // we need to send the data to service , which is gonna convert in to User entity and send it to User Repository
               // save the data in the User table

               var user = await _accountService.RegisterUser(registerRequestModel);

               if (user == 0)
               {
                    // email already exist
                    return View();
               }
               return RedirectToAction("Login");
          }

          [HttpGet]
          public async Task<IActionResult> Login()
          {
               return View();
          }

          [HttpPost]
          public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
          {
               var user = await _accountService.ValidateUser(loginRequestModel);
               if(user == null)
               {
                    // hey please check your email
                    // send message to the view saying please enter correct email/password
               }

               // we need to create a cookie => will have information Claims (MovieShopAuthCookie)
               // claims will have (FirstName, LastName, TimeZone)
               // We usually encrypt the data we store in cookies
               // Cookie Based Authentication
               // Cookie will have expiration time
               // Cookie => Browser 
               
               //redirect to homepage
               //
               return View();
          }

     }
}
