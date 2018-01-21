using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Models;
using DojoLeague.Factory;

namespace DojoLeague.Controllers
{
    public class DojoController : Controller
    {
        private readonly DojoFactory dojoFactory;
        private readonly NinjaFactory ninjaFactory;
        public DojoController()
        {
            dojoFactory = new DojoFactory();
            ninjaFactory = new NinjaFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("dojos")]
        public IActionResult Index()
        {
            //We can call upon the methods of the userFactory directly now.
            ViewBag.Dojos = dojoFactory.FindAll();
            return View();
        }

        [HttpPost]
        [Route("newdojo")]
        public IActionResult AddDojo(Dojo dojo)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Dojos = dojoFactory.FindAll();
                return View("Index");
            }
            else
            {
                dojoFactory.Add(dojo);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("dojo/{id}")]
        public IActionResult Show(int id)
        {
            var dojo = dojoFactory.FindByID(id);
            ViewBag.Id = dojo.Id;
            ViewBag.Name = dojo.Name;
            ViewBag.Location = dojo.Location;
            ViewBag.Description = dojo.Description;
            ViewBag.Members = dojoFactory.FindByID(id).ninjas;
            ViewBag.Rogues = ninjaFactory.FindAllRogues();
            return View();
        }

        [HttpGet]
        [Route("recruit/{id}/{dojo_id}")]
        public IActionResult Recruit(int id, int dojo_id)
        {
            ninjaFactory.Recruit(id, dojo_id);
            return Redirect($"/dojo/{dojo_id}");
        }

        [HttpGet]
        [Route("banish/{id}/{dojo_id}")]
        public IActionResult Banish(int id, int dojo_id)
        {
            ninjaFactory.Banish(id);
            return Redirect($"/dojo/{dojo_id}");
        }
    }
}
