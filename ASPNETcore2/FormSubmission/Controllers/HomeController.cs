using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        public ActionResult Index(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return RedirectToAction("Result");
        }

        [HttpGet]
        [Route("result")]
        public IActionResult Result()
        {
            return View();
        }
    }
}
