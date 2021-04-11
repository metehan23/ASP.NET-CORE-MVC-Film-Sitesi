using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Web.Data;
using MovieProject.Web.Entity;
using MovieProject.Web.Models;

namespace MovieProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;
        public HomeController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new HomePageVm
            {
                PopularMovies = _context.Movies.ToList()
            };
            return View(model);
        }
        public IActionResult About()
        {            
            return View();
        }
    }
}