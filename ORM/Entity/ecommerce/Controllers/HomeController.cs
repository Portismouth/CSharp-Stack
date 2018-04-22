using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Stripe;
using ecommerce.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    public class HomeController : Controller
    {
        EcommContext _context;
        public HomeController(EcommContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Product> AllProducts = _context.Products.Take(5).ToList();
            List<Order> RecentOrders = _context.Orders.Include(u => u.User).Include(p => p.Product).Take(5).ToList();
            List<User> RecentUsers = _context.Users.OrderByDescending(u => u.Created_At).Take(3).ToList();
            ViewBag.Customers = RecentUsers;
            ViewBag.Products = AllProducts;
            ViewBag.Orders = RecentOrders;
            return View();
        }
        
        [HttpGet]
        [Route("/search")]
        public IActionResult Result(string query)
        {
            List<Product> ReturnedProducts = _context.Products.Where(p => p.ProductName.ToLower().Contains(query)).ToList();

            ViewBag.Products = ReturnedProducts;
            return View();
        }
    }
}
