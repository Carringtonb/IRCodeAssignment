using System;
using System.Collections.Generic;
using IRGraduateAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace IRGraduateAssignment.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int startyear, int endYear)
        {

            return RedirectToAction("Results");

        }

        public IActionResult Results()
        {
            List<XMLReader.SystemUnit> systemUnit = XMLReader.ReadFile();
            return View(systemUnit);
        }
    }
}
