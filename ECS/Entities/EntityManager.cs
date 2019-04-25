﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Hel.ECS.Entities;
using Microsoft.Xna.Framework;

namespace Hel.ECS.Entities
{
    internal interface IEntityManager
    {
        /// <summary>
        /// Add an entity to the world. An entity is any struct with the IEntity interface implemented.
        /// </summary>
        /// <param name="entity">Struct with the IEntity interface</param>
        void AddEntity(IEntity entity);
        /// <summary>
        /// Returns a list containing all entities that implement interface T. Returning all IRender entities or IMovement entities for example/
        /// </summary>
        /// <typeparam name="T">Interface to check for.</typeparam>
        /// <returns>List containing all entities data for specified type.</returns>
        List<IEntity> GetEntityType<T>();
        /// <summary>
        /// Access an entities data based on the ID
        /// </summary>
        /// <param name="ID">ID of the entity</param>
        /// <returns>Entity component</returns>
        IEntity GetEntityID(uint ID);
        /// <summary>
        /// Removes an entity from the world
        /// </summary>
        /// <param name="ID">ID of the entity to remove.</param>
        void RemoveEntity(uint ID);
        /// <summary>
        /// Remove all entities with the same ID as the one provided. Useful if you have a list or array of entities you wish to remove. 
        /// </summary>
        /// <param name="entitiesList">IEnumerable containing IEntities</param>
        void RemoveEntities(IEnumerable<IEntity> entitiesList);
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
    /// EntityManager stores entity data and provides a safe way to mutate the entities dictionary ( Dictionary<uint, IEntity> )
    /// </summary>
    public class EntityManager : IEntityManager
    {
        private readonly Dictionary<uint, IEntity> entities = new Dictionary<uint, IEntity>();
        public World World { get; private set; }

        public EntityManager(World world) => World = world;
        public void AddEntity(IEntity entity)
        {
            entities.Add(entity.Id, entity);
        }

        public List<IEntity> GetEntityType<T>()
        {
            var entityList = entities.Values.Where(x => x is T).ToList(); //entities.OfType<T>().ToList();
            return entityList;
        }

        public IEntity GetEntityID(uint ID) => entities[ID];

        public void RemoveEntity(uint ID) => entities.Remove(ID);

        public void RemoveEntities(IEnumerable<IEntity> entitiesList)
        {
            foreach (IEntity entity in entitiesList)
                entities.Remove(entity.Id);
        }

        public void ClearEntities() => entities.Clear();

        public void ClearEntitiesType<T>()
        {
            List<IEntity> entityType = GetEntityType<T>();
            foreach (var entity in entityType)
            {
                    entities.Remove(entity.Id);
            }
        }

        public void ReplaceEntity(IEntity entity)
        {
            if (entities.ContainsKey(entity.Id))
                entities[entity.Id] = entity;
            else
                AddEntity(entity);
        }


    }
}
