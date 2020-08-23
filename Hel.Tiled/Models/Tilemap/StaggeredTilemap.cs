using Hel.Tiled.Models.Enums.Tilemap;

namespace Hel.Tiled.Models.Tilemap
{
    public class StaggeredTilemap : Tilemap
    {
        /// <summary>
        /// staggered / hexagonal maps only
        /// </summary>
        public TilemapStaggerAxisEnum StaggerAxisEnum { get; }
        
        /// <summary>
        /// staggered / hexagonal maps only
        /// </summary>
        public TilemapStaggerIndexEnum StaggerIndexEnum { get; }
    }
}