namespace Hel.Tiled.Models.Layers
{
    public class ImageLayer : Layer
    {
        /// <summary>
        /// Hex-formatted color (#RRGGBB) (optional). imagelayer only.
        /// </summary>
        public string TransparentColor { get; }
        
        /// <summary>
        /// Image used by this layer
        /// </summary>
        public string Image { get; }
    }
}