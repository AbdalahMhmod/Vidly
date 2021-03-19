using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = GetAllMovies().ToList();

            var viewmodel = new RandomMoviewViewModel
            {
                Movies = movie.ToList()
            };
            return View(viewmodel);
        }

        public List<Movie> GetAllMovies()
        {
            var movies = new List<Movie>
            {
                new Movie() {Id = 1, Name = "spider man"},
                new Movie() {Id = 2, Name = "bat man"},
                new Movie() {Id = 3, Name = "super man"},
                new Movie() {Id = 4, Name = "iron man"}
            };

            return movies.ToList();
        }
    }
}