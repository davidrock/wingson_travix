using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Core.Services;

namespace WingsOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {

        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        /// <summary>
        /// Get all passengers of a particular flight
        /// </summary>
        /// <param name="number">Flight Number</param>
        /// <returns></returns>
        [HttpGet]
        [Route("passengers/{number}")]
        public IActionResult GetAllPassengersByFlightNumber(string number)
        {
            try
            {
                var passengers = _flightService.GetFlightPassengers(number);

                return new OkObjectResult(passengers);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = e.Message
                });
            }
        }
    }
}