﻿namespace Hel.Tiled.Models.Tileset.Wang
{
    public class WangColor
    {
        /// <summary>
        /// Hex-formatted color (#RRGGBB or #AARRGGBB)
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Name of the Wang color
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Probability used when randomizing
        /// </summary>
        public double Probability { get; }
        
        /// <summary>
        /// Local ID of tile representing the Wang color
        /// </summary>
        public int Tile { get; }
    }
}