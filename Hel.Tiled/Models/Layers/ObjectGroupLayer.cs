using System.Collections.Generic;
using Hel.Tiled.Models.Enums.Layer;

namespace Hel.Tiled.Models.Layers
{
    public class ObjectGroupLayer : Layer
    {
        /// <summary>
        /// Objectgroup only
        /// </summary>
        public LayerDrawOrderEnum DrawOrderEnum { get; }
        
        /// <summary>
        /// Objects for when type is ObjectGroup
        /// </summary>
        public List<ObjectGroupLayer> Objects { get; }
    }
}