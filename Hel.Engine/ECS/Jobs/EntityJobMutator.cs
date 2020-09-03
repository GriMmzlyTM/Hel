using System.Collections.Generic;
using Hel.Engine.ECS.Components;
using Hel.Engine.ECS.Entities;

namespace Hel.Engine.ECS.Jobs
{
    public class EntityJobMutator
    {
        private static readonly EntityDictionary stagedEntities = new EntityDictionary();
        private static readonly List<string> removedEntities = new List<string>();

        public static void StageEntityMutation(string id, params IComponent[] components)
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

        public static void RemoveEntity(string id)
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
                List<string> removedEntitiesSafe = new List<string>(removedEntities);
                removedEntities.Clear();

                manager.RemoveEntities(removedEntitiesSafe);
            }

            lock (stagedEntities)
            {
                EntityDictionary stagedEntitiesSafe = new EntityDictionary(stagedEntities);
                stagedEntities.Clear();

                foreach (var entity in stagedEntitiesSafe)
                    manager.UpdateEntity(entity.Key, entity.Value);
            }
        }

    }
}
