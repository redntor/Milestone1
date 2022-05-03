using Milestone1;
using Milestone1.Controllers;
using System;
using Xunit;

namespace TestMilestone1
{
    public class MovieTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Gladiator")]
         public void GetMovie_Passing_Test(string name)
        {
            var movie = MovieController.Get(name);

            Assert.NotNull(movie);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("Saw")]
        public void GetMovie_Failing_Test(string name)
        {
            var movies = MovieController.Get(name);

            Assert.True(movies == null || movies.Count == 0);
        }


        [Fact]
        public void PostMovie_Passing_Test()
        {
            var movie = new Movie()
            {
                Id = 4,
                Name = "Back to the Future",
                ReleaseDate = DateTime.Today
            };

            var result = MovieController.Post(movie); ;

            Assert.True(movie == result);
        }

        [Fact]
        public void PutMovie_Passing_Test()
        {
            var movie = new Movie()
            {
                Id = 3,
                Name = "Sherlock Holmes: A Game of Shadows",
                ReleaseDate = DateTime.Today
            };

            var result = MovieController.Put(movie); ;

            Assert.True(movie == result);
        }
    }
}
