namespace Hel.Tiled.Models.Enums.Object
{
    /// <summary>
    /// Enables you to find what the object is meant to be so it can be used properly. Different object types contain
    /// different data.
    /// </summary>
    public enum ObjectTypeEnum
    {
        Default = 0,
        Ellipse,
        Point,
        Polygon,
        Polyline,
        Template,
        Text,
        Tile
    }
}