using System.Collections.Generic;
using Hel.Tiled.Models.Enums;
using Hel.Tiled.Models.Tileset.Tiles;
using Hel.Tiled.Models.Tileset.Wang;

namespace Hel.Tiled.Models.Tileset
{
    public class Tileset
    {
        /// <summary>
        /// 	Name given to this tileset
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The number of tile columns in the tileset
        /// </summary>
        public int Columns { get; set; }
        
        /// <summary>
        /// Each tileset has a firstgid (first global ID) property which tells you the global ID of its first tile
        /// (the one with local tile ID 0). This allows you to map the global IDs back to the right tileset,
        /// and then calculate the local tile ID by subtracting the firstgid from the global tile ID. The first tileset
        /// always has a firstgid value of 1.
        /// </summary>
        public int FirstGid { get; set; }
        
        /// <summary>
        /// Optional
        /// </summary>
        public Grid? Grid { get; set; }
        
        /// <summary>
        /// Image used for tiles in this set
        /// </summary>
        public string Image { get; set; }
        
        /// <summary>
        /// Height of source image in pixels
        /// </summary>
        public int ImageHeight { get; set; }
        
        /// <summary>
        /// Width of source image in pixels
        /// </summary>
        public int ImageWidth { get; set; }
        
        /// <summary>
        /// Buffer between image edge and first tile (pixels)
        /// </summary>
        public int Margin { get; set; }
        
        /// <summary>
        /// Hex-formatted color (#RRGGBB or #AARRGGBB) (optional)
        /// </summary>
        public string? BackgroundColor { get; set; }
        
        /// <summary>
        /// Alignment to use for tile objects
        /// </summary>
        public TilesetObjectAlignmentEnum ObjectAlignment { get; set; }
        
        /// <summary>
        /// Array of custom properties
        /// </summary>
        public List<Property> Properties { get; set; }
        
        /// <summary>
        /// The external file that contains this tilesets data
        /// </summary>
        public string Source { get; set; }
        
        /// <summary>
        /// Spacing between adjacent tiles in image (pixels)
        /// </summary>
        public int Spacing { get; set; }
        
        /// <summary>
        /// Optional terrains
        /// </summary>
        public List<Terrain>? Terrains { get; set; }
        
        /// <summary>
        /// The number of tiles in this tileset
        /// </summary>
        public int TileCount { get; set; }
        
        /// <summary>
        /// Optional
        /// </summary>
        public TileOffset? TileOffset { get; set; }
        
        /// <summary>
        /// Optional
        /// </summary>
        public List<Tile>? Tiles { get; set; }
        
        /// <summary>
        /// Maximum height of tiles in this set
        /// </summary>
        public int TileHeight { get; set; }
        
        /// <summary>
        /// Maximum width of tiles in this set
        /// </summary>
        public int TileWidth { get; set; }
        
        /// <summary>
        /// tileset (for tileset files, since 1.0)
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// JSON/XML version
        /// </summary>
        public float Version { get; set; }
        
        /// <summary>
        /// The Tiled version used to save the file
        /// </summary>
        public string TiledVersion { get; set; }

        // List of wang sets
        public List<WangSet> WangSets { get; set; }
    }
}