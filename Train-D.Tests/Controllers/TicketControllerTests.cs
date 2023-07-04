using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_D.Controllers;
using Train_D.DTO;
using Train_D.DTO.TicketDTO;
using Train_D.Models;
using Train_D.Services.Contract;

namespace Train_D.Tests.Controllers
{
    public class TicketControllerTests
    {
        private readonly ITicketService _ticketService;
        public TicketControllerTests()
        {
             _ticketService=A.Fake<ITicketService>();
        }

        
        [Fact]
        public void bookTicket_whenTheSeatIsAlreadyExistInDatabase_shouldReturnBadRequest()
        {
            //Arrange
            var username = "abdalla";
            var userid = "4123j4kl23412jl12412";
            var dto = A.Fake<TicketBookRequest>();
            var ticket = A.Fake<TicketDTO>();
            A.CallTo(() => _ticketService.IsExist(dto)).Returns(true);
            A.CallTo(() => _ticketService.Isvaild(dto.PaymentId)).Returns(true);
            A.CallTo(() => _ticketService.Book(dto,userid,username)).Returns(ticket);
            var controller = new TicketController(_ticketService);

            //Act
            var result = controller.bookTicket(dto);
            //Assert
            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));

        }
        [Fact]
        public void bookTicket_whenThePaymentFlowDoesNotWorkCorrectly_shouldReturnBadRequest()
        {
            //Arrange
            var username = "abdalla";
            var userid = "4123j4kl23412jl12412";
            var dto = A.Fake<TicketBookRequest>();
            var ticket = A.Fake<TicketDTO>();
            A.CallTo(() => _ticketService.IsExist(dto)).Returns(false);
            A.CallTo(() => _ticketService.Isvaild(dto.PaymentId)).Returns(false);
            A.CallTo(() => _ticketService.Book(dto, userid, username)).Returns(ticket);
            var controller = new TicketController(_ticketService);

            //Act
            var result = controller.bookTicket(dto);
            //Assert
            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));

        }
        [Fact]
        public void TrackingTrain_whenFindTicketInDatabase_shouldReturnOk()
        {
            //Arrange
            var response = A.Fake<TrackingResponse>();
            A.CallTo(() => _ticketService.getTrackingInfo(4234)).Returns(response);
            var controller = new TicketController(_ticketService);

            //Act
            var result = controller.TrackingTrain(4234);
            //Assert
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void TrackingTrain_whenTicketDoesNotExistInDatabase_shouldReturnBadRequest()
        {
            //Arrange
            TrackingResponse response =null;
            A.CallTo(() => _ticketService.getTrackingInfo(4234)).Returns(response);
            var controller = new TicketController(_ticketService);

            //Act
            var result = controller.TrackingTrain(4234);
            //Assert
            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));

        }
    
    }
}
