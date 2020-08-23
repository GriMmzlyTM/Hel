using System.Collections.Generic;
using Hel.Tiled.Models.Enums.Layer;

namespace Hel.Tiled.Models.Layers
{
    public class Layer
    {
        /// <summary>
        /// Incremental ID - unique across all layers
        /// </summary>
        public int Id { get; }
                
        /// <summary>
        /// Name assigned to this layer
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Whether layer is shown or hidden in editor
        /// </summary>
        public bool Visible { get; }
        
        /// <summary>
        /// The layer type dictates what values are available
        /// </summary>
        public LayerTypeEnum TypeEnum { get; }
        
        /// <summary>
        /// Row count. Same as map height for fixed-size maps.
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// Column count. Same as map width for fixed-size maps.
        /// </summary>
        public int Width { get; }
        
        /// <summary>
        /// Horizontal layer offset in tiles. Always 0
        /// </summary>
        public int X { get; }
        /// <summary>
        /// Vertical layer offset in tiles. Always 0.
        /// </summary>
        public int Y { get; }
        
        /// <summary>
        /// Array of properties set for the layer
        /// </summary>
        public List<Property>? Properties { get; }
        
        /// <summary>
        /// Horizontal layer offset in pixels (default: 0)
        /// </summary>
        public double OffsetX { get; }
        /// <summary>
        /// Vertical layer offset in pixels (default: 0)
        /// </summary>
        public double OffsetY { get; }
        /// <summary>
        /// Value between 0 and 1
        /// </summary>
        public double Opacity { get; }
        
        /// <summary>
        /// Hex-formatted color (#RRGGBB or #AARRGGBB) that is multiplied with any graphics drawn by this layer or any child layers (optional).
        /// </summary>
        public string? TintColor { get; }

        /// <summary>
        /// X coordinate where layer content starts (for infinite maps)
        /// </summary>
        public int? StartX { get; }
        /// <summary>
        /// Y coordinate where layer content starts (for infinite maps)
        /// </summary>
        public int? StartY { get; }
    }
}