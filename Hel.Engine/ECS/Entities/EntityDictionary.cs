using System.Collections;
using System.Collections.Generic;
using Hel.Engine.ECS.Components;

namespace Hel.Engine.ECS.Entities
{
    public class EntityDictionary : Dictionary<uint, ComponentDictionary>
    {
        
        public EntityDictionary() { }

        public EntityDictionary(Dictionary<uint, ComponentDictionary> newEntities) : base(newEntities) { }

        public EntityDictionary(uint id, ComponentDictionary componentDictionary)
        {
            Add(id, componentDictionary);
        }
        
        public EntityDictionary(EntityDictionary oldDictionary)
        {
            foreach (var (key, value) in oldDictionary)
            {
                Add(key, value);
            }
        }

        public void UpdateEntity(uint id, ComponentDictionary components)
        {
            if (ContainsKey(id))
            {
                this[id].UpdateComponents(components);
            }
            else
            {
                Add(id, components);
            }
        }

        public void UpdateEntities(EntityDictionary entities)
        {
            foreach (var (key, value) in entities)
            {
                UpdateEntity(key, value);
            }
        }
        
    }
}
