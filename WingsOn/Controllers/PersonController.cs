using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Core.Services;
using WingsOn.Core.ViewModels;
using WingsOn.Domain;

namespace WingsOn.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var person = await _personService.GetPersonById(id);

                return new OkObjectResult(person);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = e.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Filter(PersonFilterViewModel filters)
        {
            try
            {
                var persons = await _personService.FilterPersons(filters);

                return new OkObjectResult(persons);
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