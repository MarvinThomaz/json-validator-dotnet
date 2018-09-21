namespace JSONValidationTest.Validation
{
    public class MinLengthValidation : Validation
    {
        public override ValidationResult Validate(string property, object source)
        {
            if (source is string)
            {
                return this.FromInfo(property, (source as string).Length < (Value as string).Length);
            }

            return this.FromInfo(property, false);
        }
    }
}