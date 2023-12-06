namespace Com.WWZ.WinFormGameEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AlreadyExitException : Exception
{
    public AlreadyExitException() : base("GameSys has already been in Exit status.") { }
}
