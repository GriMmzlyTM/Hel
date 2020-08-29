namespace Hel.Tiled.Models.Enums.Layer
{
    /// <summary>
    /// The encoding used to encode the tile layer data. When used, it can be “base64” and “csv” at the moment. (optional)
    /// </summary>
    public enum LayerEncodingEnum
    {
        None = 0,
        Csv,
        Base64
    }
}