using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hel.ECS.Entities;

namespace Hel.Jobs
{
    internal interface IJob
    {
        string Key { get; }
        JobResponse Run();
    }

    internal class Job : IJob
    {
        private readonly ParameterizedThreadStart jobThreadMethod;
        private readonly IEnumerable<IEntity> entities;
        public string Key { get; private set; }

        public Job(IEnumerable<IEntity> entities, ParameterizedThreadStart job, string Key)
        {
            this.Key = Key;
            jobThreadMethod = job;
            this.entities = entities;
            JobScheduler.ScheduleJob(this);
        }

        public JobResponse Run()
        {

            //ThreadPool.QueueUserWorkItem(new WaitCallback(jobThreadMethod), entities);

            //JobResponse res = new JobResponse();

            //Thread jobThread = new Thread(jobThreadMethod);
            //jobThread.Start(entities);



            return new JobResponse();

        }
    }
}
