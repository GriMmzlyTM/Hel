using System.Collections.Generic;
using System.Drawing;
using Hel.Tiled.Models.Enums;
using Hel.Tiled.Models.Tileset.Tiles;
using Hel.Tiled.Models.Tileset.Wang;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hel.Tiled.Models.Tileset
{
    public class Tileset
    {

        /// <summary>
        /// Name given to this tileset
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Image used for tiles in this set
        /// </summary>
        public string Image { get; set; }
        
        /// <summary>
        /// Optional
        /// </summary>
        public Grid? Grid { get; set; }
        
        /// <summary>
        /// The number of tile columns in the tileset
        /// </summary>
        public ushort Columns { get; set; }
        
        /// <summary>
        /// Height of source image in pixels
        /// </summary>
        public ushort ImageHeight { get; set; }
        
        /// <summary>
        /// Width of source image in pixels
        /// </summary>
        public ushort ImageWidth { get; set; }
        
        /// <summary>
        /// Buffer between image edge and first tile (pixels)
        /// </summary>
        public ushort Margin { get; set; }
        
        /// <summary>
        /// Hex-formatted color (#RRGGBB or #AARRGGBB) (optional)
        /// </summary>
        public string? BackgroundColor { get; set; }
        
        /// <summary>
        /// Alignment to use for tile objects
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TilesetObjectAlignmentEnum ObjectAlignment { get; set; }
        
        /// <summary>
        /// Array of custom properties
        /// </summary>
        public List<Property> Properties { get; set; }
        
        /// <summary>
        /// Spacing between adjacent tiles in image (pixels)
        /// </summary>
        public ushort Spacing { get; set; }
        
        /// <summary>
        /// The number of tiles in this tileset
        /// </summary>
        public int TileCount { get; set; }
        
        /// <summary>
        /// Maximum height of tiles in this set
        /// </summary>
        public ushort TileHeight { get; set; }
        
        /// <summary>
        /// Maximum width of tiles in this set
        /// </summary>
        public ushort TileWidth { get; set; }
        
        /// <summary>
        /// Optional terrains
        /// </summary>
        public List<Terrain>? Terrains { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        public TileOffset? TileOffset { get; set; }
        
        /// <summary>
        /// Optional
        /// </summary>
        public List<Tile>? Tiles { get; set; }

        /// <summary>
        /// tileset (for tileset files, since 1.0)
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// The Tiled version used to save the file
        /// </summary>
        public string TiledVersion { get; set; }
        
        /// <summary>
        /// JSON/XML version
        /// </summary>
        public float Version { get; set; }

        // List of wang sets
        public List<WangSet> WangSets { get; set; }
        
        // NOT SERIALIZED 
        
        /// <summary>
        /// Row count
        /// </summary>
        [JsonIgnore]
        public int Rows => TileCount / Columns;
        
        [JsonIgnore]
        public Dictionary<int, Rectangle> TileRectangles { get; set; }
        
        [JsonIgnore]
        public object Texture { get; set; }

        /// <summary>
        /// Calculate how to split up the tileset so it can be properly rendered
        /// </summary>
        /// <param name="firstGid">FirstGid property in the <see cref="Tilemap"/> that uses this tileset</param>
        /// <returns></returns>
        public Dictionary<int, Rectangle> CalculateTileRectangles(int firstGid)
        {
            var rectangleDict = new Dictionary<int, Rectangle>();

            var gidCounter = firstGid;
            
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    // If first row/column, tile is at margin 
                    // spacing * column = All spaces up to that point
                    // TileHeight * column = All tiles up to that point
                    
                    var yTilePoint = row == 0
                        ? Margin
                        : Margin + (Spacing * row) + (TileHeight * row);

                    var xTilePoint = column == 0
                        ? Margin
                        : Margin + (Spacing * column) + (TileWidth * column);
                    
                    rectangleDict.Add(
                        gidCounter,
                        new Rectangle(xTilePoint, yTilePoint, TileWidth, TileHeight) );

                    gidCounter++;
                }
            }

            return rectangleDict;
        }
        
    }
}