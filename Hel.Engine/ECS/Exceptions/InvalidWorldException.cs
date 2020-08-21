using System;

namespace Hel.Engine.ECS.Exceptions
{
    public class InvalidWorldException : Exception
    {
        public InvalidWorldException(){}
        
        public InvalidWorldException(string msg) : base(msg) {}
        
    }
}