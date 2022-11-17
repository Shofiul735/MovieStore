using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VidlyWeb.Models;
using VidlyWeb.ViewModels;

namespace VidlyWeb.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _db;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var movies = _db.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _db.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }
        public IActionResult AddMovie()
        {
            var genre = _db.Genres.ToList();
            var viewModel = new MovieAndGenreViewModel()
            {
                Genres = new List<SelectListItem>()
            };

            foreach (var item in genre)
            {
                viewModel.Genres.Add(new SelectListItem() { Text = item.Name, Value = Convert.ToString(item.Id) });
            }

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMovie(Movie movie)
        {
            if(movie == null)
            {
                return View(movie);
            }
            _db.Movies.Add(movie);
            _db.SaveChanges();
            TempData["MovieAdd"] = "Movie is added successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var movie = _db.Movies.SingleOrDefault(c => c.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            var genre = _db.Genres.ToList();
            var viewModel = new MovieAndGenreViewModel()
            {
                Genres = new List<SelectListItem>(),
                Movie = movie
            };

            foreach (var item in genre)
            {
                viewModel.Genres.Add(new SelectListItem() { Text = item.Name, Value = Convert.ToString(item.Id) });
            }
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if (movie != null)
            {
                _db.Movies.Update(movie);
                _db.SaveChanges();
                TempData["MovieAdd"] = "Movie is Edited successfully";
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        public IActionResult Delete(int id)
        {
            var movie = _db.Movies.SingleOrDefault(c => c.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            _db.Movies.Remove(movie);
            _db.SaveChanges();
            TempData["MovieDeleted"] = $"Movie:- {movie.Name} is deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
