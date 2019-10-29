using System;

namespace Hel.ECS.Components
{ 
    public struct MovementComponent : IComponent
    {
        public bool Active { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }

}
