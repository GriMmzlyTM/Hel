using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hel.Jobs
{
    class JobScheduler
    {
        private static readonly Queue<IJob> jobQueue = new Queue<IJob>();

        public static void ScheduleJob(IJob job)
        {

            if (jobQueue.FirstOrDefault(x => x.Key.Equals(job.Key)) is null)
                jobQueue.Enqueue(job);
            else
                throw new JobAlreadyQueuedException($"{job.Key} is already queue'd and defined! Please make sure to purge jobs after each update cycle.");

        }

        public static Queue<IJob> GetJobs() => jobQueue;
        public static void PurgeJobs() => jobQueue.Clear();
        

    }
}
