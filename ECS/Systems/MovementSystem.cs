using Hel.Controls;
using Hel.ECS.Components;
using Hel.ECS.Components.Model;
using Hel.ECS.Entities;
using Hel.ECS.Jobs;
using Hel.Jobs.Model;
using Microsoft.Xna.Framework;

namespace Hel.ECS.Systems
{
    public class MovementSystem : System
    {

        public MovementSystem(SystemManager manager) : base(manager)
        {
            //job = new Job(world.EntityManager.GetEntities<IMovement>(), JobLogic);
        }

        public override void Update(GameTime gameTime)
        {
            EntityJobScheduler.ScheduleJob(
                new EntityJob(
                    world.EntityManager.GetEntities<MovementComponent>(),
                    JobLogic,
                    "MovementJob" ));
        }


        protected override void JobLogic(EntityDictionary entityList)
        {
            
            foreach (var entity in entityList) 
            {
                
                if (entity.Value.GetComponentOrFail(out MovementComponent movementComponent)
                    && entity.Value.GetComponentOrFail(out TransformComponent transformComponent))
                {
                    Vector2 moveDir = (MoveDirection.KeyboardDirection() * 5);
                    transformComponent.X += (moveDir.X * SystemManager.DeltaTime);
                    transformComponent.Y += (moveDir.Y * SystemManager.DeltaTime);

                    EntityJobMutator.StageEntityMutation(entity.Key, transformComponent);
                }

            }
        }

    }
}