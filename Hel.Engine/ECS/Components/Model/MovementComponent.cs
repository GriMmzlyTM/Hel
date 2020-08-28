using System;

namespace Hel.Engine.ECS.Components.Model
{
    public struct MovementComponent : IComponent, IEquatable<MovementComponent>
    {
        public bool Active { get; set; }

        public bool Equals(MovementComponent other)
        {
            return Active == other.Active;
        }
    }

}
