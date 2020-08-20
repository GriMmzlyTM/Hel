using System;

namespace Hel.Engine.Jobs.ExceptionExtensions
{
    public class JobAlreadyQueuedException : Exception
    {
        public JobAlreadyQueuedException() { }

        public JobAlreadyQueuedException(string message) : base(message) { }
    }
}
