using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AjaxNotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var notes = _dbConnector.Query("SELECT * FROM notes");
            ViewBag.Notes = notes;

            return View();
        }

        [HttpPost]
        [Route("create")]
        public object Create(Dictionary<string,string> newNote)
        {
            if (String.IsNullOrEmpty(newNote["name"]) || String.IsNullOrEmpty(newNote["desc"]))
            {
                return new 
                {
                    error = "Please enter a value!",
                    success = false 
                };
            }
            else
            {
                string nName = '"' + newNote["name"] + '"';
                string nDesc = '"' + newNote["desc"] + '"';
                string insertQuery = $"INSERT INTO notes (note, description) VALUES ({nName}, {nDesc})";
                _dbConnector.Execute(insertQuery);
                var newNotes = _dbConnector.Query("SELECT * FROM notes WHERE id = (SELECT MAX(ID) FROM notes)");

                return newNotes;
            }
        }

        // [HttpPost]
        // [Route("create")]
        // public IActionResult Create(string name)
        // {
            
        //     string nName = '"' + name + '"';
        //     string insertQuery =$"INSERT INTO notes (note) VALUES ({nName})";
        //     DbConnector.Execute(insertQuery);
            
        //     return RedirectToAction("Index");
        // }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(string desc, int id)
        {

            string description = '"' + desc + '"';
            string updateQuery = $"UPDATE notes SET description = {description} WHERE id = {id}";
            System.Console.WriteLine(updateQuery);
            _dbConnector.Execute(updateQuery);

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult delete(int id)
        {

            string deleteQuery = $"DELETE FROM notes WHERE id = {id}";
            System.Console.WriteLine(deleteQuery);
            _dbConnector.Execute(deleteQuery);

            return RedirectToAction("Index");
        }
    }
}
