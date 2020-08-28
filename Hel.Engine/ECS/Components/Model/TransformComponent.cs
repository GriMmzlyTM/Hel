using System;
using System.Runtime.InteropServices;

namespace Hel.Engine.ECS.Components.Model
{
    public struct TransformComponent : IComponent, IEquatable<TransformComponent>
    {
        /// <summary>
        /// The X position where your Texture2D will be placed when drawing
        /// </summary>
        public uint X { get; set; }

        /// <summary>
        /// The Y position where your Texture2D will be places when drawing
        /// </summary>
        public uint Y { get; set; }
        public bool Active { get; set; }

        public bool Equals(TransformComponent other)
        {
            return X.Equals(other.X) 
                   && Y.Equals(other.Y) 
                   && Active == other.Active;
        }
        
    }
}
