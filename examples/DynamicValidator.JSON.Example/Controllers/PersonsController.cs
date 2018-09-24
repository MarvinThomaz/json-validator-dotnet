using DynamicValidator.JSON.Abstractions;
using DynamicValidator.JSON.Example.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicValidator.JSON.Example.Controllers
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