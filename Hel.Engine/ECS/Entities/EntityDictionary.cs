using System.Collections;
using System.Collections.Generic;
using Hel.Engine.ECS.Components;

namespace Hel.Engine.ECS.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityDictionary : Dictionary<string, ComponentDictionary>
    {
        
        public EntityDictionary() { }

        public EntityDictionary(Dictionary<string, ComponentDictionary> newEntities) : base(newEntities) { }

        public EntityDictionary(string id, ComponentDictionary componentDictionary)
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

        public void UpdateEntity(string id, ComponentDictionary components)
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
