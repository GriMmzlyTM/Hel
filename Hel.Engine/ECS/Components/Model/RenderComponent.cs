using System;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.Engine.ECS.Components.Model
{
    /// <summary>
    /// The IRender component handles rendering the 
    /// entity texture to the screen. 
    /// IRender should be used for any entity that contains
    /// visuals as opposed to simply logic. 
    /// 
    /// IRender has its own Render system which is added to the
    /// SystemManager when the World is created. 
    /// </summary>
    public struct RenderComponent : IRenderComponent, IEquatable<RenderComponent>
    {
        /// <summary>
        /// Texture is the Texture2D your entity should draw to the screen 
        /// </summary>
        public Texture2D Texture { get; set; }
        
        public ushort ZIndex { get; set; }
        public bool Active { get; set; }
        

        public bool Equals(RenderComponent other)
        {
            return Equals(Texture, other.Texture) 
                   && ZIndex == other.ZIndex 
                   && Active == other.Active;
        }
    }
}
