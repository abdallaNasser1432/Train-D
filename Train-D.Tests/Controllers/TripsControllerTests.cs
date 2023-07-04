using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Train_D.Controllers;
using Train_D.Models;
using Train_D.Services.Contract;

namespace Train_D.Tests.Controllers
{
    public class TripsControllerTests
    {
        private readonly ITripService _tripService;
        public TripsControllerTests()
        {
            _tripService = A.Fake<ITripService>();
        }
        [Fact]
        public void GetAll_whenTripsExistInDatabase_ShouldReturnOk()
        {
            //Arrnage

            var FromTo =A.Fake<Dictionary<string, object>>();
            A.CallTo(() => _tripService.GetFromToStations()).Returns(FromTo);
            var Controller = new TripsController(_tripService);

            //Act
            var result = Controller.GetAll();
            //Assert
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
