using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LostInTheWoods.Factory;
using LostInTheWoods.Models;

namespace LostInTheWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
        public HomeController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            trailFactory = new TrailFactory();
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Trails = trailFactory.FindAll();
            return View();
        }
        [HttpGet]
        [Route("NewTrail")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("AddTrail")]
        public IActionResult Add(Trail trail)
        {
            if(!ModelState.IsValid)
            {
                return View("New");
            }
            trailFactory.Add(trail);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("trail/{id}")]
        public IActionResult Show(int id)
        {
            var trail = trailFactory.FindByID(id);
            ViewBag.Trail = trail.Name;
            return View();
        }
    }
}
