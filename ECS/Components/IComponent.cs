using System;
using System.Collections;
using System.Collections.Generic;

namespace Hel.ECS.Components
{
    public interface IComponent
    {
        bool Active { get; set; }
    }

    public class ComponentList : IEnumerable
    {

        private Dictionary<Type, IComponent> components = new Dictionary<Type, IComponent>();

        public void AddByObject(IComponent component) =>
            components.Add(component.GetType(), component);

        public void AddByType<T>() where T : Type, IComponent, new() =>
            components.Add(typeof(T), new T());

        public void RemoveByType<T>() where T : Type, IComponent =>
            components.Remove(typeof(T));

        public IEnumerator GetEnumerator()
        {
            foreach(var comp in components)
            {
                yield return comp;
            }
        }
    }

}
