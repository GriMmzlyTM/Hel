namespace Hel.Tiled.Models.Enums.Tilemap
{
    /// <summary>
    /// Tilemap orientation dictates how the map should be drawn and oriented.
    /// Defaults to Orthographic which is the basic flat tile orientation.
    /// </summary>
    public enum TilemapOrientationEnum
    {
        Orthogonal = 0,
        Isometric,
        Staggered,
        Hexagonal
    }
}