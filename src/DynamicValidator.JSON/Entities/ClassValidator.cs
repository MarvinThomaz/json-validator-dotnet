using System.Collections.Generic;

namespace DynamicValidator.JSON.Entities
{
    public class ClassValidator
    {
        public string Name { get; set; }
        public List<PropertyValidator> Properties { get; set; }
    }
}