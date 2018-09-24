namespace DynamicValidator.JSON.Services
{
    public interface IValidatorApplicationService
    {
        void Validate<T>(T obj);
    }
}