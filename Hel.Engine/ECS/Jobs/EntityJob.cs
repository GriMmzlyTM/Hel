using System.Threading;
using Hel.Engine.ECS.Entities;
using Hel.Engine.Jobs.Model;

namespace Hel.Engine.ECS.Jobs
{
    public delegate void EntityJobCallback(EntityLookup entityList);
    public class EntityJob : IJob<EntityLookup>
    {
        private readonly EntityLookup _entities;

        private readonly EntityJobCallback _jobCallback;
        public string Key { get; private set; }

        public EntityJob(
            EntityLookup entities,
            EntityJobCallback jobCallback,
            string key)
        {
            _entities = entities;
            _jobCallback = jobCallback;
            Key = key;
        }

        public void QueueJobThread() =>
            ThreadPool.QueueUserWorkItem(new WaitCallback(jobLogic), this);

        public void Run(EntityLookup entityList) => _jobCallback(entityList);

        public EntityLookup GetData() => _entities;

        private void jobLogic(object obj)
        {
            EntityJob job = (EntityJob)obj;

            job.Run(job.GetData());

            EntityJobManager.SignalJobCompletion(job.Key);

        }

    }
}
