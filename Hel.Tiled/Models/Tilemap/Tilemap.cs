using System.Collections.Generic;
using Hel.Tiled.Models.Enums.Tilemap;
using Hel.Tiled.Models.Layers;

namespace Hel.Tiled.Models.Tilemap
{
    public class Tilemap
    {
         /// <summary>
        /// Number of tile rows
        /// </summary>
        public int Height { get; }
        
        /// <summary>
        /// Number of tile columns
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Whether the map has infinite dimensions
        /// </summary>
        public bool Infinite { get; }

        /// <summary>
        /// Map grid height
        /// </summary>
        public int TileHeight { get; }
        
        /// <summary>
        /// Map grid width
        /// </summary>
        public int TileWidth { get; }

        /// <summary>
        /// Tilesets used in the map
        /// </summary>
        public List<Tileset.Tileset> Tilesets { get; }
        
        /// <summary>
        /// Tilemap layers
        /// </summary>
        public List<Layer> Layers { get; }
        
        /// <summary>
        /// The type of the tilemap (Only Map since 1.0)
        /// </summary>
        public TilemapTypeEnum TypeEnum { get; }
        
        /// <summary>
        /// Hex-formatted color (#RRGGBB or #AARRGGBB) (optional)
        /// </summary>
        public string BackgroundColor { get; }
        
        /// <summary>
        /// The next gid a layer would have (Current highest id is NextLayerId - 1)
        /// </summary>
        public int NextLayerId { get; }
        
        /// <summary>
        /// The next gid an object would have (Current highest id is NextObjectId - 1)
        /// </summary>
        public int NextObjectId { get;  }
        
        /// <summary>
        /// The compression level to use for tile layer data (defaults to -1, which means to use the algorithm default)
        /// </summary>
        public int CompressionLevel { get; }
        
        /// <summary>
        /// Length of the side of a hex tile in pixels (hexagonal maps only)
        /// </summary>
        public int HexSideLength { get; }

        /// <summary>
        /// Orientation of the tilemap
        /// </summary>
        public TilemapOrientationEnum OrientationEnum { get; }
        
        /// <summary>
        /// Defined properties
        /// </summary>
        public List<Property> Properties { get; }
        
        /// <summary>
        /// The version of tiled that was used to generate the tilemap
        /// </summary>
        public string TiledVersion { get; }
        
        /// <summary>
        /// The Json/XML format version
        /// </summary>
        public double Version { get; }

    }
}