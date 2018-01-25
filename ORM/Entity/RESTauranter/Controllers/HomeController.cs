using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;
using System.Linq;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        RESTContext _context;

        public HomeController(RESTContext context)
        {
            _context = context;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(Review review)
        {
            if(!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                Review NewReview = new Review
                {
                    ReviewerName = review.ReviewerName, 
                    RestName = review.RestName,
                    RestReview = review.RestReview,
                    VisitDate = review.VisitDate,
                    Rating = review.Rating
                };

                _context.Add(NewReview);
                _context.SaveChanges();
                return RedirectToAction("Show");
            }
        }
        
        [HttpGet]
        [Route("reviews")]
        public IActionResult Show()
        {
            List<Review> AllReviews = _context.Entries.ToList();
            ViewBag.Review = AllReviews;
            foreach(var review in AllReviews)
            {
                System.Console.WriteLine(review);
            }
            return View();
        }
    }
}
