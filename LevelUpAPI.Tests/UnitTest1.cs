using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LevelUpAPI.Models;
using LevelUpAPI.Controllers;


namespace LevelUpAPI.Tests
{
    public class GamesControllerTests
    {
        [Fact]
        public void GetGames_ReturnsOkResult_WithListOfGames()
        {
           
            var controller = new GamesController();

            var result = controller.GetGames();
            var okResult = result.Result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.IsType<List<Game>>(okResult.Value);
        }

        [Fact]
        public void GetGameById_NotFound_WhenGameDoesNotExist()
        {
            
            var controller = new GamesController();

            var result = controller.GetGameById(999).Result; 

            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
