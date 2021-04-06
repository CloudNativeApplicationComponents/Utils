namespace CloudNativeApplicationComponents.Utils
{
    public interface IValidatable<T>
        where T : IValidatable<T>
    {
        ValidationResult Validate(IValidator<T> validator);
    }
}
