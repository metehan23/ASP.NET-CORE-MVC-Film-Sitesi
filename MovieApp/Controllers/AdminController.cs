using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
using MovieProject.Web.Data;
using MovieProject.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieContext _context;
        public AdminController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MovieUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _context.Movies.Select(m => new AdminEditMovieVM
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
                SelectedGenres = m.Genre.Name
            }).FirstOrDefault(m => m.MovieId == id);

            ViewBag.Genre = _context.Genres.ToList();

            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [HttpPost]
        public IActionResult MovieUpdate(AdminEditMovieVM model, int[] genreIds)
        {
            var entity = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.MovieId == model.MovieId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;

            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
        public IActionResult MovieList()
        {
            return View(new AdminMoviesVm
            {
                Movies = _context.Movies.Include(m => m.Genre).ToList()
            });
        }
        public IActionResult GenreList()
        {
            return View(new AdminGenresVm
            {
                Genres=_context.Genres.Select(g=>new AdminGenreVm
                {
                    GenreId=g.GenreId,
                    Name=g.Name,
                    Count=g.Movies.Count()
                }).ToList()
            });
        }
    }
}
