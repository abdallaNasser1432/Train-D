using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Train_D.Controllers;
using Train_D.DTO.TripDtos;
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
        [Fact]
        public void GetTripTimes_whenTripTimesExistInDatabase_ShouldReturnOk()
        {
            //Arrnage

            var tripTimes = A.Fake<List<SearchTripResultDTO>>();
            var dto = A.Fake<SearchTripWriteDTO>();
            var Controller = new TripsController(_tripService);
            A.CallTo(() => _tripService.Isvalid(dto.Date)).Returns(true);
            A.CallTo(() => _tripService.TripTimes(dto)).Returns(tripTimes);

            //Act
            var result = Controller.GetTripTimes(dto);
            //Assert

            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void GetTripTimes_whenDateIsNotValid_ShouldReturnBadRequest()
        {
            //Arrnage

            var tripTimes = A.Fake<List<SearchTripResultDTO>>();
            var dto = A.Fake<SearchTripWriteDTO>();
            var Controller = new TripsController(_tripService);
            A.CallTo(() => _tripService.Isvalid(dto.Date)).Returns(false);
            A.CallTo(() => _tripService.TripTimes(dto)).Returns(tripTimes);

            //Act
            var result = Controller.GetTripTimes(dto);
            //Assert
            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
        }
        [Fact]
        public void GetTripTimes_whenNoTripInDatabase_ShouldReturnBadRequest()
        {
            //Arrnage

            List<SearchTripResultDTO> tripTimes = null;
            var dto = A.Fake<SearchTripWriteDTO>();
            var Controller = new TripsController(_tripService);
            A.CallTo(() => _tripService.Isvalid(dto.Date)).Returns(true);
            A.CallTo(() => _tripService.TripTimes(dto)).Returns(tripTimes);

            //Act
            var result = Controller.GetTripTimes(dto);
            //Assert
            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
        }
    }
}
