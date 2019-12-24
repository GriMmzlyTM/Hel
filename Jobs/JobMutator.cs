using Hel.ECS.Components;
using Hel.ECS.Entities;
using System.Collections.Generic;

namespace Hel.Jobs
{
    class JobMutator
    {
        private static readonly EntityDictionary stagedEntities = new EntityDictionary();
        private static readonly List<uint> removedEntities = new List<uint>();

        public static void StageEntityMutation(uint id, params IComponent[] components)
        {
            lock (stagedEntities)
            {
                ComponentDictionary stagedComponents = 
                    stagedEntities.ContainsKey(id) ? stagedEntities[id] : new ComponentDictionary();

                foreach (var component in components)
                {
                    stagedComponents.UpdateComponent(component);
                }
                stagedEntities.UpdateEntity(id, stagedComponents);
            }
        }

        public static void RemoveEntity(uint id)
        {
            lock (removedEntities)
            {
                removedEntities.Add(id);
            }
        }

        public static void ApplyMutations(IEntityManager manager)
        {
            lock (removedEntities)
            {
                List<uint> removedEntitiesSafe = new List<uint>(removedEntities);
                removedEntities.Clear();

                manager.RemoveEntities(removedEntitiesSafe);
            }

            lock (stagedEntities) {
                EntityDictionary stagedEntitiesSafe  = new EntityDictionary(stagedEntities);
                stagedEntities.Clear();

                foreach (var entity in stagedEntitiesSafe)
                    manager.UpdateEntity(entity.Key, entity.Value);
            }
        }

    }
}
