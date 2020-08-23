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
        public double Height { get; }
        /// <summary>
        /// Width in pixels
        /// </summary>
        public double Width { get; }
        
        /// <summary>
        /// Incremental ID, unique across all objects
        /// </summary>
        public int Id { get; }
        
        /// <summary>
        /// String assigned to name field in editor
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Properties set for object
        /// </summary>
        public List<Property>? Properties { get; }
        
        /// <summary>
        /// Angle in degrees clockwise
        /// </summary>
        public double Rotation { get; }
        
        /// <summary>
        /// String assigned to type field in editor
        /// </summary>
        public string Type { get; }
        
        /// <summary>
        /// Whether object is shown in editor.
        /// </summary>
        public bool Visible { get; }
        
        /// <summary>
        /// X coordinate in pixels
        /// </summary>
        public double X { get; }
        /// <summary>
        /// Y coordinate in pixels
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// Global tile ID, only if object represents a tile
        /// </summary>
        public int? GID { get; } = null;
        
        /// <summary>
        /// Only used for text objects
        /// </summary>
        public TextObject? Text { get; } = null;
        
        /// <summary>
        /// Used to mark an object as an ellipse
        /// </summary>
        public bool Ellipse { get; }

        /// <summary>
        /// Array of Points, in case the object is a polygon
        /// </summary>
        public List<Point>? Polygon { get; } = null;

        /// <summary>
        /// Array of Points, in case the object is a polyline
        /// </summary>
        public List<Point>? Polyline { get; } = null;

        /// <summary>
        /// Reference to a template file, in case object is a template instance
        /// </summary>
        public string? Template { get; } = null;
        
        /// <summary>
        /// Used to mark an object as a point
        /// </summary>
        public bool Point { get; }
        
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