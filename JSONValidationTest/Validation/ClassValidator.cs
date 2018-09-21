using System.Collections.Generic;

namespace JSONValidationTest.Validation
{
    public class ClassValidator
    {
        public string Name { get; set; }
        public List<PropertyValidator> Properties { get; set; }
    }
}