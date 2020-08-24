using System.IO;
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
        public static Tilemap LoadTilemap(string path) => LoadGeneric<Tilemap>(path);
        
    }
}