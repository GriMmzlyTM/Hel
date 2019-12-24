using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hel.Jobs
{
    class JobManager
    {

        private static List<string> _jobsRunning = new List<string>();

        public JobManager()
        {

        }

        public static void SignalJobCompletion(string key)
        {
            if (!(_jobsRunning.FirstOrDefault(x => x.Equals(key)) is null))
                _jobsRunning.Remove(key);
            else
                throw new JobNotQueuedException($"{key} job is not running!");
        }

        private static void AddRunningJob(string key) {
            if (_jobsRunning.FirstOrDefault(x => x.Equals(key)) is null)
                _jobsRunning.Add(key);
            else
                throw new JobAlreadyQueuedException($"{key} job is already running!");
        }

        public static List<string> GetRunningJobs() => _jobsRunning;

        public static void RunJobs()
        {

            Queue<IJob> jobQueue = JobScheduler.GetJobs();

            while (jobQueue.Count != 0)
            {
                IJob job = jobQueue.Dequeue();
                AddRunningJob(job.Key);
                job.QueueJobThread();
                
            }
        }

    }
}
