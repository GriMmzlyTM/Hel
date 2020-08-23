namespace Hel.Tiled.Models.Layers
{
    public class Chunk
    {
        /// <summary>
        ///  Array of unsigned int GIDs
        /// </summary>
        public string[] Data { get; }
        
        /// <summary>
        /// Height in tiles
        /// </summary>
        public int Height { get; }
        
        /// <summary>
        /// Width in tiles
        /// </summary>
        public int Width { get; }
        
        /// <summary>
        /// X coordinate in tiles
        /// </summary>
        public int X { get; }
        
        /// <summary>
        /// Y coordinate in tiles
        /// </summary>
        public int Y { get; }
        
    }
}