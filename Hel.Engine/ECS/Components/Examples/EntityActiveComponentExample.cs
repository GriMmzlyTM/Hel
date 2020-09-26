using System;
using Hel.Engine.ECS.Components.Model;

namespace Hel.Engine.ECS.Components.Examples
{
    /// <summary>
    /// Sets if the entity this is attached to is active at all. Inactive entities are not sent to any system. 
    /// </summary>
    public struct EntityActiveComponentExample : IComponent, IEquatable<EntityActiveComponentExample>
    {
        public bool Active { get; set; }

        public bool Equals(EntityActiveComponentExample other)
        {
            return Active == other.Active;
        }
    }
}
