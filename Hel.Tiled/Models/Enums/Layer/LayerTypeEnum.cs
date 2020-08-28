using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hel.Tiled.Models.Enums.Layer
{
    public enum LayerTypeEnum
    {
        TileLayer = 0,
        ObjectGroup,
        ImageLayer,
        Group
    }
}