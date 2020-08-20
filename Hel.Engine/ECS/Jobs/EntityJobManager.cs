using System.Collections.Generic;
using System.Linq;
using Hel.Engine.ECS.Entities;
using Hel.Engine.Jobs.ExceptionExtensions;
using Hel.Engine.Jobs.Model;

namespace Hel.Engine.ECS.Jobs
{
    internal class EntityJobManager
    {

        private static List<string> _jobsRunning = new List<string>();

        public EntityJobManager()
        {

        }

        public static void SignalJobCompletion(string key)
        {
            if (!(_jobsRunning.FirstOrDefault(x => x.Equals(key)) is null))
                _jobsRunning.Remove(key);
            else
                throw new JobNotQueuedException($"{key} job is not running!");
        }

        private static void AddRunningJob(string key)
        {
            if (_jobsRunning.FirstOrDefault(x => x.Equals(key)) is null)
                _jobsRunning.Add(key);
            else
                throw new JobAlreadyQueuedException($"{key} job is already running!");
        }

        public static List<string> GetRunningJobs() => _jobsRunning;

        public static void RunJobs()
        {

            Queue<IJob<EntityDictionary>> jobQueue = EntityJobScheduler.GetJobs();

            while (jobQueue.Count != 0)
            {
                IJob<EntityDictionary> job = jobQueue.Dequeue();
                AddRunningJob(job.Key);
                job.QueueJobThread();

            }
        }

    }
}
