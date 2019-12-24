using System;

namespace Hel.Jobs.ExceptionExtensions
{
    public class JobAlreadyQueuedException : Exception
    {
        public JobAlreadyQueuedException() { }

        public JobAlreadyQueuedException(string message) : base(message) { }
    }
}
