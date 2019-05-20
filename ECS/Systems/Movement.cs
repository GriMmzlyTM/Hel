using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hel.Controls;
using Hel.ECS.Components;
using Hel.ECS.Entities;
using Hel.Jobs;
using Microsoft.Xna.Framework;

namespace Hel.ECS.Systems
{
    class Movement : System
    {
        //private readonly Job job;
        public Movement(SystemManager manager) : base(manager)
        {
            //job = new Job(world.EntityManager.GetEntityType<IMovement>(), JobLogic);
        }

        public override void Update(GameTime gameTime)
        {

            JobScheduler.ScheduleJob(
                new EntityJob(
                    world.EntityManager.GetEntityType<IMovement>(),
                    JobLogic,
                    "MovementJob"
                    ));
        }
        public override void JobLogic(IEnumerable<IEntity> entityList)
        {
            
            foreach (IEntity entity in entityList)
            {
                if (entity is IMovement moveComponent)
                {
                    Vector2 moveDir = (MoveDirection.KeyboardDirection() * 5);
                    //Console.WriteLine(MoveDirection.KeyboardDirection());
                    moveComponent.X += (moveDir.X * SystemManager.DeltaTime);
                    moveComponent.Y += (moveDir.Y * SystemManager.DeltaTime);

                    JobMutator.StageEntityMutation(entity);
                }

            }
        }

    }
}
