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
            ThreadPool.QueueUserWorkItem(new WaitCallback(JobLogic), world.EntityManager.GetEntityType<IMovement>());
            //Job job = new Job(world.EntityManager.GetEntityType<IMovement>(), JobLogic, "MoveLogic");
            //                        foreach (IEntity component in world.EntityManager.GetEntityType<IMovement>())
            //                        {
            //                            if (component is IMovement moveComponent)
            //                            {
            //                                Vector2 moveDir = (MoveDirection.KeyboardDirection() * 5);
            //                                moveComponent.X += (moveDir.X * ((float) gameTime.ElapsedGameTime.TotalSeconds * 30));
            //                                moveComponent.Y += (moveDir.Y * (float) gameTime.ElapsedGameTime.TotalSeconds * 30);
            //                                world.EntityManager.ReplaceEntity((IEntity) moveComponent);
            //                            }
            //
            //                        }

        }
        public override void JobLogic(object obj)
        {
            
            foreach (IEntity entity in (obj as IEnumerable<IEntity>))
            {
                if (entity is IMovement moveComponent)
                {
                    Vector2 moveDir = (MoveDirection.KeyboardDirection() * 5);
                    Console.WriteLine(MoveDirection.KeyboardDirection());
                    moveComponent.X += (moveDir.X * SystemManager.DeltaTime);
                    moveComponent.Y += (moveDir.Y * SystemManager.DeltaTime);

                    JobMutator.StageEntityMutation(entity);

                }

            }
        }

    }
}
