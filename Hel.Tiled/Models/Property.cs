namespace Hel.Tiled.Models
{
    /// <summary>
    /// A property is custom data that was attached. When attached to an object it can dictate the
    /// logic that object is meant to have.
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Property key
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Type of value stored in property
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        ///  Property value
        /// </summary>
        public string Value { get; set; }
    }
}