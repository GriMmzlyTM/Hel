using System;
using System.Collections.Generic;
using Hel.ECS.Components.Model;
using Hel.Toolkit.DataStructure.Arrays;

namespace Hel.ECS.Components.Container
{
    /// <summary>
    /// Components of a specific type that are stored at the ID of the entity they belong to.
    ///
    /// For example:
    /// EntityLookup: Index 53 => "Character"
    /// ComponentByEntityContainer (Render) : Index 53 => "Character" IComponent
    ///  
    /// </summary>
    public class ComponentContainer
    {
        /// <summary>
        /// The type of the components stored in this container
        /// </summary>
        public Type Type { get; }

        private readonly DynamicArray<IComponent> _components;
        private readonly DynamicArray<IComponent> _componentsBuffer;

        private readonly Queue<int> _removedEntities;
        private readonly Queue<int> _addedEntities;
        private readonly Queue<int> _updatedEntities;

        public delegate void EntitiesModified(int[] entities, EntityChangeDirection changeDirection);

        public event EntitiesModified OnEntitiesModified;

        public enum EntityChangeDirection {
           Removed = 0,
           Added,
           Updated
        }
        
        public ComponentContainer(Type type)
        {
            _components = new DynamicArray<IComponent>(256);
            _componentsBuffer = new DynamicArray<IComponent>(256);
            Type = type;
            
            _removedEntities = new Queue<int>();
            _addedEntities = new Queue<int>();
            _updatedEntities = new Queue<int>();
        }

        public void UpdateComponent(int entityId, IComponent component)
        {
            if (_components[entityId] == null)
            {
                _addedEntities.Enqueue(entityId);
            }
            else
            {
                _updatedEntities.Enqueue(entityId);
            }

            _componentsBuffer[entityId] = component;
        }

        public void Remove(int entityId)
        {
            if (_components[entityId] == null)
            {
                return;
            }
            
            _removedEntities.Enqueue(entityId);
            _componentsBuffer[entityId] = null;
        }

        public void ApplyUpdates()
        {
            // Remove entities
            var removedArr = _removedEntities.ToArray();
            for (int i = 0; i < _removedEntities.Count; i++)
            {
                _components[_removedEntities.Dequeue()] = null;
            }
            if (removedArr.Length > 0)
            {
                OnEntitiesModified?.Invoke(removedArr, EntityChangeDirection.Removed);
            }

            // Added
            var addedArr = _addedEntities.ToArray();
            for (int i = 0; i < _addedEntities.Count; i++)
            {
                var ent = _addedEntities.Dequeue();
                _components[ent] = _componentsBuffer[ent];
            }
            // Add entities
            if (addedArr.Length > 0)
            {
                OnEntitiesModified?.Invoke(addedArr, EntityChangeDirection.Added);
            }

            // Updated
            var updatedEnt = _updatedEntities.ToArray();
            for (int i = 0; i < _updatedEntities.Count; i++)
            {
                var ent = _updatedEntities.Dequeue();
                _components[ent] = _componentsBuffer[ent];
            }
            if (updatedEnt.Length > 0)
            {
                OnEntitiesModified?.Invoke(updatedEnt, EntityChangeDirection.Updated);
            }
        }

        /// <summary>
        /// Get component. May return null
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="component"></param>
        /// <returns>True if componnent exists</returns>
        public IComponent Get(int entityId) 
        {
            return _components[entityId];
        }

        public IComponent this[int index]
        {
            get => _components[index];

            set {
                if (value == null)
                {
                    Remove(index);
                    return;
                }
                UpdateComponent(index, value);
            }
        }
    }
}