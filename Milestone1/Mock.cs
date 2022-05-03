using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1
{
    public static class Mock
    {
       
        public static List<Movie> CreateMockMovieList()
        {
            var movies = new List<Movie>();

            movies.Add(new Movie { Id = 1, Name = "Saving Private Ryan", ReleaseDate = DateTime.Today });
            movies.Add(new Movie { Id = 2, Name = "Gladiator", ReleaseDate = DateTime.Today });
            movies.Add(new Movie { Id = 3, Name = "Sherlock Holmes", ReleaseDate = DateTime.Today });

            return movies;

        }

        public static List<Movie> GetMovies(string name)
        {
            var movies = CreateMockMovieList();

            if (name != null && name.Length > 0)
            {
                return movies.Where(m => m.Name == name).ToList();
            }

            return movies;
        }
    }
}
