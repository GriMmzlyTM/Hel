using System.Collections.Generic;
using System.Linq;
using Hel.Engine.ECS.Components;

namespace Hel.Engine.ECS.Entities
{
    public interface IEntityManager
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
        /// Returns a list containing all entities that implement interface T. Returning all IRender entities or IMovement entities for example
        /// </summary>
        /// <typeparam name="T">Interface to check for.</typeparam>
        /// <returns>List containing all entities data for specified type.</returns>
        EntityDictionary GetEntities<T>();
        /// <summary>
        /// Returns a list containing all entities that implement interface T. Returning all IRender entities or IMovement entities for example
        /// </summary>
        /// <param name="ID">ID of the entity</param>
        /// <returns>Entity component</returns>
        EntityDictionary GetEntities(uint ID);
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
        /// Clears all entities that correspond to a certain type. For example, clearing all entities that contain IRenderable _components.
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        void ClearEntitiesType<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        void UpdateEntity(uint ID, ComponentDictionary components);

    }

    /// <summary>
    /// EntityManager stores entity data and provides a safe way to mutate the entities dictionary ( Dictionary<uint, HashSet<IComponent>> )
    /// </summary>
    public class EntityManager : IEntityManager
    {
        private readonly EntityDictionary _entities = new EntityDictionary();
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
            lock (_entities)
            {
                var entityId = GenerateEntityIdInternal();
                _entities.Add(entityId, entity.Components);
                return entityId;
            }

        }
        private uint GenerateEntityIdInternal() =>
            _entities.ContainsKey(0)
                ? _entities.First(x => !_entities.ContainsKey(x.Key + 1)).Key + 1
                : 0;

        public EntityDictionary GetEntities<T>() =>
            new EntityDictionary(_entities
            .Where(entity => entity.Value.Any(component => (component.Value is T) && (component.Value.Active)))
            .ToDictionary(id => id.Key,
                comp => comp.Value));

        public EntityDictionary GetEntities(uint ID) =>
            new EntityDictionary(ID, _entities[ID]);

        public void RemoveEntity(uint ID)
        {
            lock (_entities)
            {
                _entities.Remove(ID);
            }
        }
        public void RemoveEntities(IEnumerable<uint> entitiesList)
        {
            foreach (uint entity in entitiesList)
                this.RemoveEntity(entity);
        }

        public void ClearEntities() => _entities.Clear();

        public void ClearEntitiesType<T>()
        {
            var entityType = GetEntities<T>();

            foreach (var entity in entityType)
            {
                this.RemoveEntity(entity.Key);
            }

        }

        public void UpdateEntity(uint id, ComponentDictionary components) =>
            _entities.UpdateEntity(id, components);
    }
}
 
