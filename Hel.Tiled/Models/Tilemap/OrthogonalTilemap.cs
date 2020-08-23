using Hel.Tiled.Models.Enums.Tilemap;

namespace Hel.Tiled.Models.Tilemap
{
    public class OrthogonalTilemap : Tilemap
    {
        /// <summary>
        /// Only for orthogonal maps
        /// </summary>
        public TilemapRenderOrderEnum RenderOrderEnum { get; }
    }
}