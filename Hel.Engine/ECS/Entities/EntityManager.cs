using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading;
using Hel.Engine.ECS.Components;
using Hel.Engine.ECS.Exceptions;

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
        /// <returns>The ID of the generated entity</returns>
        int AddEntity(IEntity entity);
        /// <summary>
        /// Fetches all available entity ID's
        /// </summary>
        /// <returns>List containing all entities</returns>
        IEnumerable<int> GetEntityIds();
        /// <summary>
        /// Removes an entity from the world
        /// </summary>
        /// <param name="ID">ID of the entity to remove.</param>
        void RemoveEntity(int ID);
        /// <summary>
        /// Remove all entities with the same ID as the ones provided. Useful if you have a list or array of entities you wish to remove. 
        /// </summary>
        /// <param name="entitiesList">IEnumerable containing IEntities</param>
        void RemoveEntities(IEnumerable<int> entitiesList);
        /// <summary>
        /// Removes all entities from the world. Useful for resets, map restarts, or closing the game.
        /// </summary>
        void ClearEntities();

        /// <summary>
        /// Updates an entities compoonents. This does not REMOVE entity components but it will add new components and
        /// update existing component data. 
        /// </summary>
        /// <param name="ID">ID of the entity to modify</param>
        /// <param name="components">Components to add or update</param>
        void UpdateEntity(int ID, IEnumerable<IComponent> components);

    }

    /// <summary>
    /// EntityManager stores entity data and provides a safe way to modify and retrieve entities.
    /// </summary>
    public class EntityManager : IEntityManager
    {
        private readonly EntityLookup _entityLookup = new EntityLookup();
        private readonly ComponentContainer _components = new ComponentContainer();
        public World World { get; private set; }

        /// <summary>
        /// How many entities exist
        /// </summary>
        public int EntityCount => _entityLookup.EntityCount;

        public EntityManager(World world) => World = world;

        /*public IEntity CreateEntity(int entityName) =>
            EntityCreator.CreateEntity(entityName);

        public void LoadJSON(List<string> jsonFiles) =>
            EntityCreator.LoadJSON(jsonFiles);

        public void CreateEntityApply(int entityName) =>
            AddEntity(
                EntityCreator.CreateEntity(entityName));
                */

        public int AddEntity(IEntity entity)
        {
            return AddEntity(entity.Components);
        }
        
        public int AddEntity(string name, HashSet<IComponent> components)
        {
            lock(_entityLookup)
            lock (_components)
            {
                var id = _entityLookup.Add(name);
                _components.AddEntity(id, components);

                return id;
            }
        }
        
        public int AddEntity(HashSet<IComponent> components)
        {
            lock(_entityLookup)
            lock (_components)
            {
                var id = _entityLookup.Add();
                _components.AddEntity(id, components);

                return id;
            }
        }

        public ComponentByEntityContainer GetComponentsOfType<T>() where T : struct, IComponent
        {
            lock(_entityLookup)
            lock (_components)
            {
                return _components.GetComponentsOfType<T>();
            }
        }
        
        public IEnumerable<int> GetEntityIds(string name)
        { 
            lock(_entityLookup)
            lock (_components)
            {
                return _entityLookup.GetByName(name);
            }
        }
        
        public int GetEntityId(string name)
        {
            lock(_entityLookup)
            lock (_components)
            {
                return _entityLookup.GetFirstByName(name);
            }
        }
        public IEnumerable<int> GetEntityIds()
        {
            lock(_entityLookup)
            lock (_components)
            {
                var entities = _entityLookup.GetEntities();
                return entities;
            }
        }
        
        /// <summary>
        /// Get all entities that contain the provided types. Will return ALL components by type as well as all entity ID's
        ///
        /// You can then iterate over the entity ID's and use those to access the proper ComponentByEntity for the type you need.
        /// When iterating you need to verify that the <see cref="ComponentByEntityContainer"/> has an entry for your entity.
        /// </summary>
        /// <param name="entityIds">Returns the entityID's that match the criteria</param>
        /// <param name="types">The types that the entities must have</param>
        /// <returns></returns>
        public Dictionary<Type, ComponentByEntityContainer> GetEntities(out IEnumerable<int> entityIds, params Type[] types)
        {
            entityIds = null;
            if (types.Length == 0) return default;

            lock(_entityLookup)
            lock (_components)
            {
                var compDict = new Dictionary<Type, ComponentByEntityContainer>();
                for(int i = 0; i < types.Length; i++)
                {
                    if (_components.GetComponentsOrNull(types[i], out var component))
                    {
                        compDict.Add(types[i], component);   
                    }
                }

                entityIds = GetEntityIds();
                return compDict;
            }
        }

        public bool GetComponent<T>(int entity, out T component) where T : struct, IComponent
        {
            lock (_components)
            {
                component = (T) _components.GetComponent<T>(entity);
                return !EqualityComparer<T>.Default.Equals(component, default);
            }
        }

        public void RemoveEntity(int id)
        {
            lock(_entityLookup)
            lock (_components)
            {
                _entityLookup.RemoveEntity(id);
                _components.RemoveEntity(id);
            }
        }
        public void RemoveEntities(IEnumerable<int> entitiesList)
        {
            lock(_entityLookup)
            lock (_components)
            {
                foreach (var entity in entitiesList)
                {
                    _entityLookup.RemoveEntity(entity);
                    _components.RemoveEntity(entity);
                }
            }
        }

        public void ClearEntities()
        {
            lock(_entityLookup)
            lock (_components)
            {
                _entityLookup.Clear();
                _components.Clear();
            }
        }

        public void UpdateEntity(int id, IEnumerable<IComponent> components)
        {
            lock(_entityLookup)
            lock(_components)
            {
                _components.UpdateComponents(id, components);
            }
        }
    }
}
 
