using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (newRental.MovieIds.Count == 0)
            {
                return BadRequest("No MovieIds have been given");
            }

            // Find the customer in Db
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if(customerInDb == null)
            {
                return BadRequest("There is no customer with id=" + newRental.CustomerId);
            }

            // Create Movie Table based on supplied movieIds
            // SELECT * FROM Movies Where Id IN (newRental.MovieIds);
            var moviesInDb = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            // Check if one or more movieIds are invalid
            if (moviesInDb.Count != newRental.MovieIds.Count)
            {
                return BadRequest("One or more movieids are invalid");
            }

            // Loop over moviesInDb to create a rental for each movie and add to dbcontext
            foreach(var movie in moviesInDb)
            {
                // check if movie is available
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Not enough movie for" + movie.Name);
                }

                // if availability is ok reduce the numberAvailable by 1
                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customerInDb,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);                            }

            _context.SaveChanges();
            return Ok();
        }

    }
}