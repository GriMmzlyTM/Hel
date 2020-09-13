using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Hel.Engine.ECS.Entities;
using Hel.Engine.ECS.Exceptions;
using Hel.Engine.ECS.Jobs;

namespace Hel.Engine.ECS.Components
{
    /// <summary>
    /// Container for all component types.
    /// Allows quick retrieval of type specific components.
    /// </summary>
    public class ComponentContainer : Dictionary<Type, ComponentByEntityContainer>
    {
        public ComponentContainer() : base() { }

        /// <summary>
        /// Attempts to get all components of type from dictionary.
        /// Returns it if it exists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Dictionary of components</returns>
        public ComponentByEntityContainer GetComponentsOfType<T>() where T :struct, IComponent =>
            TryGetValue(typeof(T), out var tryGetComponent)
                ? tryGetComponent : default;

        /// <summary>
        /// Attempts to get the components from the dictionary and assigns the return to the out variable.
        /// If the components do not exist, null will be assigned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>if the components exist or not</returns>
        public IComponent GetComponent<T>(int id) where T : struct, IComponent
        {
            return !TryGetValue(typeof(T), out var tryGetComponents) ? null : tryGetComponents[id];
        }

        /// <summary>
        /// Attempts to get the components from the dictionary and assigns the return to the out variable.
        /// If the components do not exist, null will be assigned.
        /// </summary>
        /// <param name="components"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>if the components exist or not</returns>
        public bool GetComponentsOrNull<T>(out ComponentByEntityContainer components) where T : struct, IComponent
        {
            TryGetValue(typeof(T), out ComponentByEntityContainer tryGetComponent);
            components = tryGetComponent;
            return components != default;
        }
        
        public bool GetComponentsOrNull(Type type, out ComponentByEntityContainer components)
        {
            TryGetValue(type, out ComponentByEntityContainer tryGetComponent);
            components = tryGetComponent;
            return components != default;
        }

        /// <summary>
        /// Updates the component data if it exists
        /// </summary>
        /// <param name="component">And instance of IComponent</param>
        public bool UpdateComponent<T>(KeyValuePair<int, T> component) where T : struct, IComponent
        {
            return UpdateComponent(component.Key, component.Value, typeof(T));
        }

        /// <summary>
        /// Updates the component data if it exists
        /// </summary>
        /// <param name="component">And instance of IComponent</param>
        /// <param name="componentType"></param>
        private bool UpdateComponent(int entity, IComponent component, Type componentType)
        {
            if (!TryGetValue(componentType, out var tryGetComp)) return false;
            tryGetComp[entity] = component;
            return true;
        }
        
        /// <summary>
        /// Updates the component data if it exists.
        /// </summary>
        /// <param name="componentDictionary"></param>
        public void UpdateComponents(int entity, IEnumerable<IComponent> components)
        {
            foreach (var component in components)
            {
                var compType = component.GetType();
                UpdateComponent(entity, component, compType);
            }
        }

        /// <summary>
        /// Add a component to the dictionary. 
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent<T>(KeyValuePair<int, T> component) where T : struct, IComponent
        {
            AddComponent(component.Key, component.Value, typeof(T));
        }

        public void AddComponent(int entity, IComponent component)
        {
            AddComponent(entity, component, component.GetType());
        }
        
        private void AddComponent(int entity, IComponent component, Type componentType)
        {
            if (TryGetValue(componentType, out var componentDict))
            {
                componentDict.Add(entity, component);
            } 
            else
            {
                var compByEnt = new ComponentByEntityContainer(componentType) { [entity] = component };
                Add(componentType, compByEnt);
            }
        }

        /// <summary>
        /// Adds a series of components to the component array
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="components"></param>
        public void AddEntity(int entity, HashSet<IComponent> components)
        {
            foreach (var comp in components)
            {
                Type compType = comp.GetType();
                
                // Add component to list -> If type does not exist yet, add it.
                if (TryGetValue(compType, out var tryGetComp))
                {
                    tryGetComp[entity] = comp;
                    continue;
                }
                // Dict does not contain the component type, add it. 
                var compByEnt = new ComponentByEntityContainer(compType) { [entity] = comp };
                Add(compType, compByEnt);
            }
        }

        public void ClearEntities()
        {
            Clear();
        }
        
        public void RemoveEntity(int entity)
        {
            foreach (var type in this)
            {
                type.Value.Remove(entity);
            }
        }
        
        public void RemoveEntities(int[] entities)
        {
            foreach (var type in this)
            {
                for (int i = 0; i < entities.Length; i++)
                {
                    type.Value.Remove(entities[i]);
                }
            }
        }
        
        /// <summary>
        /// Removes the component of type T for an entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveEntityType<T>(int entity) where T : struct, IComponent
        {
            RemoveEntityType(entity, typeof(T));
        }

        /// <summary>
        /// Removes the component of a provided type
        /// </summary>
        private void RemoveEntityType(int entity, Type comp)
        {
            if(TryGetValue(comp, out var comps))
            {
                comps.Remove(entity);
            }
            throw new InvalidOperationException($"Entity {entity} does not have a component of type {comp} registered");
        }
        
        /// <summary>
        /// Removes multiple values belonging to a certain entity. 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="componentTypes"></param>
        public void RemoveManyFromEntity(int entity, IEnumerable<Type> componentTypes)
        {
            foreach (var compType in  componentTypes)
            {
                RemoveEntityType(entity, compType);
            }
        }

    }

}
