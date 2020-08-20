using System;

namespace Hel.Engine.Jobs.ExceptionExtensions
{
    public class JobNotQueuedException : Exception
    {
        public JobNotQueuedException() { }

        public JobNotQueuedException(string message) : base(message) { }
    }
}
