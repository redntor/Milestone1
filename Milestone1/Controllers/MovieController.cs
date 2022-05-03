using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Milestone1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Movie> Get(string name)
        {
    
            var movies =  GetMovies(name);

            //if(movies != null && movies.Count() > 0)
            //{
                return movies;
            //}

            //throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);

        }

        [HttpPost]
        public Movie Post(Movie movie)
        {
            var movies = GetMovies(null);
            movies.Add(movie);

            return movies.Where(m => m.Id == movie.Id ).First();

        }

        [HttpPut]
        public Movie Put(Movie movie)
        {
            var movies = GetMovies(null);

            var modifiedMovie = movies.Where(m => m.Id == movie.Id).First();

            //if (modifiedMovie != null)
            //{
            modifiedMovie = movie;
                return modifiedMovie;
            //}

            //throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
        }

        public static List<Movie> GetMovies(string name)
        {
            var movies = CreateMockMovieList();

            if(name != null  && name.Length > 0 )
            {
                return movies.Where(m => m.Name == name).ToList();
            }

            return movies;
        }


        public static List<Movie> CreateMockMovieList()
        {
            var movies = new List<Movie>();

            movies.Add(new Movie { Id = 1, Name = "Saving Private Ryan", ReleaseDate = DateTime.Today });
            movies.Add(new Movie { Id = 2, Name = "Gladiator", ReleaseDate = DateTime.Today });
            movies.Add(new Movie { Id = 3, Name = "Sherlock Holmes", ReleaseDate = DateTime.Today });

            return movies;

        }
    }
}
