namespace Hel.Tiled.Models.Layers
{
    public class Chunk
    {
        /// <summary>
        ///  Array of unsigned int GIDs
        /// </summary>
        public string[] Data { get; set; }
        
        /// <summary>
        /// Height in tiles
        /// </summary>
        public int Height { get; set; }
        
        /// <summary>
        /// Width in tiles
        /// </summary>
        public int Width { get; set; }
        
        /// <summary>
        /// X coordinate in tiles
        /// </summary>
        public int X { get; set; }
        
        /// <summary>
        /// Y coordinate in tiles
        /// </summary>
        public int Y { get; set; }
        
    }
}