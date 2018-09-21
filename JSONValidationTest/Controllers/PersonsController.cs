using JSONValidationTest.Entities;
using JSONValidationTest.Validation;
using Microsoft.AspNetCore.Mvc;

namespace JSONValidationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IValidator _validator;

        public PersonsController(IValidator validator)
        {
            _validator = validator;
        }

        [HttpPost]
        public ActionResult Post(Person person)
        {
            _validator.Validate(person);

            return Ok(person);
        }
    }
}