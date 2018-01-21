using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Models;
using DojoLeague.Factory;

namespace DojoLeague.Controllers
{
    public class NinjaController : Controller
    {
        private readonly NinjaFactory ninjaFactory;
        private readonly DojoFactory dojoFactory;
        public NinjaController()
        {
            ninjaFactory = new NinjaFactory();
            dojoFactory = new DojoFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("ninjas")]
        public IActionResult Index()
        {
            ViewBag.Dojos = dojoFactory.FindAll();
            ViewBag.Ninjas = ninjaFactory.FindAll();
            var ninjas = ninjaFactory.FindAll();
            return View();
        }

        [HttpPost]
        [Route("newninja")]
        public IActionResult AddNinja(Ninja ninja, long dojo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Ninjas = ninjaFactory.FindAll();
                return View("Index");
            }
            else
            {
                if(dojo == 0)
                {
                    Dojo AssignedDojo = null;    
                    ninjaFactory.Add(ninja, AssignedDojo);
                    return RedirectToAction("Index");
                }
                else
                {
                    Dojo AssignedDojo = dojoFactory.FindByID(dojo);
                    ninjaFactory.Add(ninja, AssignedDojo);
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        [Route("ninja/{id}")]
        public IActionResult Show(int id)
        {
            var ninja = ninjaFactory.FindByID(id);
            ViewBag.Name = ninja.Name;
            ViewBag.Level = ninja.Level;
            ViewBag.Description = ninja.Description;
            ViewBag.Dojo = ninja.DojoName;
            ViewBag.DojoId = ninja.DojoId;
            return View();
        }
    }
}