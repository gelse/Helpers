namespace ErrorCarrier;

public class Error : IError
{
    public Exception? InnerException { get; }
    public string ErrorMessage { get; }

    public bool IsHandled { get; private set; } = false;

    internal Error(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    internal Error(Exception innerException)
    {
        InnerException = innerException;
        ErrorMessage = innerException.Message;
    }

    public TOutput Handle<TOutput>(Func<Error, TOutput> handleErrorAction)
    {
        var output = handleErrorAction(this);
        IsHandled = true;
        return output;
    }

    public static implicit operator Exception(Error error)
    {
        var unhandledException = error.InnerException;
        if (unhandledException != null)
            return unhandledException;
        return new ErrorMessageException(error.ErrorMessage);
    }
}