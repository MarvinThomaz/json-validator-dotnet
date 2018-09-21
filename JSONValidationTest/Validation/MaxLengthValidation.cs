namespace JSONValidationTest.Validation
{
    public class MaxLengthValidation : Validation
    {
        public override ValidationResult Validate(string property, object source)
        {
            if (source is string)
            {
                
                return this.FromInfo(property, source.ToString().Length > Value.ToString().Length);
            }

            return this.FromInfo(property, false);
        }
    }
}