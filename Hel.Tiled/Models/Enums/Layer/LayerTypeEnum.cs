using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hel.Tiled.Models.Enums.Layer
{
    /// <summary>
    /// Dictates the data that can be found in the layer.
    /// </summary>
    public enum LayerTypeEnum
    {
        TileLayer = 0,
        ObjectGroup,
        ImageLayer,
        Group
    }
}