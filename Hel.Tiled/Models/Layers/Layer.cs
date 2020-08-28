using System.Collections.Generic;
using Hel.Tiled.Models.Enums.Layer;
using Hel.Tiled.Models.Layers.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hel.Tiled.Models.Layers
{
    public class Layer
    {
        /// <summary>
        /// Incremental ID - unique across all layers
        /// </summary>
        public int Id { get; set; }
                
        /// <summary>
        /// Name assigned to this layer
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Whether layer is shown or hidden in editor
        /// </summary>
        public bool Visible { get; set; }
        
        /// <summary>
        /// The layer type dictates what values are available
        /// </summary>
        public LayerTypeEnum TypeEnum { get; set; }
        
        /// <summary>
        /// Row count. Same as map height for fixed-size maps.
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Column count. Same as map width for fixed-size maps.
        /// </summary>
        public int Width { get; set; }
        
        /// <summary>
        /// Horizontal layer offset in tiles. Always 0
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Vertical layer offset in tiles. Always 0.
        /// </summary>
        public int Y { get; set; }
        
        /// <summary>
        /// Array of properties set for the layer
        /// </summary>
        public List<Property>? Properties { get; set; }
        
        /// <summary>
        /// Horizontal layer offset in pixels (default: 0)
        /// </summary>
        public double OffsetX { get; set; }
        /// <summary>
        /// Vertical layer offset in pixels (default: 0)
        /// </summary>
        public double OffsetY { get; set; }
        /// <summary>
        /// Value between 0 and 1
        /// </summary>
        public double Opacity { get; set; }
        
        /// <summary>
        /// Hex-formatted color (#RRGGBB or #AARRGGBB) that is multiplied with any graphics drawn by this layer or any child layers (optional).
        /// </summary>
        public string? TintColor { get; set; }

        /// <summary>
        /// X coordinate where layer content starts (for infinite maps)
        /// </summary>
        public int? StartX { get; set; }

        /// <summary>
        /// Y coordinate where layer content starts (for infinite maps)
        /// </summary>
        public int? StartY { get; set; }
        
        /// <summary>
        /// Layers for when type is Group
        /// </summary>
        public List<Layer> Layers { get; set; }
        
        /// <summary>
        /// Hex-formatted color (#RRGGBB) (optional). imagelayer only.
        /// </summary>
        public string TransparentColor { get; set; }
        
        /// <summary>
        /// Image used by this layer
        /// </summary>
        public string Image { get; set; }
        
        /// <summary>
        /// Objectgroup only
        /// </summary>
        public LayerDrawOrderEnum DrawOrderEnum { get; set; }
        
        /// <summary>
        /// Objects for when type is ObjectGroup
        /// </summary>
        public List<Layer> Objects { get; set; }
        
        /// <summary>
        /// Array of tile GIDs
        /// </summary>
        public int[] Data { get; set; } 
        
        /// <summary>
        /// Chunks are used to store the tile layer data for infinite maps.
        /// </summary>
        public List<Chunk> Chunks { get; set; }
        
        /// <summary>
        /// If the Data is encoded
        /// </summary>
        public LayerEncodingEnum EncodingEnum { get; set; }
        /// <summary>
        /// Compression used
        /// </summary>
        public LayerCompressionEnum CompressionEnum { get; set; }
    }
}