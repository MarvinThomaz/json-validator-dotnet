namespace JSONValidationTest.Validation
{
    public abstract class Validation : ValidationInfo
    {
        public object Value { get; set; }

        public abstract ValidationResult Validate(string property, object source);
    }
}