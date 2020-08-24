using System.Collections.Generic;
using Hel.Tiled.Models.Enums;
using Hel.Tiled.Models.Enums.Object;

namespace Hel.Tiled.Models.Layers.Objects
{
    public class Object
    {
        /// <summary>
        /// 	Height in pixels.
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Width in pixels
        /// </summary>
        public double Width { get; set; }
        
        /// <summary>
        /// Incremental ID, unique across all objects
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// String assigned to name field in editor
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Properties set for object
        /// </summary>
        public List<Property>? Properties { get; set; }
        
        /// <summary>
        /// Angle in degrees clockwise
        /// </summary>
        public double Rotation { get; set; }
        
        /// <summary>
        /// String assigned to type field in editor
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Whether object is shown in editor.
        /// </summary>
        public bool Visible { get; set; }
        
        /// <summary>
        /// X coordinate in pixels
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Y coordinate in pixels
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Global tile ID, only if object represents a tile
        /// </summary>
        public int? GID { get; set; } = null;
        
        /// <summary>
        /// Only used for text objects
        /// </summary>
        public TextObject? Text { get; set; } = null;
        
        /// <summary>
        /// Used to mark an object as an ellipse
        /// </summary>
        public bool Ellipse { get; set; }

        /// <summary>
        /// Array of Points, in case the object is a polygon
        /// </summary>
        public List<Point>? Polygon { get; set; } = null;

        /// <summary>
        /// Array of Points, in case the object is a polyline
        /// </summary>
        public List<Point>? Polyline { get; set; } = null;

        /// <summary>
        /// Reference to a template file, in case object is a template instance
        /// </summary>
        public string? Template { get; set; } = null;
        
        /// <summary>
        /// Used to mark an object as a point
        /// </summary>
        public bool Point { get; set; }
        
        /// <summary>
        /// Get the object type
        /// </summary>
        public ObjectTypeEnum ObjectType
        {
            get
            {
                if (Text != null) return ObjectTypeEnum.Text;
                if (Ellipse) return ObjectTypeEnum.Ellipse;
                if (Polygon != null) return ObjectTypeEnum.Polygon;
                if (Polyline != null) return ObjectTypeEnum.Polyline;
                if (Template != null) return ObjectTypeEnum.Template;
                if (Point) return ObjectTypeEnum.Point;
                if (GID != 0) return ObjectTypeEnum.Tile;
                
                return ObjectTypeEnum.Default;
            }
        }
    }
}