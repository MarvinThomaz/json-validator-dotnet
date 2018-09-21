namespace JSONValidationTest.Validation
{
    public class PropertyValidator
    {
        public string Name { get; set; }
        public RequiredValidation Required { get; set; }
        public MinLengthValidation MinLength { get; set; }
        public MaxLengthValidation MaxLength { get; set; }
        public MinSizeValidation MinSize { get; set; }
        public MaxSizeValidation MaxSize { get; set; }
    }
}