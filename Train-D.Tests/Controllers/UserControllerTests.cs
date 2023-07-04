using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_D.Controllers;
using Train_D.Models;
using Train_D.Services;

namespace Train_D.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly IAuth _auth;
        public UserControllerTests()
        {
            _auth = A.Fake<IAuth>();
        }
        [Fact]
        public void Login_whenUserLogin_shouldReturnOk()
        {
            //Arranage
            var model =A.Fake<LoginModel>();
            var sub=A.Fake<AuthModel>();
            A.CallTo(() => _auth.Login(model)).Returns(sub);
            sub.IsAuthenticated = true;
            var controller = new UserController(_auth);
            //Act
            var result = controller.Login(model);
            //Assert
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void Login_whenUserIsNotAuthenticated_shouldReturnBadRequest()
        {
            //Arranage
            var model = A.Fake<LoginModel>();
            var sub = A.Fake<AuthModel>();
            A.CallTo(() => _auth.Login(model)).Returns(sub);
            sub.IsAuthenticated = false;
            var controller = new UserController(_auth);
            //Act
            var result = controller.Login(model);
            //Assert
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
        }
        [Fact]
        public void LoginWithGoogle_whenUserLoginWithGoogleAccount_shouldReturnOk()
        {
            //Arranage
            var model = "fdsafsfsfsaf234fs";
            var sub = A.Fake<AuthModel>();
            A.CallTo(() => _auth.LoginGoogle(model)).Returns(sub);
            sub.IsAuthenticated = true;
            var controller = new UserController(_auth);
            //Act
            var result = controller.LoginWithGoogle(model);
            //Assert
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void LoginWithGoogle_whenUserIsNotAuthenticatedWithGoogleAccount_shouldReturnBadRequest()
        {
            //Arranage
            var model = "fsafsaflkjjlsfas23423";
            var sub = A.Fake<AuthModel>();
            A.CallTo(() => _auth.LoginGoogle(model)).Returns(sub);
            sub.IsAuthenticated = false;
            var controller = new UserController(_auth);
            //Act
            var result = controller.LoginWithGoogle(model);
            //Assert
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
        }
    }
}
