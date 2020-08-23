namespace Hel.Tiled.Models.Tileset.Tile
{
    public class Frame
    {
        /// <summary>
        /// Frame duration in milliseconds
        /// </summary>
        public int Duration { get; }
        
        /// <summary>
        /// Local tile ID representing this frame
        /// </summary>
        public int TileId { get; }
    }
}