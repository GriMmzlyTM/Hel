using System.Collections.Generic;
using System.Linq;

namespace Hel.Jobs
{
    class JobScheduler
    {
        private static readonly Queue<IJob> jobQueue = new Queue<IJob>();

        /// <summary>
        /// Tries to queue the job if not already queued. 
        /// Throws JobAlreadyQueuedException 
        /// </summary>
        /// <param name="job">The job you wish to queue</param>
        public static void ScheduleJob(IJob job)
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
        public static Queue<IJob> GetJobs() => jobQueue;

        /// <summary>
        /// Purge all jobs from the jobQueue
        /// </summary>
        public static void PurgeJobs() => jobQueue.Clear();
        

    }
}
