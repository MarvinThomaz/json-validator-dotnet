using DynamicValidator.Abstractions;
using DynamicValidator.Attributes.Example.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicValidator.Attributes.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IValidateCommand _validator;

        public PersonsController(IValidateCommand service)
        {
            _validator = service;
        }

        [HttpPost]
        public ActionResult Post(Person person)
        {
            _validator.Execute(person);

            return Ok(person);
        }
    }
}