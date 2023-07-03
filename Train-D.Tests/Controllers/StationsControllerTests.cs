using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_D.Controllers;
using Train_D.DTO;
using Train_D.DTO.StationDtos;
using Train_D.Models;
using Train_D.Services;

namespace Train_D.Tests.Controllers
{
    
    public class StationsControllerTests
    {
        private readonly IStationsServices _StationServices;
        private readonly IMapper _mapper;

        public StationsControllerTests()
        {
            _StationServices = A.Fake<IStationsServices>(); 
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        public void GetAll_whenGetAllStationFromDatabase_shouldReturnOk()
        {
            //Arrange

            var Station = A.Fake<IEnumerable<string>>();
            var StationNameGroup = A.Fake<Dictionary<char,object>>();
            A.CallTo(() => _StationServices.GetAll()).Returns(Station);
            A.CallTo(() => _StationServices.GroupedSations(Station.ToList())).Returns(StationNameGroup);
            var Controller = new StationsController(_StationServices,_mapper);

            //Act
            var result =Controller.GetAll();
            //Assert
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void GetByName_whenGetStationByNameFromDatabase_ShouldReturnOk()
        {
            //Arrange
            var StationName="ismailia";
            var Station =A.Fake<Station>();
            A.CallTo(()=>_StationServices.GetByName(StationName)).Returns(Station);
            var Controller = new StationsController(_StationServices, _mapper);

            //Act
            var result = Controller.GetByName(StationName);
            //Assert
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void GetByName_whenStationNameEqualNull_ShouldReturnBadRequest()
        {
            //Arrange
            string StationName = null;
            var Station = A.Fake<Station>();
            A.CallTo(() => _StationServices.GetByName(StationName)).Returns(Station);
            var Controller = new StationsController(_StationServices, _mapper);

            //Act
            var result = Controller.GetByName(StationName);
            //Assert
            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
        }
        [Fact]
        public void GetByName_WhenNotFoundStationInDatabase_ShouldReturnNotFound()
        {
            //Arrange
            string StationName = "Ismailia";
            Station Station = null;
            A.CallTo(() => _StationServices.GetByName(StationName)).Returns(Station);
            var Controller = new StationsController(_StationServices, _mapper);

            //Act
            var result = Controller.GetByName(StationName);
            //Assert
            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }
        [Fact]
        public void Add_whenAddStationToDatabaseSuccessfully_shouldReturnOk()
        {
            //Arrange
            var DTO = A.Fake<StationAddDto>();
            var Station = A.Fake<Station>();
            A.CallTo(() => _StationServices.IsExist(DTO.StationName)).Returns(false);
            A.CallTo(()=>_mapper.Map<Station>(DTO)).Returns(Station);
            A.CallTo(() => _StationServices.Add(Station)).Returns(Station);
            var Controller = new StationsController(_StationServices, _mapper);

            //Act
            var result = Controller.Add(DTO);

            //Assert
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void Add_whenAddStationToDatabaseFindoutThatStatoinIsAlreadyAdded_shouldReturnBadRequest()
        {
            //Arrange
            var DTO = A.Fake<StationAddDto>();
            var Station = A.Fake<Station>();
            A.CallTo(() => _StationServices.IsExist(DTO.StationName)).Returns(true);
            A.CallTo(() => _mapper.Map<Station>(DTO)).Returns(Station);
            A.CallTo(() => _StationServices.Add(Station)).Returns(Station);
            var Controller = new StationsController(_StationServices, _mapper);

            //Act
            var result = Controller.Add(DTO);

            //Assert
            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
        }

        [Fact]
        public void Update_whenStationIsUpdatedInDatabase_shouldReturnOk()
        {
            //Arrange
            string StationName = "Cairo";
            var Station = A.Fake<Station>();
            var DTO = A.Fake<StationDTO>();
            A.CallTo(() => _StationServices.GetByName(StationName)).Returns(Station);
            A.CallTo(() => _StationServices.Update()).Returns(true);
            var Controller = new StationsController(_StationServices, _mapper);

            //Act
            var result = Controller.Update(StationName,DTO);
            //Assert
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void Update_whenStationNameIsNull_shouldReturnBadRequest()
        {
            //Arrange
            string StationName = null;
            var Station = A.Fake<Station>();
            var DTO = A.Fake<StationDTO>();
            A.CallTo(() => _StationServices.GetByName(StationName)).Returns(Station);
            A.CallTo(() => _StationServices.Update()).Returns(true);
            var Controller = new StationsController(_StationServices, _mapper);

            //Act
            var result = Controller.Update(StationName, DTO);
            //Assert
            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
        }

        [Fact]
        public void Update_whenStationDoesNotExistInDatabase_shouldReturnNotFound()
        {
            //Arrange
            string StationName = "Abdalla";
            Station Station = null;
            var DTO = A.Fake<StationDTO>();
            A.CallTo(() => _StationServices.GetByName(StationName)).Returns(Station);
            A.CallTo(() => _StationServices.Update()).Returns(true);
            var Controller = new StationsController(_StationServices, _mapper);

            //Act
            var result = Controller.Update(StationName, DTO);
            //Assert
            result.Result.Should().BeOfType(typeof(NotFoundObjectResult));
        }
        [Fact]
        public void Update_whenStationDoesNotUpdated_shouldBadRequest()
        {
            //Arrange
            string StationName = "Nasser";
            var Station = A.Fake<Station>();
            var DTO = A.Fake<StationDTO>();
            A.CallTo(() => _StationServices.GetByName(StationName)).Returns(Station);
            A.CallTo(() => _StationServices.Update()).Returns(false);
            var Controller = new StationsController(_StationServices, _mapper);

            //Act
            var result = Controller.Update(StationName, DTO);
            //Assert
            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
        }

        [Fact]
        public void Delete_whenStationIsDeletedInDatabase_shouldReturnOk()
        {
            //Arrange
            string StationName = "Cairo";
            var Station = A.Fake<Station>();
            A.CallTo(() => _StationServices.GetByName(StationName)).Returns(Station);
            A.CallTo(() => _StationServices.Delete(Station)).Returns(Station);
            var Controller = new StationsController(_StationServices, _mapper);

            //Act
            var result = Controller.Delete(StationName);
            //Assert
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void Delete_whenStationNameIsNull_shouldReturnBadRequest()
        {
            //Arrange
            string StationName = null;
            var Station = A.Fake<Station>();
            A.CallTo(() => _StationServices.GetByName(StationName)).Returns(Station);
            A.CallTo(() => _StationServices.Delete(Station)).Returns(Station);
            var Controller = new StationsController(_StationServices, _mapper);

            //Act
            var result = Controller.Delete(StationName);
            //Assert
            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
        }

        [Fact]
        public void Delete_whenStationDoesNotExistInDatabase_shouldReturnNotFound()
        {
            //Arrange
            string StationName = "Cairo";
            Station Station = null;
            A.CallTo(() => _StationServices.GetByName(StationName)).Returns(Station);
            A.CallTo(() => _StationServices.Delete(Station)).Returns(Station);
            var Controller = new StationsController(_StationServices, _mapper);

            //Act
            var result = Controller.Delete(StationName);
            //Assert
            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }
    }
}
