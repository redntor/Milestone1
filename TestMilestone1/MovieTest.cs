using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Milestone1;
using Milestone1.Controllers;
using Moq;
using System;
using Xunit;

namespace TestMilestone1
{
    public class MovieTest
    {
        MovieController mc;

        public MovieTest()
        {
            var mock = new Mock<ILogger<MovieController>>();
            ILogger<MovieController> logger = mock.Object;

            mc = new MovieController(logger);
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
            Assert.IsType<NotFoundResult>(movies);
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
            Assert.IsType<OkObjectResult>(result);
       
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
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
