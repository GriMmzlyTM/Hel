using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hel.Jobs
{
    class JobManager
    {
        public JobManager()
        {

        }

        public void RunJobs()
        {

            while (JobScheduler.GetQueue().Count != 0)
            {
                JobScheduler.GetQueue().Dequeue().Run();
            }
        }

    }
}
