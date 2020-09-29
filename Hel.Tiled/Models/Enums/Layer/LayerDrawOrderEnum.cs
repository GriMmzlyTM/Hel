using System.Runtime.Serialization;

namespace Hel.Tiled.Models.Enums.Layer
{
    /// <summary>
    /// Whether the objects are drawn according to the order of appearance (“index”) or sorted by their y-coordinate (“topdown”). (defaults to “topdown”)
    /// </summary>
    public enum LayerDrawOrderEnum
    {
        None = 0,
        TopDown,
        Index
    }
}