using System;
using System.Collections;
using System.Collections.Generic;
using Hel.Engine.ECS.Exceptions;

namespace Hel.Engine.ECS.Components
{
    public class ComponentDictionary : IDictionary<Type, IComponent>
    {

        private readonly Dictionary<Type, IComponent> _components;

        public ComponentDictionary()
        {
            _components = new Dictionary<Type, IComponent>();
        }

        public ComponentDictionary(Dictionary<Type, IComponent> newComponents)
        {
            _components = new Dictionary<Type, IComponent>(newComponents);
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
            if (ContainsKey(componentType))
                _components[componentType] = component;
            else
                AddByObject(component);
        }

        public void UpdateComponents(ComponentDictionary componentDictionary)
        {
            foreach (var component in componentDictionary)
                UpdateComponent(component.Value);
        }

        public void AddByObject(IComponent component) =>
            _components.Add(component.GetType(), component);

        public void AddByType<T>() where T : Type, IComponent, new() =>
            _components.Add(typeof(T), new T());

        public void RemoveByType<T>() where T : Type, IComponent =>
            _components.Remove(typeof(T));

        public IEnumerator<KeyValuePair<Type, IComponent>> GetEnumerator()
        {
            foreach (var component in _components)
            {
                yield return component;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // IDictionary implementation

        public ICollection<Type> Keys => ((IDictionary<Type, IComponent>)_components).Keys;

        public ICollection<IComponent> Values => ((IDictionary<Type, IComponent>)_components).Values;

        public int Count => ((IDictionary<Type, IComponent>)_components).Count;

        public bool IsReadOnly => ((IDictionary<Type, IComponent>)_components).IsReadOnly;

        public IComponent this[Type key] { get => ((IDictionary<Type, IComponent>)_components)[key]; set => ((IDictionary<Type, IComponent>)_components)[key] = value; }

        public bool ContainsKey(Type key)
        {
            return ((IDictionary<Type, IComponent>)_components).ContainsKey(key);
        }

        public void Add(Type key, IComponent value)
        {
            ((IDictionary<Type, IComponent>)_components).Add(key, value);
        }

        public bool Remove(Type key)
        {
            return ((IDictionary<Type, IComponent>)_components).Remove(key);
        }

        public bool TryGetValue(Type key, out IComponent value)
        {
            return ((IDictionary<Type, IComponent>)_components).TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<Type, IComponent> item)
        {
            ((IDictionary<Type, IComponent>)_components).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<Type, IComponent>)_components).Clear();
        }

        public bool Contains(KeyValuePair<Type, IComponent> item)
        {
            return ((IDictionary<Type, IComponent>)_components).Contains(item);
        }

        public void CopyTo(KeyValuePair<Type, IComponent>[] array, int arrayIndex)
        {
            ((IDictionary<Type, IComponent>)_components).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<Type, IComponent> item)
        {
            return ((IDictionary<Type, IComponent>)_components).Remove(item);
        }

        IEnumerator<KeyValuePair<Type, IComponent>> IEnumerable<KeyValuePair<Type, IComponent>>.GetEnumerator()
        {
            return ((IDictionary<Type, IComponent>)_components).GetEnumerator();
        }
    }

}
