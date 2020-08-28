using System.Collections.Generic;

namespace Hel.Tiled.Models.Tileset.Wang
{
    public class WangSet
    {
        /// <summary>
        /// List of colors that can be used to define the corner of a Wang tile.
        /// </summary>
        public List<WangColor> CornerColors { get; set; }
        
        /// <summary>
        /// List of colors that can be used to define the edge of a Wang tile.
        /// </summary>
        public List<WangColor> EdgeColors { get; set; }
        
        /// <summary>
        /// Name of the Wang set
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Array of custom properties
        /// </summary>
        public List<Property> Properties { get; set; }
        
        /// <summary>
        /// Local ID of tile representing the Wang set
        /// </summary>
        public int Tile { get; set; }
        
        /// <summary>
        /// Defines a Wang tile, by referring to a tile in the tileset and associating it with a certain Wang ID.
        /// </summary>
        public List<WangTile> WangTiles { get; set; }
    }
}