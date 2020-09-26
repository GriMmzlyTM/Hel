using System;

namespace Hel.Engine.ECS.Exceptions
{
    public class InvalidEntityGroupException  : Exception
    {
        public  InvalidEntityGroupException() {}
        public InvalidEntityGroupException(string msg) : base(msg) {}
    }
}