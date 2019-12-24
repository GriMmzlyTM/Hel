using Hel.ECS.Components;
using System.Collections;
using System.Collections.Generic;

namespace Hel.ECS.Entities
{
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
            foreach (var entity in entities)
            {
                yield return entity;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // IDictionary implementations

        public ICollection<uint> Keys => ((IDictionary<uint, ComponentDictionary>)entities).Keys;

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
