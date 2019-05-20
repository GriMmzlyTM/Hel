using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hel.ECS.Entities;

namespace Hel.Jobs
{

    public delegate void EntityJobCallback (IEnumerable<IEntity> entityList);
    internal interface IJob
    {
        string Key { get; }
        void QueueJobThread();
    }

    internal class EntityJob : IJob
    {
        private readonly IEnumerable<IEntity> _entities;
        //public readonly JobManager manager;

        private readonly EntityJobCallback _jobCallback;
        public string Key { get; private set; }

        public EntityJob(
            IEnumerable<IEntity> entities, 
            EntityJobCallback jobCallback, 
            string key)
        {

            _entities = entities;
            //this.manager = manager;
            _jobCallback = jobCallback;
            Key = key;

        }

        public void QueueJobThread()
        {

            ThreadPool.QueueUserWorkItem(new WaitCallback(jobLogic), this);

        }

        public void Run(IEnumerable<IEntity> entity) => _jobCallback(entity);

        public IEnumerable<IEntity> GetEntities() => _entities;

        private void jobLogic(object obj)
        {
            EntityJob job = (EntityJob) obj;

            job.Run(job.GetEntities());

            JobManager.SignalJobCompletion(job.Key);

        }

    }

    public class JobAlreadyQueuedException : Exception
    {
        public JobAlreadyQueuedException() { }

        public JobAlreadyQueuedException(string message) : base(message) { }

    }
}
