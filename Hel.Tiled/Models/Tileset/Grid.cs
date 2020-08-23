﻿using Hel.Tiled.Models.Enums;

namespace Hel.Tiled.Models.Tileset
{
    public class Grid
    {
        /// <summary>
        /// Cell height of tile grid
        /// </summary>
        public int Height { get; }
        
        /// <summary>
        /// 	Cell width of tile grid
        /// </summary>
        public int Width { get; }
        
        /// <summary>
        /// Orientation of grid
        /// </summary>
        public GridOrientationEnum Orientation { get; }
    }
}