namespace user_service.Exceptions;

public class InvalidDataException : Exception
{
    public InvalidDataException(string msg) : base(msg)
    {
    }
    
    public InvalidDataException()
    {
    }
}