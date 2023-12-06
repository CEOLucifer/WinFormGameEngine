namespace Com.WWZ.WinFormGameEngine;


public class AlreadyDestroyedException : Exception
{
    public AlreadyDestroyedException(string? message) : base(message) { }
}
