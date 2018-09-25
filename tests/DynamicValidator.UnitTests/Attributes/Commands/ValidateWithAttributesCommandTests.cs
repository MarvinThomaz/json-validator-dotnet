using DynamicValidator.Abstractions;
using DynamicValidator.Attributes.Commands;
using DynamicValidator.Exceptions;
using DynamicValidator.JSON.Commands;
using DynamicValidator.JSON.Entities;
using DynamicValidator.UnitTests.Attributes.Models;
using System;
using System.Linq;
using Xunit;

namespace DynamicValidator.UnitTests.JSON.Commands
{
    public class ValidateWithAttributesCommandTests
    {
        private IValidateCommand _validator;
        
        [Fact]
        public void ValidatePersonWithRequiredName()
        {
            var person = new Person() { Name = null, Age = 10, Address = new Address() { Name = "Oi" } };
            var exception = Execute(person);
            var validation = GetValidation(person, nameof(Person.Name), typeof(IRequiredValidation));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Name));
        }

        [Fact]
        public void ValidatePersonWithNameMaxLength()
        {
            var person = new Person() { Name = Enumerable.Repeat('a', 51).ToString(), Age = 10, Address = new Address() { Name = "Oi" } };
            var exception = Execute(person);
            var validation = GetValidation(person, nameof(Person.Name), typeof(IMaxLengthValidation));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Name));
        }

        [Fact]
        public void ValidatePersonWithNameMinLength()
        {
            var person = new Person() { Name = "O", Age = 10, Address = new Address() { Name = "Oi" } };
            var exception = Execute(person);
            var validation = GetValidation(person, nameof(Person.Name), typeof(IMinLengthValidation));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Name));
        }

        [Fact]
        public void ValidatePersonWithRequiredAge()
        {
            var person = new Person() { Name = "Oi", Age = 0, Address = new Address() { Name = "Oi" } };
            var exception = Execute(person);
            var validation = GetValidation(person, nameof(Person.Age), typeof(IRequiredValidation));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Age));
        }

        [Fact]
        public void ValidatePersonWithAgeMinSize()
        {
            var person = new Person() { Name = "Oi", Age = 1, Address = new Address() { Name = "Oi" } };
            var exception = Execute(person);
            var validation = GetValidation(person, nameof(Person.Age), typeof(IMinSizeValidation));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Age));
        }

        [Fact]
        public void ValidatePersonWithAgeMaxSize()
        {
            var person = new Person() { Name = "Oi", Age = 50, Address = new Address() { Name = "Oi" } };
            var exception = Execute(person);
            var validation = GetValidation(person, nameof(Person.Age), typeof(IMaxSizeValidation));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Age));
        }

        [Fact]
        public void ValidatePersonWithRequiredAddress()
        {
            var person = new Person() { Name = "Oi", Age = 10, Address = null };
            var exception = Execute(person);
            var validation = GetValidation(person, nameof(Person.Address), typeof(IRequiredValidation));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, nameof(Person.Address));
        }

        [Fact]
        public void ValidatePersonWithRequiredAddressName()
        {
            var person = new Person() { Name = "Oi", Age = 10, Address = new Address() { Name = null } };
            var exception = Execute(person);
            var validation = GetValidation(person.Address, nameof(Address.Name), typeof(IRequiredValidation));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, $"{nameof(Address)}.{nameof(Address.Name)}");
        }

        [Fact]
        public void ValidatePersonWithAddressNameMaxLength()
        {
            var person = new Person() { Name = "Oi", Age = 10, Address = new Address() { Name = Enumerable.Repeat('a', 51).ToString() } };
            var exception = Execute(person);
            var validation = GetValidation(person.Address, nameof(Address.Name), typeof(IMaxLengthValidation));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, $"{nameof(Address)}.{nameof(Address.Name)}");
        }

        [Fact]
        public void ValidatePersonWithAddressNameMinLength()
        {
            var person = new Person() { Name = "Oi", Age = 10, Address = new Address() { Name = "O" } };
            var exception = Execute(person);
            var validation = GetValidation(person.Address, nameof(Address.Name), typeof(IMinLengthValidation));
            var exceptionValidator = exception.Validations.First();

            Asserts(exceptionValidator, validation, $"{nameof(Address)}.{nameof(Address.Name)}");
        }

        [Fact]
        public void SuccessValidate()
        {
            var person = new Person() { Name = "Oi", Age = 10, Address = new Address() { Name = "Oi" } };

            _validator = new ValidateWithAttributesCommand();

            _validator.Execute(person);
        }

        private IValidation GetValidation(object obj, string propertyName, Type validationType)
        {
            return obj.GetType().GetProperty(propertyName).GetCustomAttributes(validationType, true).First() as IValidation;
        }

        private ValidationException Execute(Person person)
        {
            _validator = new ValidateWithAttributesCommand();

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
