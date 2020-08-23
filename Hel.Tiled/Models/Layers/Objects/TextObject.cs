using Hel.Tiled.Models.Enums.Object;

namespace Hel.Tiled.Models.Layers.Objects
{
    public class TextObject
    {
        /// <summary>
        /// Whether to use a bold font (default: false)
        /// </summary>
        public bool Bold { get; }
        
        /// <summary>
        /// Hex-formatted color (#RRGGBB or #AARRGGBB) (default: #000000)
        /// </summary>
        public string Color { get; }
        
        /// <summary>
        /// Font family (default: sans-serif)
        /// </summary>
        public string FontFamily { get; }
        
        /// <summary>
        /// Horizontal alignment
        /// </summary>
        public HAlignEnum HAlign { get; }
        
        /// <summary>
        /// Vertical alignment
        /// </summary>
        public VAlignEnum VAlignEnum { get; }
        
        /// <summary>
        /// Whether to use an italic font (default: false)
        /// </summary>
        public bool Italic { get; }

        /// <summary>
        /// Whether to use kerning when placing characters (default: true)
        /// </summary>
        public bool Kerning { get; }
        
        /// <summary>
        /// Pixel size of font (default: 16)
        /// </summary>
        public int PixelSize { get; }
        
        /// <summary>
        /// Whether to strike out the text (default: false)
        /// </summary>
        public bool Strikeout { get; }
        
        /// <summary>
        /// Text data
        /// </summary>
        public string Text { get; }
        
        /// <summary>
        /// Whether to underline the text (default: false)
        /// </summary>
        public bool Underline { get; }
        
        /// <summary>
        /// Whether the text is wrapped within the object bounds (default: false)
        /// </summary>
        public bool Wrap { get; }
    }
}