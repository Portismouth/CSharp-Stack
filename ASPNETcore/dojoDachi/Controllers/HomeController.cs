using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojoDachi.Controllers
{
    
    public class HomeController : Controller
    {
        Dictionary<string, string> feedMe = new Dictionary<string, string>();
        Random rand = new Random();

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            TempData["gameStatus"] = "playing";
            TempData["image"] = "/images/1f642.png";
            // TempData["fullness"] = FeedJS();
            int? fullness = HttpContext.Session.GetInt32("fullness");
            if(fullness == null)
            {
                HttpContext.Session.SetInt32("fullness", 20);
                TempData["fullness"] = 20;
                TempData["message"] = "Hi! Meet your Dojodachi!";
            }
            else
            {
                TempData["fullness"] = FeedJS();
            }
            // int? fullness = HttpContext.Session.GetInt32("fullness");
            // if(fullness == null)
            // {
            //     HttpContext.Session.SetInt32("fullness", 20);
            //     TempData["fullness"] = 20;
            //     TempData["message"] = "Hi! Meet your Dojodachi!";
            // }
            // else
            // {
            //     // TempData["fullness"] = FeedJS();
            //     TempData["fullness"] = fullness;
            //     // TempData["image"] = "/images/1f917.png";
            // }
            int? happiness = HttpContext.Session.GetInt32("happiness");
            if(happiness == null)
            {
                HttpContext.Session.SetInt32("happiness", 20);
                TempData["happiness"] = 20;
            }
            else
            {
                TempData["happiness"] = happiness;
            }
            int? meals = HttpContext.Session.GetInt32("meals");
            if(meals == null)
            {
                HttpContext.Session.SetInt32("meals", 3);
                TempData["meals"] = 3;
            }
            else
            {
                int? meal = HttpContext.Session.GetInt32("meals") - 1;
                TempData["meals"] = meal;
            }
            int? energy = HttpContext.Session.GetInt32("energy");
            if (energy == null)
            {
                HttpContext.Session.SetInt32("energy", 50);
                TempData["energy"] = 50;
            }
            else
            {
                TempData["energy"] = energy;
            }
            // if(energy > 100 && fullness > 100 && happiness > 100)
            // {
            //     TempData["message"] = "You win!!!";
            //     TempData["image"] = "/images/1f60d.png";
            //     TempData["gameStatus"] = "over";
            // }
            // if(fullness <= 0 || happiness <= 0)
            // {
            //     TempData["message"] = "Your Dojodachi has passed away... :(";
            //     TempData["image"] = "/images/1f635.png";
            //     TempData["gameStatus"] = "over";
            // }
            return View();
        }
        
        [Route("feedjs")]
        [HttpGet]
        public object FeedJS()
        {
            // if (fullness == null)
            // {
            //     HttpContext.Session.SetInt32("fullness", 20);
            //     TempData["fullness"] = 20;
            //     TempData["message"] = "Hi! Meet your Dojodachi!";
                
            //     //add attributes to dict feedMe for AJAX
            //     feedMe.Add("fullness", Convert.ToString(TempData["fullness"]));
            //     feedMe.Add("message", (string)TempData["message"]);
            //     feedMe.Add("img", (string)TempData["image"]);
            //     return feedMe;
            // }

            int? fullness = HttpContext.Session.GetInt32("fullness");
            int fill = rand.Next(5, 11);
            int chance = rand.Next(1, 5);
            HttpContext.Session.SetInt32("meals", 3);
            int? meals = HttpContext.Session.GetInt32("meals");
            TempData["meals"] = meals;

            if(meals > 0)
            {
                if(chance == 1)
                {
                    int? meal = HttpContext.Session.GetInt32("meals") - 1;
                    HttpContext.Session.SetInt32("meals", (int)meal);
                    int? mealCount = HttpContext.Session.GetInt32("meals");
                    TempData["meals"] = mealCount;
                    TempData["message"] = $"BOOO! Your Dojodachi didn't like it's meal.";
                    TempData["image"] = "/images/1f922.png";

                    //add attributes to dict feedMe for AJAX
                    feedMe.Add("message", (string)TempData["message"]);
                    feedMe.Add("img", (string)TempData["image"]);
                    feedMe.Add("meals", Convert.ToString(TempData["meals"]));
                    
                    //returns Dictionary
                    return feedMe;
                }
                else
                {
                    int? meal = HttpContext.Session.GetInt32("meals") - 1;
                    HttpContext.Session.SetInt32("meals", (int)meal);
                    int? _fullness = HttpContext.Session.GetInt32("fullness") + fill;
                    HttpContext.Session.SetInt32("fullness", (int)_fullness);
                    int? mealCount = HttpContext.Session.GetInt32("meals");
                    TempData["meals"] = mealCount;
                    TempData["fullness"] = fullness;
                    TempData["image"] = "/images/1f917.png";
                    TempData["message"] = $"NOM NOM! You just fed your Dojodachi. Fullness +{fill}";
                    
                    //add attributes to dict feedMe for AJAX
                    feedMe.Add("fullness", Convert.ToString(TempData["fullness"]));
                    feedMe.Add("message", (string)TempData["message"]);
                    feedMe.Add("img", (string)TempData["image"]);
                    feedMe.Add("meals", Convert.ToString(TempData["meals"]));
                    
                    //returns Dictionary
                    return feedMe;
                }
            }
            else
            {
                TempData["message"] = "You have no more meals to feed your Dojodachi!";
                TempData["image"] = "/images/1f615.png";
                int? mealCount = HttpContext.Session.GetInt32("meals");
                TempData["meals"] = mealCount;

                //add attributes to dict feedMe for AJAX
                feedMe.Add("fullness", Convert.ToString(TempData["fullness"]));
                feedMe.Add("message", (string)TempData["message"]);
                feedMe.Add("img", (string)TempData["image"]);
                feedMe.Add("meals", Convert.ToString(TempData["meals"]));
                
                //returns Dictionary
                return feedMe;
            }
        }

        [Route("feed")]
        [HttpGet]
        public IActionResult Feed()
        {
            Random rand = new Random();
            int fill = rand.Next(5, 11);
            int chance = rand.Next(1, 5);
            int? meals = HttpContext.Session.GetInt32("meals");
            if(meals > 0)
            {
                if(chance == 1)
                {
                    int? meal = HttpContext.Session.GetInt32("meals") - 1;
                    HttpContext.Session.SetInt32("meals", (int)meal);
                    TempData["message"] = $"BOOO! Your Dojodachi didn't like it's meal.";
                    TempData["image"] = "/images/1f922.png";
                }
                else
                {
                    int? meal = HttpContext.Session.GetInt32("meals") - 1;
                    HttpContext.Session.SetInt32("meals", (int)meal);
                    int? fullness = HttpContext.Session.GetInt32("fullness") + fill;
                    HttpContext.Session.SetInt32("fullness", (int)fullness);
                    TempData["message"] = $"NOM NOM! You just fed your Dojodachi. Fullness +{fill}";
                }
            }
            else
            {
                TempData["message"] = "You have no more meals to feed your Dojodachi!";
            }

            return RedirectToAction("Index");
        }

        [Route("playjs")]
        [HttpGet]
        public int? PlayJS()
        {
            Random rand = new Random();
            int chance = rand.Next(1, 5);
            int? energy = HttpContext.Session.GetInt32("energy");
            int affect = rand.Next(5, 11);
            if (energy > 0)
            {
                if (chance == 1)
                {
                    int? _energy = HttpContext.Session.GetInt32("energy") - 5;
                    HttpContext.Session.SetInt32("energy", (int)_energy);
                    TempData["message"] = $"BOOO! Your Dojodachi didn't feel like playing.";
                }
                else
                {
                    int? _energy = HttpContext.Session.GetInt32("energy") - 5;
                    HttpContext.Session.SetInt32("energy", (int)_energy);
                    int? happiness = HttpContext.Session.GetInt32("happiness") + affect;
                    HttpContext.Session.SetInt32("happiness", (int)happiness);
                    TempData["message"] = $"YIPEE! You just played with your Dojodachi. Happiness +{affect}";
                }
            }
            else
            {
                TempData["message"] = "You're Dojodachi is too tired to play... Try sleeping";
            }
            return energy;
        }

        [Route("play")]
        [HttpGet]
        public IActionResult Play()
        {
            Random rand = new Random();
            int affect = rand.Next(5, 11);
            int chance = rand.Next(1, 5);
            int? energy = HttpContext.Session.GetInt32("energy");
            if (energy > 0)
            {
                if(chance == 1)
                {
                    int? _energy = HttpContext.Session.GetInt32("energy") - 5;
                    HttpContext.Session.SetInt32("energy", (int)_energy);
                    TempData["message"] = $"BOOO! Your Dojodachi didn't feel like playing.";
                }
                else
                {
                    int? _energy = HttpContext.Session.GetInt32("energy") - 5;
                    HttpContext.Session.SetInt32("energy", (int)_energy);
                    int? happiness = HttpContext.Session.GetInt32("happiness") + affect;
                    HttpContext.Session.SetInt32("happiness", (int)happiness);
                    TempData["message"] = $"YIPEE! You just played with your Dojodachi. Happiness +{affect}";
                }
            }
            else
            {
                TempData["message"] = "You're Dojodachi is too tired to play... Try sleeping";
            }

            return RedirectToAction("Index");
        }
        [Route("work")]
        [HttpGet]
        public IActionResult Work()
        {
            Random rand = new Random();
            int affect = rand.Next(1, 4);
            int? energy = HttpContext.Session.GetInt32("energy");
            if (energy > 0)
            {
                int? _energy = HttpContext.Session.GetInt32("energy") - 5;
                HttpContext.Session.SetInt32("energy", (int)_energy);
                int? meals = HttpContext.Session.GetInt32("meals") + affect;
                HttpContext.Session.SetInt32("meals", (int)meals);
                TempData["message"] = $"Your Dojodachi just worked to earn {affect} meals.";
            }
            else
            {
                TempData["message"] = "Your Dojodachi is too tired to work... Try sleeping";
            }

            return RedirectToAction("Index");
        }
        [Route("sleep")]
        [HttpGet]
        public IActionResult Sleep()
        {
            int? energy = HttpContext.Session.GetInt32("energy");
            int? _energy = HttpContext.Session.GetInt32("energy") + 15;
            HttpContext.Session.SetInt32("energy", (int)_energy);
            int? fullness = HttpContext.Session.GetInt32("fullness") - 5;
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            int? happiness = HttpContext.Session.GetInt32("happiness") - 5;
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            TempData["message"] = $"Your Dojodachi just slept and gained 15 energy.";

            return RedirectToAction("Index");
        }
        [Route("reset")]
        [HttpGet]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}