using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Stripe;
using ecommerce.Models;
using System.Linq;

namespace ecommerce.Controllers
{
    public class CustomerController : Controller
    {
        EcommContext _context;
        public CustomerController(EcommContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("customers")]
        public IActionResult Index()
        {
            List<User> AllUsers = _context.Users.ToList();
            ViewBag.Customers = AllUsers;
            return View();
        }

        [HttpPost]
        [Route("customers/new")]
        public IActionResult NewCustomer(string name)
        {
            User Newuser = new User
            {
                FirstName = name,
                Created_At = DateTime.Now
            };
            _context.Add(Newuser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
