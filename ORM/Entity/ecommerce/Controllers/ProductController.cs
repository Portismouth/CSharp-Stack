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
    public class ProductController : Controller
    {
        EcommContext _context;
        public ProductController(EcommContext context)
        {
            _context = context;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("products")]
        public IActionResult Index()
        {
            List<Product> AllProducts = _context.Products.ToList();
            ViewBag.Products = AllProducts;
            return View();
        }

        [HttpGet]
        [Route("products/{id}")]
        public IActionResult Show(int id)
        {
            Product ViewProduct = _context.Products.SingleOrDefault(p => p.ProductId == id);
            ViewBag.Product = ViewProduct;
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult AddProduct(NewProduct product)
        {
            if(ModelState.IsValid)
            {
                Product NewProduct = new Product
                {
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductInventory = product.ProductInventory,
                    ProductImage = product.ProductImage,
                    Created_At = DateTime.Now
                };
                _context.Add(NewProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
    

}