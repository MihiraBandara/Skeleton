namespace Skeleton.Application.Exceptions
{
    public class ValdationException : Exception
    {
        public IReadOnlyCollection<ValidationError> _errors { get; set; }
        public ValdationException(IReadOnlyCollection<ValidationError> errors)
        {
            _errors = errors;
        }
    }

    public record ValidationError(string PropertyName, string ErrorMessage);
}
