using Hel.Tiled.Models.Layers.Objects;

namespace Hel.Tiled.Models
{
    public class Template
    {
        public string Type { get; }
        
        public Tileset.Tileset? Tileset { get; }
        
        public Object Object { get; }
    }
}