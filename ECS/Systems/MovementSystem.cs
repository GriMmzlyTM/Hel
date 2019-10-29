using Hel.Controls;
using Hel.ECS.Components;
using Hel.Jobs;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Hel.ECS.Systems
{
    public class MovementSystem : System
    {

        public MovementSystem(SystemManager manager) : base(manager)
        {
            //job = new Job(world.EntityManager.GetEntityType<IMovement>(), JobLogic);
        }

        public override void Update(GameTime gameTime)
        {

            JobScheduler.ScheduleJob(
                new EntityJob(
                    world.EntityManager.GetEntityType<MovementComponent>(),
                    JobLogic,
                    "MovementJob" ));
        }


        protected override void JobLogic(Dictionary<uint, HashSet<IComponent>> entityList)
        {
            
            foreach (var entity in entityList)
            {
                IComponent component;
                if (entity.Value.TryGetValue(typeof(MovementComponent), out component) == false) continue;
                if (entity is MovementComponent moveComponent)
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