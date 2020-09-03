using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
        string AddEntity(IEntity entity);

        /// <summary>
        /// Returns a list containing all entities that implement interface T. Returning all IRender entities or IMovement entities for example
        /// </summary>
        /// <typeparam name="T">Interface to check for.</typeparam>
        /// <returns>List containing all entities data for specified type.</returns>
        EntityDictionary GetEntities<T>() where T : struct, IComponent;
        /// <summary>
        /// Returns a list containing all entities that implement interface T. Returning all IRender entities or IMovement entities for example
        /// </summary>
        /// <param name="ID">ID of the entity</param>
        /// <returns>Entity component</returns>
        EntityDictionary GetEntities(string ID);
        /// <summary>
        /// Removes an entity from the world
        /// </summary>
        /// <param name="ID">ID of the entity to remove.</param>
        void RemoveEntity(string ID);
        /// <summary>
        /// Remove all entities with the same ID as the one provided. Useful if you have a list or array of entities you wish to remove. 
        /// </summary>
        /// <param name="entitiesList">IEnumerable containing IEntities</param>
        void RemoveEntities(IEnumerable<string> entitiesList);
        /// <summary>
        /// Removes all entities from the world. Useful for resets, map restarts, or closing the game.
        /// </summary>
        void ClearEntities();
        /// <summary>
        /// Clears all entities that correspond to a certain type. For example, clearing all entities that contain IRenderable _components.
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        void ClearEntitiesType<T>() where T : struct, IComponent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        void UpdateEntity(string ID, ComponentDictionary components);

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

        public string CreateEntityApply(string entityName) =>
            AddEntity(
                EntityCreator.CreateEntity(entityName));

        public string AddEntity(IEntity entity)
        {
            lock (_entities)
            {
                return AddEntityInternal(entity);
            }
        }

        private string AddEntityInternal(IEntity entity)
        {
            var entityId = entity.Name + Guid.NewGuid();
                try
                {
                    _entities.Add(entityId, entity.Components);
                }
                catch (ArgumentException)
                {
                    return AddEntityInternal(entity);
                }

                return entityId;
        }

        public EntityDictionary GetEntities<T>() where T : struct, IComponent
        {
            var entityDict = new EntityDictionary();
            foreach (KeyValuePair<string, ComponentDictionary> entity in _entities)
            {
                if (entity.Value.GetComponentOrNull(out T comp) && comp.Active)
                {
                    entityDict[entity.Key] =  entity.Value;
                }
            }

            return entityDict;
        }

        public EntityDictionary GetEntities(string ID) =>
            new EntityDictionary(ID, _entities[ID]);

        public void RemoveEntity(string ID)
        {
            lock (_entities)
            {
                _entities.Remove(ID);
            }
        }
        public void RemoveEntities(IEnumerable<string> entitiesList)
        {
            foreach (string entity in entitiesList)
                this.RemoveEntity(entity);
        }

        public void ClearEntities() => _entities.Clear();

        public void ClearEntitiesType<T>() where T : struct, IComponent
        {
            var entityType = GetEntities<T>();

            foreach (var entity in entityType)
            {
                this.RemoveEntity(entity.Key);
            }

        }

        public void UpdateEntity(string id, ComponentDictionary components) =>
            _entities.UpdateEntity(id, components);
    }
}
 
