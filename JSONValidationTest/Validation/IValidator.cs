namespace JSONValidationTest.Validation
{
    public interface IValidator
    {
        void Validate<T>(T obj);
    }
}