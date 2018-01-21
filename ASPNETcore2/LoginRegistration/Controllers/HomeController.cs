using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LoginRegistration.Models;

namespace LoginRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserViewModel NewUser)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                string Email = '"' + NewUser.RegisterUser.Email + '"';

                var UserExists = _dbConnector.Query($"SELECT * FROM users WHERE Email = {Email}");

                if(UserExists.Count == 0)
                {
                    string FirstName = '"' + NewUser.RegisterUser.FirstName + '"';
                    string LastName = '"' + NewUser.RegisterUser.LastName + '"';
                    string Password = '"' + NewUser.RegisterUser.Password + '"';
                    string createQuery = $"INSERT INTO users (FirstName, LastName, Email, Password) VALUES ({FirstName}, {LastName}, {Email}, {Password})";
                    _dbConnector.Execute(createQuery);
                }
                else
                {
                    ViewBag.EmailExists = "That user already exists!";
                    return View("Index");
                }
            }
            ViewBag.EmailExists = "";
            return RedirectToAction("Registered");
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(UserViewModel User)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                string Email = '"' + User.LoginUser.Email + '"';

                var UserExists = _dbConnector.Query($"SELECT * FROM users WHERE Email = {Email}");

                if (UserExists.Count == 0)
                {
                    ViewBag.NoUser = "It looks like you need to register!";
                    return View("Index");
                }
                else
                {
                    if((string)User.LoginUser.Password != (string)UserExists[0]["Password"])
                    {
                        ViewBag.NoUser = "Invalid Email or Password";
                        return View("Index");
                    }
                    else
                    {
                        ViewBag.NoUser = "";
                        return RedirectToAction("Registered");
                    }
                }
            }
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Registered()
        {
            return View();
        }
    }
}
