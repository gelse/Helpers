namespace ErrorCarrier;

public class ErrorMessageException :  Exception
{
    public ErrorMessageException(string unhandledErrorErrorMessage)
        : base(unhandledErrorErrorMessage)
    { }
}