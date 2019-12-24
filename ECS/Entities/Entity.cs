using Hel.ECS.Components;
using System.Collections;
using System.Collections.Generic;

namespace Hel.ECS.Entities
{
    /// <summary>
    /// IEntity is the base component all entities need to use. 
    /// The entire ECS system uses the IEntity interface to store, remove
    /// and send entities to their respective systems. 
    /// These entities are not stored as objects but rather deconstructed into an ID and a list of _components.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// List of _components that will be assigned in the EntityManager
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

        public Entity(params IComponent[] components)
        {
            Components = new ComponentDictionary();
            AddComponents(components);
        }

        public Entity(List<IComponent> componentList)
        {
            Components = new ComponentDictionary();
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

    public class EntityDictionary : IDictionary<uint, ComponentDictionary>, IEnumerable, IEnumerable<KeyValuePair<uint, ComponentDictionary>>
    {

        private readonly Dictionary<uint, ComponentDictionary> entities;

        public EntityDictionary()
        {
            entities = new Dictionary<uint, ComponentDictionary>();
        }

        public EntityDictionary(Dictionary<uint, ComponentDictionary> newEntities)
        {
            entities = new Dictionary<uint, ComponentDictionary>(newEntities);
        }

        public EntityDictionary(uint id, ComponentDictionary componentDictionary) : base()
        {
            AddEntity(id, componentDictionary);
        }

        public EntityDictionary(EntityDictionary oldDictionary)
        {
            entities = new Dictionary<uint, ComponentDictionary>(oldDictionary);
        }

        public void UpdateEntity(uint id, ComponentDictionary components)
        {
            if (ContainsKey(id))
                entities[id].UpdateComponents(components);
            else
                AddEntity(id, components);
        }

        public void AddEntity(uint id, ComponentDictionary components) =>
          entities.Add(id, components);

        public void RemoveEntityById(uint id) =>
            entities.Remove(id);

        public IEnumerator<KeyValuePair<uint, ComponentDictionary>> GetEnumerator()
        {
            foreach(var entity in entities)
            {
                yield return entity;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // IDictionary implementations

        public ICollection<uint> Keys => ((IDictionary<uint, ComponentDictionary>) entities).Keys;

        public ICollection<ComponentDictionary> Values => ((IDictionary<uint, ComponentDictionary>)entities).Values;

        public int Count => ((IDictionary<uint, ComponentDictionary>)entities).Count;

        public bool IsReadOnly => ((IDictionary<uint, ComponentDictionary>)entities).IsReadOnly;

        public ComponentDictionary this[uint key] { get => ((IDictionary<uint, ComponentDictionary>)entities)[key]; set => ((IDictionary<uint, ComponentDictionary>)entities)[key] = value; }

        public bool ContainsKey(uint key)
        {
            return ((IDictionary<uint, ComponentDictionary>)entities).ContainsKey(key);
        }

        public void Add(uint key, ComponentDictionary value)
        {
            ((IDictionary<uint, ComponentDictionary>)entities).Add(key, value);
        }

        public bool Remove(uint key)
        {
            return ((IDictionary<uint, ComponentDictionary>)entities).Remove(key);
        }

        public bool TryGetValue(uint key, out ComponentDictionary value)
        {
            return ((IDictionary<uint, ComponentDictionary>)entities).TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<uint, ComponentDictionary> item)
        {
            ((IDictionary<uint, ComponentDictionary>)entities).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<uint, ComponentDictionary>)entities).Clear();
        }

        public bool Contains(KeyValuePair<uint, ComponentDictionary> item)
        {
            return ((IDictionary<uint, ComponentDictionary>)entities).Contains(item);
        }

        public void CopyTo(KeyValuePair<uint, ComponentDictionary>[] array, int arrayIndex)
        {
            ((IDictionary<uint, ComponentDictionary>)entities).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<uint, ComponentDictionary> item)
        {
            return ((IDictionary<uint, ComponentDictionary>)entities).Remove(item);
        }

        IEnumerator<KeyValuePair<uint, ComponentDictionary>> IEnumerable<KeyValuePair<uint, ComponentDictionary>>.GetEnumerator()
        {
            return ((IDictionary<uint, ComponentDictionary>)entities).GetEnumerator();
        }
    }

}
