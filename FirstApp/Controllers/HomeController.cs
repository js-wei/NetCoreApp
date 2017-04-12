using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Emgu.CV;
using Emgu.Util;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("_Date") == null)
            {
                HttpContext.Session.SetString("_Date", DateTime.Now.ToString());
            }
            HttpContext.Session.Set<DateTime>("_Date1", DateTime.Now);
            return View();
        }

        public IActionResult About()
        {
            string date = HttpContext.Session.GetString("_Date");
            ViewData["Message"] = $"Your application description page. the session date is {date}";
            return View();
            //DateTime date1 = HttpContext.Session.Get<DateTime>("_Date1");
            //var sessionTime = date1.TimeOfDay.ToString();
            //var currentTime = DateTime.Now.TimeOfDay.ToString();
            //return Content($"Current time: {currentTime} - "
            //+ $"session time: {sessionTime}");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
