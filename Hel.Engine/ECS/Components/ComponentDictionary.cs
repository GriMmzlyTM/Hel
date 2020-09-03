using System;
using System.Collections;
using System.Collections.Generic;
using Hel.Engine.ECS.Exceptions;

namespace Hel.Engine.ECS.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class ComponentDictionary : Dictionary<Type, IComponent>
    {

        public ComponentDictionary() : base() { }

        public ComponentDictionary(IDictionary<Type, IComponent> newComponents) : base(newComponents) { }

        /// <summary>
        /// Attempts to get the component from the dictionary. Returns it if it exists, otherwise throws an exception. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponentOfType<T>() where T :struct, IComponent
        {
            return (TryGetValue(typeof(T), out IComponent tryGetComponent)
                         && tryGetComponent is T genericComponent)
                ? genericComponent : throw new InvalidComponentException($"Unable to find component of type {typeof(T)}");
        }
        
        /// <summary>
        /// Attempts to retrieve a component from the dictionary. If the component does not exist in the dictionary an exception will
        /// be thrown.
        /// Assigns the component to the out value.
        /// </summary>
        /// <param name="component">out value which gets assigned the component if it exists</param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="InvalidComponentException">Unable to find component in dictionary -> If you aren't sure whether or not the
        /// component is in the dictionary, use <see cref="GetComponentOrNull{T}"/> instead.</exception>
        /// <returns>if the component exists</returns>
        public bool GetComponentOrFail<T>(out T component) where T : struct, IComponent
        {
            component = (TryGetValue(typeof(T), out IComponent tryGetComponent)
                && tryGetComponent is T genericComponent)
                    ? genericComponent : throw new InvalidComponentException($"Unable to find component of type {typeof(T)}");

            return !EqualityComparer<T>.Default.Equals(component, default);
        }
        
        /// <summary>
        /// Attempts to get a component from the dictionary and assigns it to the out variable. If the component does not exist, null will be assigned.
        /// </summary>
        /// <param name="component"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>if the component exists or not</returns>
        public bool GetComponentOrNull<T>(out T component) where T : struct, IComponent
        {
            try
            {
                component = (T) this[typeof(T)];
                return true;
            }
            catch (Exception)
            {
                component = default;
                return false;
            }
        }

        /// <summary>
        /// Updates the component data if it exists, adds the component if it does not exist.
        /// </summary>
        /// <param name="component">And instance of IComponent</param>
        public void UpdateComponent(IComponent component)
        {
            Type componentType = component.GetType();
            if (ContainsKey(componentType)) {
                this[componentType] = component;
            } else {
                AddByObject(component);
            }
        }

        /// <summary>
        /// Updates the component data if it exists, adds the component if it does not exist.
        /// </summary>
        /// <param name="componentDictionary"></param>
        public void UpdateComponents(ComponentDictionary componentDictionary)
        {
            foreach (var component in componentDictionary)
                UpdateComponent(component.Value);
        }

        /// <summary>
        /// Add a component to the dictionary
        /// </summary>
        /// <param name="component"></param>
        public void AddByObject(IComponent component) => Add(component.GetType(), component);

        /// <summary>
        /// Add a component to the dictionary by its type (Creates new instance)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void AddByType<T>() where T : Type, IComponent, new() => Add(typeof(T), new T());

        /// <summary>
        /// Removes the component of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveByType<T>() where T : Type, IComponent => Remove(typeof(T));
        

    }

}
