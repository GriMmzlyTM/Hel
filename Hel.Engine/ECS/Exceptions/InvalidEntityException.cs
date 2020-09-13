using System;

namespace Hel.Engine.ECS.Exceptions
{
    public class InvalidEntityException : Exception
    {
        public  InvalidEntityException() {}
        public InvalidEntityException(string msg) : base(msg) {}
    }
}