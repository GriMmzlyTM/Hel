using System.Linq;
using Hel.Tiled;
using Hel.Tiled.Models.Tilemap;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.Engine.Tiled
{
    public static class TiledLoader
    {
        public static Tilemap TilemapLoader(string path)
        {
            path = !path.StartsWith("Content") ? $@"Content/{path}" : path;
            var tilemap = TiledFactory.LoadTilemap(path);

            foreach (var tileset in tilemap.Tilesets.Select(set => set.Tileset))
            {
                tileset.Texture = Engine.Game.Content.Load<Texture2D>(tileset.Image.Split('.')[0]);
            }

            return tilemap;
        }
    }
}