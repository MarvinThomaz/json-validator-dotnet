namespace JSONValidationTest.Validation
{
    public class MaxSizeValidation : Validation
    {
        public override ValidationResult Validate(string property, object source)
        {
            return this.FromInfo(property, source.ToNumber() > Value.ToNumber());
        }
    }
}