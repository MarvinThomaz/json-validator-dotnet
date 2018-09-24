using DynamicValidator.JSON.Example.Models;
using DynamicValidator.JSON.Services;
using Microsoft.AspNetCore.Mvc;

namespace DynamicValidator.JSON.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IValidatorApplicationService _validationService;

        public PersonsController(IValidatorApplicationService service)
        {
            _validationService = service;
        }

        [HttpPost]
        public ActionResult Post(Person person)
        {
            _validationService.Validate(person);

            return Ok(person);
        }
    }
}