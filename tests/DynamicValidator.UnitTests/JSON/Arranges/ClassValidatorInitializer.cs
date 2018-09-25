using DynamicValidator.JSON.Entities;
using DynamicValidator.JSON.Types;
using DynamicValidator.UnitTests.JSON.Models;
using System.Collections.Generic;

namespace DynamicValidator.UnitTests.JSON.Arranges
{
    public class ClassValidatorInitializer
    {
        public List<ClassValidator> Validators = new List<ClassValidator>
        {
            new ClassValidator
            {
                Name = nameof(Person),
                Properties = new List<PropertyValidator>
                {
                    new PropertyValidator
                    {
                        Name = nameof(Person.Name),
                        Required = new RequiredValidation
                        {
                            Value = true,
                            Code = 1,
                            Message = "Invalid"
                        },
                        MaxLength = new MaxLengthValidation
                        {
                            Value = 50,
                            Code = 2,
                            Message = "Invalid"
                        },
                        MinLength = new MinLengthValidation
                        {
                            Value = 2,
                            Code = 3,
                            Message = "Invalid"
                        }
                    },
                    new PropertyValidator
                    {
                        Name = nameof(Person.Age),
                        Required = new RequiredValidation
                        {
                            Value = true,
                            Code = 4,
                            Message = "Invalid"
                        },
                        MaxSize = new MaxSizeValidation
                        {
                            Value = 45,
                            Code = 5,
                            Message = "Invalid"
                        },
                        MinSize = new MinSizeValidation
                        {
                            Value = 9,
                            Code = 6,
                            Message = "Invalid"
                        }

                    },
                    new PropertyValidator
                    {
                        Name = nameof(Person.Address),
                        Required = new RequiredValidation
                        {
                            Value = true,
                            Code = 7,
                            Message = "Invalid"
                        }
                    }
                }
            },
            new ClassValidator
            {
                Name = nameof(Address),
                Properties = new List<PropertyValidator>
                {
                    new PropertyValidator
                    {
                        Name = nameof(Address.Name),
                        Required = new RequiredValidation
                        {
                            Value = true,
                            Code = 8,
                            Message = "Invalid"
                        },
                        MaxLength = new MaxLengthValidation
                        {
                            Value = 50,
                            Code = 9,
                            Message = "Invalid"
                        },
                        MinLength = new MinLengthValidation
                        {
                            Value = 2,
                            Code = 10,
                            Message = "Invalid"
                        }
                    }
                }
            }
        };
    }
}
