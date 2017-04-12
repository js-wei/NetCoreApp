using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstApp.Controllers
{
    public class AboutController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public string Welcome(string name, int ID = 1)
        {
            var date = HttpContext.Session.Get("_Date").ToString();
            return $"Session Date {date},now Date {DateTime.Now.ToString()}";
            //return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}
