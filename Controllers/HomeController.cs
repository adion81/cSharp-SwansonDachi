using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwansonDachi.Models;
using Microsoft.AspNetCore.Http;

namespace SwansonDachi.Controllers
{
    public class HomeController : Controller
    {
        public static Swanson Ron;

        [HttpGet("")]
        public IActionResult Index()
        {
            Ron = new Swanson();
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("Message","Welcome, here is your very own Ron Swanson, please treat him well.");
            ViewBag.Message = HttpContext.Session.GetString("Message");
            return View(Ron);
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            ViewBag.Message = Ron.Play();
            if(Ron.didWin)
            {
                return View("Success",Ron);
            }
            else if(Ron.didLose)
            {
                return View("Kill",Ron);
            }
            return View("Index",Ron);
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            ViewBag.Message = Ron.Feed();
            if(Ron.didWin)
            {
                return View("Success",Ron);
            }
            else if(Ron.didLose)
            {
                return View("Kill",Ron);
            }
            return View("Index",Ron);
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            ViewBag.Message = Ron.Sleep();
            if(Ron.didWin)
            {
                return View("Success",Ron);
            }
            else if(Ron.didLose)
            {
                return View("Kill",Ron);
            }
            return View("Index",Ron);
        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            ViewBag.Message = Ron.Work();
            if(Ron.didWin)
            {
                return View("Success",Ron);
            }
            else if(Ron.didLose)
            {
                return View("Kill",Ron);
            }
            return View("Index",Ron);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
