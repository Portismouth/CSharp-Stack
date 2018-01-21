using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TheWall.Models;

namespace TheWall.Controllers
{
    public class UserController : Controller
    {
        private readonly DbConnector _dbConnector;
        public UserController(DbConnector connect)
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
                var UserExists = _dbConnector.Query($"SELECT id FROM users WHERE email ='{NewUser.RegisterUser.Email}'");

                if (UserExists.Count == 0)
                {
                    PasswordHasher<Register> hasher = new PasswordHasher<Register>();
                    string HashedPW = hasher.HashPassword(NewUser.RegisterUser, NewUser.RegisterUser.Password);
                    _dbConnector.Query($"INSERT INTO users (first_name, last_name, email, password) VALUES ('{NewUser.RegisterUser.FirstName}', '{NewUser.RegisterUser.LastName}', '{NewUser.RegisterUser.Email}', '{HashedPW}')");

                    var RegUser = _dbConnector.Query($"SELECT id, first_name FROM users WHERE email = '{NewUser.RegisterUser.Email}'");

                    HttpContext.Session.SetInt32("UserId", (int)RegUser[0]["id"]);
                    HttpContext.Session.SetString("name", (string)RegUser[0]["first_name"]);

                    return RedirectToAction("Index", "Message");
                }
                else
                {
                    ViewBag.EmailExists = "That user already exists!";
                    return View("Index");
                }
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserViewModel User)
        {   
            if (!ModelState.IsValid)
            {
                System.Console.WriteLine(ModelState);
                return View("Index");
            }
            else
            {
                var LoggingIn = _dbConnector.Query($"SELECT * FROM users WHERE Email = '{User.LoginUser.Email}'");
                if (LoggingIn.Count == 0)
                {
                    ViewBag.NoUser = "It looks like you need to register!";
                    return View("Index");
                }
                else
                {   
                    PasswordHasher<Login> hasher = new PasswordHasher<Login>();
                    System.Console.WriteLine(hasher.VerifyHashedPassword(User.LoginUser, (string)LoggingIn[0]["password"], User.LoginUser.Password));
                    if (hasher.VerifyHashedPassword(User.LoginUser, (string)LoggingIn[0]["password"], User.LoginUser.Password) == 0)
                    {
                        ViewBag.NoUser = "Invalid Email or Password";
                        return View("Index");
                    }
                    else
                    {
                        //Grabbing User from DB and putting into session
                        var LoggedIn = _dbConnector.Query($"SELECT id, first_name FROM users WHERE Email = '{User.LoginUser.Email}'");
                        HttpContext.Session.SetInt32("UserId", (int)LoggedIn[0]["id"]);
                        HttpContext.Session.SetString("name", (string)LoggedIn[0]["first_name"]);
                        ViewBag.NoUser = "";
                        return RedirectToAction("Index", "Message");
                    }
                }
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
