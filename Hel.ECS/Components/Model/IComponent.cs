using Hel.ECS.Entities.Logic;

namespace Hel.ECS.Components.Model
{
    /// <summary>
    /// Marks a struct as a component that can be linked to an entity.
    /// This is the base interface all components MUST implement.
    ///
    /// A component is a struct that contains single purpose values that is passed to one or multiple systems in-order
    /// to run the logic associated.
    ///
    /// For example, a 2Dtransform component would contain X and Y location data, X and Y rotation and X and Y scale. 
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// A component that is not active will not be returned when fetching components from an entity.
        /// Setting this to false is the same as if the component was not attached to the entity.
        /// <see cref="EntityManager.GetEntities"/>
        /// </summary>
        bool Active { get; set; }
    }

}
