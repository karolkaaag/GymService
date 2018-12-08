using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GymService.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GymService.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string message = "hello, it's me !";

            ViewBag.Message = message.Split('\n');
            return View();
        }
    }
}
