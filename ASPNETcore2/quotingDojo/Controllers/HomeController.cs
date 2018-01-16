using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace testCandy.Controllers
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
        [Route("post")]
        public IActionResult post(string name, string quote)
        {
            string qName = '"' + name + '"';
            string qQuote = '"' + quote + '"';
            System.Console.WriteLine(qName);
            string insertQuery = $"INSERT INTO quotes (name, quote) VALUES ({qName}, {qQuote})";
            System.Console.WriteLine(insertQuery);
            DbConnector.Execute(insertQuery);
            
            return RedirectToAction("quotes");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            var quotes = DbConnector.Query("SELECT * FROM quotes");
            ViewBag.Quotes = quotes;
            return View();
        }
    }
}
