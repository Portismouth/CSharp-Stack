using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace portfolio.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("home")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("projects")]
        public IActionResult Projects()
        {
            return View();
        }
        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}