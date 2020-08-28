using System;

namespace Hel.Engine.ECS.Components.Model
{
    /// <summary>
    /// Sets if the entity this is attached to is active at all. Inactive entities are not sent to any system. 
    /// </summary>
    public struct EntityActiveComponent : IComponent, IEquatable<EntityActiveComponent>
    {
        public bool Active { get; set; }

        public bool Equals(EntityActiveComponent other)
        {
            return Active == other.Active;
        }
    }
}
