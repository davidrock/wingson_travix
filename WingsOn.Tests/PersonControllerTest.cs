using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Controllers;
using WingsOn.Core.Services;
using WingsOn.Core.ViewModels;
using WingsOn.Dal;
using WingsOn.Domain;
using Xunit;

namespace WingsOn.Tests
{
    public class PersonControllerTest
    {

        private IPersonService _service;
        private PersonController _controller;

        public PersonControllerTest()
        {
            _service = new PersonService();
            _controller = new PersonController(_service);
        }

        [Fact]
        public async void GetById_ExistingIdPassed_ReturnOkObjectResult()
        {
            //Arrange
            var rep = new PersonRepository();
            var personId = rep.GetAll().First().Id;

            //Act
            var okResult = await _controller.Get(personId);

            //Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public async void GetById_NonExistentIdPassed_ReturnBadRequestObjectResult()
        {
            //Arrange
            var rep = new PersonRepository();
            var personId = rep.GetAll().Last().Id + 15000; //I hope this system is not registering more than 15k new users por millisecond

            //Act
            var badRequest = await _controller.Get(personId);

            //Assert
            Assert.IsType<BadRequestObjectResult>(badRequest);
        }

        [Fact]
        public async void GetAllByGender_ValidMaleGenderCodePassed_ReturnOkObjectResult()
        {
            var filter = new PersonFilterViewModel
            {
                Gender = (int)GenderType.Male
            };

            //Act
            var oKResult = await _controller.Filter(filter);

            //Assert
            Assert.IsType<OkObjectResult>(oKResult);
        }

        [Fact]
        public async void GetAllByGender_ValidFemaleGenderCodePassed_ReturnOkObjectResult()
        {
            //Arrange
            var filter = new PersonFilterViewModel
            {
                Gender = (int)GenderType.Female
            };

            //Act
            var oKResult = await _controller.Filter(filter);

            //Assert
            Assert.IsType<OkObjectResult>(oKResult);
        }

        [Fact]
        public async void GetAllByGender_InvalidGenderCodePassed_ReturnBadRequestObjectResult()
        {
            //Arrange
            var filter = new PersonFilterViewModel
            {
                Gender = 99999
            };

            //Act
            var result = await _controller.Filter(filter);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
