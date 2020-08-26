using System;
using System.Collections;
using System.Collections.Generic;
using Hel.Engine.ECS.Exceptions;

namespace Hel.Engine.ECS.Components
{
    public class ComponentDictionary : Dictionary<Type, IComponent>
    {

        public ComponentDictionary() : base() { }

        public ComponentDictionary(IDictionary<Type, IComponent> newComponents) : base(newComponents) { }

        public T GetComponentOfType<T>() where T : IComponent
        {
            return (TryGetValue(typeof(T), out IComponent tryGetComponent)
                         && tryGetComponent is T genericComponent)
                ? genericComponent : throw new InvalidComponentException($"Unable to find component of type {typeof(T)}");
        }
        
        public bool GetComponentOrFail<T>(out T component) where T : struct, IComponent
        {
            component = (TryGetValue(typeof(T), out IComponent tryGetComponent)
                && tryGetComponent is T genericComponent)
                    ? genericComponent : throw new InvalidComponentException($"Unable to find component of type {typeof(T)}");

            return !EqualityComparer<T>.Default.Equals(component, default);
        }
        
        public bool GetComponentOrNull<T>(out T component) where T : struct, IComponent
        {
            component = (TryGetValue(typeof(T), out IComponent tryGetComponent)
                         && tryGetComponent is T genericComponent)
                ? genericComponent : default;

            return !EqualityComparer<T>.Default.Equals(component, default);
        }

        public void UpdateComponent(IComponent component)
        {
            Type componentType = component.GetType();
            if (ContainsKey(componentType)) {
                this[componentType] = component;
            } else {
                AddByObject(component);
            }
        }

        public void UpdateComponents(ComponentDictionary componentDictionary)
        {
            foreach (var component in componentDictionary)
                UpdateComponent(component.Value);
        }

        public void AddByObject(IComponent component) => Add(component.GetType(), component);

        public void AddByType<T>() where T : Type, IComponent, new() => Add(typeof(T), new T());

        public void RemoveByType<T>() where T : Type, IComponent => Remove(typeof(T));
        

    }

}
