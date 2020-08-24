using System.Collections.Generic;

namespace Hel.Tiled.Models.Tileset.Tiles
{
    public class Terrain
    {
        /// <summary>
        /// Name of terrain
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// List of custom properties for terrain
        /// </summary>
        public List<Property> Properties { get; set; }
        
        /// <summary>
        /// Local ID of tile representing terrain
        /// </summary>
        public int Tile { get; set; }
    }
}