using System.Collections.Generic;
using System.Linq;
using Hel.Engine.ECS.Entities;
using Hel.Engine.Jobs.ExceptionExtensions;
using Hel.Engine.Jobs.Model;

namespace Hel.Engine.ECS.Jobs
{
    public class EntityJobScheduler
    {
        private static readonly Queue<IJob<EntityLookup>> jobQueue = new Queue<IJob<EntityLookup>>();

        /// <summary>
        /// Tries to queue the job if not already queued. 
        /// Throws JobAlreadyQueuedException 
        /// </summary>
        /// <param name="job">The job you wish to queue</param>
        public static void ScheduleJob(IJob<EntityLookup> job)
        {

            if (jobQueue.FirstOrDefault(x => x.Key.Equals(job.Key)) is null)
                jobQueue.Enqueue(job);
            else
                throw new JobAlreadyQueuedException($"{job.Key} is already queue'd and defined! Please make sure to purge jobs after each update cycle.");

        }

        /// <summary>
        /// Returns the jobQueue.
        /// </summary>
        /// <returns></returns>
        public static Queue<IJob<EntityLookup>> GetJobs() => jobQueue;

        /// <summary>
        /// Purge all jobs from the jobQueue
        /// </summary>
        public static void PurgeJobs() => jobQueue.Clear();

    }
}
