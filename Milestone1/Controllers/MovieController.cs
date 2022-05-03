using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Movie>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string name)
        {
    
            var movies =  Mock.GetMovies(name);

            if (movies != null && movies.Count > 0)
            {
                return Ok(movies);
            }

            return NotFound();


        }

        [HttpPost]
        public Movie Post(Movie movie)
        {
            var movies = Mock.GetMovies(null);
            movies.Add(movie);

            return movies.Where(m => m.Id == movie.Id ).First();

        }

        [HttpPut]
        public Movie Put(Movie movie)
        {
            var movies = Mock.GetMovies(null);

            var modifiedMovie = movies.Where(m => m.Id == movie.Id).First();

            //if (modifiedMovie != null)
            //{
            modifiedMovie = movie;
                return modifiedMovie;
            //}

            //throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
        }

      


    
    }
}
