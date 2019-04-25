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

            if (jobQueue.FirstOrDefault(x => x.Key.Equals(job.Key)) == null)
                jobQueue.Enqueue(job);
        }

        public static Queue<IJob> GetQueue() => jobQueue;

    }
}
