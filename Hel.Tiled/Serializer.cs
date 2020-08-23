using System;
using Hel.Tiled.Models.Tilemap;
using Newtonsoft.Json;

namespace Hel.Tiled
{
    public static class Serialization
    {
        public static Tilemap GenerateTilemapFromData(string tilemapData) 
            => JsonConvert.DeserializeObject<Tilemap>(tilemapData);
    }
}