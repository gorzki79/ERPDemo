namespace ERPDemo.Infrastructure.ErrorHandling
{
    public interface IExceptionTranslator
    {
        ErrorResponse Translate(Exception exception);
        ErrorResponse Translate<TEx>(TEx exception) where TEx : Exception;
    }
}
