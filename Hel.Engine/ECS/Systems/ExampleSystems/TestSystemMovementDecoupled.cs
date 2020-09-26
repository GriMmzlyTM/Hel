using Hel.Engine.ECS.Components.Examples;
using Hel.Engine.ECS.Components.Model;
using Hel.Engine.ECS.Entities.Matcher.Groups;
using Hel.Engine.ECS.Systems.System;
using Hel.Engine.Input.GameComponent;
using Microsoft.Xna.Framework;

namespace Hel.Engine.ECS.Systems.ExampleSystems
{
    /// <summary>
    /// System generic order matters
    /// </summary>
    public class TestSystemMovementDecoupled : ISystem<MovementExample, TransformExample>
    {
        /// <summary>
        /// Is run by <see cref="EntityGroup{TComponent1, TComponent2}"/> every update
        /// </summary>
        /// <returns>Returns modified data to the <see cref="EntityGroup{TComponent1, TComponent2}"/> and updates the component containers</returns>
        public (MovementExample?, TransformExample?) RunSystem(int entityId, MovementExample movementExample, TransformExample transformExample)
        {
            var moveDirection = InputHandler.MoveVector;

            if (moveDirection != Vector2.Zero)
            {
                transformExample.X += (moveDirection.X * movementExample.Speed);
                transformExample.Y += (moveDirection.Y * movementExample.Speed);
                return (default, transformExample);
            }

            // For performance reasons, only return data that has been modified and needs to be updated
            return default;

        }
    }
}