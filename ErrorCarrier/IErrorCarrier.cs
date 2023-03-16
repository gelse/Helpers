namespace ErrorCarrier;

public interface IErrorCarrier
{
    public IList<IError> Errors { get; }
}