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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

      

        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Movie> Get(string name)
        {
    
            var movies =  GetMovies(name);

            if(movies != null && movies.Count() > 0)
            {
                return movies;
            }

            throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);

        }

        [HttpPost]
        public Movie Post(Movie movie)
        {
            return movie;

        }

        [HttpPut]
        public Movie Put(Movie movie)
        {
            var movies = GetMovies(null);

            var modifiedMovie = movies.Where(m => m.Id == movie.Id).First();

            if (modifiedMovie != null)
            {
                modifiedMovie.Name = movie.Name;
                modifiedMovie.ReleaseDate = movie.ReleaseDate;
                return modifiedMovie;
            }
                    

            throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
        }

        public static IEnumerable<Movie> GetMovies(string name)
        {
            var movies = new List<Movie>();

            movies.Add(new Movie { Id = 1, Name = "Saving Private Ryan", ReleaseDate = DateTime.Today });
            movies.Add(new Movie { Id = 2, Name = "Gladiator", ReleaseDate = DateTime.Today });
            movies.Add(new Movie { Id = 3, Name = "Sherlock Holmes", ReleaseDate = DateTime.Today });

            if(name != null  && name.Length > 0 )
            {
                return movies.Where(m => m.Name == name);
            }

            return movies;
        }
    }
}
