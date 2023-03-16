namespace ErrorCarrier;

public class ExceptionCollectionException : Exception
{
    public IList<Exception> InnerExceptions { get; }

    public ExceptionCollectionException(IList<Exception> exceptions)
        : base($"{exceptions.Count} errors occurred:\n{string.Join(Environment.NewLine, exceptions.ToString())}")
    {
        InnerExceptions = exceptions;
    }
}