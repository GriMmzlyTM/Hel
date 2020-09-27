using System;
using System.Linq;
using Hel.Engine.Rendering.Models.Enums;
using Hel.Engine.Rendering.Models.Payloads;
using Hel.Tiled.Models.Enums.Layer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.Engine.Rendering
{
    public class TilemapRenderer : IRenderer<TilemapRendererPayload>
    {
        public RendererApi RendererApi { get; } = RendererApi.OpenGL;
        
        public void Draw(TilemapRendererPayload payload, SpriteBatch spriteBatch)
        {
            foreach (var layer in payload.Tilemap.Layers.Where(layer => layer.Type == LayerTypeEnum.TileLayer))
            {
                for (var i = 0; i < layer.Data.Length; i++)
                {
                    var gid = layer.Data[i];
    
                    if (gid == 0) continue;
                        
                    var tilemapX = (i % payload.Tilemap.Width) * payload.Tilemap.TileWidth;
                    var tilemapY = (float)Math.Floor(i / (double)payload.Tilemap.Width) * payload.Tilemap.TileHeight;
    
                    for (var setCount = payload.Tilemap.Tilesets.Count - 1; setCount >= 0; setCount--)
                    {
                        if (payload.Tilemap.Tilesets[setCount].FirstGid > gid) continue;
    
                        var tileset = payload.Tilemap.Tilesets[setCount].Tileset;
                        var texture = (Texture2D) tileset.Texture;
    
                        var tileRect = tileset.TileRectangles[gid - payload.Tilemap.Tilesets[setCount].FirstGid];

                        spriteBatch.Draw(texture,
                            new Rectangle(tilemapX, (int)tilemapY, tileset.TileWidth, tileset.TileHeight),
                            new Rectangle(tileRect.X, tileRect.Y, tileset.TileWidth, tileset.TileHeight ),
                            Color.White, 0, Vector2.Zero, SpriteEffects.None , 0);
                            
                        break;
                    }
                }
            }
        }
    }
}