using System;
using Hel.Engine.Toolkit.DataStructure.Arrays;

namespace Hel.Engine.ECS.Components
{
    /// <summary>
    /// Components of a specific type that are stored at the ID of the entity they belong to.
    ///
    /// For example:
    /// EntityLookup: Index 53 => "Character"
    /// ComponentByEntityContainer (Render) : Index 53 => "Character" IComponent
    ///  
    /// </summary>
    public class ComponentByEntityContainer
    {
        /// <summary>
        /// The type of the components stored in this container
        /// </summary>
        public Type Type { get; }
        private DynamicArray<IComponent> Components { get; }

        public ComponentByEntityContainer(Type type)
        {
            Components = new DynamicArray<IComponent>(256);
            Type = type;
        }

        public void Add(int entityId, IComponent component) => Components[entityId] = component;

        public void Remove(int entityId) => Components[entityId] = null;

        /// <summary>
        /// Get component. May return null
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="component"></param>
        /// <returns>True if componnent exists</returns>
        public bool Get(int entityId, out IComponent component)
        {
            component = Components[entityId];
            return component != null;
        }

        public IComponent this[int index]
        {
            get => Components[index];

            set => Components[index] = value;
        }

    }
}