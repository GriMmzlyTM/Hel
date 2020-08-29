namespace Hel.Tiled.Models.Enums.Layer
{
    /// <summary>
    /// The compression used to compress the tile layer data
    /// </summary>
    public enum LayerCompressionEnum
    {
        Empty = 0,
        Zlib,
        Gzip,
        Zstd
    }
}