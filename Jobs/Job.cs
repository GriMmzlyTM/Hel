using Hel.ECS.Entities;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Hel.Jobs
{

    public delegate void EntityJobCallback (IEnumerable<IEntity> entityList);
    public interface IJob
    {
        /// <summary>
        /// The key that represents the job. Should properly represent the functionality 
        /// of the job to ensure multiple jobs with the same function dont run. 
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Queues the job to be run whenever a thread is available.
        /// </summary>
        void QueueJobThread();

        /// <summary>
        /// Returns the entities that the job utilizes.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IEntity> GetEntities();

        /// <summary>
        /// Runs the job logic specified on creation. 
        /// </summary>
        /// <param name="entityList">The list of entities to pass to the job.</param>
        void Run(IEnumerable<IEntity> entityList);
    }

    public class EntityJob : IJob
    {
        private readonly IEnumerable<IEntity> _entities;

        private readonly EntityJobCallback _jobCallback;
        public string Key { get; private set; }

        public EntityJob(
            IEnumerable<IEntity> entities, 
            EntityJobCallback jobCallback, 
            string key)
        {

            _entities = entities;
            _jobCallback = jobCallback;
            Key = key;

        }

        public void QueueJobThread() =>
            ThreadPool.QueueUserWorkItem(new WaitCallback(jobLogic), this);

        public void Run(IEnumerable<IEntity> entityList) => _jobCallback(entityList);

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
