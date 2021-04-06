namespace CloudNativeApplicationComponents.Utils
{
    public interface IValidator<T>
    {
        ValidationResult Validate(IValidator<T> validator);
    }
}
