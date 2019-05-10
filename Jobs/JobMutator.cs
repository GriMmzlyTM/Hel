using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hel.ECS.Entities;

namespace Hel.Jobs
{
    class JobMutator
    {
        private static readonly List<IEntity> stagedEntities = new List<IEntity>();
        private static readonly List<IEntity> removedEntities = new List<IEntity>();

        public static void StageEntityMutation(IEntity entity)
        {
            lock (stagedEntities) {
                stagedEntities.Add(entity);
            }
        }

        public static void RemoveEntity(IEntity entity)
        {
            lock (removedEntities)
            {
                removedEntities.Add(entity);
            }
        }

        public static void ApplyMutations(EntityManager manager)
        {
            lock (stagedEntities) {
                List<IEntity> stagedEntitiesSafe  = new List<IEntity>(stagedEntities);
                List<IEntity> removedEntitiesSafe = new List<IEntity>(removedEntities);
                removedEntities.Clear();
                stagedEntities.Clear();

                manager.RemoveEntities(removedEntitiesSafe);

                foreach (IEntity entity in stagedEntitiesSafe)
                    manager.ReplaceEntity(entity);
            }
        }

    }
}
