using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Stripe;
using ecommerce.Models;

namespace ecommerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("products")]
        public IActionResult Index()
        {
            return View();
        }
    }
}