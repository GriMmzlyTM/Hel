using System.Collections.Generic;
using Hel.Tiled.Models.Enums.Layer;

namespace Hel.Tiled.Models.Layers
{
    public class TileLayer : Layer
    {
        /// <summary>
        /// Array of tile GIDs
        /// </summary>
        public string[] Data { get; } 
        
        /// <summary>
        /// Chunks are used to store the tile layer data for infinite maps.
        /// </summary>
        public List<Chunk> Chunks { get; }
        
        /// <summary>
        /// If the Data is encoded
        /// </summary>
        public LayerEncodingEnum EncodingEnum { get; }
        /// <summary>
        /// Compression used
        /// </summary>
        public LayerCompressionEnum CompressionEnum { get; }
    }
}