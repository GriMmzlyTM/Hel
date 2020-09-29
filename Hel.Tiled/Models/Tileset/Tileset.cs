using System.Collections.Generic;
using System.Drawing;
using Hel.Tiled.Models.Enums;
using Hel.Tiled.Models.Tileset.Tiles;
using Hel.Tiled.Models.Tileset.Wang;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hel.Tiled.Models.Tileset
{
    /// <summary>
    /// Tileset containing all information required to render the tileset image.
    /// The purpose of this object is to tell you how to cut up and render the texture image.
    /// This object allows you to cut up the texture image into rectangles. 
    /// </summary>
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

        /// <summary>
        /// List of wang tiles
        /// </summary>
        public List<WangSet> WangSets { get; set; }
        
        // NOT SERIALIZED 
        
        /// <summary>
        /// Row count
        /// </summary>
        [JsonIgnore]
        public int Rows => TileCount / Columns;

        /// <summary>
        /// Framework independent texture object. In Monogame this is a Texture2D
        /// </summary>
        [JsonIgnore]
        public object Texture { get; set; }


        public Dictionary<int, Rectangle> TileRectangles { get; set; }

        /// <summary>
        /// Calculate how to split up the tileset so it can be properly rendered. The data here is GID Independent.
        /// To use with a tilemap (Which gives each tileset a FirstGid) substract the firstGid from the tile GID the tilemap is requesting.
        /// I.E. FirstGid = 32
        /// Tilemap needs Gid 37
        /// rectangle index = 37 - 32
        /// </summary>
        /// <returns>Dictionary providing the rectangles required to split up a tilemap. GID independent.</returns>
        public Dictionary<int, Rectangle> CalculateTileRectangles()
        {
            var rectangleDict = new Dictionary<int, Rectangle>();

            var tileCounter = 0;
            
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
                        tileCounter,
                        new Rectangle(xTilePoint, yTilePoint, TileWidth, TileHeight) );

                    tileCounter++;
                }
            }

            return rectangleDict;
        }
        
    }
}