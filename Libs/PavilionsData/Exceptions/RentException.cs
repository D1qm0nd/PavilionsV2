namespace PavilionsData.Exceptions;

public class RentException : Exception
{
    public new string Message;

    public RentException(string? message = null)
    {
        Message = message ?? string.Empty;
    }
}