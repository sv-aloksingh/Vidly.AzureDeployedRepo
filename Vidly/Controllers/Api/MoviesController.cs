using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET /api/movie
        [Authorize]
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            var movie = _context.Movies.ToList();


            return movie;
        }

        //GET /api/movie/1
        [Authorize]
        [HttpGet]
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault( c => c.Id == id);


            return movie;
        }

        //POST /api/movie/
        [Authorize]
        [HttpPost]
        public Movie CreateMovie(int id, Movie movie)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            _context.Movies.Add(movieInDb);
            _context.SaveChanges();
            return movieInDb;
        }

        //PUT /api/movie/1
        [Authorize]
        [HttpPut]
        public Movie UpdateMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault( c=> c.Id == id);

            _context.SaveChanges();
            return movieInDb;
        }

        //DELETE /api/movie/1
        [Authorize]
        [HttpDelete]
        public Movie DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault( c=> c.Id == id);

            _context.SaveChanges();
            return movieInDb;
        }
    }
}
