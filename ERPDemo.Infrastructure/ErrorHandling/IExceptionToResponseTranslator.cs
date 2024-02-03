namespace ERPDemo.Infrastructure.ErrorHandling
{
    public interface IExceptionToResponseTranslator<TEx>
        where TEx : Exception
    {
        ErrorResponse Translate(TEx exception);
    }
}
