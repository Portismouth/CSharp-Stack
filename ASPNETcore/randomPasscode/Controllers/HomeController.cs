using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojoSurvey.Controllers
{
    public class HomeController : Controller
    {
        private static Random rand = new Random();
        private static int count = 1;

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            TempData["Passcode"] = Generate();
            return View();
        }
        [Route("generate")]
        [HttpGet]
        public string Generate()
        {
            TempData["SessionCount"] = count++;
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string passcode = "";
            for (int idx = 0; idx < 15; idx++)
            {
                int newIdx = rand.Next(chars.Length);
                passcode += chars[newIdx];
            }
            return passcode;
        }
        [Route("reset")]
        [HttpGet]
        public IActionResult Reset()
        {
            count = 1;
            return Redirect("/");
        }
    }
}