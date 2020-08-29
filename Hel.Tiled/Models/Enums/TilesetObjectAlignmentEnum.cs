namespace Hel.Tiled.Models.Enums
{
    /// <summary>
    /// Controls the alignment for tile objects. Valid values are unspecified, topleft, top, topright, left, center,
    /// right, bottomleft, bottom and bottomright. The default value is unspecified, for compatibility reasons.
    /// When unspecified, tile objects use bottomleft in orthogonal mode and bottom in isometric mode.
    /// </summary>
    public enum TilesetObjectAlignmentEnum
    {
        Unspecified = 0,
        TopLeft,
        Top,
        TopRight,
        Left,
        Center,
        Right,
        BottomLeft,
        Bottom,
        BottomRight
    }
}