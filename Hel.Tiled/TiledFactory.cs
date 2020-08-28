using System.IO;
using System.Linq;
using Hel.Tiled.Models;
using Hel.Tiled.Models.Tilemap;
using Hel.Tiled.Models.Tileset;
using Newtonsoft.Json;

namespace Hel.Tiled
{
    public static class TiledFactory
    {
        public static T LoadGeneric<T>(string path)
        {
            var data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static Tileset LoadTileset(string path) => LoadGeneric<Tileset>(path);
        public static Template LoadTemplate(string path) => LoadGeneric<Template>(path);
        
        /// <summary>
        /// Loads a tilemap and its required tilesets
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Tilemap LoadTilemap(string path)
        {
            var tilemap = LoadGeneric<Tilemap>(path);
            tilemap.Tilesets = tilemap.Tilesets.OrderBy(tileset => tileset.FirstGid).ToList();
            
            foreach (var tileset in tilemap.Tilesets)
            {
                var loadedTileset = LoadGeneric<Tileset>(tileset.Source);
                loadedTileset.TileRectangles = loadedTileset.CalculateTileRectangles(tileset.FirstGid);
                tileset.Tileset = loadedTileset;
            }

            return tilemap;
        }
    }
}