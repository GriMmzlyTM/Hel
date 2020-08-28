using Hel.Tiled.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hel.Tiled.Models.Tileset
{
    public class Grid
    {
        /// <summary>
        /// Cell height of tile grid
        /// </summary>
        public ushort Height { get; set; }
        
        /// <summary>
        /// Cell width of tile grid
        /// </summary>
        public ushort Width { get; set; }
        
        /// <summary>
        /// Orientation of grid
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public GridOrientationEnum Orientation { get; set; }
    }
}