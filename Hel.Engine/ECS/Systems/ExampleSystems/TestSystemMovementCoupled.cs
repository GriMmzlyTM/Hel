using Hel.Engine.ECS.Components.Examples;
using Hel.Engine.ECS.Components.Model;
using Hel.Engine.ECS.Entities.Matcher;
using Hel.Engine.ECS.Entities.Matcher.Groups;
using Hel.Engine.Input.GameComponent;
using Microsoft.Xna.Framework;

namespace Hel.Engine.ECS.Systems.ExampleSystems
{
    public class TestCoupledSystemMovementCoupled : System.CoupledSystem
    {
        
        public override void Update(GameTime gameTime, float deltaTime)
        {

            ((IEntityGroup<MovementExample, TransformExample>) GetMatcherQuerier().GetEntityMatcher(
                    new EntityGroupQuery()
                        .Containing<MovementExample>()
                        .Containing<TransformExample>()
                        .Build()))
                .ForEach((entityId, movement, transform) =>
                {
                    var moveDirection = InputHandler.MoveVector;

                    if (moveDirection != Vector2.Zero)
                    {
                        transform.X += (moveDirection.X * movement.Speed);
                        transform.Y += (moveDirection.Y * movement.Speed);
                        return (default, transform);
                    }

                    return (movement, transform);
                });
        }
    }
}