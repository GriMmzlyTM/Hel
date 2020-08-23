﻿using System.Collections.Generic;
using Hel.Tiled.Models.Layers;

namespace Hel.Tiled.Models.Tileset.Tile
{
    public class Tile
    {
        /// <summary>
        /// Local ID of the tile
        /// </summary>
        public int Id { get; }
        
        /// <summary>
        /// Frames for animation
        /// </summary>
        public List<Frame> Animation { get; }
        
        /// <summary>
        /// Image representing this tile (optional)
        /// </summary>
        public string? Image { get; }
        
        /// <summary>
        /// Height of the tile image in pixels
        /// </summary>
        public int ImageHeight { get; }
        
        /// <summary>
        /// Width of the tile image in pixels
        /// </summary>
        public int ImageWidth { get; }
        
        /// <summary>
        /// Layer with type objectgroup, when collision shapes are specified (optional)
        /// </summary>
        public ObjectGroupLayer ObjectGroup { get; }
        
        /// <summary>
        /// Percentage chance this tile is chosen when competing with others in the editor (optional)
        /// </summary>
        public double? Probability { get; }
        
        // <summary>
        /// Array of custom properties
        /// </summary>
        public List<Property> Properties { get; }
        
        /// <summary>
        /// Index of terrain for each corner of tile (optional)
        /// each value is a length-4 array where each element is the index of a terrain on one corner of the tile.
        /// The order of indices is: top-left, top-right, bottom-left, bottom-right.
        /// </summary>
        public int[] Terrain { get; }
        
        /// <summary>
        /// The type of the tile (optional)
        /// </summary>
        public string? Type { get; }
    }
}