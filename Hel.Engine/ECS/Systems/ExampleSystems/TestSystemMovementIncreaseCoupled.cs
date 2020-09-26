using Hel.Engine.ECS.Components.Examples;
using Hel.Engine.ECS.Components.Model;
using Hel.Engine.ECS.Entities.Matcher;
using Hel.Engine.ECS.Entities.Matcher.Groups;
using Microsoft.Xna.Framework;

namespace Hel.Engine.ECS.Systems.ExampleSystems
{
    public class TestCoupledSystemMovementIncreaseCoupled : System.CoupledSystem
    {
        
        /// <summary>
        /// The system manager will run this every update. This runs AFTER the <see cref="EntityGroup{TComponent1}" events/>
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="deltaTime"></param>
        public override void Update(GameTime gameTime, float deltaTime)
        {

            // Order of generics for casting matters
            ((IEntityGroup<TransformExample, MovementExample>) GetMatcherQuerier().GetEntityMatcher(
                    new EntityGroupQuery()
                        // Containing order does not matter
                        .Containing<TransformExample>()
                        .Containing<MovementExample>()
                        .Build()))
                .ForEach((entityId, transform, movement) =>
                {
                    movement.Speed += 5;
                    return (transform, movement);
                });
        }
    }
}