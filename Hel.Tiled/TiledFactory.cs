using System.IO;
using System.Linq;
using Hel.Tiled.Models;
using Hel.Tiled.Models.Tilemap;
using Hel.Tiled.Models.Tileset;
using Newtonsoft.Json;

namespace Hel.Tiled
{
    /// <summary>
    /// Prefered entrypoint for creating Tiled data objects.
    /// </summary>
    public static class TiledFactory
    {
        public static T LoadGeneric<T>(string path)
        {
            var data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// Load and structure a tileset that is not associated with a tilemap.
        /// </summary>
        /// <param name="path">The path where the tileset can be found</param>
        /// <returns>Fully structured <see cref="Tileset"/></returns>
        public static Tileset LoadTileset(string path) => LoadGeneric<Tileset>(path);
        public static Template LoadTemplate(string path) => LoadGeneric<Template>(path);
        
        /// <summary>
        /// Loads a tilemap and its required tilesets. This will load and prepare all data required to use the tilemap.
        /// </summary>
        /// <param name="path">The path where the tilemap can be loaded.</param>
        /// <returns>Structured <see cref="Tilemap"/></returns>
        public static Tilemap LoadTilemap(string path)
        {
            var tilemap = LoadGeneric<Tilemap>(path);
            tilemap.Tilesets = tilemap.Tilesets.OrderBy(tileset => tileset.FirstGid).ToList();
            
            foreach (var tileset in tilemap.Tilesets)
            {
                var loadedTileset = LoadGeneric<Tileset>(tileset.Source);
                tileset.Tileset = loadedTileset;
            }

            return tilemap;
        }
    }
}