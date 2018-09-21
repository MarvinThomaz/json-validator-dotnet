namespace JSONValidationTest.Validation
{
    public class RequiredValidation : Validation
    {
        public override ValidationResult Validate(string property, object source)
        {
            var result = (source.IsNumber() && source.ToNumber() == 0) || (source is string && string.IsNullOrEmpty(source.ToString())) || source == null;

            return this.FromInfo(property, result);
        }
    }
}