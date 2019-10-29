using Microsoft.Xna.Framework.Graphics;

namespace Hel.ECS.Components
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
    public interface IRender : IComponent
    {
        /// <summary>
        /// Texture is the Texture2D your entity should draw to the screen 
        /// </summary>
        Texture2D Texture { get; set; }

        /// <summary>
        /// The X position where your Texture2D will be placed when drawing
        /// </summary>
        float X { get; set; }

        /// <summary>
        /// The Y position where your Texture2D will be places when drawing
        /// </summary>
        float Y { get; set; }

    }

    public struct Render : IRender
    {
        public Texture2D Texture { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public bool Active { get; set; }
    }
}
