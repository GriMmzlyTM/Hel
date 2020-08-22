using System;

namespace Hel.Engine.ECS.Exceptions
{
    public class InvalidComponentException : Exception
    {
        public  InvalidComponentException() {}
        public InvalidComponentException(string msg) : base(msg) {}
    }
}