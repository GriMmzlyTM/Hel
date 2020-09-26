using Hel.Engine.ECS.Components.Examples;
using Hel.Engine.ECS.Components.Model;
using Hel.Engine.ECS.Systems.System;

namespace Hel.Engine.ECS.Systems.ExampleSystems
{
    public class TestSystemMovementIncreaseDecoupled : ISystem<TransformExample, MovementExample>
    {
        public (TransformExample?, MovementExample?) RunSystem(int entityId, TransformExample transformExample, MovementExample movementExample)
        {
            movementExample.Speed += 5;
            return (transformExample, movementExample);
        }
    }
}