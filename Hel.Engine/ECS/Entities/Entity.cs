using System.Collections.Generic;
using Hel.Engine.ECS.Components;

namespace Hel.Engine.ECS.Entities
{
    /// <summary>
    /// IEntity is the base component all entities need to use. 
    /// The entire ECS system uses the IEntity interface to store, remove
    /// and send entities to their respective systems. 
    /// These entities are not stored as objects but rather deconstructed into an ID and a list of _components.
    /// </summary>
    public interface IEntity
    {
        string Name { get; set; }
        /// <summary>
        /// List of Icomponents that will be assigned in the EntityManager
        /// </summary>        
        ComponentDictionary Components { get; }

        /// <summary>
        /// Add a component to the entities component list. This list of _components is then added to the new entity in the manager.
        /// </summary>
        /// <param name="component"></param>
        void AddComponent(IComponent component);

        /// <summary>
        /// Add a list of _components to the entities component list. This list of _components is then added to the new entity in the manager.
        /// </summary>
        /// <param name="componentList"></param>
        void AddComponents(List<IComponent> componentList);

    }

    public struct Entity : IEntity
    {
        public ComponentDictionary Components { get; }

        public string Name { get; set; }

        public Entity(params IComponent[] components)
        {
            Components = new ComponentDictionary();
            Name = "";
            AddComponents(components);
        }

        public Entity(List<IComponent> componentList)
        {
            Components = new ComponentDictionary();
            Name = "";
            AddComponents(componentList);
        }

        public void AddComponent(IComponent component)
        {
            Components.AddByObject(component);
        }

        public void AddComponents(params IComponent[] components)
        {
            AddComponents(new List<IComponent>(components));
        }

        public void AddComponents(List<IComponent> componentList)
        {
            foreach (var component in componentList)
            {
                AddComponent(component);
            }
        }
    }

}
