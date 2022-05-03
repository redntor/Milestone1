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

            var movies = Mock.GetMovies(name);

            if (movies != null && movies.Count > 0)
            {
                return Ok(movies);
            }

            return NotFound();


        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(Movie movie)
        {
            if(movie == null || movie.Id == 0 || movie.Name.Length == 0 || movie.ReleaseDate == DateTime.MinValue)
            {
                return BadRequest();
            }

            var movies = Mock.GetMovies(null);
            movies.Add(movie);

            var result = movies.Where(m => m.Id == movie.Id).FirstOrDefault();

            if (result != null && result.Id > 0)
            {
                return Ok(result);
            }

            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(Movie movie)
        {
            if (movie == null || movie.Id == 0 || movie.Name.Length == 0 || movie.ReleaseDate == DateTime.MinValue)
            {
                return BadRequest();
            }

            var movies = Mock.GetMovies(null);

            var modifiedMovie = movies.Where(m => m.Id == movie.Id).First();

            if (modifiedMovie != null)
            {
                modifiedMovie = movie;
                return Ok(modifiedMovie);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

      


    
    }
}
