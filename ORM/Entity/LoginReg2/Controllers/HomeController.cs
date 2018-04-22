using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using LoginReg2.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace LoginReg2.Controllers
{
    public class HomeController : Controller
    {
        LoginReg2Context _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public HomeController(LoginReg2Context context, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("home")]
        public IActionResult UserHome()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Create a new User object, without adding a Password
                User NewUser = new User { UserName = model.RegisterUser.Email, Email = model.RegisterUser.Email };
                //CreateAsync will attempt to create the User in the database, simultaneously hashing the
                //password
                IdentityResult result = await _userManager.CreateAsync(NewUser, model.RegisterUser.Password);
                //If the User was added to the database successfully
                if (result.Succeeded)
                {
                    HttpContext.Session.SetString("UserId", NewUser.Id);
                    //Sign In the newly created User
                    //We're using the SignInManager, not the UserManager!
                    await _signInManager.SignInAsync(NewUser, isPersistent: false);
                    return RedirectToAction("UserHome");
                }
                //If the creation failed, add the errors to the View Model
                foreach (var error in result.Errors)
                {

                    ModelState.AddModelError(string.Empty, error.Description);
                    TempData["PWError"] = error.Description;
                    return View("Index");
                }
            }
            System.Console.WriteLine(ModelState.ErrorCount);
            return View("Index");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User LoggingIn = _context.users.Where(u => u.Email == model.LoginUser.Email).SingleOrDefault();
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.LoginUser.Email, model.LoginUser.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserHome");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    TempData["PWError"] = "Invalid login attempt.";
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
