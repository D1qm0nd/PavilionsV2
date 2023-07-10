namespace PavilionsData.Exceptions;

public class RecordExistingException : Exception
{
    public new string Message { get; set; }

    public RecordExistingException(string? message = null)
    {
        Message = message ?? string.Empty;
    }
}