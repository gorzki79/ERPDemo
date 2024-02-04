namespace ERPDemo.Application.Commands.Validation
{
    public class ValidationException : Exception
    {
        public Dictionary<string, string[]> Errors { get; }

        public ValidationException(Dictionary<string, string[]> errors)
        {
            Errors = errors;
        }
    }
}
