using Hel.Tiled.Models.Layers.Objects;

namespace Hel.Tiled.Models
{
    public class Template
    {
        public string Type { get; set; }
        
        public Tileset.Tileset? Tileset { get; set; }
        
        public Object Object { get; set; }
    }
}