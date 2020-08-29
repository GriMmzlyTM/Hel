namespace Hel.Tiled.Models.Tileset.Tiles
{
    /// <summary>
    /// Single frame of a tile animation
    /// </summary>
    public class Frame
    {
        /// <summary>
        /// Frame duration in milliseconds
        /// </summary>
        public int Duration { get; set; }
        
        /// <summary>
        /// Local tile ID representing this frame (This is tilemap specific)
        /// </summary>
        public int TileId { get; set; }
    }
}