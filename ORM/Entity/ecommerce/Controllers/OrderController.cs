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
    public class OrderController : Controller
    {
        EcommContext _context;
        public OrderController(EcommContext context)
        {
            _context = context;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("order")]
        public IActionResult Index()
        {
            List<Order> AllOrders = _context.Orders.OrderByDescending(o => o.Created_At).Include(u => u.User).Include(p => p.Product).ToList();
            List<User> AllUsers = _context.Users.ToList();
            List<Product> AllProducts = _context.Products.ToList();
            ViewBag.Customers = AllUsers;
            ViewBag.Products = AllProducts;
            ViewBag.Orders = AllOrders;
            return View();
        }

        [HttpPost]
        [Route("order/new")]
        public IActionResult Order(Order order, int UserId, int ProductId, int Quantity)
        {
            Product Ordered = _context.Products.SingleOrDefault(p => p.ProductId == ProductId);
            Order NewOrder = new Order
            {
                ProductId = ProductId, 
                UserId = UserId,
                Quantity = Quantity,
                Created_At = DateTime.Now
            };
            Ordered.ProductInventory -= Quantity;
            _context.Add(NewOrder);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
