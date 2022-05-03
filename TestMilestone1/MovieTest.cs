using Microsoft.Extensions.Logging;
using Milestone1;
using Milestone1.Controllers;
using System;
using Xunit;

namespace TestMilestone1
{
    public class MovieTest
    {
        MovieController mc;

        public MovieTest()
        {
            mc = new MovieController();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Gladiator")]
         public void GetMovie_Passing_Test(string name)
        {
            var movie = mc.Get(name);

            Assert.NotNull(movie);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("Saw")]
        public void GetMovie_Failing_Test(string name)
        {
            var movies = mc.Get(name);

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

            var result = mc.Post(movie); ;

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

            var result = mc.Put(movie); ;

            Assert.True(movie == result);
        }
    }
}
