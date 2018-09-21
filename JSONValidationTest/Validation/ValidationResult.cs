namespace JSONValidationTest.Validation
{
    public class ValidationResult : ValidationInfo
    {
        public ValidationResult(ValidationInfo validation, string property, bool result)
        {
            Property = property;
            Result = result;
            Code = validation.Code;
            Message = validation.Message;
        }

        public bool Result { get; set; }
        public string Property { get; set; }
    }
}