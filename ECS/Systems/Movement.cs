using Hel.Controls;
using Hel.ECS.Components;
using Hel.ECS.Entities;
using Hel.Jobs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Hel.ECS.Systems
{
    public class Movement : System
    {

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


        protected override void JobLogic(IEnumerable<IEntity> entityList)
        {
            
            foreach (IEntity entity in entityList)
            {
                if (entity.Active == false) continue;
                if (entity is IMovement moveComponent)
                {
                    Vector2 moveDir = (MoveDirection.KeyboardDirection() * 5);
                    moveComponent.X += (moveDir.X * SystemManager.DeltaTime);
                    moveComponent.Y += (moveDir.Y * SystemManager.DeltaTime);

                    JobMutator.StageEntityMutation(entity);
                }

            }
        }

    }
}