﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
       
        //// GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie()
        //    {
        //        Name = "Shrek!"
        //    };
        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1"},
        //        new Customer {Name = "Customer 2"}
        //    };

        //    var viewModel = new RandomMovieViewModel()
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };


        //    // Helper method View() {}
        //    //var viewResult = new ViewResult();
        //    //viewResult.ViewData.Model = movie;

        //    // ActionResult Types
        //    return View(viewModel);
        //    //return HttpNotFound();
        //    //return Content("Hello World");
        //    //return new EmptyResult();
        //    //return RedirectToAction("Index", "Home",
        //    //    new { page = 1, sortBy = "name" });
        //}
        
        // Attribute route
        // There are other types of constraint
        // like min, max, range, maxlength etc.
        // use ^ and $ for start/end of string
        //[Route("movies/released/{year:regex(^\\d{4}$):max(2020)}/{month:regex(^\\d{2}$):range(1, 12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}


        // movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    // For a parameter to be optional in action parameters
        //    // You need to make a nullable types
        //    // If it's reference type
        //    //then it's' already nullable.

        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}",
        //        pageIndex, sortBy));
        //}





    }
}