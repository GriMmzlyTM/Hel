namespace Hel.Engine.ECS.Components.Model
{
    public struct TransformComponent : IComponent
    {
        /// <summary>
        /// The X position where your Texture2D will be placed when drawing
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// The Y position where your Texture2D will be places when drawing
        /// </summary>
        public float Y { get; set; }
        public bool Active { get; set; }
    }
}
