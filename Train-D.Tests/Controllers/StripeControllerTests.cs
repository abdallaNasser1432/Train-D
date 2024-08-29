using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_D.Controllers;
using Train_D.DTO.Stripe;
using Train_D.Models.Stripe;
using Train_D.Services;
using Train_D.Services.Contract;

namespace Train_D.Tests.Controllers
{
    public class StripeControllerTests
    {
        private readonly IStripeAppService _stripeService;
        private readonly ITicketService _ticketService;
        public StripeControllerTests()
        {
            _stripeService = A.Fake<IStripeAppService>();
            _ticketService = A.Fake<ITicketService>();
        }
        [Fact]
        public void AddStripeCustomer_whenCustomerIsCreated_shouldReturnOk()
        {
            //Arranage
            var createdCustomer = A.Fake<StripeCustomer>();
            var customer = A.Fake<AddStripeCustomer>();
            CancellationToken cancelToken = new CancellationToken();
            A.CallTo(() => _stripeService.AddStripeCustomerAsync(customer, cancelToken)).Returns(createdCustomer);
            var controller = new StripeController(_stripeService, _ticketService);
            //Act
            var result=controller.AddStripeCustomer(customer, cancelToken); 
            //Assert

            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void AddStripePayment_whenPaymentDoneSuccessfully_shouldReturnOk()
        {
            //Arranage
            var createdCustomer = A.Fake<StripePayment>();
            var customer = A.Fake<AddStripePayment>();
            CancellationToken cancelToken = new CancellationToken();
            A.CallTo(() => _stripeService.AddStripePaymentAsync(customer, cancelToken)).Returns(createdCustomer);
            var controller = new StripeController(_stripeService, _ticketService);
            //Act
            var result = controller.AddStripePayment(customer, cancelToken);
            //Assert

            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void Refund_whenRefundDoneSuccessfully_shouldReturnOk()
        {
            //Arranage
            var refundResult = A.Fake<RefundCheckDto>();
            var refundRequest = A.Fake<RefundRequestModel>();
            A.CallTo(() => _stripeService.Refund(refundRequest.PaymentId, refundRequest.Amount)).Returns(refundResult);
            var controller = new StripeController(_stripeService,_ticketService);
            refundResult.Success = true;
            //Act
            var result = controller.Refund(refundRequest);
            //Assert

            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void Refund_whenRefundDoesNotDoneSuccessfully_shouldReturnBadRequeset()
        {
            //Arranage
            var refundResult = A.Fake<RefundCheckDto>();
            var refundRequest = A.Fake<RefundRequestModel>();
            A.CallTo(() => _stripeService.Refund(refundRequest.PaymentId, refundRequest.Amount)).Returns(refundResult);
            var controller = new StripeController(_stripeService,_ticketService);
            refundResult.Success = false;
            //Act
            var result = controller.Refund(refundRequest);
            //Assert

            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
        }
    }
}
