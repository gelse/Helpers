namespace ErrorCarrier;

public class ErrorCarrier<T> : IErrorCarrier
{
    public ErrorCarrier(T? valueObject)
    {
        ValueObject = valueObject;
    }
    
    public T? ValueObject { get; }

    public static implicit operator T?(ErrorCarrier<T> carrier) => carrier.GetValue();

    private T? GetValue()
    {
        if (Errors.All(e => e.IsHandled))
            return ValueObject;
        var unHandledErrors = Errors
            .Where(e => !e.IsHandled)
            .Cast<Error>()
            .Select(e => (Exception)e)
            .ToList();
        if (unHandledErrors.Count == 1)
        {
            throw unHandledErrors.Single();
        }
        
        throw new ExceptionCollectionException(unHandledErrors);
    }

    public IList<IError> Errors { get; } = new List<IError>();
}