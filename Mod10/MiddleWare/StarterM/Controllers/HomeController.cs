﻿using Microsoft.AspNetCore.Mvc;

namespace StarterM.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine(5);
            return View();
        }
    }
}
