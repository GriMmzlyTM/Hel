using System.Collections.Generic;

namespace Hel.Tiled.Models.Layers
{
    public class GroupLayer : Layer
    {
        /// <summary>
        /// Layers for when type is Group
        /// </summary>
        public List<Layer> Layers { get; }
    }
}