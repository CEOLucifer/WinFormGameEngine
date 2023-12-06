namespace Com.WWZ.WinFormGameEngine;

using System;

public class AlreadyEnterException : Exception
{
    public AlreadyEnterException() : base("GameSys has already been in Enter status.") { }
}
