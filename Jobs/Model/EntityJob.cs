using Hel.ECS.Entities;
using Hel.ECS.Jobs;
using System.Threading;

namespace Hel.Jobs.Model
{
    public delegate void EntityJobCallback(EntityDictionary entityList);
    public class EntityJob : IJob<EntityDictionary>
    {
        private readonly EntityDictionary _entities;

        private readonly EntityJobCallback _jobCallback;
        public string Key { get; private set; }

        public EntityJob(
            EntityDictionary entities,
            EntityJobCallback jobCallback,
            string key)
        {
            _entities = entities;
            _jobCallback = jobCallback;
            Key = key;
        }

        public void QueueJobThread() =>
            ThreadPool.QueueUserWorkItem(new WaitCallback(jobLogic), this);

        public void Run(EntityDictionary entityList) => _jobCallback(entityList);

        public EntityDictionary GetData() => _entities;

        private void jobLogic(object obj)
        {
            EntityJob job = (EntityJob)obj;

            job.Run(job.GetData());

            EntityJobManager.SignalJobCompletion(job.Key);

        }

    }
}
