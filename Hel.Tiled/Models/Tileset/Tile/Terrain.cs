using System.Collections.Generic;

namespace Hel.Tiled.Models.Tileset.Tile
{
    public class Terrain
    {
        /// <summary>
        /// Name of terrain
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// List of custom properties for terrain
        /// </summary>
        public List<Property> Properties { get; }
        
        /// <summary>
        /// Local ID of tile representing terrain
        /// </summary>
        public int Tile { get; }
    }
}