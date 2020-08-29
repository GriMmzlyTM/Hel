using System.Runtime.Serialization;

namespace Hel.Tiled.Models.Enums.Tilemap
{
    /// <summary>
    /// The order in which tiles on tile layers are rendered. Valid values are right-down (the default), right-up,
    /// left-down and left-up. In all cases, the map is drawn row-by-row.
    /// (only supported for orthogonal maps at the moment)
    /// </summary>
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