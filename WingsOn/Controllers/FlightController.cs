using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WingsOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var person = _personService.GetPersonById(id);

                return new OkObjectResult(person);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = e
                });
            }
        }
    }
}