using System.Collections.Generic;
using Hel.Tiled.Models.Enums.Tilemap;
using Hel.Tiled.Models.Layers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hel.Tiled.Models.Tilemap
{
    /// <summary>
    /// The tilemap to draw. Contains all data required to properly render the tilemap.
    /// </summary>
    public sealed class Tilemap
    {
         /// <summary>
        /// Number of tile rows
        /// </summary>
        public int Height { get; set; }
        
        /// <summary>
        /// Number of tile columns
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Map grid height
        /// </summary>
        public int TileHeight { get; set; }
        
        /// <summary>
        /// Map grid width
        /// </summary>
        public int TileWidth { get; set; }

        /// <summary>
        /// Whether the map has infinite dimensions
        /// </summary>
        public bool Infinite { get; set; }
        
        /// <summary>
        /// Tilesets used in the map
        /// </summary>
        public List<TilesetInfo> Tilesets { get; set; }

        /// <summary>
        /// Associates the tilemap info with the loaded tilemap to make it easy to render and manage
        /// </summary>
        public sealed class TilesetInfo
        {
            /// <summary>
            /// The external file that contains this tilesets data
            /// </summary>
            public string Source { get; set; }
            
            /// <summary>
            /// Each tileset has a firstgid (first global ID) property which tells you the global ID of its first tile
            /// (the one with local tile ID 0). This allows you to map the global IDs back to the right tileset,
            /// and then calculate the local tile ID by subtracting the firstgid from the global tile ID. The first tileset
            /// always has a firstgid value of 1.
            /// </summary>
            public int FirstGid { get; set; }
            
            /// <summary>
            /// The loaded tileset
            /// </summary>
            public Tileset.Tileset Tileset { get; set; }

        } 
        
        /// <summary>
        /// Tilemap layers
        /// </summary>
        public List<Layer> Layers { get; set; }
        
        /// <summary>
        /// The type of the tilemap (Only Map since 1.0)
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TilemapTypeEnum Type { get; set; }
        
        /// <summary>
        /// Hex-formatted color (#RRGGBB or #AARRGGBB) (optional)
        /// </summary>
        public string BackgroundColor { get; set; }
        
        /// <summary>
        /// The next gid a layer would have (Current highest id is NextLayerId - 1)
        /// </summary>
        public int NextLayerId { get; set; }
        
        /// <summary>
        /// The next gid an object would have (Current highest id is NextObjectId - 1)
        /// </summary>
        public int NextObjectId { get; set;  }
        
        /// <summary>
        /// The compression level to use for tile layer data (defaults to -1, which means to use the algorithm default)
        /// </summary>
        public int CompressionLevel { get; set; }
        
        /// <summary>
        /// Length of the side of a hex tile in pixels (hexagonal maps only)
        /// </summary>
        public int HexSideLength { get; set; }

        /// <summary>
        /// Orientation of the tilemap
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TilemapOrientationEnum Orientation { get; set; }
        
        /// <summary>
        /// Defined properties
        /// </summary>
        public List<Property> Properties { get; set; }
        
        /// <summary>
        /// The version of tiled that was used to generate the tilemap
        /// </summary>
        public string TiledVersion { get; set; }
        
        /// <summary>
        /// The Json/XML format version
        /// </summary>
        public float Version { get; set; }

        /// <summary>
        /// staggered / hexagonal maps only
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TilemapStaggerAxisEnum StaggerAxis { get; set; }
        
        /// <summary>
        /// staggered / hexagonal maps only
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TilemapStaggerIndexEnum StaggerIndex { get; set; }
        
        /// <summary>
        /// Only for orthogonal maps
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TilemapRenderOrderEnum RenderOrder { get; set; }
    }
}