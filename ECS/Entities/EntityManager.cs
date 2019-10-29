using Hel.ECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hel.ECS.Entities
{
    internal interface IEntityManager
    {
        /// <summary>
        /// The world that this entity manager belongs to
        /// </summary>
        World World { get; }
        /// <summary>
        /// Add an entity to the world. An entity is any struct with the IEntity interface implemented.
        /// </summary>
        /// <param name="entity">Struct with the IEntity interface</param>
        uint AddEntity(IEntity entity);
        /// <summary>
        /// Returns a list containing all entities that implement interface T. Returning all IRender entities or IMovement entities for example/
        /// </summary>
        /// <typeparam name="T">Interface to check for.</typeparam>
        /// <returns>List containing all entities data for specified type.</returns>
        Dictionary<uint, HashSet<IComponent>> GetEntityType<T>();
        /// <summary>
        /// Access an entities data based on the ID
        /// </summary>
        /// <param name="ID">ID of the entity</param>
        /// <returns>Entity component</returns>
        HashSet<IComponent> GetEntityID(uint ID);
        /// <summary>
        /// Removes an entity from the world
        /// </summary>
        /// <param name="ID">ID of the entity to remove.</param>
        void RemoveEntity(uint ID);
        /// <summary>
        /// Remove all entities with the same ID as the one provided. Useful if you have a list or array of entities you wish to remove. 
        /// </summary>
        /// <param name="entitiesList">IEnumerable containing IEntities</param>
        void RemoveEntities(IEnumerable<uint> entitiesList);
        /// <summary>
        /// Removes all entities from the world. Useful for resets, map restarts, or closing the game.
        /// </summary>
        void ClearEntities();
        /// <summary>
        /// Clears all entities that correspond to a certain type. For example, clearing all entities that contain IRenderable components.
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        void ClearEntitiesType<T>();

    }

    /// <summary>
    /// EntityManager stores entity data and provides a safe way to mutate the entities dictionary ( Dictionary<uint, HashSet<IComponent>> )
    /// </summary>
    public class EntityManager : IEntityManager
    {
        private readonly Dictionary<uint, HashSet<IComponent>> entities = new Dictionary<uint, HashSet<IComponent>>();
        public World World { get; private set; }

        public EntityManager(World world) => World = world;

        public IEntity CreateEntity(string entityName) =>
            EntityCreator.CreateEntity(entityName);

        public void LoadJSON(List<string> jsonFiles) =>
            EntityCreator.LoadJSON(jsonFiles);

        public uint CreateEntityApply(string entityName) =>
            AddEntity(
                EntityCreator.CreateEntity(entityName));

        public uint AddEntity(IEntity entity) =>
            AddEntityInternal(entity);

        private uint AddEntityInternal(IEntity entity)
        {
            lock (entities)
            {
                uint _entity_id = GenerateEntityIdInternal();
                entities.Add(_entity_id, entity.Components);
                return _entity_id;
            }

        }
        private uint GenerateEntityIdInternal() =>
            entities.ContainsKey(0)
                ? entities.Where(x => !entities.ContainsKey(x.Key + 1)).First().Key + 1
                : 0;

        public Dictionary<uint, HashSet<IComponent>> GetEntityType<T>() => 
            entities
            .Where(x => x.Value.Any(p => p is T))
            .ToDictionary(x => x.Key,
                x => x.Value);

        public HashSet<IComponent> GetEntityID(uint ID) => entities[ID];

        public void RemoveEntity(uint ID) => entities.Remove(ID);

        public void RemoveEntities(IEnumerable<uint> entitiesList)
        {
            foreach (uint entity in entitiesList)
                entities.Remove(entity);
        }

        public void ClearEntities() => entities.Clear();

        public void ClearEntitiesType<T>()
        {
            var entityType = GetEntityType<T>();
            lock (entities)
            {
                foreach (var entity in entityType)
                {
                    entities.Remove(entity.Key);
                }
            }
        }

    }
}
