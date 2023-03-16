namespace ErrorCarrier;

public interface IError
{
    string ErrorMessage { get; }
    Exception? InnerException { get; }
    bool IsHandled { get; }
}