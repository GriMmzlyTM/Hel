namespace Hel.Tiled.Models.Tileset.Tiles
{
    public class Frame
    {
        /// <summary>
        /// Frame duration in milliseconds
        /// </summary>
        public int Duration { get; set; }
        
        /// <summary>
        /// Local tile ID representing this frame
        /// </summary>
        public int TileId { get; set; }
    }
}