namespace Hel.Tiled.Models.Tileset.Wang
{
    public class WangTile
    {
        /// <summary>
        /// Tile is flipped diagonally (default: false)
        /// </summary>
        public bool DFlip { get; }
        
        /// <summary>
        /// Tile is flipped horizontally (default: false
        /// </summary>
        public bool HFlip { get; }
        
        /// <summary>
        /// Tile is flipped vertically (default: false)
        /// </summary>
        public bool VFlip { get; }

        /// <summary>
        /// 	Local ID of tile
        /// </summary>
        public int TileId { get; }
        
        /// <summary>
        /// Array of Wang color indexes
        /// </summary>
        public int[] WangId { get; }
    }
}