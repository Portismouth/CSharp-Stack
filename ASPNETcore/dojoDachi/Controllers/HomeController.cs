using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojoDachi.Controllers
{
    public class HomeController : Controller
    {
        public static Dictionary<string, string> dojodachi = new Dictionary<string, string>();
        public static Random rand = new Random();

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            TempData["gameStatus"] = "playing";
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? meals = HttpContext.Session.GetInt32("meals");
            if(fullness == null && meals == null)
            {
                HttpContext.Session.SetInt32("fullness", 20);
                HttpContext.Session.SetInt32("meals", 3);
                TempData["fullness"] = HttpContext.Session.GetInt32("fullness");
                TempData["meals"] = HttpContext.Session.GetInt32("meals");
                TempData["message"] = "Hi! Meet your Dojodachi!";
                TempData["image"] = "/images/1f642.png";

                dojodachi.Add("fullness", Convert.ToString(TempData["fullness"]));
                dojodachi.Add("meals", Convert.ToString(TempData["meals"]));
                dojodachi.Add("message", (string)TempData["message"]);
                dojodachi.Add("image", (string)TempData["image"]);
            }
            else
            {
                TempData["fullness"] = fullness;
                TempData["meals"] = meals;
            }
            int? happiness = HttpContext.Session.GetInt32("happiness");
            if(happiness == null)
            {
                HttpContext.Session.SetInt32("happiness", 20);
                TempData["happiness"] = HttpContext.Session.GetInt32("happiness");

                dojodachi.Add("happiness", Convert.ToString(TempData["happiness"]));
            }
            else
            {
                TempData["happiness"] = happiness;
            }
            int? energy = HttpContext.Session.GetInt32("energy");
            if (energy == null)
            {
                HttpContext.Session.SetInt32("energy", 50);
                TempData["energy"] = HttpContext.Session.GetInt32("energy");

                dojodachi.Add("energy", Convert.ToString(TempData["energy"]));
            }
            else
            {
                TempData["energy"] = energy;
            }

            int _fullness = Convert.ToInt32(dojodachi["fullness"]);
            if(_fullness <= 0 || happiness <= 0)
            {
                TempData["message"] = "Your Dojodachi has passed away... :(";
                TempData["image"] = "/images/1f635.png";
                TempData["gameStatus"] = "over";

                dojodachi["message"] = (string)TempData["message"];
                dojodachi["image"] = (string)TempData["image"];
            }
            if(energy > 100 && fullness > 100 && happiness > 100)
            {
                TempData["message"] = "You win!!!";
                TempData["image"] = "/images/1f60d.png";
                TempData["gameStatus"] = "over";
            }
            return View();
        }

        [Route("feedJS")]
        [HttpGet]
        public object FeedJS()
        {
            int fill = rand.Next(5, 11);
            int chance = rand.Next(1, 5);
            int? meals = HttpContext.Session.GetInt32("meals");
            if (meals > 0)
            {
                if (chance == 1)
                {
                    int? meal = HttpContext.Session.GetInt32("meals") - 1;
                    HttpContext.Session.SetInt32("meals", (int)meal);
                    TempData["message"] = $"BOOO! Your Dojodachi didn't like it's meal.";
                    TempData["image"] = "/images/1f922.png";

                    dojodachi["message"] = (string)TempData["message"];
                    dojodachi["meals"] = Convert.ToString(HttpContext.Session.GetInt32("meals"));
                    dojodachi["image"] = (string)TempData["image"];
                }
                else
                {
                    int? meal = HttpContext.Session.GetInt32("meals") - 1;
                    HttpContext.Session.SetInt32("meals", (int)meal);
                    int? fullness = HttpContext.Session.GetInt32("fullness") + fill;
                    HttpContext.Session.SetInt32("fullness", (int)fullness);
                    TempData["message"] = $"NOM NOM! You just fed your Dojodachi. Fullness +{fill}";
                    TempData["image"] = "/images/1f917.png";

                    dojodachi["message"] = (string)TempData["message"];
                    dojodachi["meals"] = Convert.ToString(HttpContext.Session.GetInt32("meals"));
                    dojodachi["fullness"] = Convert.ToString(HttpContext.Session.GetInt32("fullness"));
                    dojodachi["image"] = (string)TempData["image"];
                }
            }
            else
            {
                TempData["message"] = "You have no more meals to feed your Dojodachi!";
                dojodachi["message"] = (string)TempData["message"];
            }

            return dojodachi;
        }

        // [Route("feed")]
        // [HttpGet]
        // public IActionResult Feed()
        // {
        //     int fill = rand.Next(5, 11);
        //     int chance = rand.Next(1, 5);
        //     int? meals = HttpContext.Session.GetInt32("meals");
        //     if(meals > 0)
        //     {
        //         if(chance == 1)
        //         {
        //             int? meal = HttpContext.Session.GetInt32("meals") - 1;
        //             HttpContext.Session.SetInt32("meals", (int)meal);
        //             TempData["message"] = $"BOOO! Your Dojodachi didn't like it's meal.";
        //             TempData["image"] = "/images/1f922.png";
        //         }
        //         else
        //         {
        //             int? meal = HttpContext.Session.GetInt32("meals") - 1;
        //             HttpContext.Session.SetInt32("meals", (int)meal);
        //             int? fullness = HttpContext.Session.GetInt32("fullness") + fill;
        //             HttpContext.Session.SetInt32("fullness", (int)fullness);
        //             TempData["message"] = $"NOM NOM! You just fed your Dojodachi. Fullness +{fill}";
        //         }
        //     }
        //     else
        //     {
        //         TempData["message"] = "You have no more meals to feed your Dojodachi!";
        //     }

        //     return RedirectToAction("Index");
        // }

        [Route("playJS")]
        [HttpGet]
        public object PlayJS()
        {
            int affect = rand.Next(5, 11);
            int chance = rand.Next(1, 5);
            int? energy = HttpContext.Session.GetInt32("energy");
            if (energy > 0)
            {
                if (chance == 1)
                {
                    int? _energy = HttpContext.Session.GetInt32("energy") - 5;
                    HttpContext.Session.SetInt32("energy", (int)_energy);
                    TempData["energy"] = HttpContext.Session.GetInt32("energy");
                    TempData["message"] = $"BOOO! Your Dojodachi didn't feel like playing.";
                    TempData["image"] = "/images/1f612.png";

                    dojodachi["energy"] = Convert.ToString(TempData["energy"]);
                    dojodachi["message"] = (string)TempData["message"];
                    dojodachi["image"] = (string)TempData["image"];
                }
                else
                {
                    int? _energy = HttpContext.Session.GetInt32("energy") - 5;
                    HttpContext.Session.SetInt32("energy", (int)_energy);
                    int? happiness = HttpContext.Session.GetInt32("happiness") + affect;
                    HttpContext.Session.SetInt32("happiness", (int)happiness);

                    TempData["energy"] = HttpContext.Session.GetInt32("energy");
                    TempData["happiness"] = HttpContext.Session.GetInt32("happiness");
                    TempData["message"] = $"YIPEE! You just played with your Dojodachi. Happiness +{affect}";
                    TempData["image"] = "/images/1f606.png";

                    dojodachi["energy"] = Convert.ToString(TempData["energy"]);
                    dojodachi["happiness"] = Convert.ToString(TempData["happiness"]);
                    dojodachi["message"] = (string)TempData["message"];
                    dojodachi["image"] = (string)TempData["image"];
                }
            }
            else
            {
                TempData["message"] = "You're Dojodachi is too tired to play... Try sleeping";

                dojodachi["message"] = (string)TempData["message"];
            }

            return dojodachi;
        }

        // [Route("play")]
        // [HttpGet]
        // public IActionResult Play()
        // {
        //     int affect = rand.Next(5, 11);
        //     int chance = rand.Next(1, 5);
        //     int? energy = HttpContext.Session.GetInt32("energy");
        //     if (energy > 0)
        //     {
        //         if(chance == 1)
        //         {
        //             int? _energy = HttpContext.Session.GetInt32("energy") - 5;
        //             HttpContext.Session.SetInt32("energy", (int)_energy);
        //             TempData["message"] = $"BOOO! Your Dojodachi didn't feel like playing.";
        //         }
        //         else
        //         {
        //             int? _energy = HttpContext.Session.GetInt32("energy") - 5;
        //             HttpContext.Session.SetInt32("energy", (int)_energy);
        //             int? happiness = HttpContext.Session.GetInt32("happiness") + affect;
        //             HttpContext.Session.SetInt32("happiness", (int)happiness);
        //             TempData["message"] = $"YIPEE! You just played with your Dojodachi. Happiness +{affect}";
        //         }
        //     }
        //     else
        //     {
        //         TempData["message"] = "You're Dojodachi is too tired to play... Try sleeping";
        //     }

        //     return RedirectToAction("Index");
        // }

        [Route("workJS")]
        [HttpGet]
        public object WorkJS()
        {
            int affect = rand.Next(1, 4);
            int? energy = HttpContext.Session.GetInt32("energy");
            if (energy > 0)
            {
                int? _energy = HttpContext.Session.GetInt32("energy") - 5;
                HttpContext.Session.SetInt32("energy", (int)_energy);
                int? meals = HttpContext.Session.GetInt32("meals") + affect;
                HttpContext.Session.SetInt32("meals", (int)meals);

                TempData["message"] = $"Your Dojodachi just worked to earn {affect} meals.";
                TempData["energy"] = HttpContext.Session.GetInt32("energy");
                TempData["meals"] = HttpContext.Session.GetInt32("meals");
                TempData["image"] = "/images/1f615.png";

                dojodachi["energy"] = Convert.ToString(TempData["energy"]);
                dojodachi["meals"] = Convert.ToString(TempData["meals"]);
                dojodachi["message"] = (string)TempData["message"];
                dojodachi["image"] = (string)TempData["image"];

            }
            else
            {
                TempData["message"] = "Your Dojodachi is too tired to work... Try sleeping";
                TempData["image"] = "/images/1f634.png";

                dojodachi["message"] = (string)TempData["message"];
                dojodachi["image"] = (string)TempData["image"];
            }

            return dojodachi;
        }

        // [Route("work")]
        // [HttpGet]
        // public IActionResult Work()
        // {
        //     int affect = rand.Next(1, 4);
        //     int? energy = HttpContext.Session.GetInt32("energy");
        //     if (energy > 0)
        //     {
        //         int? _energy = HttpContext.Session.GetInt32("energy") - 5;
        //         HttpContext.Session.SetInt32("energy", (int)_energy);
        //         int? meals = HttpContext.Session.GetInt32("meals") + affect;
        //         HttpContext.Session.SetInt32("meals", (int)meals);
        //         TempData["message"] = $"Your Dojodachi just worked to earn {affect} meals.";
        //     }
        //     else
        //     {
        //         TempData["message"] = "Your Dojodachi is too tired to work... Try sleeping";
        //     }

        //     return RedirectToAction("Index");
        // }

        [Route("sleepJS")]
        [HttpGet]
        public object SleepJS()
        {
            int? fullnessCheck = HttpContext.Session.GetInt32("fullness");
            if (fullnessCheck <= 0)
            {
                TempData["message"] = "Your Dojodachi has passed away... :(";
                TempData["image"] = "/images/1f635.png";
                TempData["gameStatus"] = "over";

                dojodachi["message"] = (string)TempData["message"];
                dojodachi["image"] = (string)TempData["image"];
            }
            else
            {
                int? energy = HttpContext.Session.GetInt32("energy") + 15;
                HttpContext.Session.SetInt32("energy", (int)energy);
                int? fullness = HttpContext.Session.GetInt32("fullness") - 5;
                HttpContext.Session.SetInt32("fullness", (int)fullness);
                int? happiness = HttpContext.Session.GetInt32("happiness") - 5;
                HttpContext.Session.SetInt32("happiness", (int)happiness);

                TempData["message"] = $"Your Dojodachi just slept and gained 15 energy.";
                TempData["energy"] = HttpContext.Session.GetInt32("energy");
                TempData["fullness"] = HttpContext.Session.GetInt32("fullness");
                TempData["happiness"] = HttpContext.Session.GetInt32("happiness");
                TempData["image"] = "/images/1f634.png";

                dojodachi["message"] = (string)TempData["message"];
                dojodachi["energy"] = Convert.ToString(TempData["energy"]);
                dojodachi["fullness"] = Convert.ToString(TempData["fullness"]);
                dojodachi["happiness"] = Convert.ToString(TempData["happiness"]);
                dojodachi["image"] = (string)TempData["image"];
            }
            return dojodachi;
        }

        // [Route("sleep")]
        // [HttpGet]
        // public IActionResult Sleep()
        // {
        //     int? energy = HttpContext.Session.GetInt32("energy");
        //     int? _energy = HttpContext.Session.GetInt32("energy") + 15;
        //     HttpContext.Session.SetInt32("energy", (int)_energy);
        //     int? fullness = HttpContext.Session.GetInt32("fullness") - 5;
        //     HttpContext.Session.SetInt32("fullness", (int)fullness);
        //     int? happiness = HttpContext.Session.GetInt32("happiness") - 5;
        //     HttpContext.Session.SetInt32("happiness", (int)happiness);
        //     TempData["message"] = $"Your Dojodachi just slept and gained 15 energy.";

        //     return RedirectToAction("Index");
        // }

        [Route("reset")]
        [HttpGet]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            Dictionary<string, string> dojodachi = new Dictionary<string, string>();
            return RedirectToAction("Index");
        }
    }
}