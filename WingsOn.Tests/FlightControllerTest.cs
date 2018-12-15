using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Controllers;
using WingsOn.Core.Services;
using WingsOn.Dal;
using Xunit;

namespace WingsOn.Tests
{
    public class FlightControllerTest
    {
        private FlightController _controller;
        private IFlightService _service;

        public FlightControllerTest()
        {
            _service = new FlightService();
            _controller = new FlightController(_service);

        }

        [Fact]
        public async void GetAllPassengersByFlightNumber_ExistingNumberPassed_ReturnOkObjectResult()
        {
            //Arrange
            var flightNumber = "PZ696";

            //Act
            var okResult = await _controller.GetAllPassengersByFlightNumber(flightNumber);

            //Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public async void GetAllPassengersByFlightNumber_InvalidNumberPassed_ReturnBadRequestObjectResult()
        {
            //Arrange
            var flightNumber = "";

            //Act
            var badRequest = await _controller.GetAllPassengersByFlightNumber(flightNumber);

            //Assert
            Assert.IsType<BadRequestObjectResult>(badRequest);
        }


        [Fact]
        public async void GetAllPassengersByFlightNumber_NonExistentNumberPassed_ReturnBadRequestObjectResult()
        {
            //Arrange
            var flightNumber = "ZZZYYYXXX";

            //Act
            var badRequest = await _controller.GetAllPassengersByFlightNumber(flightNumber);

            //Assert
            Assert.IsType<BadRequestObjectResult>(badRequest);
        }


    }
}
