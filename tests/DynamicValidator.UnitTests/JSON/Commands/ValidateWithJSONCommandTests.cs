using DynamicValidator.Abstractions;
using DynamicValidator.Exceptions;
using DynamicValidator.JSON.Commands;
using DynamicValidator.JSON.Entities;
using DynamicValidator.JSON.Types;
using DynamicValidator.UnitTests.JSON.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DynamicValidator.UnitTests.JSON.Commands
{
    public class ValidateWithJSONCommandTests
    {
        private IValidateCommand _validator;

        private readonly List<ClassValidator> _validators = new List<ClassValidator>
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

        [Fact]
        public void ValidatePersonWithRequiredName()
        {
            var person = new Person() { Name = null, Age = 10, Address = new Address() { Name = "Oi" } };
            var exception = Execute(person);
            var validation = GetValidation(nameof(Person), nameof(Person.Name), nameof(PropertyValidator.Required));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Name));
        }

        [Fact]
        public void ValidatePersonWithNameMaxLength()
        {
            var person = new Person() { Name = Enumerable.Repeat('a', 51).ToString(), Age = 10, Address = new Address() { Name = "Oi" } };
            var exception = Execute(person);
            var validation = GetValidation(nameof(Person), nameof(Person.Name), nameof(PropertyValidator.MaxLength));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Name));
        }

        [Fact]
        public void ValidatePersonWithNameMinLength()
        {
            var person = new Person() { Name = "O", Age = 10, Address = new Address() { Name = "Oi" } };
            var exception = Execute(person);
            var validation = GetValidation(nameof(Person), nameof(Person.Name), nameof(PropertyValidator.MinLength));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Name));
        }

        [Fact]
        public void ValidatePersonWithRequiredAge()
        {
            var person = new Person() { Name = "Oi", Age = 0, Address = new Address() { Name = "Oi" } };
            var exception = Execute(person);
            var validation = GetValidation(nameof(Person), nameof(Person.Age), nameof(PropertyValidator.Required));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Age));
        }

        [Fact]
        public void ValidatePersonWithAgeMinSize()
        {
            var person = new Person() { Name = "Oi", Age = 1, Address = new Address() { Name = "Oi" } };
            var exception = Execute(person);
            var validation = GetValidation(nameof(Person), nameof(Person.Age), nameof(PropertyValidator.MinSize));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Age));
        }

        [Fact]
        public void ValidatePersonWithAgeMaxSize()
        {
            var person = new Person() { Name = "Oi", Age = 50, Address = new Address() { Name = "Oi" } };
            var exception = Execute(person);
            var validation = GetValidation(nameof(Person), nameof(Person.Age), nameof(PropertyValidator.MaxSize));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Age));
        }

        [Fact]
        public void ValidatePersonWithRequiredAddress()
        {
            var person = new Person() { Name = "Oi", Age = 10, Address = null };
            var exception = Execute(person);
            var validation = GetValidation(nameof(Person), nameof(Person.Address), nameof(PropertyValidator.Required));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Address));
        }

        [Fact]
        public void ValidatePersonWithRequiredAddressName()
        {
            var person = new Person() { Name = "Oi", Age = 10, Address = new Address() { Name = null } };
            var exception = Execute(person);
            var validation = GetValidation(nameof(Address), $"{nameof(Address)}.{nameof(Address.Name)}", nameof(PropertyValidator.Required));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, $"{nameof(Address)}.{nameof(Address.Name)}");
        }

        [Fact]
        public void ValidatePersonWithAddressNameMaxLength()
        {
            var person = new Person() { Name = "Oi", Age = 10, Address = new Address() { Name = Enumerable.Repeat('a', 51).ToString() } };
            var exception = Execute(person);
            var validation = GetValidation(nameof(Address), $"{nameof(Address)}.{nameof(Address.Name)}", nameof(PropertyValidator.MaxLength));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, $"{nameof(Address)}.{nameof(Address.Name)}");
        }

        [Fact]
        public void ValidatePersonWithAddressNameMinLength()
        {
            var person = new Person() { Name = "Oi", Age = 10, Address = new Address() { Name = "O" } };
            var exception = Execute(person);
            var validation = GetValidation(nameof(Address), $"{nameof(Address)}.{nameof(Address.Name)}", nameof(PropertyValidator.MinLength));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, $"{nameof(Address)}.{nameof(Address.Name)}");
        }

        [Fact]
        public void SuccessValidate()
        {
            var person = new Person() { Name = "Oi", Age = 10, Address = new Address() { Name = "Oi" } };

            _validator = new ValidateWithJSONCommand(_validators.ToList());

            _validator.Execute(person);
        }

        private IValidation GetValidation(string className, string propertyName, string validationName)
        {
            var validation = _validators.FirstOrDefault(v => v.Name == className).Properties.FirstOrDefault(p => p.Name == propertyName);

            return validation.GetType().GetProperty(validationName).GetValue(validation) as IValidation;
        }

        private ValidationException Execute(Person person)
        {
            _validator = new ValidateWithJSONCommand(_validators.ToList());

            return Assert.Throws<ValidationException>(() => _validator.Execute(person));
        }

        private void Asserts(ValidationError result, IValidation expected, string propertyName)
        {
            Assert.Equal(expected.Message, result.Message);
            Assert.Equal(expected.Code, result.Code);
            Assert.Equal(propertyName, result.Property);
        }
    }
}
