using System.Runtime.Serialization;

namespace Hel.Tiled.Models.Enums.Tilemap
{
    public enum TilemapRenderOrderEnum
    {
        None = 0,
        [EnumMember(Value = "right-down")]
        RightDown,
        [EnumMember(Value = "right-up")]
        RightUp,
        [EnumMember(Value = "left-down")]
        LeftDown,
        [EnumMember(Value = "left-up")]
        LeftUp
    }
}